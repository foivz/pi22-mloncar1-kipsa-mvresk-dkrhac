using ClassLibrary1;
using Registracija_i_Prijava.DodatneKlase;
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
    public partial class DodajPića : Form
    {
        bool mouseDown;
        private Point offset;
        public DodajPića()
        {
            InitializeComponent();
            this.KeyPreview = true;
            comboBoxVrstaPićaPodaci();
            comboBoxKoličinaPodaci();
            comboBoxDohvatiProizvođaće();
           
        }

        private void comboBoxDohvatiProizvođaće()
        {
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Proizvođać
                            select p.Naziv_Proizvođaća.ToString();
                comboBoxProizvođać.DataSource = query.Distinct().ToList();
            }
        }

        private void comboBoxKoličinaPodaci()
        {
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Količina
                            select p.Količina1.ToString();
               comboBoxKoličina.DataSource = query.Distinct().ToList();
            }
        }

        private void comboBoxVrstaPićaPodaci()
        {
            using(var context=new ModelPodataka())
            {
                var query = from p in context.Vrsta_pića
                            select p.Naziv_Vrste.ToString();
                comboBoxVrstaPića.DataSource=query.Distinct().ToList();
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

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            using (var context = new ModelPodataka())
            {
                int VrstaPića_Id = 1;
                int Proizvođać_Id = 1;
                int KoličinaPića_Id = 1;
             
                bool postoji = false;
               

                string Cijena = textBoxCijena.Text;
                string NazivPića = textBoxNaziv.Text;
                string Količina = comboBoxKoličina.SelectedItem.ToString();
                Convert.ToDecimal(Količina);

                foreach (var item in context.Količina)
                {
                    if (Količina == (item.Količina1).ToString())
                    {
                        KoličinaPića_Id = item.Količina_Id;

                    }

                }


                string PostotakAlkohola = textBoxPostotakAlkohola.Text;

                string VrstaPića = comboBoxVrstaPića.SelectedItem.ToString();
                foreach (var item in context.Vrsta_pića)
                {
                    if (VrstaPića == (item.Naziv_Vrste).ToString())
                    {
                        VrstaPića_Id = item.VrstaPića_Id;
                    }

                }

                string Proizvođač = comboBoxProizvođać.SelectedItem.ToString();

                foreach (var item in context.Proizvođać)
                {
                    if (Proizvođač == (item.Naziv_Proizvođaća).ToString())
                    {
                        Proizvođać_Id = item.Proizvođać_Id;
                    }
                }

                string Opis = textBoxOpis.Text;

               
                    var query = from pića in context.Pića
                                join vrstaPića in context.Vrsta_pića on pića.VrstaPića_Id equals vrstaPića.VrstaPića_Id
                                join proizvođać in context.Proizvođać on pića.Proizvođać_Id equals proizvođać.Proizvođać_Id
                                join količinaPića in context.Količina_Pića on pića.Piće_Id equals količinaPića.Piće_Id
                                join količina in context.Količina on količinaPića.Količina_Id equals količina.Količina_Id
                                orderby pića.Piće_Id
                                select new PregledPićaExtd
                                {
                                    Piće_Id = pića.Piće_Id,
                                    Naziv_Pića = pića.Naziv_Pića,
                                    Količina1 = količina.Količina1,
                                    Postotak_Alkohola = pića.Postotak_Alkohola,
                                    Naziv_Vrste = vrstaPića.Naziv_Vrste,
                                    Naziv_Proizvođaća = proizvođać.Naziv_Proizvođaća,
                                    Cijena = količinaPića.Cijena,
                                    Opis = pića.Opis

                                };

                    foreach (var item2 in query ) {
                        if (item2.Naziv_Pića == textBoxNaziv.Text && item2.Količina1 == Količina)
                        {
                            postoji = true;
                        }
                    }
                         
                    
              

                

                if (postoji == false)
                {
                    Pića novo = new Pića()
                    {
                       
                        Naziv_Pića = NazivPića,
                        Postotak_Alkohola = PostotakAlkohola,
                        VrstaPića_Id = VrstaPića_Id,
                        Proizvođać_Id = Proizvođać_Id,
                        Opis = Opis
                    };
                    Količina_Pića novi = new Količina_Pića()
                    {

                        Količina_Id = KoličinaPića_Id,
                        Cijena = Cijena
                    };

                    context.Pića.Add(novo);
                    context.Količina_Pića.Add(novi);
                    context.SaveChanges();
                    MessageBox.Show("Uspješno ste dodali podatke");
                }
                else 
                {
                    MessageBox.Show("Već postoji piće s tim nazivom i količinom");
                }
               

            }
           
        }
  
        private void buttonOdustani_MouseHover(object sender, EventArgs e)
        {
            buttonOdustani.ForeColor=Color.Blue;
        }

        private void buttonOdustani_MouseLeave(object sender, EventArgs e)
        {
            buttonOdustani.ForeColor = Color.Black;
        }

        private void buttonSpremi_MouseHover(object sender, EventArgs e)
        {
            buttonSpremi.ForeColor = Color.Blue;
        }

        private void buttonSpremi_MouseLeave(object sender, EventArgs e)
        {
            buttonSpremi.ForeColor = Color.Black;
        }

        private void DodajPića_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "DodavanjeKorisnika.htm");
            }
        }
    }
}
