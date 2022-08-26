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
    public partial class Registracija : Form
    {
        bool mouseDown;
        private Point offset;
        public Registracija()
        {
            InitializeComponent();
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

        private void panelDrag_Paint(object sender, PaintEventArgs e)
        {
            
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
            comboBoxSpol.Text = "";
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
            textBoxAdresa.Text = "";
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

        
    }
}
