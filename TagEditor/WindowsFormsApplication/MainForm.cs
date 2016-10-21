using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Shared;

namespace WindowsFormsApplication
{
    using System.Windows.Forms.VisualStyles;

    using Helpers;

    public partial class MainForm : Form
    {
        private IList<FullTrackInfo> trackList = new List<FullTrackInfo>();

        public MainForm()
        {
            WebRequest.DefaultWebProxy = null;

            InitializeComponent();
            InitializeDataGridColumns();
            //AddFilesToList(new string[] { 
            //    @"D:\yadisk\_ Music\\Enter Shikari\Enter Shikari - The Last Garrison.mp3",
            //    @"D:\yadisk\_ Music\\Enter Shikari\Enter Shikari - Destabilise.mp3",
            //    @"D:\yadisk\_ Music\\Hadouken!\Every Weekend [2013]\13. Hadouken! - Oxygen.mp3"
            //});
            //AddFilesToList(new string[] { 
            //    @"D:\Yandex.Disk\_ Music\\Enter Shikari\Enter Shikari - The Last Garrison.mp3",
            //    @"D:\Yandex.Disk\_ Music\\Enter Shikari\Enter Shikari - Destabilise.mp3",
            //    @"D:\Yandex.Disk\_ Music\\Hadouken!\Every Weekend [2013]\13. Hadouken! - Oxygen.mp3"
            //});

            //AddFilesToList(new string[] { 
            //    @"C:\TestSongs\Calvin Harris Feat. Ellie Goulding - Outside.mp3",
            //    @"C:\TestSongs\Joy Division - She's Lost Control.mp3",
            //    @"C:\TestSongs\Limp Bizkit - Behind Blue Eyes.mp3"
            //});

            try
            {
                GoogleHelper.DisableRedirecting();
            }
            catch
            {
                toolStripStatusLabel.Text = "Seems like you don't have internet connection. Please don't do anything.";
            }
        }

        private void InitializeDataGridColumns()
        {
            var columnId = dataGridViewTrackList.Columns.Add("FileNameColumn", "File Name");
            dataGridViewTrackList.Columns[columnId].Width = dataGridViewTrackList.Width - 2;
        }

        private void AddFilesToList(string[] files)
        {
            foreach (string filePath in files)
            {
                var track = new FullTrackInfo(filePath);
                this.trackList.Add(track);

                var filename = Path.GetFileName(filePath);
                this.dataGridViewTrackList.Rows.Add(filename);
            }

            toolStripStatusLabel.Text = "Loaded " + files.Length + " file(s)";
        }

        // dataGridView Events

        private void dataGridViewTrackList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dataGridViewTrackList_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            dataGridViewTrackList.Rows.Clear();
            this.trackList.Clear();

            AddFilesToList(files);
        }

        private void dataGridViewTrackList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var trackIndex = dataGridViewTrackList.CurrentRow.Index;

                var track = this.trackList[trackIndex];

                toolStripStatusLabel.Text = string.Empty;
                if (track.LocalInfo == null)
                {
                    track.LocalInfo = TaglibHelper.ScanFile(track.Path);
                    toolStripStatusLabel.Text = "Tag information successfully scanned";
                }
                
                textBoxTitle.Text = track.LocalInfo.Title;
                textBoxArtist.Text = track.LocalInfo.Artist;
                textBoxAlbum.Text = track.LocalInfo.Album;
                textBoxYear.Text = track.LocalInfo.Year.ToString();
                textBoxGenre.Text = track.LocalInfo.Genre;
                textBoxLyrics.Text = track.LocalInfo.Lyrics;
                pictureBoxCover.Image = track.LocalInfo.Cover;
                labelCoverInfo.Text = "Cover info";
                labelLyricsInfo.Text = "Lyrics info";
                textBoxLastFmInfo.Text = string.Empty;
            }
            catch
            {
                toolStripStatusLabel.Text = "Oops, something went wrong";
            }
        }

        private async void buttonLastFmInfo_Click(object sender, EventArgs e)
        {
            this.buttonLastFmInfo.Enabled = false;

            try
            {
                var trackIndex = dataGridViewTrackList.CurrentRow.Index;

                var track = this.trackList[trackIndex]; // we 

                track.LastFmInfo = await LastFmHelper.GetTrackInfoAsync(textBoxArtist.Text, textBoxTitle.Text);

                textBoxLastFmInfo.Text = track.LastFmInfo.ToString();
            }
            catch (Exception)
            {
                toolStripStatusLabel.Text = "Oops, something went wrong";
            }

            this.buttonLastFmInfo.Enabled = true;
        }

        private void buttonGetLyrics_Click(object sender, EventArgs e)
        {
            this.buttonGetLyrics.Enabled = false;

            try
            {
                var lyricsInfo = LyricsHelper.GetLyrics(this.textBoxArtist.Text, this.textBoxTitle.Text);

                this.textBoxLyrics.Text = lyricsInfo.Url + Environment.NewLine + lyricsInfo.Lyrics;
                labelLyricsInfo.Text = lyricsInfo.ToString();
            }
            catch (Exception)
            {
                toolStripStatusLabel.Text = "Oops, something went wrong";
            }
            
            this.buttonGetLyrics.Enabled = true;
        }

        private void buttonGetCover_Click(object sender, EventArgs e)
        {
            this.buttonGetCover.Enabled = false;

            try
            {
                var coverInfo = CoverHelper.GetCover(this.textBoxArtist.Text, this.textBoxAlbum.Text);

                pictureBoxCover.Image = coverInfo.Image;
                labelCoverInfo.Text = coverInfo.ToString();
            }
            catch
            {
                toolStripStatusLabel.Text = "Oops, something went wrong";
            }

            this.buttonGetCover.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var trackIndex = dataGridViewTrackList.CurrentRow.Index;

                var track = this.trackList[trackIndex];

                var localTrackInfo = new LocalTrackInfo(track.Path)
                {
                    Title = textBoxTitle.Text,
                    Album = textBoxAlbum.Text,
                    Artist = textBoxArtist.Text,
                    Cover = pictureBoxCover.Image,
                    Genre = textBoxGenre.Text,
                    Lyrics = textBoxLyrics.Text,
                    Year = uint.Parse(textBoxYear.Text)
                };

                TaglibHelper.SaveFile(localTrackInfo);

                track.LocalInfo = null;

                toolStripStatusLabel.Text = "Tags information succesfully saved";
            }
            catch
            {
                toolStripStatusLabel.Text = "Oops, something went wrong";
            }
        }

        // test controls
        private void buttonTest_Click(object sender, EventArgs e)
        {
            GoogleHelper.DisableRedirecting();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //linkLabel1.Links.Add(0, 3, "last.fm");
            //var clicked = e.Link.LinkData.ToString();
            //Process.Start("http://google.com/");
        }
    }
}
