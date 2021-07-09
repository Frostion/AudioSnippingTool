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
        string filename_name, filename_ext;

        WasapiLoopbackCapture audio_capture;
        WaveOut audio_player;

        List<float> recorded_audio = new List<float>();
        WaveFormat wave_format;

        enum FileStatus { NONE, RECORDING, LISTENING, READY, WAITING };
        FileStatus file_status = FileStatus.NONE;
        bool selecting = false;
        int selection_start = 0, selection_end = 0, recorded_audio_samples = 0;
        float recorded_audio_seconds = 0;
        Bitmap waveform_bmp;

        public Form1()
        {
            InitializeComponent();

            //create bmp for drawing waveform display onto
            waveform_bmp = new Bitmap(pictureBox_wave.Width, pictureBox_wave.Height);
            comboBoxFileType.SelectedIndex = 0;
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
                    toolStripDropDownButtonNormalize.Enabled = false;
                    comboBoxFileType.Enabled = true;
                    toolStripButton_export.Enabled = false;
                    timer_updateplaydisp.Enabled = false;
                    showSplashScreen();
                    break;

                case FileStatus.RECORDING:
                case FileStatus.LISTENING:
                    toolStripButton_record.Enabled = false;
                    toolStripButton_stop.Enabled = true;
                    toolStripButton_play.Enabled = false;
                    toolStripDropDownButtonNormalize.Enabled = false;
                    comboBoxFileType.Enabled = false;
                    toolStripButton_export.Enabled = false;
                    timer_updateplaydisp.Enabled = true;
                    break;

                case FileStatus.WAITING:
                    toolStripButton_record.Enabled = false;
                    toolStripButton_stop.Enabled = false;
                    toolStripButton_play.Enabled = false;
                    toolStripDropDownButtonNormalize.Enabled = false;
                    comboBoxFileType.Enabled = false;
                    toolStripButton_export.Enabled = false;
                    timer_updateplaydisp.Enabled = false;
                    break;

                case FileStatus.READY:
                    toolStripButton_record.Enabled = true;
                    toolStripButton_stop.Enabled = false;
                    toolStripButton_play.Enabled = true;
                    toolStripDropDownButtonNormalize.Enabled = true;
                    comboBoxFileType.Enabled = true;
                    toolStripButton_export.Enabled = true;
                    timer_updateplaydisp.Enabled = false;
                    break;
            }
        }



        //============================================================================================================================================================
        //audio events
        //============================================================================================================================================================

        //new data is available while recording, so save it to the files
        private void audioDataAvailable(object sender, WaveInEventArgs e)
        {
            for (int i = 0; i < e.BytesRecorded; i += 4)
            {
                recorded_audio.Add(BitConverter.ToSingle(e.Buffer, i));
            }

            recorded_audio_seconds = recorded_audio.Count / (float)wave_format.SampleRate / wave_format.Channels;
            toolStripStatusLabel_status.Text = "Now recording... " + recorded_audio_seconds.ToString("0.0") + " sec";
        }

        //recording has been stopped by the user
        private void audioRecordingStopped(object sender, StoppedEventArgs e)
        {
            selection_start = 0;
            recorded_audio_samples = recorded_audio.Count / wave_format.Channels;
            selection_end = recorded_audio_samples - 1;
            audio_capture.Dispose();

            if (recorded_audio.Count == 0)
            {
                setStatus(FileStatus.NONE);
            }
            else
            {
                saveTrimmedAudio();
                renderWaveformDisplay();
            }
        }

        //playback has completed or has been stopped by the user
        void audioPlaybackStopped(object sender, StoppedEventArgs e)
        {
            audio_player.Dispose();

            //update UI
            setStatus(FileStatus.READY);
            pictureBox_wave.Refresh();
        }



        //============================================================================================================================================================
        //ui element events
        //============================================================================================================================================================

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
            IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(getSelectedAsByteArray()), wave_format);
            audio_player = new WaveOut();
            audio_player.Init(provider);
            audio_player.Play();
            audio_player.PlaybackStopped += audioPlaybackStopped;
        }

        private void toolStripMenuItemNormalize25_Click(object sender, EventArgs e)
        {
            normalizeRecordedAudio(0.25);
        }

        private void toolStripMenuItemNormalize50_Click(object sender, EventArgs e)
        {
            normalizeRecordedAudio(0.5);
        }

        private void toolStripMenuItemNormalize100_Click(object sender, EventArgs e)
        {
            normalizeRecordedAudio(1);
        }

        private void comboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(file_status == FileStatus.READY)
            {
                saveTrimmedAudio();
            }
        }

        private void toolStripButton_export_MouseDown(object sender, MouseEventArgs e)
        {
            String new_filename = textBoxFileName.Text;
            File.Move(filename_name + filename_ext, new_filename + filename_ext);
            filename_name = new_filename;

            if (file_status == FileStatus.READY)
            {
                FileInfo fi = new FileInfo(filename_name + filename_ext);
                string[] filename_to_drag = { fi.FullName };
                toolStripButton_export.DoDragDrop(new DataObject(DataFormats.FileDrop, filename_to_drag), DragDropEffects.Copy);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteFileIfExists(filename_name + filename_ext);
        }

        private void pictureBox_wave_MouseDown(object sender, MouseEventArgs e)
        {
            if (file_status == FileStatus.READY)
            {
                if (e.Button == MouseButtons.Right)
                {
                    selection_start = 0;
                    selection_end = recorded_audio_samples - 1;
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
            if (selecting)
            {
                selection_end = mouseXToBlock(e.Location.X);
                pictureBox_wave.Refresh();
            }
        }

        private void pictureBox_wave_MouseUp(object sender, MouseEventArgs e)
        {
            if (selecting && e.Button == MouseButtons.Left)
            {
                selecting = false;
                if (selection_end < selection_start)
                {
                    int temp = selection_start;
                    selection_start = selection_end;
                    selection_end = temp;
                }
                if (selection_end - selection_start == 0)
                {
                    selection_start = 0;
                    selection_end = recorded_audio_samples - 1;
                    pictureBox_wave.Refresh();
                }

                if (selection_start < 0) { selection_start = 0; }
                if (selection_end > recorded_audio_samples - 1) { selection_end = recorded_audio_samples - 1; }
                saveTrimmedAudio();
            }
        }



        //============================================================================================================================================================
        //file and audio operations
        //============================================================================================================================================================

        void saveTrimmedAudio()
        {
            setStatus(FileStatus.WAITING);
            deleteFileIfExists(filename_name + filename_ext);
            filename_name = textBoxFileName.Text;
            byte[] selected_audio_array = getSelectedAsByteArray();

            if(comboBoxFileType.SelectedIndex == 0)
            {
                filename_ext = ".wav";
                WaveFileWriter writer = new WaveFileWriter(filename_name + filename_ext, wave_format);
                writer.Write(selected_audio_array, 0, selected_audio_array.Length);
                writer.Dispose();
            }
            else
            {
                int bitrate;
                if(comboBoxFileType.SelectedIndex == 1) { bitrate = 320; }
                else { bitrate = 192; }

                filename_ext = ".mp3";
                LameMP3FileWriter writer = new LameMP3FileWriter(filename_name + filename_ext, wave_format, bitrate);
                writer.Write(selected_audio_array, 0, selected_audio_array.Length);
                writer.Dispose();
            }

            recorded_audio_seconds = (float)selected_audio_array.Length / wave_format.AverageBytesPerSecond;
            double file_mb = new FileInfo(filename_name + filename_ext).Length / 1024.0 / 1024.0;

            toolStripStatusLabel_status.Text = "Selected length: " + recorded_audio_seconds.ToString("0.0") + " sec | File size: " + file_mb.ToString("0.00") + " MB";
            setStatus(FileStatus.READY);
        }

        void deleteFileIfExists(string filename)
        {
            try
            {
                File.Delete(filename);
            }
            catch { }
        }

        byte[] getRecordingAsByteArray(int start, int length)
        {
            byte[] output = new byte[length * 4 * wave_format.Channels];
            float[] input = recorded_audio.GetRange(start * wave_format.Channels, length * wave_format.Channels).ToArray();
            Buffer.BlockCopy(input, 0, output, 0, output.Length);
            return output;
        }

        byte[] getSelectedAsByteArray()
        {
            return getRecordingAsByteArray(selection_start, selection_end - selection_start);
        }

        void normalizeRecordedAudio(double new_max)
        {
            float min = recorded_audio.Min();
            float max = recorded_audio.Max();
            for (int i = 0; i < recorded_audio.Count; i++)
            {
                recorded_audio[i] = map(recorded_audio[i], min, max, (float)-new_max, (float)new_max);
            }
            saveTrimmedAudio();
            renderWaveformDisplay();
        }



        //============================================================================================================================================================
        //draw waveform display
        //============================================================================================================================================================

        private void pictureBox_wave_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            if(file_status != FileStatus.NONE && file_status != FileStatus.RECORDING)
            {
                float rect_x = map((selection_end >= selection_start) ? selection_start : selection_end, 0, recorded_audio_samples, 0, pictureBox_wave.Width);
                float rect_w = map(Math.Abs(selection_end - selection_start), 0, recorded_audio_samples - 1, 0, pictureBox_wave.Width);
                SolidBrush b = new SolidBrush(Color.FromArgb(30,0,70));
                g.FillRectangle(b, rect_x, 0, rect_w, pictureBox_wave.Height);

                if(file_status == FileStatus.LISTENING)
                {
                    rect_w = map(audio_player.GetPosition() / wave_format.BlockAlign, 0, selection_end - selection_start, 0, rect_w);
                    b = new SolidBrush(Color.FromArgb(0,150,0));
                    g.FillRectangle(b, rect_x, 0, rect_w, pictureBox_wave.Height);
                }

                g.DrawImage(waveform_bmp, 0, 0, pictureBox_wave.Width, pictureBox_wave.Height);
            }
            else
            {
                g.DrawImage(Properties.Resources.splash, 0, 0, pictureBox_wave.Width, pictureBox_wave.Height);
            }
        }

        void renderWaveformDisplay()
        {
            using (Graphics g = Graphics.FromImage(waveform_bmp))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(drawSpectrogram(), 0, 0, waveform_bmp.Width, waveform_bmp.Height);

                float last_y = waveform_bmp.Height / 2;
                for(int x = 0; x < waveform_bmp.Width; x++)
                {
                    int audio_pos = (int)map(x, 0, waveform_bmp.Width, 0, recorded_audio_samples);
                    float y_left = map(Math.Abs(getSample(audio_pos, 0)), 0, 1, waveform_bmp.Height / 2, 0);
                    float y_right = map(Math.Abs(getSample(audio_pos, 1)), 0, 1, waveform_bmp.Height / 2, waveform_bmp.Height - 1);
                    g.DrawLine(Pens.White, x, y_left, x, y_right);
                }
            }
            pictureBox_wave.Refresh();
        }
        
        Bitmap drawSpectrogram()
        {
            List<double> samples = new List<double>();
            for(int i = 0; i < recorded_audio.Count; i += wave_format.Channels)
            {
                double acc = 0;
                for(int c = 0; c < wave_format.Channels; c++) { acc += recorded_audio[i + c]; }
                samples.Add(acc / wave_format.Channels);
            }

            int fft_length = 512;
            double[] window = FftSharp.Window.Hanning(fft_length);
            int spec_width = samples.Count / fft_length;
            Bitmap bmp = new Bitmap(spec_width, waveform_bmp.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                for(int slice = 0; slice < spec_width; slice++)
                {
                    double[] buf = samples.GetRange(slice * fft_length, fft_length).ToArray();
                    FftSharp.Window.ApplyInPlace(window, buf);
                    double[] result = FftSharp.Transform.FFTpower(buf);
                    float result_max = (float)result.Max();
                    for(int y = 0; y < bmp.Height; y++)
                    {
                        int pos = (int)((float)y / bmp.Height * (result.Length / 2));
                        float r = (float)result[pos];
                        if(r < -60) { r = -60; }

                        int val = (int)map(r, result_max, -60, 255, 0);
                        if(val < 0 || val > 255) { val = 0; }
                        bmp.SetPixel(slice, bmp.Height - y - 1, Color.FromArgb(val, 0, 255, 255));
                    }
                }
            }
            return bmp;
        }
        


        //============================================================================================================================================================
        //misc helper functions
        //============================================================================================================================================================

        float getSample(int sample_num, int channel)
        {
            return recorded_audio[sample_num * wave_format.Channels + channel];
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

        int mouseXToBlock(int mouse_x)
        {
            return (int)maplong(mouse_x, 0, pictureBox_wave.Width, 0, recorded_audio_samples);
        }
    }
}
