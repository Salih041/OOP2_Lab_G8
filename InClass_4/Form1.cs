using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InClass_4
{
    public partial class Form1 : Form
    {
        List<Rent> siparisler = new List<Rent>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VehicleListBox.Items.Add("Tesla Model Y");
            VehicleListBox.Items.Add("VW Golf 8");
            VehicleListBox.Items.Add("Ford Mustang");
            VehicleListBox.Items.Add("Renault Clio");
            VehicleListBox.Items.Add("Fiat Egea");
            VehicleListBox.Items.Add("Nissan Skyline");
            VehicleListBox.Items.Add("BMW M3");
            VehicleListBox.Items.Add("Mercedes C200");


            PickupCombo.Items.Add("Eskişehir"); PickupCombo.Items.Add("Ankara"); PickupCombo.Items.Add("Bursa");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (VehicleListBox.SelectedItem == null || PickupCombo.SelectedItem == null || ReturnCombo.SelectedItem == null || NameTextBox.Text.Trim() == "" || NoText.Text.Trim() == "")
                {
                    ErrorLabel.Text = "Lütfen tüm alanları doldurun.";
                    return; 
                }
                ErrorLabel.Text = "";
                List<string> extras = new List<string>();
                
                foreach (Control control in groupBox5.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        extras.Add(checkBox.Text);
                    }
                }

                Rent siparis = new Rent(NameTextBox.Text, NoText.Text, VehicleListBox.SelectedItem.ToString(), PickupCombo.SelectedItem.ToString(), ReturnCombo.SelectedItem.ToString(),extras);
                siparisler.Add(siparis);

                string extrasText = "";
                foreach(var item in siparis.extras)
                {
                    extrasText += item + ", ";
                }
                Agreements.Items.Add(siparis.name + " | " + siparis.no + " | " + siparis.car + " | " + siparis.pickup + " | Extras: " + extrasText +" | " + siparis.pickup+ @"\ "+siparis.returnLocation);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PickupCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PickupCombo.SelectedItem.ToString()=="Eskişehir")
            {
                ReturnCombo.Items.Clear();
                ReturnCombo.Items.Add("Tepebaşı");
                ReturnCombo.Items.Add("Odunpazarı");
            }
            else if(PickupCombo.SelectedItem.ToString() == "Ankara")
            {
                ReturnCombo.Items.Clear();
                ReturnCombo.Items.Add("Çankaya");
                ReturnCombo.Items.Add("Kızılay");
            }
            else if (PickupCombo.SelectedItem.ToString() == "Bursa")
            {
                ReturnCombo.Items.Clear();
                ReturnCombo.Items.Add("Osmangazi");
                ReturnCombo.Items.Add("Nilüfer");
            }
        }
    }

    public class Rent
    {
        public string name { get; set; }
        public string no { get; set; }
        public string car { get; set; }
        public string pickup { get; set; }
        public string returnLocation { get; set; }

        public List<string> extras { get; set; }

        public Rent(string name,string no, string car, string p, string r, List<string> extras)
        {
            this.name = name;
            this.no = no;
            this.car = car;
            this.pickup = p;
            this.returnLocation = r;
            this.extras = extras;
        }
    }
}
