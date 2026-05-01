using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;

namespace InClass6
{
    public partial class Form1 : Form
    {
        int score = 0;
        int timeElapsed = 0;
        int matchedPairs = 0;
        int totalPairs = 0;
        int gridSize = 4;

        Button firstClicked = null;
        Button secondClicked = null;

        List<CardData> deck = new List<CardData>();
        List<Image> originalImages = new List<Image>();
        Image crossImage;


        public Form1()
        {
            InitializeComponent();
        }

        class CardData
        {
            public int ImageId { get; set; }
            public bool IsGray { get; set; }
            public Image DisplayImg { get; set; }
            public bool IsWildcard { get; set; }
        }


        private void btnLoadImages_Click(object sender, EventArgs e)
        {
            
            if (comboBoxGridSize.SelectedIndex == -1) // combobox boşsa izin verme
            {
                MessageBox.Show("Önce bir oyun boyutu seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Grid boyutunu ve gereken resim saysı
            gridSize = comboBoxGridSize.SelectedIndex == 0 ? 3 : 4;
            int requiredImages = (gridSize == 3) ? 4 : 8;

            OpenFileDialog ofd = new OpenFileDialog();

            // Başlangıç klasörünü ayarlama
            string projeAnaDizini = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\"));
            string propertiesKlasoru = System.IO.Path.Combine(projeAnaDizini, "Properties\\pictures2");

            if (System.IO.Directory.Exists(propertiesKlasoru))
            {
                ofd.InitialDirectory = propertiesKlasoru;
            }
            else
            {
                ofd.InitialDirectory = Application.StartupPath;
            }

            ofd.Multiselect = true;
            ofd.Title = $"Lütfen {requiredImages} adet resim seçin (Cross resmi hariç!)";
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Sayı kontrolü
                if (ofd.FileNames.Length != requiredImages)
                {
                    MessageBox.Show($"Hatalı seçim! Bu mod için {requiredImages} adet resim seçmelisiniz.");
                    return;
                }

                // Cross image seçildiyse izin verme
                foreach (string dosyaAdi in ofd.SafeFileNames)
                {
                    if (dosyaAdi.ToLower().Contains("cross"))
                    {
                        MessageBox.Show("Hata! Çarpı (cross) resmini seçmemelisiniz.");
                        return;
                    }
                }

                originalImages.Clear();

                try
                {
                    // seçilen resimleri listeye ekleme
                    foreach (string dosyaYolu in ofd.FileNames)
                    {
                        originalImages.Add(Image.FromFile(dosyaYolu));
                    }

                    MessageBox.Show("Resimler başarıyla yüklendi. Oyuna başlayabilirsiniz!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resimler eklenemedi! " + ex.Message);
                }
            }
        }


        private void PrepareDeck()
        {
            deck.Clear();

            for (int i = 0; i < originalImages.Count; i++)
            {
                // Renkli kart
                deck.Add(new CardData { ImageId = i, IsGray = false, DisplayImg = originalImages[i], IsWildcard = false });

                // Gri kart
                Bitmap grayBmp = ConvertToGrayscale(new Bitmap(originalImages[i]));
                deck.Add(new CardData { ImageId = i, IsGray = true, DisplayImg = grayBmp, IsWildcard = false });
            }

            // 3x3 seçildiyse 9. kart cross olacak
            if (gridSize == 3)
            {
                deck.Add(new CardData { ImageId = 99, IsGray = false, DisplayImg = crossImage, IsWildcard = true });
            }

            // Kartları karıştır
            Random rnd = new Random();
            deck = deck.OrderBy(x => rnd.Next()).ToList();
        }

        private void CreateDynamicGrid()
        {
            // önce temizle
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            tableLayoutPanel1.RowCount = gridSize;
            tableLayoutPanel1.ColumnCount = gridSize;

            for (int i = 0; i < gridSize; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
            }

            for (int i = 0; i < deck.Count; i++) // her bir kart için buton oluşturma
            {
                Button btnCard = new Button();
                btnCard.Dock = DockStyle.Fill;
                btnCard.Tag = deck[i];
                btnCard.BackgroundImageLayout = ImageLayout.Stretch; // Büyük resimleri butona sığdırmak için
                btnCard.Click += Card_Click;

                tableLayoutPanel1.Controls.Add(btnCard);
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (originalImages.Count == 0)
            {
                MessageBox.Show("Önce resimleri yükleyin!");
                return;
            }

            crossImage = Properties.Resources.cross;

            score = 0;
            timeElapsed = 0;
            matchedPairs = 0;
            totalPairs = originalImages.Count;
            UpdateLabels();

            PrepareDeck();
            CreateDynamicGrid();

            timerGame.Start();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            // Eğer timerFlip çalışıyorsa bekleme anındaysak tıklamaları yoksay
            if (timerFlip.Enabled) return;

            Button clickedBtn = sender as Button;
            CardData cardInfo = clickedBtn.Tag as CardData;

            // Zaten açılmış karta tıklanmasını engelle
            if (clickedBtn.BackgroundImage != null) return;

            // Cross durumu
            if (cardInfo.IsWildcard)
            {
                clickedBtn.BackgroundImage = cardInfo.DisplayImg;
                score -= 50; // -50 puan
                timeElapsed += 60; // +1 dakika ceza
                UpdateLabels();
                MessageBox.Show("-50 Puan ve +1 Dakika ceza.");
                clickedBtn.BackgroundImage = null; // cross kartını geri kapatma
                return;
            }

            // Resmi göster
            clickedBtn.BackgroundImage = cardInfo.DisplayImg;

            if (firstClicked == null)
            {
                firstClicked = clickedBtn;
                return;
            }

            secondClicked = clickedBtn;
            CheckForMatch();
        }

        private void CheckForMatch()
        {
            CardData firstData = firstClicked.Tag as CardData;
            CardData secondData = secondClicked.Tag as CardData;

            // Biri renkli, biri gri olmalı VE ID'leri aynı olmalı
            if (firstData.ImageId == secondData.ImageId && firstData.IsGray != secondData.IsGray)
            {
                // Eşleşme başarılı
                score += 100;
                matchedPairs++;
                UpdateLabels();

                firstClicked = null;
                secondClicked = null;

                if (matchedPairs == totalPairs)
                {
                    timerGame.Stop();

                    if(gridSize==3)
                    {
                        foreach (Control ctrl in tableLayoutPanel1.Controls)
                        {
                            Button btn = ctrl as Button;
                            CardData data = btn?.Tag as CardData;
                            if (data != null && data.IsWildcard)
                            {
                                btn.BackgroundImage = data.DisplayImg; // Cross kartını aç
                                break;
                            }
                            
                        }
                    }

                    MessageBox.Show($"Oyun Bitti! Skorunuz: {score}, Süre: {timeElapsed}s");

                }
            }
            else //Eşleşmediyse
            {
              
                score -= 10; // Yanlış tahmin cezası
                UpdateLabels();
                timerFlip.Start();
            }
        }



        private Bitmap ConvertToGrayscale(Bitmap original) // Resmi grileştiren fonksyion
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color originalColor = original.GetPixel(x, y);

                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));

                    Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    newBitmap.SetPixel(x, y, grayColor);
                }
            }
            return newBitmap;
        }

        // Hata durumunda kartları geri kapatan fonksiyon
        private void timerFlip_Tick(object sender, EventArgs e)
        {
            timerFlip.Stop();

            if (firstClicked != null) firstClicked.BackgroundImage = null;
            if (secondClicked != null) secondClicked.BackgroundImage = null;

            firstClicked = null;
            secondClicked = null;
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lblScore.Text = $"Score: {score} pts";

            TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
            lblTime.Text = $"Time: {time.ToString(@"mm\:ss")}";

            lblMatches.Text = $"Matches: {matchedPairs}/{totalPairs}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}