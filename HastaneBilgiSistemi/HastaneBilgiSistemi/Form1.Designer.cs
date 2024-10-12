namespace HastaneBilgiSistemi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxDoktor = new ComboBox();
            comboBoxBolum = new ComboBox();
            buttonrandevu = new Button();
            comboBoxsaatler = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBoxAdi = new TextBox();
            textBoxSoyadi = new TextBox();
            textBoxtc = new TextBox();
            buttonRandevuGoruntule = new Button();
            listBoxRandevu = new ListBox();
            buttonHastaKaydi = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(317, 25);
            label1.Name = "label1";
            label1.Size = new Size(193, 25);
            label1.TabIndex = 0;
            label1.Text = "Doktor Randevusu Al";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(490, 124);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 1;
            label2.Text = "Doktor Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(522, 71);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Bölüm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(534, 173);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "Saat";
            // 
            // comboBoxDoktor
            // 
            comboBoxDoktor.FormattingEnabled = true;
            comboBoxDoktor.Items.AddRange(new object[] { "İsmail Sevinç", "Ahmet Cansız", "Suzan Direk", "fatih bal" });
            comboBoxDoktor.Location = new Point(578, 120);
            comboBoxDoktor.Name = "comboBoxDoktor";
            comboBoxDoktor.Size = new Size(151, 28);
            comboBoxDoktor.TabIndex = 5;
            comboBoxDoktor.SelectedIndexChanged += comboBoxDoktor_SelectedIndexChanged;
            // 
            // comboBoxBolum
            // 
            comboBoxBolum.FormattingEnabled = true;
            comboBoxBolum.Location = new Point(578, 68);
            comboBoxBolum.Name = "comboBoxBolum";
            comboBoxBolum.Size = new Size(151, 28);
            comboBoxBolum.TabIndex = 6;
            comboBoxBolum.SelectedIndexChanged += comboBoxBolum_SelectedIndexChanged;
            // 
            // buttonrandevu
            // 
            buttonrandevu.Location = new Point(770, 113);
            buttonrandevu.Name = "buttonrandevu";
            buttonrandevu.Size = new Size(103, 35);
            buttonrandevu.TabIndex = 7;
            buttonrandevu.Text = "Randevu Al";
            buttonrandevu.UseVisualStyleBackColor = true;
            buttonrandevu.Click += button1_Click;
            // 
            // comboBoxsaatler
            // 
            comboBoxsaatler.FormattingEnabled = true;
            comboBoxsaatler.Location = new Point(578, 172);
            comboBoxsaatler.Name = "comboBoxsaatler";
            comboBoxsaatler.Size = new Size(151, 28);
            comboBoxsaatler.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(120, 74);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 9;
            label6.Text = "Adınız";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(98, 124);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 10;
            label7.Text = "Soyadınız";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(16, 173);
            label8.Name = "label8";
            label8.Size = new Size(155, 20);
            label8.TabIndex = 11;
            label8.Text = "TC Kimlik Numaranız";
            // 
            // textBoxAdi
            // 
            textBoxAdi.Location = new Point(177, 71);
            textBoxAdi.Name = "textBoxAdi";
            textBoxAdi.Size = new Size(125, 27);
            textBoxAdi.TabIndex = 12;
            // 
            // textBoxSoyadi
            // 
            textBoxSoyadi.Location = new Point(177, 124);
            textBoxSoyadi.Name = "textBoxSoyadi";
            textBoxSoyadi.Size = new Size(125, 27);
            textBoxSoyadi.TabIndex = 13;
            // 
            // textBoxtc
            // 
            textBoxtc.Location = new Point(177, 173);
            textBoxtc.Name = "textBoxtc";
            textBoxtc.Size = new Size(125, 27);
            textBoxtc.TabIndex = 14;
            // 
            // buttonRandevuGoruntule
            // 
            buttonRandevuGoruntule.Location = new Point(764, 287);
            buttonRandevuGoruntule.Name = "buttonRandevuGoruntule";
            buttonRandevuGoruntule.Size = new Size(109, 53);
            buttonRandevuGoruntule.TabIndex = 15;
            buttonRandevuGoruntule.Text = "Randevuları Görüntüle";
            buttonRandevuGoruntule.UseVisualStyleBackColor = true;
            buttonRandevuGoruntule.Click += button2_Click;
            // 
            // listBoxRandevu
            // 
            listBoxRandevu.FormattingEnabled = true;
            listBoxRandevu.Location = new Point(38, 229);
            listBoxRandevu.Name = "listBoxRandevu";
            listBoxRandevu.Size = new Size(691, 204);
            listBoxRandevu.TabIndex = 16;
            // 
            // buttonHastaKaydi
            // 
            buttonHastaKaydi.Location = new Point(334, 104);
            buttonHastaKaydi.Name = "buttonHastaKaydi";
            buttonHastaKaydi.Size = new Size(109, 53);
            buttonHastaKaydi.TabIndex = 17;
            buttonHastaKaydi.Text = "Yeni Hasta Kaydı";
            buttonHastaKaydi.UseVisualStyleBackColor = true;
            buttonHastaKaydi.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(928, 529);
            Controls.Add(buttonHastaKaydi);
            Controls.Add(listBoxRandevu);
            Controls.Add(buttonRandevuGoruntule);
            Controls.Add(textBoxtc);
            Controls.Add(textBoxSoyadi);
            Controls.Add(textBoxAdi);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBoxsaatler);
            Controls.Add(buttonrandevu);
            Controls.Add(comboBoxBolum);
            Controls.Add(comboBoxDoktor);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxDoktor;
        private ComboBox comboBoxBolum;
        private Button buttonrandevu;
        private ComboBox comboBoxsaatler;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxAdi;
        private TextBox textBoxSoyadi;
        private TextBox textBoxtc;
        private Button buttonRandevuGoruntule;
        private ListBox listBoxRandevu;
        private Button buttonHastaKaydi;
    }
}
