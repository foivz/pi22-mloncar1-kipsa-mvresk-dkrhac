using ClassLibrary1;
using Registracija_i_Prijava.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserHelp;


namespace Registracija_i_Prijava
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            this.KeyPreview = true;
            InitializeComponent();
            DohvatiKorisnika();
           

        }
        

        private Korisnik DohvatiKorisnika()
        {

            using (var context = new ModelPodataka())
            {
                var query = from p in context.Korisnik
                            where p.Korisničko_Ime == textBoxKorisničkoIme.Text && p.Lozinka == textBoxLozinka.Text
                            select p;

                return query.FirstOrDefault();
            }
        }

        private void buttonPrijaviSe_MouseHover(object sender, EventArgs e)
        {
            buttonPrijaviSe.ForeColor = Color.Blue;
        }

        private void buttonPrijaviSe_MouseLeave(object sender, EventArgs e)
        {
            buttonPrijaviSe.ForeColor = Color.Black;
        }
        private void labelRegistrirajSe_MouseHover(object sender, EventArgs e)
        {
            labelRegistrirajSe.ForeColor = Color.Blue;
        }

        private void labelRegistrirajSe_MouseLeave(object sender, EventArgs e)
        {
            labelRegistrirajSe.ForeColor = Color.Black;
        }

        private void labelIzlaz_MouseHover(object sender, EventArgs e)
        {
           labelIzlaz.ForeColor = Color.Blue;
        }
        
        private void labelIzlaz_MouseLeave(object sender, EventArgs e)
        {
            labelIzlaz.ForeColor = Color.Black;
        }
        private void labelIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelRegistrirajSe_Click(object sender, EventArgs e)
        {
            
            Registracija registracija = new Registracija();
            Hide();
            registracija.ShowDialog();
            

        }

        private void textBoxKorisničkoIme_Click(object sender, EventArgs e)
        {
            textBoxKorisničkoIme.Text = "";
        }

        private void textBoxLozinka_Click(object sender, EventArgs e)
        {
            textBoxLozinka.Text = "";
        }

        private void pictureBoxLogoVIK_Click(object sender, EventArgs e)
        {
            textBoxKorisničkoIme.Text = " Korisničko ime";
            textBoxLozinka.Text = " Lozinka";
        }

       

        private void pictureBoxPrikažiLozinku_Click(object sender, EventArgs e)
        {
            pictureBoxSakrijLozinku.BringToFront();
            if (textBoxLozinka.PasswordChar == '*')
            {
                pictureBoxPrikažiLozinku.BringToFront();
                textBoxLozinka.PasswordChar = '\0';
            }

        }

        private void pictureBoxSakrijLozinku_Click(object sender, EventArgs e)
        {
            pictureBoxPrikažiLozinku.BringToFront();
            if (textBoxLozinka.PasswordChar == '\0')
            {
                pictureBoxSakrijLozinku.BringToFront();
                textBoxLozinka.PasswordChar = '*';
            }
        }

        private void buttonPrijaviSe_Click(object sender, EventArgs e)
        {
            if(DohvatiKorisnika() != null) {
                string email = DohvatiKorisnika().Email;
                
                PočetnaStranica početna = new PočetnaStranica(email);
            Hide();
            početna.ShowDialog();
            Close(); }
            else
            {
                MessageBox.Show("Ne postoji korisnik s navedenim podacima!!!");
            }
        }

        private void labelZaboravljenaLozinka_Click(object sender, EventArgs e)
        {
            ZaboravljenaLozinka zaboravljenaLozinka = new ZaboravljenaLozinka();
            Hide();
            zaboravljenaLozinka.ShowDialog();
            Close();
        }

        private void labelZaboravljenaLozinka_MouseHover(object sender, EventArgs e)
        {
            labelZaboravljenaLozinka.ForeColor = Color.Blue;
        }

        private void labelZaboravljenaLozinka_MouseLeave(object sender, EventArgs e)
        {
            labelZaboravljenaLozinka.ForeColor = Color.Black;
        }

       

        private void Prijava_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                
                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "Prijava.htm");
            }
        }
    }
}
