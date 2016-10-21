namespace WindowsFormsApplication
{
    partial class MainForm
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
            this.dataGridViewTrackList = new System.Windows.Forms.DataGridView();
            this.labelCurrentTagsHeader = new System.Windows.Forms.Label();
            this.labelFileListHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.textBoxAlbum = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxLyrics = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonGetLyrics = new System.Windows.Forms.Button();
            this.textBoxLastFmInfo = new System.Windows.Forms.TextBox();
            this.buttonLastFmInfo = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelLastFmHeader = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.buttonGetCover = new System.Windows.Forms.Button();
            this.labelLyricsInfo = new System.Windows.Forms.Label();
            this.labelCoverInfo = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrackList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTrackList
            // 
            this.dataGridViewTrackList.AllowDrop = true;
            this.dataGridViewTrackList.AllowUserToAddRows = false;
            this.dataGridViewTrackList.AllowUserToDeleteRows = false;
            this.dataGridViewTrackList.AllowUserToOrderColumns = true;
            this.dataGridViewTrackList.AllowUserToResizeRows = false;
            this.dataGridViewTrackList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewTrackList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTrackList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTrackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrackList.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewTrackList.Name = "dataGridViewTrackList";
            this.dataGridViewTrackList.ReadOnly = true;
            this.dataGridViewTrackList.RowHeadersVisible = false;
            this.dataGridViewTrackList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTrackList.Size = new System.Drawing.Size(243, 508);
            this.dataGridViewTrackList.TabIndex = 0;
            this.dataGridViewTrackList.SelectionChanged += new System.EventHandler(this.dataGridViewTrackList_SelectionChanged);
            this.dataGridViewTrackList.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewTrackList_DragDrop);
            this.dataGridViewTrackList.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewTrackList_DragEnter);
            // 
            // labelCurrentTagsHeader
            // 
            this.labelCurrentTagsHeader.AutoSize = true;
            this.labelCurrentTagsHeader.Location = new System.Drawing.Point(269, 9);
            this.labelCurrentTagsHeader.Name = "labelCurrentTagsHeader";
            this.labelCurrentTagsHeader.Size = new System.Drawing.Size(98, 13);
            this.labelCurrentTagsHeader.TabIndex = 1;
            this.labelCurrentTagsHeader.Text = "Tags for current file";
            // 
            // labelFileListHeader
            // 
            this.labelFileListHeader.AutoSize = true;
            this.labelFileListHeader.Location = new System.Drawing.Point(12, 9);
            this.labelFileListHeader.Name = "labelFileListHeader";
            this.labelFileListHeader.Size = new System.Drawing.Size(184, 13);
            this.labelFileListHeader.TabIndex = 2;
            this.labelFileListHeader.Text = "List of files (use drag and drop to add)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.9726F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.0274F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxArtist, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAlbum, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYear, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxGenre, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(272, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(325, 132);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Album";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTitle.Location = new System.Drawing.Point(48, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(274, 20);
            this.textBoxTitle.TabIndex = 5;
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxArtist.Location = new System.Drawing.Point(48, 29);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.Size = new System.Drawing.Size(274, 20);
            this.textBoxArtist.TabIndex = 6;
            // 
            // textBoxAlbum
            // 
            this.textBoxAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAlbum.Location = new System.Drawing.Point(48, 55);
            this.textBoxAlbum.Name = "textBoxAlbum";
            this.textBoxAlbum.Size = new System.Drawing.Size(274, 20);
            this.textBoxAlbum.TabIndex = 7;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxYear.Location = new System.Drawing.Point(48, 81);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(274, 20);
            this.textBoxYear.TabIndex = 8;
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGenre.Location = new System.Drawing.Point(48, 107);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(274, 20);
            this.textBoxGenre.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Genre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(618, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cover";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(886, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Lyrics";
            // 
            // textBoxLyrics
            // 
            this.textBoxLyrics.Location = new System.Drawing.Point(889, 37);
            this.textBoxLyrics.Multiline = true;
            this.textBoxLyrics.Name = "textBoxLyrics";
            this.textBoxLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLyrics.Size = new System.Drawing.Size(274, 250);
            this.textBoxLyrics.TabIndex = 12;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(320, 175);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(106, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save changes";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonGetLyrics
            // 
            this.buttonGetLyrics.Location = new System.Drawing.Point(889, 293);
            this.buttonGetLyrics.Name = "buttonGetLyrics";
            this.buttonGetLyrics.Size = new System.Drawing.Size(106, 23);
            this.buttonGetLyrics.TabIndex = 7;
            this.buttonGetLyrics.Text = "Get Lyrics";
            this.buttonGetLyrics.UseVisualStyleBackColor = true;
            this.buttonGetLyrics.Click += new System.EventHandler(this.buttonGetLyrics_Click);
            // 
            // textBoxLastFmInfo
            // 
            this.textBoxLastFmInfo.Location = new System.Drawing.Point(272, 235);
            this.textBoxLastFmInfo.Multiline = true;
            this.textBoxLastFmInfo.Name = "textBoxLastFmInfo";
            this.textBoxLastFmInfo.Size = new System.Drawing.Size(325, 185);
            this.textBoxLastFmInfo.TabIndex = 8;
            // 
            // buttonLastFmInfo
            // 
            this.buttonLastFmInfo.Location = new System.Drawing.Point(272, 426);
            this.buttonLastFmInfo.Name = "buttonLastFmInfo";
            this.buttonLastFmInfo.Size = new System.Drawing.Size(238, 23);
            this.buttonLastFmInfo.TabIndex = 9;
            this.buttonLastFmInfo.Text = "Get lasf.fm info for entered Artist and Title";
            this.buttonLastFmInfo.UseVisualStyleBackColor = true;
            this.buttonLastFmInfo.Click += new System.EventHandler(this.buttonLastFmInfo_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(138, 520);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(62, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "google.com";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonTest
            // 
            this.buttonTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTest.Location = new System.Drawing.Point(12, 515);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(120, 23);
            this.buttonTest.TabIndex = 14;
            this.buttonTest.Text = "test button";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Visible = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelLastFmHeader
            // 
            this.labelLastFmHeader.AutoSize = true;
            this.labelLastFmHeader.Location = new System.Drawing.Point(275, 219);
            this.labelLastFmHeader.Name = "labelLastFmHeader";
            this.labelLastFmHeader.Size = new System.Drawing.Size(117, 13);
            this.labelLastFmHeader.TabIndex = 6;
            this.labelLastFmHeader.Text = "last.fm song information";
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Location = new System.Drawing.Point(621, 37);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCover.TabIndex = 13;
            this.pictureBoxCover.TabStop = false;
            // 
            // buttonGetCover
            // 
            this.buttonGetCover.Location = new System.Drawing.Point(621, 293);
            this.buttonGetCover.Name = "buttonGetCover";
            this.buttonGetCover.Size = new System.Drawing.Size(75, 23);
            this.buttonGetCover.TabIndex = 15;
            this.buttonGetCover.Text = "Get Cover";
            this.buttonGetCover.UseVisualStyleBackColor = true;
            this.buttonGetCover.Click += new System.EventHandler(this.buttonGetCover_Click);
            // 
            // labelLyricsInfo
            // 
            this.labelLyricsInfo.Location = new System.Drawing.Point(889, 323);
            this.labelLyricsInfo.Name = "labelLyricsInfo";
            this.labelLyricsInfo.Size = new System.Drawing.Size(274, 186);
            this.labelLyricsInfo.TabIndex = 16;
            this.labelLyricsInfo.Text = "Lyrics info";
            // 
            // labelCoverInfo
            // 
            this.labelCoverInfo.Location = new System.Drawing.Point(621, 323);
            this.labelCoverInfo.Name = "labelCoverInfo";
            this.labelCoverInfo.Size = new System.Drawing.Size(250, 186);
            this.labelCoverInfo.TabIndex = 17;
            this.labelCoverInfo.Text = "Cover info";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 549);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1178, 22);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "tesdf";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel.Text = "Hello";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 571);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.labelCoverInfo);
            this.Controls.Add(this.labelLyricsInfo);
            this.Controls.Add(this.buttonGetCover);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonLastFmInfo);
            this.Controls.Add(this.textBoxLastFmInfo);
            this.Controls.Add(this.buttonGetLyrics);
            this.Controls.Add(this.labelLastFmHeader);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelFileListHeader);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLyrics);
            this.Controls.Add(this.labelCurrentTagsHeader);
            this.Controls.Add(this.dataGridViewTrackList);
            this.Name = "MainForm";
            this.Text = "TagEditor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrackList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTrackList;
        private System.Windows.Forms.Label labelCurrentTagsHeader;
        private System.Windows.Forms.Label labelFileListHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAlbum;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonGetLyrics;
        private System.Windows.Forms.TextBox textBoxLastFmInfo;
        private System.Windows.Forms.Button buttonLastFmInfo;
        private System.Windows.Forms.TextBox textBoxLyrics;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelLastFmHeader;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button buttonGetCover;
        private System.Windows.Forms.Label labelLyricsInfo;
        private System.Windows.Forms.Label labelCoverInfo;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxArtist;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

