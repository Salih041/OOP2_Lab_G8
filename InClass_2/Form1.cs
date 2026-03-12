using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace prelab_2
{
    public partial class Form1 : Form
    {
        int[] list = new int[0]; // global dinamik array
        public Form1()
        {
            InitializeComponent();
            Input.BringToFront();

        }

        private void Buton_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(Input.Text);

                int sinir = (First10CB.Checked && n > 10) ? 10 : n;

                AvgLabel.Text = "";
                Array.Resize(ref list, sinir);

                //Lucas serisi:
                if (sinir >= 1) list[0] = 2;
                if (sinir >= 2) list[1] = 1;
                for (int i = 2; i < sinir; i++)
                {
                    list[i] = list[i - 1] + list[i - 2];
                }

                ErrLabel.Text = "";
                ListBox.Items.Clear();
                for (int i = 0; i < list.Length; i++)
                {
                    ListBox.Items.Add(list[i]);
                }
                if (AvgCB.Checked)
                {
                    double avg = list.Average();
                    AvgLabel.Text = "Average: " + avg.ToString();
                }
            }
            catch
            {
                ErrLabel.Text = "Please enter a valid number";
            }
        }

        private void AvgCB_CheckedChanged(object sender, EventArgs e)
        {
            if(AvgCB.Checked)
            {
                Buton.Text = "Generate and Calculate";
            }
            else
            {
                Buton.Text = "Generate";
            }
        }

        private void Buton_MouseLeave(object sender, EventArgs e)
        {
            Buton.BackColor = Color.FromArgb(70, 130, 255); 
        }

        private void Buton_MouseEnter(object sender, EventArgs e)
        {
            Buton.BackColor = Color.FromArgb(80, 160, 255); 
        }

        private void First10CB_CheckedChanged(object sender, EventArgs e)
        {
            if (First10CB.Checked)
            {
                Input.Text = "10";
                ErrLabel.Text = ""; 
            }
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {

            if (First10CB.Checked && Input.Text != "10")
            {
                Input.Text = "10";
                Input.SelectionStart = Input.Text.Length;
                ErrLabel.Text = "Değiştirebilmek için 'Calculate only first 10 values' tikini kaldırmalısınız.";
            }

            else if (!First10CB.Checked && ErrLabel.Text.Contains("kaldırmalısınız"))
            {
                ErrLabel.Text = "";
            }
        }
    }
}
