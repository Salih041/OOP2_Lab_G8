using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace INclass5
{
    public partial class Form1 : Form
    {
        private Button[,] buttons;
        private int gridSize = 4;
        private int moves = 0;
        private int timeElapsed = 0;
        List<string> scores = new List<string>();
        private Image lastImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbGridSize.Items.Clear();
            cmbImages.Items.Clear();

            cmbGridSize.Items.AddRange(new string[] { "2x2", "3x3", "4x4", "5x5" });
            cmbImages.Items.AddRange(new string[] { "fish", "fungus", "tulip" });

            cmbGridSize.SelectedIndex = 2;
            cmbImages.SelectedIndex = 0;   

            pictureBoxPreview.Image = Properties.Resources.fish;
        }

        private void cmbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImages.SelectedIndex == 0) pictureBoxPreview.Image = Properties.Resources.fish;
            else if (cmbImages.SelectedIndex == 1) pictureBoxPreview.Image = Properties.Resources.fungus;
            else if (cmbImages.SelectedIndex == 2) pictureBoxPreview.Image = Properties.Resources.tulip;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gridSize = cmbGridSize.SelectedIndex + 2;
            moves = 0;
            timeElapsed = 0;
            lblMoves.Text = "Hamle: " + moves;
            lblTime.Text = "Süre: 00:00";

            timer1.Interval = 1000;
            timer1.Stop();
            timer1.Start();

            int fixedSize = 100;

            // Paneli yeni ızgara boyutuna göre genişletir
            pnlGameGrid.Width = gridSize * fixedSize;
            pnlGameGrid.Height = gridSize * fixedSize;

            CreateButtons(gridSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
            lblTime.Text = "Süre: " + time.ToString(@"mm\:ss");
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return b;
        }

        // Verilen resimden, belirtilen konum ve boyutta bir parça kesmek için
        private Image CropImage(Image mainImage, int width, int height, int x, int y)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(mainImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            }
            return bmp;
        }

        private void CreateButtons(int size)
        {
            pnlGameGrid.Controls.Clear();
            buttons = new Button[size, size];

            Image originalImage = Properties.Resources.fish; // default resim fish
            if (cmbImages.SelectedIndex == 1) originalImage = Properties.Resources.fungus;
            if (cmbImages.SelectedIndex == 2) originalImage = Properties.Resources.tulip;

            Image scaledImage = ResizeImage(originalImage, pnlGameGrid.Width, pnlGameGrid.Height);

            int pieceWidth = pnlGameGrid.Width / size;
            int pieceHeight = pnlGameGrid.Height / size;
            int counter = 1;

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Button btn = new Button
                    {
                        Width = pieceWidth,
                        Height = pieceHeight,
                        Location = new Point(c * pieceWidth, r * pieceHeight),
                        FlatStyle = FlatStyle.Flat,
                        Margin = new Padding(0),
                        Padding = new Padding(0)
                    };

                    if (r == size - 1 && c == size - 1)
                    {
                        lastImage = CropImage(scaledImage, pieceWidth, pieceHeight, c * pieceWidth, r * pieceHeight);
                        btn.Image = null;
                        btn.Visible = false; // Boşluk karesi
                        btn.Tag = size * size;
                    }
                    else
                    {
                        btn.Image = CropImage(scaledImage, pieceWidth, pieceHeight, c * pieceWidth, r * pieceHeight);
                        btn.Tag = counter++;
                    }

                    btn.Click += Button_Click;

                    buttons[r, c] = btn;
                    pnlGameGrid.Controls.Add(btn);
                }
            }
            ShuffleBoard();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            int r1 = -1, c1 = -1, r2 = -1, c2 = -1;
            Button blankBtn = null;

            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (buttons[r, c] == clickedBtn) { r1 = r; c1 = c; }
                    if (!buttons[r, c].Visible) { r2 = r; c2 = c; blankBtn = buttons[r, c]; }
                }
            }

            // Seçilen buton boşluk butonuna komşu mu kontrolü
            if (Math.Abs(r1 - r2) + Math.Abs(c1 - c2) == 1)
            {
                SwapButtons(clickedBtn, blankBtn);
                moves++;
                lblMoves.Text = "Hamle: " + moves;
                CheckWin();
            }
        }

        // İki butonun özelliklerini birbirleriyle değiştirir
        private void SwapButtons(Button b1, Button b2)
        {
            Image tempImg = b1.Image; b1.Image = b2.Image; b2.Image = tempImg;
            object tempTag = b1.Tag; b1.Tag = b2.Tag; b2.Tag = tempTag;
            bool tempVis = b1.Visible; b1.Visible = b2.Visible; b2.Visible = tempVis;
        }

        private void ShuffleBoard()
        { 
            //karıştırma fonksiyonu

            Random rnd = new Random();
            int blankR = gridSize - 1;
            int blankC = gridSize - 1; 

            for (int i = 0; i < 150; i++)
            {
                int direction = rnd.Next(4); // 0: yukarı, 1: aşağı, 2: sol, 3: sağ
                int targetR = blankR + (direction == 0 ? -1 : (direction == 1 ? 1 : 0));
                int targetC = blankC + (direction == 2 ? -1 : (direction == 3 ? 1 : 0));

                if (targetR >= 0 && targetR < gridSize && targetC >= 0 && targetC < gridSize)
                {
                    SwapButtons(buttons[blankR, blankC], buttons[targetR, targetC]);
                    blankR = targetR;
                    blankC = targetC;
                }
            }

            // random karelerden sonra boşluğu sağ alt köşeye götürme
            while (blankR < gridSize - 1)
            {
                SwapButtons(buttons[blankR, blankC], buttons[blankR + 1, blankC]);
                blankR++;
            }
            while (blankC < gridSize - 1)
            {
                SwapButtons(buttons[blankR, blankC], buttons[blankR, blankC + 1]);
                blankC++;
            }
        }

        private void CheckWin()
        {
            int expectedTag = 1;
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (Convert.ToInt32(buttons[r, c].Tag) != expectedTag)
                        return;
                    expectedTag++;
                }
            }

            // kazanıldığında süre durur, skor kaydedilri
            timer1.Stop();
            buttons[gridSize - 1, gridSize - 1].Image = lastImage;
            buttons[gridSize - 1, gridSize - 1].Visible = true;

            string timeString = lblTime.Text.Split(' ')[1];

            string scoreEntry = $"{gridSize}x{gridSize} Modu | Hamle: {moves} | Süre: {timeString}";
            scores.Add(scoreEntry);

            MessageBox.Show($"Oyunu {moves} hamlede ve {timeString} sürede bitirdiniz.", "Kazandınız!");
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            if (scores.Count == 0)
            {
                MessageBox.Show("Kayıtlı Skor Yok!", "Yüksek Skorlar");
                return;
            }

            // Listedeki tüm skorları birleştirir
            string allScores = string.Join("\n", scores);
            MessageBox.Show("--- OYNANAN OYUNLAR ---\n\n" + allScores, "Yüksek Skorlar");
        }

        private void btnShowSolution_Click(object sender, EventArgs e)
        {
            if (buttons == null) return; // Oyun başlamadıysa hiçbir şey yapma

            timer1.Stop(); 

            // Tüm parçaları doğru sıraya yerleştirir
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    int expectedTag = r * gridSize + c + 1;
                    Button targetBtn = FindButtonByTag(expectedTag);

                    if (targetBtn != null && targetBtn != buttons[r, c])
                    {
                        SwapButtons(buttons[r, c], targetBtn);
                    }
                }
            }
            buttons[gridSize - 1, gridSize - 1].Image = lastImage;
            buttons[gridSize - 1, gridSize - 1].Visible = true; // boşluğa son parçayı ekler
            MessageBox.Show("Çözüm gösterildi.", "Çözüm Gösterildi");
        }

        // Verilen tag değerine sahip butonu bulur
        private Button FindButtonByTag(int tag)
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (Convert.ToInt32(buttons[r, c].Tag) == tag)
                        return buttons[r, c];
                }
            }
            return null;
        }
    }
}