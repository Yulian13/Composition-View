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
    partial class Input_Key : Form
    {
        public string GetText => maskedTextBox1.Text;

        public Input_Key()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length > 0 || label1.ForeColor == Color.Red)
                this.DialogResult = DialogResult.OK;
            else
                label1.ForeColor = Color.Red;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                buttonOK_Click(buttonOK, null);
        }
    }
}
