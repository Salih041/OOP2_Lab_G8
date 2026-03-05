using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();
            TasarimAyarlari();
        }

        private void TasarimAyarlari()
        {
            btnShowName.Cursor = Cursors.Hand;
            btnSwap.Cursor = Cursors.Hand;
            btnColor.Cursor = Cursors.Hand;
            btnSize.Cursor = Cursors.Hand;

            txtName.Enter += TxtName_Enter;
            txtName.Leave += TxtName_Leave;

            txtSurname.Enter += TxtSurname_Enter;
            txtSurname.Leave += TxtSurname_Leave;

            lbl.Text = "";
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Name";
                txtName.ForeColor = Color.Gray;
            }
        }

        private void TxtSurname_Enter(object sender, EventArgs e)
        {
            if (txtSurname.Text == "Surname")
            {
                txtSurname.Text = "";
                txtSurname.ForeColor = Color.Black;
            }
        }

        private void TxtSurname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.Text = "Surname";
                txtSurname.ForeColor = Color.Gray;
            }
        }

        private void btnShowName_Click(object sender, EventArgs e)
        {
            lbl.Text = txtName.Text + " " + txtSurname.Text;
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string temp = txtName.Text;

            txtName.Text = txtSurname.Text;

            txtSurname.Text = temp;

            lbl.Text = txtName.Text + " " + txtSurname.Text;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            switch (counter)
            {
                case 0:
                    lbl.ForeColor = Color.Blue;
                    break;
                case 1:
                    lbl.ForeColor = Color.Black;
                    break;
                case 2:
                    lbl.ForeColor = Color.Pink;
                    break;
                case 3:
                    lbl.ForeColor = Color.Orange;
                    break;
            }

            counter = (counter + 1) % 4;
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            if (lbl.Font.Size == 15)
            {
                lbl.Font = new Font(lbl.Font.FontFamily, 9, lbl.Font.Style);
            }
            else
            {
                lbl.Font = new Font(lbl.Font.FontFamily, 15, lbl.Font.Style);
            }
        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
