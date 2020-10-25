namespace AudioSnippingTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_record = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_play = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_wav = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_mp3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_export = new System.Windows.Forms.ToolStripButton();
            this.timer_updateplaydisp = new System.Windows.Forms.Timer(this.components);
            this.pictureBox_wave = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wave)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 187);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(516, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_status
            // 
            this.toolStripStatusLabel_status.Name = "toolStripStatusLabel_status";
            this.toolStripStatusLabel_status.Size = new System.Drawing.Size(223, 17);
            this.toolStripStatusLabel_status.Text = "Audio Snipping Tool - by Frost Sheridan";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_record,
            this.toolStripButton_stop,
            this.toolStripButton_play,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripButton_wav,
            this.toolStripButton_mp3,
            this.toolStripButton_export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(516, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_record
            // 
            this.toolStripButton_record.Image = global::AudioSnippingTool.Properties.Resources.icon_record;
            this.toolStripButton_record.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_record.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_record.Name = "toolStripButton_record";
            this.toolStripButton_record.Size = new System.Drawing.Size(102, 28);
            this.toolStripButton_record.Text = "Record New";
            this.toolStripButton_record.ToolTipText = "Start recording a new audio snippet";
            this.toolStripButton_record.Click += new System.EventHandler(this.toolStripButton_record_Click);
            // 
            // toolStripButton_stop
            // 
            this.toolStripButton_stop.Enabled = false;
            this.toolStripButton_stop.Image = global::AudioSnippingTool.Properties.Resources.icon_stop;
            this.toolStripButton_stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_stop.Name = "toolStripButton_stop";
            this.toolStripButton_stop.Size = new System.Drawing.Size(61, 28);
            this.toolStripButton_stop.Text = "Stop";
            this.toolStripButton_stop.ToolTipText = "End recording or stop listening";
            this.toolStripButton_stop.Click += new System.EventHandler(this.toolStripButton_stop_Click);
            // 
            // toolStripButton_play
            // 
            this.toolStripButton_play.Enabled = false;
            this.toolStripButton_play.Image = global::AudioSnippingTool.Properties.Resources.icon_play;
            this.toolStripButton_play.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_play.Name = "toolStripButton_play";
            this.toolStripButton_play.Size = new System.Drawing.Size(67, 28);
            this.toolStripButton_play.Text = "Listen";
            this.toolStripButton_play.ToolTipText = "Play recorded audio";
            this.toolStripButton_play.Click += new System.EventHandler(this.toolStripButton_play_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(62, 28);
            this.toolStripLabel1.Text = "Export as:";
            // 
            // toolStripButton_wav
            // 
            this.toolStripButton_wav.Checked = true;
            this.toolStripButton_wav.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton_wav.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_wav.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_wav.Image")));
            this.toolStripButton_wav.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_wav.Name = "toolStripButton_wav";
            this.toolStripButton_wav.Size = new System.Drawing.Size(39, 28);
            this.toolStripButton_wav.Text = "WAV";
            this.toolStripButton_wav.ToolTipText = "Recording will be exported as a .wav file";
            this.toolStripButton_wav.Click += new System.EventHandler(this.toolStripButton_wav_Click);
            // 
            // toolStripButton_mp3
            // 
            this.toolStripButton_mp3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_mp3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_mp3.Image")));
            this.toolStripButton_mp3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_mp3.Name = "toolStripButton_mp3";
            this.toolStripButton_mp3.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton_mp3.Text = "MP3";
            this.toolStripButton_mp3.ToolTipText = "Recording will be exported as a 320kbps .mp3 file";
            this.toolStripButton_mp3.Click += new System.EventHandler(this.toolStripButton_mp3_Click);
            // 
            // toolStripButton_export
            // 
            this.toolStripButton_export.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_export.Enabled = false;
            this.toolStripButton_export.Image = global::AudioSnippingTool.Properties.Resources.icon_export;
            this.toolStripButton_export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_export.Name = "toolStripButton_export";
            this.toolStripButton_export.Size = new System.Drawing.Size(71, 28);
            this.toolStripButton_export.Text = "Export";
            this.toolStripButton_export.ToolTipText = "Drag me to another window to export audio";
            this.toolStripButton_export.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_export_MouseDown);
            // 
            // timer_updateplaydisp
            // 
            this.timer_updateplaydisp.Interval = 10;
            this.timer_updateplaydisp.Tick += new System.EventHandler(this.timer_updateplaydisp_Tick);
            // 
            // pictureBox_wave
            // 
            this.pictureBox_wave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox_wave.Location = new System.Drawing.Point(8, 34);
            this.pictureBox_wave.Name = "pictureBox_wave";
            this.pictureBox_wave.Size = new System.Drawing.Size(500, 150);
            this.pictureBox_wave.TabIndex = 1;
            this.pictureBox_wave.TabStop = false;
            this.pictureBox_wave.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_wave_Paint);
            this.pictureBox_wave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_wave_MouseDown);
            this.pictureBox_wave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_wave_MouseMove);
            this.pictureBox_wave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_wave_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 209);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox_wave);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Audio Snipping Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_status;
        private System.Windows.Forms.PictureBox pictureBox_wave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_record;
        private System.Windows.Forms.ToolStripButton toolStripButton_stop;
        private System.Windows.Forms.ToolStripButton toolStripButton_play;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton_wav;
        private System.Windows.Forms.ToolStripButton toolStripButton_mp3;
        private System.Windows.Forms.Timer timer_updateplaydisp;
        private System.Windows.Forms.ToolStripButton toolStripButton_export;
    }
}

