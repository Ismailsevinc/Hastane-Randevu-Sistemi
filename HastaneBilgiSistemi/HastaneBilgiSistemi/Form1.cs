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
            Bolumler Goz = new Bolumler(1, "G�z");
            Bolumler KulakBurunBogaz = new Bolumler(2, "Kulak Burun Bo�az");
            Bolumler Ortopedi = new Bolumler(3, "Ortopedi");
            Doktorlar DoktorAhmetCans�z = new Doktorlar(2, "Ahmet", "Cans�z", KulakBurunBogaz, sabahdoktorsaatleri, true);

            doktorlar.Add(DoktorAhmetCans�z);

            Doktorlar DoktorElvanSimsek = new Doktorlar(3, "Elvan", "�im�ek", KulakBurunBogaz, oglendoktorsaatleri, false);

            doktorlar.Add(DoktorElvanSimsek);
            Doktorlar DoktorFatihDag = new Doktorlar(4, "Fatih", "Da�", Ortopedi, sabahdoktorsaatleri, true);

            doktorlar.Add(DoktorFatihDag);
            Doktorlar Doktor�smailSevinc = new Doktorlar(1, "�smail", "Sevin�", Goz, oglendoktorsaatleri, false);

            doktorlar.Add(Doktor�smailSevinc);

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
        public void Doktorlar�Goruntule(string bolumad)
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
                case "G�z":

                    Doktorlar�Goruntule("G�z");
                    break;
                case "Kulak Burun Bo�az":
                    Doktorlar�Goruntule("Kulak Burun Bo�az");
                    break;
                case "Ortopedi":
                    Doktorlar�Goruntule("Ortopedi");
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
                MessageBox.Show("Eksik Tc Kimlik Numaras�");
                return;
            }
            if (string.IsNullOrWhiteSpace(Rdoktoradi) && string.IsNullOrWhiteSpace(Rsaati))
            {
                MessageBox.Show("L�tfen Doktor ve Randevu Saati Se�iniz");
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
                MessageBox.Show("randevu alma ba�ar�l�");
                HucreleriTemizle();
            }
            else
            {
                MessageBox.Show("Hatal� Tc Kimlik Numaras�");
            }

        }

        private void comboBoxDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxsaatler.Items.Clear();
            comboBoxsaatler.Text = "";
            string doktoradisoyadi = comboBoxDoktor.Text;
            string doktoradi = doktoradisoyadi.Split(' ')[0];

            var sabahci = doktorlar.Where(d => d.DoktorAd == doktoradi && d.Sabahcimi == true);

            if (sabahci.Any()) // Any() metodu, koleksiyonda en az bir eleman varsa true d�ner
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
                string Rkay�tlar� = $"Doktor Ad�:{item.Doktor.ToString()}  Randevu Saati:{item.RandevuSaati.ToString()}";
                listBoxRandevu.Items.Add(Rkay�tlar�);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-471QMFA;Initial Catalog=hastane;Integrated Security=True"))
            {
                if (string.IsNullOrWhiteSpace(textBoxAdi.Text) || string.IsNullOrWhiteSpace(textBoxSoyadi.Text) || string.IsNullOrWhiteSpace(textBoxtc.Text) || textBoxtc.Text.Length != 11)
                {
                    MessageBox.Show("L�tfen Ad Soyad ve Tc kimlik alanlar�n� eksiksiz doldurunuz ");
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

                        MessageBox.Show("ayn� tc kimlik numaras�na sahip kay�t vard�r");
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO kisiler (Tckimlik, Ad, Soyad) VALUES (@tckimlik, @ad, @soyad)", baglanti);
                        cmd.Parameters.AddWithValue("@tckimlik", textBoxtc.Text);
                        cmd.Parameters.AddWithValue("@ad", textBoxAdi.Text);
                        cmd.Parameters.AddWithValue("@soyad", textBoxSoyadi.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Yeni Kay�t Olu�turulmu�tur");
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kay�t olu�turulurken bir hata olu�tu. L�tfen tekrar deneyin.");
                    Console.WriteLine($"Hata: {ex.Message}"); // Hata detaylar� loglanabilir.
                }
            }

        }
    }
}
