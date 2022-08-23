using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registracija_i_Prijava
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
          
           

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
    }
}
