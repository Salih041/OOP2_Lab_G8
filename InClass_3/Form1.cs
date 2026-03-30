using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prelab_3
{
    public partial class Form1 : Form
    {
        DateTime currentTime;
        Color dayColor = Color.Black;
        int currentOffset = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime = currentTime.AddSeconds(1);
            DateTime displayTime = currentTime.AddHours(currentOffset);

            LabelMain.Text = currentTime.ToString("HH:mm:ss");
            dateTimePicker1.Text = displayTime.ToString("HH:mm:ss");

            //Saat 08:00 ile 20:00 arasındaysa kullanıcının seçtiği renk, değilse Yeşil oluyor CurrentTime
            if (currentTime.Hour >= 8 && currentTime.Hour < 20)
            {
                LabelMain.ForeColor = dayColor;
            }
            else
            {
                LabelMain.ForeColor = Color.Green;
            }
        }


        private void ButtonColor_Click(object sender, EventArgs e)
        {
            // Kullanıcının seçtiği rengi dayColor değişkenine atar
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                dayColor = colorDialog1.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentTime = DateTime.Now;
            LabelMain.Text = currentTime.ToString("HH:mm:ss");
            dateTimePicker1.Value = currentTime;
            timer1.Start();

            // Default olarak 3 bölge ekledik
            TimeZoneItem default1 = new TimeZoneItem();
            TimeZoneItem default2 = new TimeZoneItem();
            TimeZoneItem default3 = new TimeZoneItem();
            default1.Name = "İstanbul"; default1.Offset = 0;
            default2.Name = "London"; default2.Offset = -3;
            default3.Name = "Tokyo"; default3.Offset = 6;
            checkedListBox1.Items.Add(default1); checkedListBox1.Items.Add(default2);
            comboBox1.Items.Add(default1); comboBox1.Items.Add(default2);
            checkedListBox1.Items.Add(default3); comboBox1.Items.Add(default3);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            LblErr.Text = "";
            // Kullanıcının girdiği değerleri kontrol eder 
            int offset;
            if (int.TryParse(TBTZOffset.Text, out offset) == false)
            {
                LblErr.Text = "Lütfen geçerli bir sayı giriniz!";
                LblErr.ForeColor = Color.Red;
                LblErr.Visible = true;
                return;
            }

            if (offset < -12 || offset > 14)
            {
                LblErr.Text = "Lütfen -12 ile +14 arasında bir sayı giriniz!";
                LblErr.ForeColor = Color.Red;
                LblErr.Visible = true;
                return;
            }

            // TimeZoneItem oluşturmak için bölge isminin boş olup olmadığını kontrol eder
            if (string.IsNullOrWhiteSpace(TBTZName.Text))
            {
                LblErr.Text = "Lütfen bir bölge ismi giriniz!";
                LblErr.ForeColor = Color.Red;
                LblErr.Visible = true;
                return;
            }

            LblErr.Visible = false;


            string name = TBTZName.Text;

            // Yukarıda girilenler geçerli ise yeni bir TimeZoneItem oluşturup listeye ekler
            TimeZoneItem newItem = new TimeZoneItem();
            newItem.Name = name;
            newItem.Offset = offset;

            comboBox1.Items.Add(newItem);
            checkedListBox1.Items.Add(newItem);

            TBTZName.Clear();
            TBTZOffset.Clear();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kullanıcının comboBox1'de seçtiği bölgeye göre currentOffset değerini günceller
            if (comboBox1.SelectedItem != null)
            {
                TimeZoneItem secilenBolge = (TimeZoneItem)comboBox1.SelectedItem;
                currentOffset = secilenBolge.Offset;
            }
            else
            {
                currentOffset = 0;
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            // checkedListBox1'de seçili olan bölge veya bölgeleri siler ve comboBox1'i günceller
            TimeZoneItem currentZone = null;
            if (comboBox1.SelectedItem != null)
            {
                currentZone = (TimeZoneItem)comboBox1.SelectedItem;
            }

            while (checkedListBox1.CheckedItems.Count > 0)
            {
                checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[0]);
            }

            // comboBox güncellenir ve eğer silinen bölge comboBox'da seçili ise currentOffset sıfırlanır
            comboBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                comboBox1.Items.Add(checkedListBox1.Items[i]);
            }

            if (currentZone != null && comboBox1.Items.Contains(currentZone))
            {
                comboBox1.SelectedItem = currentZone;
            }
            else
            {
                currentOffset = 0;
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "";
            }


            TBTZName.Clear();
            TBTZOffset.Clear();
        }

        // checkedListBox1'de seçili olan bölgeyi günceller ve comboBox1'i güncellenir. 
        // Girilen yeni değerlerin geçerli olup olmadığını kontrol eder ve eğer geçerli değilse hata mesajı gösterir.
        private void ButtonUpt_Click(object sender, EventArgs e)
        {
            LblErr.Text = "";

            if (checkedListBox1.SelectedIndex == -1)
            {
                LblErr.Text = "Güncellemek için bir öğe seçmelisiniz!";
                LblErr.ForeColor = Color.Red;
                LblErr.Visible = true;
                return;
            }

            int offset;
            if (int.TryParse(TBTZOffset.Text, out offset) == false)
            {
                LblErr.Text = "Lütfen geçerli bir sayı giriniz!";
                LblErr.ForeColor = Color.Red;
                LblErr.Visible = true;
                return;
            }

            if (offset < -12 || offset > 14)
            {
                LblErr.Text = "Lütfen -12 ile +14 arasında bir sayı giriniz!";
                LblErr.ForeColor = Color.Red;
                LblErr.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(TBTZName.Text))
            {
                LblErr.Text = "Lütfen bir bölge ismi giriniz!";
                LblErr.ForeColor = Color.Red;
                LblErr.Visible = true;
                return;
            }
            // Güncelleme işlemi yapılırken güncellenen bölge comboBox1'de seçili ise güncelleme sonrası da seçili kalmasını sağlar
            bool currentTime = (comboBox1.SelectedItem == checkedListBox1.SelectedItem);

            // checkedListBox1'de seçili olan bölge güncellenir
            TimeZoneItem guncellenecekItem = (TimeZoneItem)checkedListBox1.SelectedItem;
            guncellenecekItem.Name = TBTZName.Text;
            guncellenecekItem.Offset = offset;

            // checkedListBox1'de seçili olan bölge güncellendikten sonra listede aynı konumda kalması sağlanır
            int listIndex = checkedListBox1.SelectedIndex;
            checkedListBox1.Items.RemoveAt(listIndex);
            checkedListBox1.Items.Insert(listIndex, guncellenecekItem);

            comboBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                comboBox1.Items.Add(checkedListBox1.Items[i]);
            }

            if (currentTime)
            {
                comboBox1.SelectedItem = guncellenecekItem;
            }

            TBTZName.Clear();
            TBTZOffset.Clear();
        }

        // checkedListBox1'deki öğelerin seçili sayısı kontrol edilir
        // Birden fazla veya hiç seçili yoksa Güncelle butonu devre dışı kalır
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int checkedCount = checkedListBox1.CheckedItems.Count;
            if (e.NewValue == CheckState.Checked)
            {
                checkedCount++;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                checkedCount--;
            }

            if (checkedCount > 1 || checkedCount == 0)
            {
                ButtonUpt.Enabled = false;
            }
            else
            {
                ButtonUpt.Enabled = true;
            }
        }

        public class TimeZoneItem
        {
            public string Name { get; set; }
            public int Offset { get; set; }
            public override string ToString()
            {
                string isaret = Offset >= 0 ? "+" : "";
                return Name + " (TR " + isaret + Offset + ")";
            }
        }

    }
}
