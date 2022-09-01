using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registracija_i_Prijava.Forme
{
    public partial class Pregled_pića : Form
    {
        bool mouseDown;
        private Point offset;
        public Pregled_pića()
        {
            InitializeComponent();
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

        private void labelIzlaz_Click(object sender, EventArgs e)
        {
            Forme.PočetnaStranica početnaStranica=new PočetnaStranica();
            Hide();
            početnaStranica.ShowDialog();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Forme.PočetnaStranica početnaStranica = new PočetnaStranica();
            Hide();
            početnaStranica.ShowDialog();
            Close();
        }
    }
}
