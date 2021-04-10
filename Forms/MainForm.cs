using Composition_View.SQL_Class;
using Composition_View.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composition_View.Forms
{
    public partial class MainForm : Form
    {

        private const string Connect = @"Data Source=DESKTOP-HI8BT21\SQLEXPRESS;Database=Composition;Trusted_Connection=True;AttachDbFileName=D:\Anime\DataBase\Composition.mdf";
        static PhotoContext db;
        public MainForm()
        {
            InitializeComponent();

            try
            {
                db = new PhotoContext(Connect);
                db.Compositions.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                return;
            }

            dataGridViewComposition.DataSource = db.Compositions.Local.ToBindingList();

            CallInputKey();
        }

        int NowId
        {
            get
            {
                if (dataGridViewComposition.Rows.Count == 0 || dataGridViewComposition.SelectedRows.Count < 1)
                    return -1;

                int index = dataGridViewComposition.SelectedRows[idDataGridViewTextBoxColumn.Index].Index;

                int id = 0;
                bool converted = Int32.TryParse(dataGridViewComposition[idDataGridViewTextBoxColumn.Index, index].Value.ToString(), out id);
                if (converted == false)
                    return -1;

                return id;
            }
        }

        private void CallGridView_SelectionChanged(object sender = null, EventArgs e = null) => dataGridView_SelectionChanged(sender, e);
        int PastDataRowIndex = -1;
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int id = NowId;
            if (id < 0 || (id == PastDataRowIndex && RightKey))
                return;

            PastDataRowIndex = id;

            try
            {
                Composition composition = db.Compositions.Find(id);
                labelNameComposistion.Text = Librari.DeShifrovka(composition.Name, Key);

                NewImage image = new NewImage(db.Photos.Find(composition.IdFirstPhoto));
                image.DeShifrovkaImage(Key);
                pictureBox1.Image = image.image;
                RightKey = true;
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                c("Key is wrong: ");
            }
            catch (Exception ex)
            {
                c(ex.Message);
            }


            void c(string Message)
            {
                labelNameComposistion.Text = Message;
                pictureBox1.Image = pictureBox1.ErrorImage;
                RightKey = false;
            }
        }

        #region Buttons of options 

        bool _rightKey = false;
        bool RightKey
        {
            get => _rightKey;
            set
            {
                _rightKey = value;
                buttonOpen.Enabled = value;
                buttonDelete.Enabled = value;
                buttonAdd.Enabled = value;
            }

        }
        private string Key;

        private void CallInputKey(object sender = null, EventArgs e = null) => changeKeyToolStripMenuItem_Click(sender, e);
        private void changeKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Input_Key input = new Input_Key())
            {
                input.ShowDialog();
                this.Key = new string(input.GetText.ToCharArray());
            }
            if (string.IsNullOrEmpty(Key))
                RightKey = false;


            buttonOpen.Enabled = !String.IsNullOrWhiteSpace(this.Key);

            if (sender != null | e != null)
                CallGridView_SelectionChanged();
        }

        private void resetKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Key = "";
            RightKey = false;
            pictureBox1.Image = pictureBox1.ErrorImage;
            foreach (DataGridViewRow row in dataGridViewComposition.Rows)
            {
                row.Cells[OrigNameDataGridViewTextBoxColumn.Index].Value = "";
            }
            GC.Collect();
        }
        #endregion

        private void checkBoxDecryption_CheckedChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewComposition.Rows)
            { 
                try
                {
                    if (row.Cells[OrigNameDataGridViewTextBoxColumn.Index].Value != null)
                        continue;

                    row.Cells[OrigNameDataGridViewTextBoxColumn.Index].Value = Librari.DeShifrovka(
                            row.Cells[nameDataGridViewTextBoxColumn.Index].Value.ToString(),
                            Key
                        );
                }
                catch
                {
                    row.Cells[OrigNameDataGridViewTextBoxColumn.Index].Value = "Error";
                }

            } // Translation


            CheckBox checkBox = (sender as CheckBox);
            if (checkBox == null)
                return;

            if (checkBox.Checked)
                OrigNameDataGridViewTextBoxColumn.FillWeight = nameDataGridViewTextBoxColumn.FillWeight;
            else
                nameDataGridViewTextBoxColumn.FillWeight = OrigNameDataGridViewTextBoxColumn.FillWeight;

            OrigNameDataGridViewTextBoxColumn.Visible = checkBox.Checked;
            nameDataGridViewTextBoxColumn.Visible     = !checkBox.Checked;
        }

        private void buttonGetRandom_Click(object sender, EventArgs e)
        {
            var rn = new Random();
            int number;

            do
                number = rn.Next(dataGridViewComposition.RowCount);
            while (dataGridViewComposition.CurrentRow.Index == number);

            dataGridViewComposition.CurrentCell = dataGridViewComposition[idDataGridViewTextBoxColumn.Index, number];
        } //Get random Row

        bool usedBackgroundWorker = false;
        public bool UsedBackgroundWorker
        {
            get => usedBackgroundWorker;
            set
            {
                usedBackgroundWorker = value;

                progressBar1.Visible = usedBackgroundWorker;
                buttonCancel.Visible = usedBackgroundWorker;

                buttonAdd.Enabled = !usedBackgroundWorker;
                //buttonExport.Enabled = !usedBackgroundWorker;
                //changeCompositionsKeyToolStripMenuItem.Enabled = !usedBackgroundWorker;

                if (!usedBackgroundWorker) progressBar1.Value = 0;
            }
        }

        #region Adding

        static Composition composition;
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FilePath = new FolderBrowserDialog();
            if (FilePath.ShowDialog() != DialogResult.OK)
                return;
            backgroundWorkerAdding.RunWorkerAsync(FilePath.SelectedPath);
            UsedBackgroundWorker = true;

        }

        private void backgroundWorkerAdding_DoWork(object sender, DoWorkEventArgs e)
        {
            string Key = new string(this.Key.ToCharArray());
            string FilePath = (string)e.Argument;
            string[] imagesPath = Directory.GetFiles(FilePath, "*jpg", SearchOption.TopDirectoryOnly);
            if (imagesPath.Length == 0)
                imagesPath = Directory.GetFiles(FilePath, "*png", SearchOption.TopDirectoryOnly);

            Image[] Images = null;

            try
            {
                Images = new Image[imagesPath.Length];
                for (int i = 0; i < imagesPath.Length; i++)
                {
                    Images[i] = Image.FromFile(imagesPath[i]);
                    if (Images[i].Size.Height < 32 && Images[i].Size.Width < 32)
                        throw new Exception($"Image №{i} is too small");
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Error");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (Images.Length == 0) throw new Exception("there isn't images");

            string[] Files = FilePath.Split('\\');
            string DirectoryName = Librari.Shifrovka(Files.Last(), Key);
            Files = null;

            Random rndm = new Random();
            composition = new Composition() { Name = DirectoryName, NumberPhotos = Images.Length };

            for (int a = 0; a < Images.Length; a++)
            {
                if (backgroundWorkerAdding.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                backgroundWorkerAdding.ReportProgress(Images.Length);

                NewImage myBitmaps = new NewImage(Images[a], rndm);

                myBitmaps.ShifrovkaImage();

                Photo photo = new Photo()
                {
                    Image = Librari.imageToByteArray(myBitmaps.image),
                    RightKey = Librari.Shifrovka(myBitmaps.RightKey, Key),
                    Composition = composition
                };
                composition.Photos.Add(photo);

                backgroundWorkerAdding.ReportProgress(Images.Length);

            }
        }

        private void backgroundWorkerAdding_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = e.ProgressPercentage * 2;
            progressBar1.Value++;
        }

        private void backgroundWorkerAdding_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                MessageBox.Show("Error!: " + e.Error.Message);
            }
            else if (e.Cancelled == false)
            {
                foreach (var photo in composition.Photos)
                    db.Photos.Add(photo);
                db.Compositions.Add(composition);

                db.SaveChanges();

                composition.IdFirstPhoto = composition.Photos.First().Id;

                db.SaveChanges();

                MessageBox.Show("Composition have been added");
            }

            UsedBackgroundWorker = false;

            composition = null;
        }


        #endregion

        #region Deleting
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete it?", "Deleting",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2,
            MessageBoxOptions.DefaultDesktopOnly);


            if (result == DialogResult.No || dataGridViewComposition.SelectedRows.Count < 1)
                return;

            int id = NowId;
            if (id < 0) return;

            Composition composition = db.Compositions.Find(id);
            db.Photos.RemoveRange(composition.Photos);
            db.Compositions.Remove(composition);

            buttonDelete.Enabled = false;

            await db.SaveChangesAsync();

            buttonDelete.Enabled = true;

            CallGridView_SelectionChanged();
            MessageBox.Show("Composition have been Deleted");

        }
        #endregion
    }
}
