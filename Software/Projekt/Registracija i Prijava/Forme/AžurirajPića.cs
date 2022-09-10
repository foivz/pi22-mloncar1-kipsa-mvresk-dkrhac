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
    public partial class AžurirajPića : Form
    {
        bool mouseDown;
        private Point offset;
        private PregledPićaExtd novi;
        public string nazivPiča;
        public string email;
        
        public AžurirajPića()
        {
            InitializeComponent();
            this.KeyPreview = true;
            comboBoxVrstaPićaPodaci();
            comboBoxDohvatiProizvođaće();
            
            
        }
        public AžurirajPića(PregledPićaExtd pića,string NazivPića,string Email) : this()
        {
            novi = pića;
            nazivPiča = NazivPića;
            textBoxNaziv.Text = NazivPića.ToString();
            textBoxPostotakAlkohola.Text = pića.Postotak_Alkohola;
            textBoxCijena.Text = pića.Cijena;
            textBoxOpis.Text=pića.Opis;
            comboBoxProizvođać.SelectedItem = pića.Naziv_Proizvođaća;
            comboBoxVrstaPića.SelectedItem = pića.Naziv_Vrste;
            email = Email;
            

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

       

        private void comboBoxVrstaPićaPodaci()
        {
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Vrsta_pića
                            select p.Naziv_Vrste.ToString();
                comboBoxVrstaPića.DataSource = query.Distinct().ToList();
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
            Pregled_pića pregledPića = new Pregled_pića(email);
            Hide();
            pregledPića.ShowDialog();
            Close();
        }

        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            int Proizvođać_Id = 1;
            int VrstaPića_Id = 1;


            string NazivPića = textBoxNaziv.Text;
            string PostotakAlkohola = textBoxPostotakAlkohola.Text;
           
            string Opis = textBoxOpis.Text;
            string Cijena = textBoxCijena.Text;
            
           


            using (var context = new ModelPodataka())
            {
                string Proizvođač = comboBoxProizvođać.SelectedItem.ToString();

                foreach (var item in context.Proizvođać)
                {
                    if (Proizvođač == (item.Naziv_Proizvođaća).ToString())
                    {
                        Proizvođać_Id = item.Proizvođać_Id;
                    }
                }

                string VrstaPića = comboBoxVrstaPića.SelectedItem.ToString();
                foreach (var item in context.Vrsta_pića)
                {
                    if (VrstaPića == (item.Naziv_Vrste).ToString())
                    {
                        VrstaPića_Id = item.VrstaPića_Id;
                    }

                }

                var query = from pića in context.Pića
                            join vrstaPića in context.Vrsta_pića on pića.VrstaPića_Id equals vrstaPića.VrstaPića_Id
                            join proizvođać in context.Proizvođać on pića.Proizvođać_Id equals proizvođać.Proizvođać_Id
                            join količinaPića in context.Količina_Pića on pića.Piće_Id equals količinaPića.Piće_Id
                            join količina in context.Količina on količinaPića.Količina_Id equals količina.Količina_Id
                            where pića.Piće_Id == novi.Piće_Id
                            orderby pića.Piće_Id
                            select new
                            {
                                pića,
                                vrstaPića,
                                proizvođać,
                                količinaPića,
                                količina
                            };

                foreach (var item in query)
                {
                    item.pića.Naziv_Pića = NazivPića;
                    item.pića.Opis = Opis;
                    item.pića.VrstaPića_Id = VrstaPića_Id;
                    item.pića.Proizvođać_Id = Proizvođać_Id;
                    item.pića.Postotak_Alkohola = PostotakAlkohola;


                }
                
                
                context.SaveChanges();
            }
            
            using (var context = new ModelPodataka())
                {

                
                var query = from pića in context.Pića
                                join vrstaPića in context.Vrsta_pića on pića.VrstaPića_Id equals vrstaPića.VrstaPića_Id
                                join proizvođać in context.Proizvođać on pića.Proizvođać_Id equals proizvođać.Proizvođać_Id
                                join količinaPića in context.Količina_Pića on pića.Piće_Id equals količinaPića.Piće_Id
                                join količina in context.Količina on količinaPića.Količina_Id equals količina.Količina_Id
                                where pića.Piće_Id == novi.Piće_Id &&količina.Količina1==novi.Količina1
                                orderby pića.Piće_Id
                                select new
                                {
                                    pića,
                                    vrstaPića,
                                    proizvođać,
                                    količinaPića,
                                    količina
                                };

                    foreach (var item in query)
                    {
                    
                    item.količinaPića.Cijena = Cijena;
                    
                }
                    context.SaveChanges();
            }
            MessageBox.Show("Uspješno ste ažurirali podatke.");
            Pregled_pića pregledPića = new Pregled_pića(email);
            Hide();
            pregledPića.ShowDialog();
            Close();
        }

        private void buttonSpremi_MouseHover(object sender, EventArgs e)
        {
            buttonSpremi.ForeColor = Color.Blue;
        }

        private void buttonSpremi_MouseLeave(object sender, EventArgs e)
        {
            buttonSpremi.ForeColor= Color.Black;
        }

        private void buttonOdustani_MouseHover(object sender, EventArgs e)
        {
            buttonOdustani.ForeColor= Color.Blue;
        }

        private void buttonOdustani_MouseLeave(object sender, EventArgs e)
        {
            buttonOdustani.ForeColor = Color.Black;
        }

        private void AžurirajPića_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "AžuriranjePića.htm");
            }
        }
    }
}
