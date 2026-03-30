namespace prelab_3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LabelMain = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ButtonColor = new System.Windows.Forms.Button();
            this.TBTZName = new System.Windows.Forms.TextBox();
            this.TZNameLabel = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.TBTZOffset = new System.Windows.Forms.TextBox();
            this.TZOffsetLabel = new System.Windows.Forms.Label();
            this.LblErr = new System.Windows.Forms.Label();
            this.ButtonUpt = new System.Windows.Forms.Button();
            this.SelectZoneLb = new System.Windows.Forms.Label();
            this.Current = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelMain
            // 
            this.LabelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelMain.Location = new System.Drawing.Point(81, 438);
            this.LabelMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(221, 52);
            this.LabelMain.TabIndex = 0;
            this.LabelMain.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(575, 67);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(516, 100);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(45, 237);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(286, 109);
            this.checkedListBox1.TabIndex = 3;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // ButtonColor
            // 
            this.ButtonColor.BackColor = System.Drawing.Color.DeepPink;
            this.ButtonColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonColor.Location = new System.Drawing.Point(40, 182);
            this.ButtonColor.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonColor.Name = "ButtonColor";
            this.ButtonColor.Size = new System.Drawing.Size(291, 30);
            this.ButtonColor.TabIndex = 4;
            this.ButtonColor.Text = "Renk Seç (08:00-20:00)";
            this.ButtonColor.UseVisualStyleBackColor = false;
            this.ButtonColor.Click += new System.EventHandler(this.ButtonColor_Click);
            // 
            // TBTZName
            // 
            this.TBTZName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TBTZName.Location = new System.Drawing.Point(40, 67);
            this.TBTZName.Margin = new System.Windows.Forms.Padding(2);
            this.TBTZName.Name = "TBTZName";
            this.TBTZName.Size = new System.Drawing.Size(132, 22);
            this.TBTZName.TabIndex = 5;
            // 
            // TZNameLabel
            // 
            this.TZNameLabel.BackColor = System.Drawing.Color.LightGreen;
            this.TZNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TZNameLabel.Location = new System.Drawing.Point(40, 36);
            this.TZNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TZNameLabel.Name = "TZNameLabel";
            this.TZNameLabel.Size = new System.Drawing.Size(132, 22);
            this.TZNameLabel.TabIndex = 6;
            this.TZNameLabel.Text = "Timezone Name";
            this.TZNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonAdd.Location = new System.Drawing.Point(44, 139);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(107, 25);
            this.ButtonAdd.TabIndex = 7;
            this.ButtonAdd.Text = "Ekle";
            this.ButtonAdd.UseVisualStyleBackColor = false;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.ButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonDelete.Location = new System.Drawing.Point(129, 360);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(117, 25);
            this.ButtonDelete.TabIndex = 7;
            this.ButtonDelete.Text = "Sil";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // TBTZOffset
            // 
            this.TBTZOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TBTZOffset.Location = new System.Drawing.Point(199, 67);
            this.TBTZOffset.Margin = new System.Windows.Forms.Padding(2);
            this.TBTZOffset.Name = "TBTZOffset";
            this.TBTZOffset.Size = new System.Drawing.Size(132, 22);
            this.TBTZOffset.TabIndex = 9;
            // 
            // TZOffsetLabel
            // 
            this.TZOffsetLabel.BackColor = System.Drawing.Color.LightGreen;
            this.TZOffsetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TZOffsetLabel.Location = new System.Drawing.Point(199, 36);
            this.TZOffsetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TZOffsetLabel.Name = "TZOffsetLabel";
            this.TZOffsetLabel.Size = new System.Drawing.Size(132, 22);
            this.TZOffsetLabel.TabIndex = 10;
            this.TZOffsetLabel.Text = "Offset";
            this.TZOffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblErr
            // 
            this.LblErr.AutoSize = true;
            this.LblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblErr.Location = new System.Drawing.Point(41, 104);
            this.LblErr.Name = "LblErr";
            this.LblErr.Size = new System.Drawing.Size(0, 18);
            this.LblErr.TabIndex = 11;
            // 
            // ButtonUpt
            // 
            this.ButtonUpt.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ButtonUpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonUpt.Location = new System.Drawing.Point(216, 139);
            this.ButtonUpt.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonUpt.Name = "ButtonUpt";
            this.ButtonUpt.Size = new System.Drawing.Size(103, 25);
            this.ButtonUpt.TabIndex = 7;
            this.ButtonUpt.Text = "Güncelle";
            this.ButtonUpt.UseVisualStyleBackColor = false;
            this.ButtonUpt.Click += new System.EventHandler(this.ButtonUpt_Click);
            // 
            // SelectZoneLb
            // 
            this.SelectZoneLb.BackColor = System.Drawing.Color.LightGreen;
            this.SelectZoneLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SelectZoneLb.Location = new System.Drawing.Point(543, 36);
            this.SelectZoneLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelectZoneLb.Name = "SelectZoneLb";
            this.SelectZoneLb.Size = new System.Drawing.Size(160, 22);
            this.SelectZoneLb.TabIndex = 13;
            this.SelectZoneLb.Text = "Selected Time Zone";
            this.SelectZoneLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Current
            // 
            this.Current.BackColor = System.Drawing.Color.LightGreen;
            this.Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Current.Location = new System.Drawing.Point(109, 416);
            this.Current.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(160, 22);
            this.Current.TabIndex = 14;
            this.Current.Text = "Current Time";
            this.Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::prelab_3.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(802, 520);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.SelectZoneLb);
            this.Controls.Add(this.ButtonUpt);
            this.Controls.Add(this.LblErr);
            this.Controls.Add(this.TZOffsetLabel);
            this.Controls.Add(this.TBTZOffset);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.TZNameLabel);
            this.Controls.Add(this.TBTZName);
            this.Controls.Add(this.ButtonColor);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.LabelMain);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button ButtonColor;
        private System.Windows.Forms.TextBox TBTZName;
        private System.Windows.Forms.Label TZNameLabel;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.TextBox TBTZOffset;
        private System.Windows.Forms.Label TZOffsetLabel;
        private System.Windows.Forms.Label LblErr;
        private System.Windows.Forms.Button ButtonUpt;
        private System.Windows.Forms.Label SelectZoneLb;
        private System.Windows.Forms.Label Current;
    }
}

