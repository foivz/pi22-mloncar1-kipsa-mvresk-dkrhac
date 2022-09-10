using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validacija;
using UserHelp;

namespace Registracija_i_Prijava
{
    public partial class Registracija : Form
    {
        bool mouseDown;
        private Point offset;
    
        public Registracija()
        {
            InitializeComponent();
            DohvatiKorisnika();
            this.KeyPreview = true;
        }

        private Korisnik DohvatiKorisnika()
        {
            
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Korisnik
                            where p.Korisničko_Ime==textBoxKorisničkoIme.Text
                            select p;
                
                return query.FirstOrDefault();
            }
        }

        private void panelDrag_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown=true;
        }

        private void panelDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point trenutnaPozicijaEkrana = PointToScreen(e.Location);
                Location = new Point(trenutnaPozicijaEkrana.X - offset.X, trenutnaPozicijaEkrana.Y - offset.Y);
            }
        }

        private void panelDrag_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

       

        private void labelOdustani_MouseHover(object sender, EventArgs e)
        {
            labelOdustani.ForeColor = Color.Blue;
        }

        private void labelOdustani_MouseLeave(object sender, EventArgs e)
        {
            labelOdustani.ForeColor = Color.Black;
        }

        private void buttonRegistrirajse_MouseHover(object sender, EventArgs e)
        {
            buttonRegistrirajse.ForeColor = Color.Blue;
        }

        private void buttonRegistrirajse_MouseLeave(object sender, EventArgs e)
        {
            buttonRegistrirajse.ForeColor= Color.Black;
        }

        private void pictureBoxLogoVIK_Click(object sender, EventArgs e)
        {
            textBoxIme.Text = "Ime";
            textBoxPrezime.Text = "Prezime";
            textBoxEmail.Text = "E-mail";
            textBoxBrojMobitela.Text = "Broj mobitela";
            textBoxAdresa.Text = "Adresa";
            textBoxKorisničkoIme.Text = "Korisničko ime";
            textBoxLozinka.Text = "Lozinka";
            textBoxPonovljenaLozinka.Text = "Ponovljena lozinka";
            textBoxSpol.Text = "";
        }

        private void textBoxIme_Click(object sender, EventArgs e)
        {
            textBoxIme.Text = "";
        }

        private void textBoxPrezime_Click(object sender, EventArgs e)
        {
            textBoxPrezime.Text = "";
        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "";
        }

        private void textBoxBrojMobitela_Click(object sender, EventArgs e)
        {
            textBoxBrojMobitela.Text = "";
        }

        private void textBoxAdresa_Click(object sender, EventArgs e)
        {
            textBoxSpol.Text = "";
        }

        private void textBoxKorisničkoIme_Click(object sender, EventArgs e)
        {
            textBoxKorisničkoIme.Text = "";
        }

        private void textBoxLozinka_Click(object sender, EventArgs e)
        {
            textBoxLozinka.Text = "";
        }

        private void textBoxPonovljenaLozinka_Click(object sender, EventArgs e)
        {
            textBoxPonovljenaLozinka.Text = "";
        }

        private void labelOdustani_Click(object sender, EventArgs e)
        {
            
            Prijava prijava= new Prijava();
            Hide();
            prijava.ShowDialog();
            Close();
            
        }

        private void buttonRegistrirajse_Click(object sender, EventArgs e)
        {

            
            string[] validacijaKorisnika = new string[9];
            validacijaKorisnika[0] = textBoxIme.Text;
            validacijaKorisnika[1]=textBoxPrezime.Text;
            validacijaKorisnika[2]=textBoxEmail.Text;
            validacijaKorisnika[3]=textBoxBrojMobitela.Text;
            validacijaKorisnika[4]=textBoxAdresa.Text;
            validacijaKorisnika[5] = textBoxSpol.Text;
            validacijaKorisnika[6]=textBoxKorisničkoIme.Text;
            validacijaKorisnika[7] = textBoxLozinka.Text;
            validacijaKorisnika[8] = textBoxPonovljenaLozinka.Text;
            ValidacijaRegistracije validacija = new ValidacijaRegistracije();
            string poruka = validacija.ValidirajKorisnika(validacijaKorisnika);
            Korisnik dohvaćeniKorisnik = DohvatiKorisnika();
            if (poruka != "")
            {
                MessageBox.Show(poruka);
            }

            else if (dohvaćeniKorisnik != null) { 
                MessageBox.Show("Korisničko ime je zauzeto!");
            }
            else
            {
                using (var context = new ModelPodataka())
                {
                    Korisnik novo = new Korisnik()
                    {
                        Ime = textBoxIme.Text,
                        Prezime = textBoxPrezime.Text,
                        Email = textBoxEmail.Text,
                        Broj_Mobitela= (int)Convert.ToInt64(textBoxBrojMobitela.Text),  
                        Adresa =textBoxAdresa.Text,
                        Spol=textBoxSpol.Text,
                        Korisničko_Ime=textBoxKorisničkoIme.Text,
                        Lozinka =textBoxLozinka.Text,
                        Ponovljena_Lozinka=textBoxPonovljenaLozinka.Text,
                        Uloga_Id=1
                    };

                    context.Korisnik.Add(novo);
                    context.SaveChanges();
                    MessageBox.Show("Uspješno ste obavili registraciju");
                    Prijava prijava= new Prijava();
                    Hide();
                    prijava.ShowDialog();
                    Close();

                }

            }
        }

        private void textBoxAdresa_Click_1(object sender, EventArgs e)
        {
            textBoxAdresa.Text = "";
        }

        private void Registracija_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                
                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "Registracija.htm");
            }
        }
    }
}
