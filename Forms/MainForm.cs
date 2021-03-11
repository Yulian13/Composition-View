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

        int PastDataRowIndex = -1;
        int NowId
        {
            get
            {
                if (dataGridViewComposition.Rows.Count == 0 || dataGridViewComposition.SelectedRows.Count < 1)
                    return -1;

                int index = dataGridViewComposition.SelectedRows[idDataGridViewTextBoxColumn.Index].Index;
                if (index == PastDataRowIndex)
                    return -1;
                else
                    PastDataRowIndex = index;

                int id = 0;
                bool converted = Int32.TryParse(dataGridViewComposition[idDataGridViewTextBoxColumn.Index, index].Value.ToString(), out id);
                if (converted == false)
                    return -1;

                return id;
            }
        }

        bool RightKey { get; set; }
        private string Key;

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

        private void CallGridView_SelectionChanged(object sender = null, EventArgs e = null) => dataGridView_SelectionChanged(sender, e);
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int id = NowId;
            if (id < 0)
                return;

            try
            {
                Composition composition = db.Compositions.Find(id);
                labelNameComposistion.Text = Librari.DeShifrovka(composition.Name, Key);

                NewImage image = new NewImage(db.Photos.Find(composition.IdFirstPhoto));
                image.DeShifrovkaImage(Key);
                pictureBox1.Image = image.image;
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

        private void CallInputKey(object sender = null, EventArgs e = null) => changeKeyToolStripMenuItem_Click(sender, e);
        private void changeKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Input_Key input = new Input_Key())
            {
                input.ShowDialog();
                this.Key = new string(input.GetText.ToCharArray());
            }

            buttonAdd.Enabled = !String.IsNullOrWhiteSpace(this.Key);

            if (sender != null & e != null)
                CallGridView_SelectionChanged();

            for (int i = 0; i < dataGridViewComposition.Rows.Count; i++)
            {
                string origName = dataGridViewComposition[nameDataGridViewTextBoxColumn.Index, i].Value.ToString();
                dataGridViewComposition[OrigNameDataGridViewTextBoxColumn.Index, i].Value = Librari.DeShifrovka(origName, Key);
            }
        }

        private void resetKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Key = null;
            pictureBox1.Image = null;
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
                            Key);
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
    }
}
