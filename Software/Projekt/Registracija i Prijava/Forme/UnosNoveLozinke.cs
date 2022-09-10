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
using UserHelp;

namespace Registracija_i_Prijava.Forme
{
    public partial class UnosNoveLozinke : Form
    {
        bool mouseDown;
        private Point offset;
        public string email;
        
        public UnosNoveLozinke(string Email)
        {
            InitializeComponent();
            DohvatiKorisnika();
            email= Email;
            this.KeyPreview = true;
        }
        private Korisnik DohvatiKorisnika()
        {
            

            using (var context = new ModelPodataka())
            {
                var query = from p in context.Korisnik
                            where p.Email == email
                            select p;

                return query.FirstOrDefault();
            }
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
            ZaboravljenaLozinka zaboravljenaLozinka = new ZaboravljenaLozinka();
            Hide();
            zaboravljenaLozinka.ShowDialog();
            Close();
        }

        private void buttonResetirajLozinku_Click(object sender, EventArgs e)
        {
            if (DohvatiKorisnika()!= null)
            {
               
                string lozinka = textBoxLozinka.Text;
                string ponovljenalozinka = textBoxPonovljenaLozinka.Text;
                if (lozinka == ponovljenalozinka && lozinka.Length>7)
                {
                    using (var context = new ModelPodataka())
                    {
                        var query = from k in context.Korisnik
                                    where k.Email == email
                                    select new
                                    {
                                       k
                                    };

                        foreach (var item in query)
                        {
                            item.k.Lozinka = lozinka;
                            item.k.Ponovljena_Lozinka = ponovljenalozinka;
                        }
                        context.SaveChanges();
                        MessageBox.Show("Lozinka uspješno promjenjena.");
                    }
                }
                else if(lozinka != ponovljenalozinka)
                {
                    MessageBox.Show("Lozinke nisu identične.");
                    MessageBox.Show(lozinka.Length.ToString());
                }
                else if (lozinka.Length < 7 && ponovljenalozinka.Length<7)
                {
                    MessageBox.Show("Lozinka nema dovoljno znakova.");
                }

            }
            else
            {
                MessageBox.Show("Ne postoji korisnik s unesenim e-mailom");
            }
            }

        private void textBoxLozinka_Click(object sender, EventArgs e)
        {
            textBoxLozinka.Text = "";
        }

        private void textBoxPonovljenaLozinka_Click(object sender, EventArgs e)
        {
            textBoxPonovljenaLozinka.Text = "";
        }

        private void buttonResetirajLozinku_MouseHover(object sender, EventArgs e)
        {
            buttonResetirajLozinku.ForeColor = Color.Blue;
        }

        private void buttonResetirajLozinku_MouseLeave(object sender, EventArgs e)
        {
            buttonResetirajLozinku.ForeColor = Color.Black;
        }

        private void labelIzlaz_MouseHover(object sender, EventArgs e)
        {
            labelIzlaz.ForeColor = Color.Blue;
        }

        private void labelIzlaz_MouseLeave(object sender, EventArgs e)
        {
            labelIzlaz.ForeColor = Color.Black;
        }

        private void pictureBoxLogoVIK_Click(object sender, EventArgs e)
        {
            textBoxLozinka.Text = "Nova lozinka";
            textBoxPonovljenaLozinka.Text = "Ponovljena lozinka";
        }

        private void UnosNoveLozinke_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                UserHelpp help=new UserHelpp();
                help.OtvoriUserHelp(this, "UnosNoveLozinke.htm");
            }
        }
    }
    }

