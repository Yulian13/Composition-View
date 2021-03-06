using Composition_View.SQL_Class;
using Composition_View.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composition_View.Forms
{
    public partial class Watching : Form
    {
        static Image[] originImage;
        static Image[] NewImages;
        static bool[] ReadyPhotos;
        bool _isClose = false;

        bool originDeshifrovka = true;
        bool normalZoom = true;
        string Key;
        int numberPhoto;
        private int _numberPhoto
        {
            get => numberPhoto;
            set
            {
                numberPhoto = value;
                LabelView.Text = $"Page: {_numberPhoto + 1}/{ReadyPhotos.Length}";
                ProgressBarView.Value = numberPhoto + 1;
                pictureBox1_SizeChanged(null, null);
            }
        }

        public Watching(Composition composition, Image startPhoto, string Key)
        {
            InitializeComponent();

            this.Key = new String(Key.ToCharArray());
            this.Text = Librari.DeShifrovka(composition.Name, this.Key);
            originImage = new Image[composition.Photos.Count];
            NewImages = new Image[composition.Photos.Count];
            ReadyPhotos = new bool[composition.Photos.Count];

            ProgressBarProgress.Maximum = ReadyPhotos.Length;
            ProgressBarView.Maximum = ReadyPhotos.Length;

            backgroundWorker1.RunWorkerAsync(composition);

            NewImages[0] = startPhoto;

            _numberPhoto = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Image error = pictureBox1.ErrorImage;
            int i = 0;
            foreach (Photo photo in (e.Argument as Composition).Photos)
            {
                if (_isClose) return; // Crutch
                try
                {
                    NewImages[i] = new NewImage(photo).DeShifrovkaImage(Key);
                    originImage[i] = Librari.byteArrayToImage(photo.Image);
                }
                catch (Exception)
                {
                    NewImages[i] = error;
                }
                ReadyPhotos[i] = true;
                backgroundWorker1.ReportProgress(++i);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (_isClose) return; // Crutch

            LabelProgress.Text = $"{e.ProgressPercentage}/{NewImages.Length}";
            ProgressBarProgress.Value++;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_isClose) return; // Crutch

            ProgressBarProgress.Visible = false;
            LabelProgress.Visible = false;
        }

        private void buttonForward_Click(object sender = null, EventArgs e = null)
        {
            panel1.VerticalScroll.Value = 0;
            if (_numberPhoto < NewImages.Length - 1 && ReadyPhotos[_numberPhoto + 1] == true)
                _numberPhoto++;
        }

        private void buttonBack_Click(object sender = null, EventArgs e = null)
        {
            panel1.VerticalScroll.Value = 0;
            if (_numberPhoto > 0)
                _numberPhoto--;
        }

        private void Watching_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Location.X < pictureBox1.Width / 2)
                    buttonBack_Click();
                else
                    buttonForward_Click();
            }
            else if (e.Button == MouseButtons.XButton1)
                buttonBack_Click();
            else if (e.Button == MouseButtons.XButton2)
                buttonForward_Click();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Image image = (originDeshifrovka) ? NewImages[numberPhoto] :
                    originImage[numberPhoto];
            LabelView.Margin = new Padding((int)(toolStrip1.Width * 0.4), 3, 0, 2);
            if (normalZoom)
            {
                int Width = panel1.Width - 20;
                int Height = (int)(((double)image.Height / image.Width) * Width);
                Size newSize = new Size(Width, Height);
                pictureBox1.Image = new Bitmap(image, newSize);
                pictureBox1.Size = new Size(newSize.Width, newSize.Height + statusStrip1.Height);
            }
            else
            {
                pictureBox1.Size = new Size(panel1.Width - 20, panel1.Height - 20);
                pictureBox1.Image = image;
            }
        }

        private void toolStripButtonOriginalDeshifrovka_Click(object sender, EventArgs e)
        {
            originDeshifrovka = !originDeshifrovka;
            toolStripButtonOriginalDeshifrovka.Text = (originDeshifrovka) ? "origin" : "Deshifrovka";
            _numberPhoto = _numberPhoto;
        }

        private void ButtonZoomNormal_Click(object sender, EventArgs e)
        {
            normalZoom = !normalZoom;
            pictureBox1.SizeMode = (normalZoom) ? PictureBoxSizeMode.Normal : PictureBoxSizeMode.Zoom;
            pictureBox1.Image = NewImages[_numberPhoto];
            ButtonZoomNormal.Text = (normalZoom) ? "Zoom" : "Normal";
            pictureBox1_SizeChanged(null, null);
        }

        private void Watching_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isClose = true;
            for (int i = 0; i < NewImages.Length; i++)
            {
                if (NewImages[i] != null)
                    NewImages[i].Dispose();
                if (originImage[i] != null)
                    originImage[i].Dispose();
            }
        }
    }
}
