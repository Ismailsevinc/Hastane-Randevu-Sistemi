using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace HastaneBilgiSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Doktorlar> doktorlar = new List<Doktorlar>();
        List<string> sabahdoktorsaatleri = new List<string>() { "09:00", "09:30", "10:00", "10:30", "11:00" };
        List<string> oglendoktorsaatleri = new List<string>() { "14:00", "14:30", "15:00", "15:30", "16:00" };
        List<Randevular> randevular = new List<Randevular>();

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBoxDoktor.Enabled = false;
            Bolumler Goz = new Bolumler(1, "Göz");
            Bolumler KulakBurunBogaz = new Bolumler(2, "Kulak Burun Boðaz");
            Bolumler Ortopedi = new Bolumler(3, "Ortopedi");
            Doktorlar DoktorAhmetCansýz = new Doktorlar(2, "Ahmet", "Cansýz", KulakBurunBogaz, sabahdoktorsaatleri, true);

            doktorlar.Add(DoktorAhmetCansýz);

            Doktorlar DoktorElvanSimsek = new Doktorlar(3, "Elvan", "Þimþek", KulakBurunBogaz, oglendoktorsaatleri, false);

            doktorlar.Add(DoktorElvanSimsek);
            Doktorlar DoktorFatihDag = new Doktorlar(4, "Fatih", "Dað", Ortopedi, sabahdoktorsaatleri, true);

            doktorlar.Add(DoktorFatihDag);
            Doktorlar DoktorÝsmailSevinc = new Doktorlar(1, "Ýsmail", "Sevinç", Goz, oglendoktorsaatleri, false);

            doktorlar.Add(DoktorÝsmailSevinc);

            comboBoxBolum.Items.Add(Goz.BolumAd);
            comboBoxBolum.Items.Add(KulakBurunBogaz.BolumAd);
            comboBoxBolum.Items.Add(Ortopedi.BolumAd);

            comboBoxsaatler.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBolum.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDoktor.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public void HucreleriTemizle()
        {
            textBoxAdi.Clear();
            textBoxSoyadi.Clear();
            textBoxtc.Clear();
            comboBoxBolum.Text = "";
            comboBoxDoktor.Text = "";
            comboBoxsaatler.Text = "";

        }
        public void DoktorlarýGoruntule(string bolumad)
        {
            comboBoxDoktor.Text = "";
            comboBoxDoktor.Enabled = true;
            var SecilenDoktor = doktorlar.Where(d => d.Bolum.BolumAd == bolumad);
            foreach (var d in SecilenDoktor)
            {
                comboBoxDoktor.Items.Add($"{d.DoktorAd} {d.DoktorSoyad}");

            }
        }
        private void comboBoxBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDoktor.Items.Clear();
            comboBoxDoktor.Enabled = false;

            switch (comboBoxBolum.Text)
            {
                case "Göz":

                    DoktorlarýGoruntule("Göz");
                    break;
                case "Kulak Burun Boðaz":
                    DoktorlarýGoruntule("Kulak Burun Boðaz");
                    break;
                case "Ortopedi":
                    DoktorlarýGoruntule("Ortopedi");
                    break;


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {


            TcSorgu tcsorgu = new TcSorgu();
            string Rdoktoradi = comboBoxDoktor.SelectedItem?.ToString();
            string Rsaati = comboBoxsaatler.SelectedItem?.ToString();
            string tc = textBoxtc.Text;

            if (string.IsNullOrWhiteSpace(tc) || tc.Length != 11)
            {
                MessageBox.Show("Eksik Tc Kimlik Numarasý");
                return;
            }
            if (string.IsNullOrWhiteSpace(Rdoktoradi) && string.IsNullOrWhiteSpace(Rsaati))
            {
                MessageBox.Show("Lütfen Doktor ve Randevu Saati Seçiniz");
                return;
            }

            if (tcsorgu.baglanti.State != ConnectionState.Open)
            {
                tcsorgu.baglanti.Open();
            }

            TcSorgu tcSorgu = new TcSorgu();
            if (tcSorgu.yap(tc))
            {


                randevular.Add(new Randevular(Rsaati, Rdoktoradi));
                string secilensaat = comboBoxsaatler.SelectedItem?.ToString();
                comboBoxsaatler.Items.Remove(secilensaat);
                MessageBox.Show("randevu alma baþarýlý");
                HucreleriTemizle();
            }
            else
            {
                MessageBox.Show("Hatalý Tc Kimlik Numarasý");
            }

        }

        private void comboBoxDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxsaatler.Items.Clear();
            comboBoxsaatler.Text = "";
            string doktoradisoyadi = comboBoxDoktor.Text;
            string doktoradi = doktoradisoyadi.Split(' ')[0];

            var sabahci = doktorlar.Where(d => d.DoktorAd == doktoradi && d.Sabahcimi == true);

            if (sabahci.Any()) // Any() metodu, koleksiyonda en az bir eleman varsa true döner
            {
                foreach (var item in sabahci)
                {
                    foreach (var item2 in sabahdoktorsaatleri)
                    {

                        comboBoxsaatler.Items.Add(item2.ToString());
                    }
                }

            }
            else
            {
                comboBoxsaatler.Items.Clear();
                foreach (var item in oglendoktorsaatleri)
                {
                    comboBoxsaatler.Items.Add(item.ToString());
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBoxRandevu.Items.Clear();
            foreach (var item in randevular)
            {
                string Rkayýtlarý = $"Doktor Adý:{item.Doktor.ToString()}  Randevu Saati:{item.RandevuSaati.ToString()}";
                listBoxRandevu.Items.Add(Rkayýtlarý);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-471QMFA;Initial Catalog=hastane;Integrated Security=True"))
            {
                if (string.IsNullOrWhiteSpace(textBoxAdi.Text) || string.IsNullOrWhiteSpace(textBoxSoyadi.Text) || string.IsNullOrWhiteSpace(textBoxtc.Text) || textBoxtc.Text.Length != 11)
                {
                    MessageBox.Show("Lütfen Ad Soyad ve Tc kimlik alanlarýný eksiksiz doldurunuz ");
                    return;
                }
                
               
                try
                {
                    baglanti.Open();
                    SqlCommand tckontrol = new SqlCommand("SELECT COUNT(*) FROM kisiler WHERE Tckimlik=@tckimlik", baglanti);

                    tckontrol.Parameters.AddWithValue("@tckimlik",textBoxtc.Text);
                    
                    int kayitsayisi=(int)tckontrol.ExecuteScalar();

                    if (kayitsayisi>0)
                    {

                        MessageBox.Show("ayný tc kimlik numarasýna sahip kayýt vardýr");
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO kisiler (Tckimlik, Ad, Soyad) VALUES (@tckimlik, @ad, @soyad)", baglanti);
                        cmd.Parameters.AddWithValue("@tckimlik", textBoxtc.Text);
                        cmd.Parameters.AddWithValue("@ad", textBoxAdi.Text);
                        cmd.Parameters.AddWithValue("@soyad", textBoxSoyadi.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Yeni Kayýt Oluþturulmuþtur");
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayýt oluþturulurken bir hata oluþtu. Lütfen tekrar deneyin.");
                    Console.WriteLine($"Hata: {ex.Message}"); // Hata detaylarý loglanabilir.
                }
            }

        }
    }
}
