
namespace Composition_View.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewComposition = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNameComposistion = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkBoxDecryption = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.OrigNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resetKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberPhotosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compositionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComposition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compositionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewComposition
            // 
            this.dataGridViewComposition.AllowUserToAddRows = false;
            this.dataGridViewComposition.AllowUserToDeleteRows = false;
            this.dataGridViewComposition.AllowUserToResizeRows = false;
            this.dataGridViewComposition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewComposition.AutoGenerateColumns = false;
            this.dataGridViewComposition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewComposition.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewComposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComposition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.OrigNameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.numberPhotosDataGridViewTextBoxColumn});
            this.dataGridViewComposition.DataSource = this.compositionBindingSource;
            this.dataGridViewComposition.Location = new System.Drawing.Point(369, 156);
            this.dataGridViewComposition.Name = "dataGridViewComposition";
            this.dataGridViewComposition.ReadOnly = true;
            this.dataGridViewComposition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewComposition.Size = new System.Drawing.Size(282, 432);
            this.dataGridViewComposition.TabIndex = 10;
            this.dataGridViewComposition.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Location = new System.Drawing.Point(13, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 521);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(663, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeKeyToolStripMenuItem,
            this.resetKeyToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripDropDownButton1.Text = "options";
            // 
            // changeKeyToolStripMenuItem
            // 
            this.changeKeyToolStripMenuItem.Name = "changeKeyToolStripMenuItem";
            this.changeKeyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeKeyToolStripMenuItem.Text = "Change Key";
            this.changeKeyToolStripMenuItem.Click += new System.EventHandler(this.changeKeyToolStripMenuItem_Click);
            // 
            // labelNameComposistion
            // 
            this.labelNameComposistion.AutoSize = true;
            this.labelNameComposistion.Location = new System.Drawing.Point(10, 38);
            this.labelNameComposistion.Name = "labelNameComposistion";
            this.labelNameComposistion.Size = new System.Drawing.Size(35, 13);
            this.labelNameComposistion.TabIndex = 13;
            this.labelNameComposistion.Text = "label1";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(369, 127);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(125, 23);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxDecryption
            // 
            this.checkBoxDecryption.AutoSize = true;
            this.checkBoxDecryption.Location = new System.Drawing.Point(500, 133);
            this.checkBoxDecryption.Name = "checkBoxDecryption";
            this.checkBoxDecryption.Size = new System.Drawing.Size(75, 17);
            this.checkBoxDecryption.TabIndex = 15;
            this.checkBoxDecryption.Text = "decryption";
            this.checkBoxDecryption.UseVisualStyleBackColor = true;
            this.checkBoxDecryption.CheckedChanged += new System.EventHandler(this.checkBoxDecryption_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(500, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(500, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // OrigNameDataGridViewTextBoxColumn
            // 
            this.OrigNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.OrigNameDataGridViewTextBoxColumn.Name = "OrigNameDataGridViewTextBoxColumn";
            this.OrigNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.OrigNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // resetKeyToolStripMenuItem
            // 
            this.resetKeyToolStripMenuItem.Name = "resetKeyToolStripMenuItem";
            this.resetKeyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetKeyToolStripMenuItem.Text = "Reset Key";
            this.resetKeyToolStripMenuItem.Click += new System.EventHandler(this.resetKeyToolStripMenuItem_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.FillWeight = 35F;
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 35;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberPhotosDataGridViewTextBoxColumn
            // 
            this.numberPhotosDataGridViewTextBoxColumn.DataPropertyName = "NumberPhotos";
            this.numberPhotosDataGridViewTextBoxColumn.FillWeight = 25F;
            this.numberPhotosDataGridViewTextBoxColumn.HeaderText = "Count";
            this.numberPhotosDataGridViewTextBoxColumn.MinimumWidth = 40;
            this.numberPhotosDataGridViewTextBoxColumn.Name = "numberPhotosDataGridViewTextBoxColumn";
            this.numberPhotosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // compositionBindingSource
            // 
            this.compositionBindingSource.DataSource = typeof(Composition_View.SQL_Class.Composition);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 600);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxDecryption);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelNameComposistion);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewComposition);
            this.MinimumSize = new System.Drawing.Size(650, 300);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComposition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compositionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewComposition;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource compositionBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label labelNameComposistion;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ToolStripMenuItem changeKeyToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxDecryption;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrigNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberPhotosDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem resetKeyToolStripMenuItem;
    }
}

