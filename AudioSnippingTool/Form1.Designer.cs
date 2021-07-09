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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.textBoxFileName = new System.Windows.Forms.ToolStripTextBox();
            this.comboBoxFileType = new System.Windows.Forms.ToolStripComboBox();
            this.timer_updateplaydisp = new System.Windows.Forms.Timer(this.components);
            this.toolStripButton_record = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_play = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonNormalize = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemNormalize25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNormalize50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNormalize100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_export = new System.Windows.Forms.ToolStripButton();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 192);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(588, 22);
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
            this.toolStripDropDownButtonNormalize,
            this.toolStripButton_export,
            this.toolStripSeparator2,
            this.textBoxFileName,
            this.comboBoxFileType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(588, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(115, 31);
            this.textBoxFileName.Text = "AST_Export";
            this.textBoxFileName.ToolTipText = "Name of file to export";
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.DropDownWidth = 90;
            this.comboBoxFileType.Items.AddRange(new object[] {
            ".wav",
            ".mp3 (320k)",
            ".mp3 (192k)"});
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(85, 31);
            this.comboBoxFileType.ToolTipText = "File type to export audio as";
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // timer_updateplaydisp
            // 
            this.timer_updateplaydisp.Interval = 10;
            this.timer_updateplaydisp.Tick += new System.EventHandler(this.timer_updateplaydisp_Tick);
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
            this.toolStripButton_play.ToolTipText = "Play selected audio";
            this.toolStripButton_play.Click += new System.EventHandler(this.toolStripButton_play_Click);
            // 
            // toolStripDropDownButtonNormalize
            // 
            this.toolStripDropDownButtonNormalize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonNormalize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNormalize25,
            this.toolStripMenuItemNormalize50,
            this.toolStripMenuItemNormalize100});
            this.toolStripDropDownButtonNormalize.Enabled = false;
            this.toolStripDropDownButtonNormalize.Image = global::AudioSnippingTool.Properties.Resources.icon_normalize;
            this.toolStripDropDownButtonNormalize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonNormalize.Name = "toolStripDropDownButtonNormalize";
            this.toolStripDropDownButtonNormalize.Size = new System.Drawing.Size(29, 28);
            this.toolStripDropDownButtonNormalize.ToolTipText = "Normalize recorded audio";
            // 
            // toolStripMenuItemNormalize25
            // 
            this.toolStripMenuItemNormalize25.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemNormalize25.Name = "toolStripMenuItemNormalize25";
            this.toolStripMenuItemNormalize25.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemNormalize25.Text = "Normalize to 25%";
            this.toolStripMenuItemNormalize25.Click += new System.EventHandler(this.toolStripMenuItemNormalize25_Click);
            // 
            // toolStripMenuItemNormalize50
            // 
            this.toolStripMenuItemNormalize50.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemNormalize50.Name = "toolStripMenuItemNormalize50";
            this.toolStripMenuItemNormalize50.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemNormalize50.Text = "Normalize to 50%";
            this.toolStripMenuItemNormalize50.Click += new System.EventHandler(this.toolStripMenuItemNormalize50_Click);
            // 
            // toolStripMenuItemNormalize100
            // 
            this.toolStripMenuItemNormalize100.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemNormalize100.Name = "toolStripMenuItemNormalize100";
            this.toolStripMenuItemNormalize100.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemNormalize100.Text = "Normalize to 100%";
            this.toolStripMenuItemNormalize100.Click += new System.EventHandler(this.toolStripMenuItemNormalize100_Click);
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
            // pictureBox_wave
            // 
            this.pictureBox_wave.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_wave.Location = new System.Drawing.Point(12, 34);
            this.pictureBox_wave.Name = "pictureBox_wave";
            this.pictureBox_wave.Size = new System.Drawing.Size(564, 150);
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
            this.ClientSize = new System.Drawing.Size(588, 214);
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
        private System.Windows.Forms.Timer timer_updateplaydisp;
        private System.Windows.Forms.ToolStripButton toolStripButton_export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox comboBoxFileType;
        private System.Windows.Forms.ToolStripTextBox textBoxFileName;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonNormalize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNormalize25;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNormalize50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNormalize100;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

