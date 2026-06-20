using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLearning_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        Yer[,] yTablosu; // Yerlesim Tablosu
        int[,] R_Tablosu; // Namı değer R Tablosu
        double[,] Q_Tablosu; // Q Tablosu
        double oK; // Öğrenme katsayısı

        private void Nud_OdaSayisi_ValueChanged(object sender, EventArgs e)
        {
            // Numeric Up Down değer ayarlamaları
            Nud_HedefOda.Maximum = Nud_OdaSayisi.Value;
            Nud_Baslangic.Maximum = Nud_OdaSayisi.Value;

            grOdalar = Tual.CreateGraphics();
            grOdalar.Clear(Color.FromKnownColor(KnownColor.Control));
            yTablosu = OdalariYerlestir();
            yollariBelirle();
            yollariCizdir();
            OdalariYerlestir();
            try
            {
                oK = Convert.ToDouble(Tb_OgrenmeKatsayisi.Text);
            }
            catch
            {
                L_Durum.Text = "Yanlış Katsayı Girdisi..";
            }
            L_Durum.Text = "İşlem Tamamlandı..";
           
        }
        //Nud_OdaSayisi_ValueChanged--

        //Tual üzerine odaların çizilmesi
        int bolmeSayisi;
        int odaSayisi;
        int cap;
        Graphics grOdalar;
        public Yer[,] OdalariYerlestir()
        {
            L_Durum.Text = "Odalar Yerleştiriliyor..";
            odaSayisi = (int)Nud_OdaSayisi.Value; // toplam oda sayısı
            bolmeSayisi = (int)Math.Ceiling(Math.Sqrt((double)odaSayisi)); // herbir satırda kaç oda çizilecek
            
            int birBolme = 500 / bolmeSayisi; // herbir odanın çizileceği alan piksel cinsinden
            Point ilkYerlesim = new Point((birBolme) / 2, (birBolme) / 2); // ilk yerleştirilecek odanın yeri
            Yer[,] yT = new Yer[bolmeSayisi,bolmeSayisi]; // Yerleşim tablosu
            int j = 0; // Odaların Y koordinatındaki yeri
            int k = 0; // Odaların X koordinatındaki yeri
            for (int i = 0; i < odaSayisi; i++)
            {
                cap = (birBolme * 3) / 4;
                int odaX = (ilkYerlesim.X) + (birBolme * k) - cap/2; // Dairenin X'i
                int odaY = (ilkYerlesim.Y) + (birBolme * j)- cap/2; // Dairenin Y'si
                grOdalar.FillEllipse(Brushes.Green, odaX,odaY , cap, cap); // Dairenin çizimi
                int isimUzunlugu = (int)grOdalar.MeasureString((i + 1).ToString(), new Font("Verdana", 200*(1/(float)odaSayisi))).Width;
                int isimYuksekligi = (int)grOdalar.MeasureString((i + 1).ToString(), new Font("Verdana", 200*(1/(float)odaSayisi))).Height;
                grOdalar.DrawString((i + 1).ToString(),new Font("Verdana", 200*(1/(float)odaSayisi)),Brushes.Black,new Point((odaX+cap/2)-(isimUzunlugu/2),odaY+(cap/2)-(isimYuksekligi/2)));
                if(i==((int)Nud_HedefOda.Value-1))
                {
                    grOdalar.DrawEllipse(new Pen(Brushes.Red,2), odaX, odaY, cap, cap);
                }
                yT[k, j] = new Yer();
                yT[k,j].X = odaX + cap / 2;//Değerler tabloya kaydediliyor
                yT[k, j].Y = odaY + cap / 2;
                yT[k, j].Deger = i;

                //satır ve sütünlara ayırma
                if (k == (bolmeSayisi-1))
                {
                    k = -1;
                    j++;
                }
                k++;
            }
                        
            return yT;
        }
        //odalariYerlestir--

        //Yolların Belirlenmesi
        public void yollariBelirle()
        {
            L_Durum.Text = "Yollar Yerleştiriliyor..";
            R_Tablosu = new int[odaSayisi, odaSayisi]; // R tablosunun boyutları belirleniyor
            Q_Tablosu = new double[odaSayisi, odaSayisi]; // Q tablosunun boyutları belirleniyor
            
            Random R = new Random();
            
            //Hepsini -1 yap
            for (int j = 0; j < odaSayisi; j++)
            {
                for (int i = 0; i < odaSayisi; i++)
                {
                    R_Tablosu[j, i] = -1;
                }
            }

            // Yolları random belirle
            for (int j = 0; j < odaSayisi; j++)
            {
                int[] komsular = KomsuBul(j);
                for (int a = 0; a < 8; a++)
                {
                    if (komsular[a] != -1)
                    {
                        if (R.Next() % 2 == 0)
                        {
                            R_Tablosu[j, komsular[a]] = 0;
                            R_Tablosu[komsular[a], j] = 0;
                        }
                    }
                }
            }
            //yollariBelirle--

            //hedefe varan yolların değerini 100 yap
            for (int i = 0; i < odaSayisi; i++)
            {
                if (R_Tablosu[i, (int)Nud_HedefOda.Value - 1] == 0)
                {
                    R_Tablosu[i, (int)Nud_HedefOda.Value - 1] = 100;
                }                
            }
        }

      
        // yerleşim classı
        public class Yer
        {
            public int X;
            public int Y;
            public int Deger;
        }
        //class Yer--

        // Komşu bulan fonksiyon
        public int[] KomsuBul(int oda)
        {
            int[] komsular = new int[8];

            //butun degerleri sıfırla
            for (int i = 0; i < 8; i++)
            {
                komsular[i] = -1;
            }

            // komsuları bul
            for (int i = 0; i < bolmeSayisi; i++)
            {
                for (int j = 0; j < bolmeSayisi; j++)
                {
                    if ((yTablosu[i, j]!= null) && (yTablosu[i, j].Deger == oda))
                    {
                        try
                        {
                            komsular[0] = yTablosu[i - 1, j - 1].Deger;
                        }
                        catch
                        { }
                        try
                        {
                            komsular[1] = yTablosu[i - 1, j].Deger;
                        }
                        catch
                        { }
                        try
                        {
                            komsular[2] = yTablosu[i - 1, j + 1].Deger;
                        }
                        catch
                        { }
                        try
                        {
                            komsular[3] = yTablosu[i , j - 1].Deger;
                        }
                        catch
                        { }
                        try
                        {
                            komsular[4] = yTablosu[i , j +1].Deger;
                        }
                        catch
                        { }
                        try
                        {
                            komsular[5] = yTablosu[i +1, j - 1].Deger;
                        }
                        catch
                        { }
                        try
                        {
                            komsular[6] = yTablosu[i + 1, j ].Deger;
                        }
                        catch
                        { }
                        try
                        {
                            komsular[7] = yTablosu[i + 1, j + 1].Deger;
                        }
                        catch
                        { }
                    }
                }
            }
            return komsular;
        }
        //KomsuBul--

        // yolları ekrana çizdiren fonksiyon
        public void yollariCizdir()
        {
            L_Durum.Text = "Yollar Çiziliyor..";
            for (int z = 0; z < odaSayisi; z++)
            {
                for (int i = 0; i < odaSayisi; i++)
                {
                    int korXi = i % bolmeSayisi;
                    int korYi = i / bolmeSayisi;
                    int korXz = z % bolmeSayisi;
                    int korYz = z / bolmeSayisi;
                    if (R_Tablosu[i, z] == 0)
                    {
                        grOdalar.DrawLine(new Pen(Brushes.Blue, 2), new Point(yTablosu[korXi, korYi].X, yTablosu[korXi, korYi].Y), new Point(yTablosu[korXz, korYz].X, yTablosu[korXz, korYz].Y));
                    }
                    if (R_Tablosu[i, z] == 100)
                    {                       
                        grOdalar.DrawLine(new Pen(Brushes.Blue, 2), new Point(yTablosu[korXi, korYi].X, yTablosu[korXi, korYi].Y), new Point(yTablosu[korXz, korYz].X, yTablosu[korXz, korYz].Y));
                    }

                }
            }
        }
        //yollariCizdir--

        // bir episode çalışan fonksiyon
        Random R = new Random();
        int oncekiRandom = 0;
        public void QHesap()
        {
            R = new Random();
            int anlikOda = R.Next(odaSayisi);
            while (oncekiRandom == anlikOda)
            {
                anlikOda = R.Next(odaSayisi);
            }
            oncekiRandom = anlikOda;
            int gidilecekOda = anlikOda;
            double Qmax = 0;
            while (anlikOda != (Nud_HedefOda.Value-1))
            {
                // Anlık odadan gidilebilecek odalardan bir tanesi seçiliyor..
                int Rand = R.Next(odaSayisi); // ilk random değer
                while (R_Tablosu[anlikOda, Rand] == -1)
                {
                    Rand = R.Next(odaSayisi);
                }
                
                // Eğer 100 varsa onlardan birini kullan
                for (int h = 0; h < odaSayisi; h++)
                {
                    if (R_Tablosu[anlikOda, h] == 100)
                    {
                        Rand = h;
                    }
                }

                // AnlikOda->Rand için bütün olası yollar içerisinden Q su en büyük olan alınacak
                for (int h = 0; h < odaSayisi; h++)
                {
                    if (R_Tablosu[Rand, h] != -1)
                    {
                        if (Qmax < R_Tablosu[Rand, h])
                        {
                            Qmax = Q_Tablosu[Rand, h];
                        }
                    }
                }
                
                Q_Tablosu[anlikOda, Rand] = R_Tablosu[anlikOda, Rand] + oK*Qmax;
                
                anlikOda = Rand;                           
            }
            
        }//QHesap--

        private void Btn_OgrenmeyiBaslat_Click(object sender, EventArgs e)
        {
            L_Durum.Text = "Öğrenme Başlatıldı";
            for (int i = 0; i < (int)Nud_OgrenmeTurlari.Value; i++)
            {
                QHesap();
            }
            L_Durum.Text = "Öğrenme Tamamlandı";
        }

        private void Btn_Bul_Click(object sender, EventArgs e)
        {
            L_Durum.Text = "Yol Bulunuyor...";
            grOdalar.Clear(Color.FromKnownColor(KnownColor.Control));
            yollariCizdir();
            OdalariYerlestir();
            int oncekiX = 0, oncekiY = 0;
            bool ilk = true;
            int oncekiKonum=0;
            richTextBox1.Clear();
            int konum = (int)Nud_Baslangic.Value-1;
            while (konum != (int)Nud_HedefOda.Value-1)
            {
                foreach (Yer y in yTablosu)
                {
                    if ((y != null) && (y.Deger == konum))
                    {                        
                        if (ilk == false)
                        {
                            grOdalar.DrawLine(new Pen(Brushes.Red, 6), new Point(y.X, y.Y), new Point(oncekiX, oncekiY));
                            grOdalar.DrawLine(new Pen(Brushes.Blue, 2), new Point(y.X, y.Y), new Point(oncekiX, oncekiY));
                            
                        }
                        else
                        {
                            ilk = false;
                        }
                        oncekiX = y.X;
                        oncekiY = y.Y;
                        grOdalar.DrawEllipse(new Pen(Brushes.Red, 4), y.X - cap / 2, y.Y - cap / 2, cap, cap);
                    }
                }
                double Maks = 0;
                int gidilecek = 0;
                for (int d = 0; d < odaSayisi; d++)
                {
                    if (Q_Tablosu[konum, d] >= Maks)
                    {
                        Maks = Q_Tablosu[konum, d];
                        if (R_Tablosu[konum, d] != -1)
                        {
                            gidilecek = d;
                        }
                    }                    
                }
                richTextBox1.Text += " -> "+(konum+1);
                if (oncekiKonum == gidilecek)
                {
                    int f = 0;
                    while (R_Tablosu[konum, f] == -1)
                    {
                        f = R.Next(odaSayisi);
                    }
                    gidilecek = f;
                }
                oncekiKonum = konum;
                konum = gidilecek;
                
            }

            foreach (Yer y in yTablosu)
            {
                if ((y != null) && (y.Deger == konum))
                {
                    if (ilk == false)
                    {
                        grOdalar.DrawLine(new Pen(Brushes.Red, 6), new Point(y.X, y.Y), new Point(oncekiX, oncekiY));
                        grOdalar.DrawLine(new Pen(Brushes.Blue, 2), new Point(y.X, y.Y), new Point(oncekiX, oncekiY));

                    }
                    else
                    {
                        ilk = false;
                    }
                    oncekiX = y.X;
                    oncekiY = y.Y;
                    grOdalar.DrawEllipse(new Pen(Brushes.Red, 4), y.X - cap / 2, y.Y - cap / 2, cap, cap);
                }
            }

            OdalariYerlestir();
            richTextBox1.Text += " -> " + (konum+1);
            L_Durum.Text = "Yol Bulundu...";
            
        }
        
        

            
    }
}
