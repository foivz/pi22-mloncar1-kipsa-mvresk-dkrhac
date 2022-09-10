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

namespace Registracija_i_Prijava.Forme
{
    public partial class PočetnaStranica : Form
    {
        bool mouseDown;
        private Point offset;
        public string email;
        public PočetnaStranica(string Email)
        {
            InitializeComponent();
            this.KeyPreview = true;
            textBoxPregledPića.Enabled = false;
            textBoxNaručiPiće.Enabled = false;
            textBoxPregledDobavljača.Enabled = false;
            textBoxPregledNarudžbi.Enabled = false;
            textBoxRasporedRada.Enabled = false;
            textBoxStatistika.Enabled = false;
            textBoxRecenzije.Enabled = false;   
            textBoxOdjava.Enabled = false;
            email = Email;
            

        }

        private void panelDrag_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
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

        

        private void pictureBoxOdjavaGlavna_Click(object sender, EventArgs e)
        {
            Prijava prijava=new Prijava();
            Hide();
            prijava.ShowDialog();
            Close ();
        }

       private void pictureBoxOdjava_Click_1(object sender, EventArgs e)
        {
            Prijava prijava = new Prijava();
            Hide();
            prijava.ShowDialog();
            Close();
        }

        private void pictureBoxPregledPića_Click(object sender, EventArgs e)
        {
            Pregled_pića pregledPića = new Pregled_pića(email);
            Hide();
            pregledPića.ShowDialog();
            Close();
        }

        private void pictureBoxPregledPićaGlavna_Click(object sender, EventArgs e)
        {
            Pregled_pića pregledPića = new Pregled_pića(email);
            Hide();
            pregledPića.ShowDialog();
            Close();
        }

        private void PočetnaStranica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "PočetnaStranica.htm");
            }
        }

        private void pictureBoxNaručiPićeGlavna_Click(object sender, EventArgs e)
        {
            NaručiPića naručiPića=new NaručiPića(email);
            Hide();
            naručiPića.ShowDialog();
            Close();
        }

        private void pictureBoxNaručiPiće_Click(object sender, EventArgs e)
        {
            NaručiPića naručiPića = new NaručiPića(email);
            Hide();
            naručiPića.ShowDialog();
            Close();

        }
    }
}
