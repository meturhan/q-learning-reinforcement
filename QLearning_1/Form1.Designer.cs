namespace QLearning_1
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
            this.Tual = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Nud_OdaSayisi = new System.Windows.Forms.NumericUpDown();
            this.Tb_OgrenmeKatsayisi = new System.Windows.Forms.TextBox();
            this.Btn_OgrenmeyiBaslat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Nud_HedefOda = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.L_Durum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Nud_OgrenmeTurlari = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.Nud_Baslangic = new System.Windows.Forms.NumericUpDown();
            this.Btn_Bul = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Tual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_OdaSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_HedefOda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_OgrenmeTurlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Baslangic)).BeginInit();
            this.SuspendLayout();
            // 
            // Tual
            // 
            this.Tual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tual.Location = new System.Drawing.Point(12, 12);
            this.Tual.Name = "Tual";
            this.Tual.Size = new System.Drawing.Size(500, 500);
            this.Tual.TabIndex = 0;
            this.Tual.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oda Sayısı :";
            // 
            // Nud_OdaSayisi
            // 
            this.Nud_OdaSayisi.Location = new System.Drawing.Point(587, 10);
            this.Nud_OdaSayisi.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.Nud_OdaSayisi.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Nud_OdaSayisi.Name = "Nud_OdaSayisi";
            this.Nud_OdaSayisi.Size = new System.Drawing.Size(120, 20);
            this.Nud_OdaSayisi.TabIndex = 2;
            this.Nud_OdaSayisi.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Nud_OdaSayisi.ValueChanged += new System.EventHandler(this.Nud_OdaSayisi_ValueChanged);
            // 
            // Tb_OgrenmeKatsayisi
            // 
            this.Tb_OgrenmeKatsayisi.Location = new System.Drawing.Point(624, 52);
            this.Tb_OgrenmeKatsayisi.Name = "Tb_OgrenmeKatsayisi";
            this.Tb_OgrenmeKatsayisi.Size = new System.Drawing.Size(100, 20);
            this.Tb_OgrenmeKatsayisi.TabIndex = 3;
            this.Tb_OgrenmeKatsayisi.Text = "0,8";
            // 
            // Btn_OgrenmeyiBaslat
            // 
            this.Btn_OgrenmeyiBaslat.Location = new System.Drawing.Point(522, 119);
            this.Btn_OgrenmeyiBaslat.Name = "Btn_OgrenmeyiBaslat";
            this.Btn_OgrenmeyiBaslat.Size = new System.Drawing.Size(215, 23);
            this.Btn_OgrenmeyiBaslat.TabIndex = 4;
            this.Btn_OgrenmeyiBaslat.Text = "Öğrenmeyi Başlat";
            this.Btn_OgrenmeyiBaslat.UseVisualStyleBackColor = true;
            this.Btn_OgrenmeyiBaslat.Click += new System.EventHandler(this.Btn_OgrenmeyiBaslat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Öğrenme Katsayısı :";
            // 
            // Nud_HedefOda
            // 
            this.Nud_HedefOda.Location = new System.Drawing.Point(587, 93);
            this.Nud_HedefOda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_HedefOda.Name = "Nud_HedefOda";
            this.Nud_HedefOda.Size = new System.Drawing.Size(120, 20);
            this.Nud_HedefOda.TabIndex = 7;
            this.Nud_HedefOda.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Nud_HedefOda.ValueChanged += new System.EventHandler(this.Nud_OdaSayisi_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hedef Oda :";
            // 
            // L_Durum
            // 
            this.L_Durum.AutoSize = true;
            this.L_Durum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.L_Durum.Location = new System.Drawing.Point(518, 155);
            this.L_Durum.Name = "L_Durum";
            this.L_Durum.Size = new System.Drawing.Size(130, 20);
            this.L_Durum.TabIndex = 8;
            this.L_Durum.Text = "Girdi Bekliyor...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 508);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "M.EMRE TURHAN";
            // 
            // Nud_OgrenmeTurlari
            // 
            this.Nud_OgrenmeTurlari.Location = new System.Drawing.Point(617, 194);
            this.Nud_OgrenmeTurlari.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.Nud_OgrenmeTurlari.Name = "Nud_OgrenmeTurlari";
            this.Nud_OgrenmeTurlari.Size = new System.Drawing.Size(120, 20);
            this.Nud_OgrenmeTurlari.TabIndex = 11;
            this.Nud_OgrenmeTurlari.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Öğrenme Turları :";
            // 
            // Nud_Baslangic
            // 
            this.Nud_Baslangic.Location = new System.Drawing.Point(617, 220);
            this.Nud_Baslangic.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.Nud_Baslangic.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_Baslangic.Name = "Nud_Baslangic";
            this.Nud_Baslangic.Size = new System.Drawing.Size(120, 20);
            this.Nud_Baslangic.TabIndex = 13;
            this.Nud_Baslangic.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Btn_Bul
            // 
            this.Btn_Bul.Location = new System.Drawing.Point(522, 246);
            this.Btn_Bul.Name = "Btn_Bul";
            this.Btn_Bul.Size = new System.Drawing.Size(215, 23);
            this.Btn_Bul.TabIndex = 14;
            this.Btn_Bul.Text = "Yolu Göster";
            this.Btn_Bul.UseVisualStyleBackColor = true;
            this.Btn_Bul.Click += new System.EventHandler(this.Btn_Bul_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(522, 275);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(215, 212);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(549, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Başlangıç : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 530);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Btn_Bul);
            this.Controls.Add(this.Nud_Baslangic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Nud_OgrenmeTurlari);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.L_Durum);
            this.Controls.Add(this.Nud_HedefOda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_OgrenmeyiBaslat);
            this.Controls.Add(this.Tb_OgrenmeKatsayisi);
            this.Controls.Add(this.Nud_OdaSayisi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tual);
            this.Name = "Form1";
            this.Text = "QLearning - M.Emre TURHAN";
            ((System.ComponentModel.ISupportInitialize)(this.Tual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_OdaSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_HedefOda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_OgrenmeTurlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Baslangic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Tual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Nud_OdaSayisi;
        private System.Windows.Forms.TextBox Tb_OgrenmeKatsayisi;
        private System.Windows.Forms.Button Btn_OgrenmeyiBaslat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Nud_HedefOda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_Durum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Nud_OgrenmeTurlari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Nud_Baslangic;
        private System.Windows.Forms.Button Btn_Bul;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label6;
    }
}

