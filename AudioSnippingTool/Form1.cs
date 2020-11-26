using NAudio.Wave;
using NAudio.Lame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace AudioSnippingTool
{
    public partial class Form1 : Form
    {
        private readonly string filename_trim_wav = "AST_Export.wav";
        private readonly string filename_trim_mp3 = "AST_Export.mp3";

        WasapiLoopbackCapture audio_capture;
        WaveFileReader audio_player_reader;
        WaveOut audio_player;
        
        List<Byte> recorded_audio = new List<Byte>();
        byte[] recorded_audio_array;
        WaveFormat wave_format;

        enum FileStatus { NONE, RECORDING, LISTENING, READY, WAITING };
        FileStatus file_status = FileStatus.NONE;
        bool selecting = false;
        long selection_start = 0, selection_end = 0, num_audio_blocks = 0;
        float recording_seconds = 0;
        Bitmap waveform_bmp;

        public Form1()
        {
            InitializeComponent();

            //create bmp for drawing waveform display onto
            waveform_bmp = new Bitmap(pictureBox_wave.Width, pictureBox_wave.Height);
        }

        void showSplashScreen()
        {
            toolStripStatusLabel_status.Text = "Audio Snipping Tool - by Frost Sheridan";
            pictureBox_wave.Refresh();
        }

        void setStatus(FileStatus new_status)
        {
            file_status = new_status;
            switch (file_status)
            {
                case FileStatus.NONE:
                    toolStripButton_record.Enabled = true;
                    toolStripButton_stop.Enabled = false;
                    toolStripButton_play.Enabled = false;
                    toolStripButton_export.Enabled = false;
                    timer_updateplaydisp.Enabled = false;
                    showSplashScreen();
                    break;

                case FileStatus.RECORDING:
                case FileStatus.LISTENING:
                    toolStripButton_record.Enabled = false;
                    toolStripButton_stop.Enabled = true;
                    toolStripButton_play.Enabled = false;
                    toolStripButton_export.Enabled = false;
                    timer_updateplaydisp.Enabled = true;
                    break;

                case FileStatus.WAITING:
                    toolStripButton_record.Enabled = false;
                    toolStripButton_stop.Enabled = false;
                    toolStripButton_play.Enabled = false;
                    toolStripButton_export.Enabled = false;
                    timer_updateplaydisp.Enabled = false;
                    break;

                case FileStatus.READY:
                    toolStripButton_record.Enabled = true;
                    toolStripButton_stop.Enabled = false;
                    toolStripButton_play.Enabled = true;
                    toolStripButton_export.Enabled = true;
                    timer_updateplaydisp.Enabled = false;
                    break;
            }
        }

        //======================================================================================================
        //audio events
        //======================================================================================================

        //new data is available while recording, so save it to the files
        private void audioDataAvailable(object sender, WaveInEventArgs e)
        {
            for (int i = 0; i < e.BytesRecorded; i++)
            {
                recorded_audio.Add(e.Buffer[i]);
            }

            recording_seconds = recorded_audio.Count / (float)wave_format.AverageBytesPerSecond;
            toolStripStatusLabel_status.Text = "Now recording... " + recording_seconds.ToString("0.0") + " sec";
        }

        //recording has been stopped by the user
        private void audioRecordingStopped(object sender, StoppedEventArgs e)
        {
            recorded_audio_array = recorded_audio.ToArray();
            selection_start = 0;
            num_audio_blocks = recorded_audio.Count / wave_format.BlockAlign;
            selection_end = num_audio_blocks - 1;
            audio_capture.Dispose();

            if (recorded_audio.Count == 0)
            {
                setStatus(FileStatus.NONE);
            }
            else
            {
                setStatus(FileStatus.READY);
                renderWaveformDisplay();
                saveTrimmedAudio();
            }
        }

        //playback has completed or has been stopped by the user
        void audioPlaybackStopped(object sender, StoppedEventArgs e)
        {
            audio_player_reader.Dispose();
            audio_player.Dispose();

            //update UI
            setStatus(FileStatus.READY);
            pictureBox_wave.Refresh();
        }


        //======================================================================================================
        //ui element events
        //======================================================================================================

        private void toolStripButton_record_Click(object sender, EventArgs e)
        {
            //clear old recording
            recorded_audio.Clear();

            //update UI
            setStatus(FileStatus.RECORDING);
            pictureBox_wave.Refresh();

            //create WASAPI recording and saving objects
            audio_capture = new WasapiLoopbackCapture();
            wave_format = audio_capture.WaveFormat;

            //when audio has been captured, save it to the file
            audio_capture.DataAvailable += audioDataAvailable;

            //when audio recording has stopped, close the file and get rid of recording objects
            audio_capture.RecordingStopped += audioRecordingStopped;

            //start recording audio
            audio_capture.StartRecording();
        }

        private void toolStripButton_stop_Click(object sender, EventArgs e)
        {
            if(file_status == FileStatus.LISTENING)
            {
                audio_player.Stop();
            }
            else
            {
                audio_capture.StopRecording();
            }
        }

        private void toolStripButton_play_Click(object sender, EventArgs e)
        {
            //update UI
            setStatus(FileStatus.LISTENING);
            

            //play file
            audio_player_reader = new WaveFileReader(filename_trim_wav);
            audio_player = new WaveOut();
            audio_player.Init(audio_player_reader);
            audio_player.Play();
            audio_player.PlaybackStopped += audioPlaybackStopped;
        }

        private void pictureBox_wave_MouseDown(object sender, MouseEventArgs e)
        {
            if(file_status == FileStatus.READY)
            {
                if(e.Button == MouseButtons.Right)
                {
                    selection_start = 0;
                    selection_end = num_audio_blocks - 1;
                    pictureBox_wave.Refresh();
                    saveTrimmedAudio();
                }
                else
                {
                    selecting = true;
                    selection_end = selection_start = mouseXToBlock(e.Location.X);
                    pictureBox_wave.Refresh();
                }
            }
        }

        private void pictureBox_wave_MouseMove(object sender, MouseEventArgs e)
        {
            if(selecting)
            {
                selection_end = mouseXToBlock(e.Location.X);
                pictureBox_wave.Refresh();
            }
        }

        private void pictureBox_wave_MouseUp(object sender, MouseEventArgs e)
        {
            if(selecting && e.Button == MouseButtons.Left)
            {
                selecting = false;
                if (selection_end < selection_start)
                {
                    long temp = selection_start;
                    selection_start = selection_end;
                    selection_end = temp;
                }
                if (selection_end - selection_start == 0)
                {
                    selection_start = 0;
                    selection_end = num_audio_blocks - 1;
                    pictureBox_wave.Refresh();
                }
                saveTrimmedAudio();
            }
        }
        

        private void toolStripButton_wav_Click(object sender, EventArgs e)
        {
            toolStripButton_wav.Checked = true;
            toolStripButton_mp3.Checked = false;
        }

        private void toolStripButton_mp3_Click(object sender, EventArgs e)
        {
            toolStripButton_mp3.Checked = true;
            toolStripButton_wav.Checked = false;
        }

        private void toolStripButton_export_MouseDown(object sender, MouseEventArgs e)
        {
            if (file_status == FileStatus.READY)
            {
                FileInfo fi;
                if (toolStripButton_wav.Checked)
                {
                    fi = new FileInfo(filename_trim_wav);
                }
                else
                {
                    fi = new FileInfo(filename_trim_mp3);
                }

                string[] filename_to_drag = { fi.FullName };
                toolStripButton_export.DoDragDrop(new DataObject(DataFormats.FileDrop, filename_to_drag), DragDropEffects.Copy);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteFileIfExists(filename_trim_wav);
            deleteFileIfExists(filename_trim_mp3);
        }
        void deleteFileIfExists(string filename)
        {
            if(new FileInfo(filename).Exists)
            {
                File.Delete(filename);
            }
        }
        void saveTrimmedAudio()
        {
            int start_pos = (int)(selection_start * wave_format.BlockAlign);
            int length = (int)(wave_format.BlockAlign * (selection_end - selection_start));
            byte[] buf = recorded_audio.GetRange(start_pos, length).ToArray();

            WaveFileWriter writer_wav = new WaveFileWriter(filename_trim_wav, wave_format);
            LameMP3FileWriter writer_mp3 = new LameMP3FileWriter(filename_trim_mp3, wave_format, 320);
            writer_wav.Write(buf, 0, buf.Length);
            writer_mp3.Write(buf, 0, buf.Length);
            writer_wav.Dispose();
            writer_mp3.Dispose();

            recording_seconds = (float)writer_wav.Length / writer_wav.WaveFormat.AverageBytesPerSecond;
            double file_mb_wav = new FileInfo(filename_trim_wav).Length / 1024.0 / 1024.0;
            double file_mb_mp3 = new FileInfo(filename_trim_mp3).Length / 1024.0 / 1024.0;
            toolStripStatusLabel_status.Text = "Recording time: " + recording_seconds.ToString("0.0") + " sec | WAV size: " + file_mb_wav.ToString("0.00") + " MB | MP3 size: " + file_mb_mp3.ToString("0.00") + " MB";
        }

        //======================================================================================================
        //draw waveform display
        //======================================================================================================

        private void pictureBox_wave_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            if(file_status != FileStatus.NONE && file_status != FileStatus.RECORDING)
            {
                float rect_x = map((selection_end >= selection_start) ? selection_start : selection_end, 0, num_audio_blocks, 0, pictureBox_wave.Width);
                float rect_w = map(Math.Abs(selection_end - selection_start), 0, num_audio_blocks - 1, 0, pictureBox_wave.Width);
                SolidBrush b = new SolidBrush(Color.FromArgb(30,0,70));
                g.FillRectangle(b, rect_x, 0, rect_w, pictureBox_wave.Height);

                if(file_status == FileStatus.LISTENING)
                {
                    rect_w = map(audio_player.GetPosition(), 0, audio_player_reader.Length, 0, rect_w);
                    b = new SolidBrush(Color.FromArgb(0,150,0));
                    g.FillRectangle(b, rect_x, 0, rect_w, pictureBox_wave.Height);
                }

                g.DrawImage(waveform_bmp,0,0,pictureBox_wave.Width, pictureBox_wave.Height);
            }
            else
            {
                g.DrawImage(Properties.Resources.splash,0,0,pictureBox_wave.Width,pictureBox_wave.Height);
            }
        }

        void renderWaveformDisplay()
        {
            using (Graphics g = Graphics.FromImage(waveform_bmp))
            {
                g.Clear(Color.Transparent);

                int num_samples = recorded_audio.Count / (wave_format.BlockAlign / wave_format.Channels);
                
                for(int x = 0; x < waveform_bmp.Width; x++)
                {
                    int audio_pos = (int)map(x, 0, waveform_bmp.Width, 0, num_samples / 2) * 2;
                    float y_left = map(Math.Abs(getSample(audio_pos)), 0, 1, waveform_bmp.Height / 2, 0);
                    float y_right = map(Math.Abs(getSample(audio_pos + 1)), 0, 1, waveform_bmp.Height / 2, waveform_bmp.Height - 1);
                    g.DrawLine(Pens.Cyan, x, y_left, x, y_right);
                }
            }
            pictureBox_wave.Refresh();
        }
        float getSample(int sample_num)
        {
            return BitConverter.ToSingle(recorded_audio_array,sample_num * (wave_format.BlockAlign / wave_format.Channels));
        }

        private void timer_updateplaydisp_Tick(object sender, EventArgs e)
        {
            pictureBox_wave.Refresh();
        }

        float map(float x, float in_min, float in_max, float out_min, float out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        long maplong(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        long mouseXToBlock(int mouse_x)
        {
            return maplong(mouse_x, 0, pictureBox_wave.Width, 0, num_audio_blocks);
        }
    }
}
