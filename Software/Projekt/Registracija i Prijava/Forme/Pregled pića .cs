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
    public partial class Pregled_pića : Form
    {
        bool mouseDown;
        private Point offset;
        public string email;
        
        public Pregled_pića(string Email)
        {
            InitializeComponent();
            this.KeyPreview = true;
            DohvatiPodatke();
            textBoxNaziv.Enabled = false;
            textBoxKoličina.Enabled = false;
            textBoxPostotakAlkohola.Enabled = false;
            textBoxVrstaPića.Enabled = false;
            textBoxProizvođać.Enabled = false;
            textBoxCijena.Enabled = false;
            email= Email;
            DohvatiUlogu();
            
        }

        private Korisnik DohvatiUlogu()
        {
            using (var context=new ModelPodataka())
            {
                var query = from i in context.Korisnik
                            where i.Email == email
                            select  i;
                return query.FirstOrDefault();
            }
        }

        private void DohvatiPodatke()
        {
            using (var context = new ModelPodataka())
            {
                var query = from pića in context.Pića
                            join vrstaPića in context.Vrsta_pića on pića.VrstaPića_Id equals vrstaPića.VrstaPića_Id
                            join proizvođać in context.Proizvođać on pića.Proizvođać_Id equals proizvođać.Proizvođać_Id
                            join količinaPića in context.Količina_Pića on pića.Piće_Id equals količinaPića.Piće_Id
                            join količina in context.Količina on količinaPića.Količina_Id equals količina.Količina_Id
                            orderby pića.Naziv_Pića
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


                dataGridViewPića.DataSource = query.ToList();
                dataGridViewPića.Columns["Piće_Id"].Visible = false;
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
            PočetnaStranica početnaStranica = new PočetnaStranica(email);
            Hide();
            početnaStranica.ShowDialog();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PočetnaStranica početnaStranica = new PočetnaStranica(email);
            Hide();
            početnaStranica.ShowDialog();
            Close();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (DohvatiUlogu().Uloga_Id == 4)

            {
                DodajPića dodajPićaForm = new DodajPića();
                dodajPićaForm.ShowDialog();
                DohvatiPodatke();
                
            }
            else {
                
                MessageBox.Show("Nemate ovlasti za tu operaciju");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DohvatiUlogu().Uloga_Id == 1)

            {
                
                MessageBox.Show("Nemate ovlasti za tu operaciju");
            }
            else
            {
                PregledPićaExtd odabrano = dataGridViewPića.CurrentRow.DataBoundItem as PregledPićaExtd;
                string Naziv_Pića = dataGridViewPića.CurrentRow.Cells[1].Value.ToString();
                AžurirajPića ažurirajPića = new AžurirajPića(odabrano, Naziv_Pića, email);
                Hide();
                ažurirajPića.ShowDialog();
                Close();
                DohvatiPodatke();
            }
        }

        private void buttonIzbriši_Click(object sender, EventArgs e)

        {
            if (DohvatiUlogu().Uloga_Id == 1)

            {
               
                MessageBox.Show("Nemate ovlasti za tu operaciju");
            }
            else
            {
                int Piće_Id = int.Parse(dataGridViewPića.CurrentRow.Cells[0].Value.ToString());
                string NazivPića = dataGridViewPića.CurrentRow.Cells[1].Value.ToString();
                string Količina = dataGridViewPića.CurrentRow.Cells[2].Value.ToString();

                using (var context = new ModelPodataka())
                {
                    var query = from pića in context.Pića
                                join vrstaPića in context.Vrsta_pića on pića.VrstaPića_Id equals vrstaPića.VrstaPića_Id
                                join proizvođać in context.Proizvođać on pića.Proizvođać_Id equals proizvođać.Proizvođać_Id
                                join količinaPića in context.Količina_Pića on pića.Piće_Id equals količinaPića.Piće_Id
                                join količina in context.Količina on količinaPića.Količina_Id equals količina.Količina_Id
                                where pića.Naziv_Pića == NazivPića && količina.Količina1 == Količina
                                orderby pića.Piće_Id

                                select new
                                {
                                    Pića = pića,
                                    Količina_Pića = količinaPića

                                };

                    foreach (var item in query)
                    {

                        context.Količina_Pića.Remove(item.Količina_Pića);

                    }

                    context.SaveChanges();
                }
                DohvatiPodatke();
            }
            
                
        }

        private void textBoxPretraživanje_TextChanged(object sender, EventArgs e)
        {
            string nazivPića = textBoxPretraživanje.Text;
            string nazivVrste = textBoxNaziv.Text;
            string nazivProizvodaca=textBoxProizvođać.Text;
          
           
            using (var context = new ModelPodataka())
            {
                var query = from pića in context.Pića
                            join vrstaPića in context.Vrsta_pića on pića.VrstaPića_Id equals vrstaPića.VrstaPića_Id
                            join proizvođać in context.Proizvođać on pića.Proizvođać_Id equals proizvođać.Proizvođać_Id
                            join količinaPića in context.Količina_Pića on pića.Piće_Id equals količinaPića.Piće_Id
                            join količina in context.Količina on količinaPića.Količina_Id equals količina.Količina_Id
                            where pića.Naziv_Pića.Contains(nazivPića) ||vrstaPića.Naziv_Vrste.Contains(nazivVrste)|| proizvođać.Naziv_Proizvođaća.Contains(nazivProizvodaca)
                            orderby pića.Naziv_Pića
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

              
                dataGridViewPića.DataSource = query.ToList();
                dataGridViewPića.Columns["Piće_Id"].Visible = false;
            }
        }

        private void panelDrag_Paint(object sender, PaintEventArgs e)
        {
           PregledPićaExtd odabrano = dataGridViewPića.CurrentRow.DataBoundItem as PregledPićaExtd;
            if (odabrano != null)
            {
                textBoxNaziv.Text = odabrano.Naziv_Pića.ToString();
                textBoxKoličina.Text = odabrano.Količina1.ToString();
                textBoxPostotakAlkohola.Text = odabrano.Postotak_Alkohola.ToString();
                textBoxVrstaPića.Text = odabrano.Naziv_Vrste.ToString();
                textBoxProizvođać.Text = odabrano.Naziv_Proizvođaća.ToString();
                textBoxCijena.Text = odabrano.Cijena.ToString();
                textBoxOpis.Text = odabrano.Opis.ToString();
            }
        }

        private void dataGridViewPića_SelectionChanged(object sender, EventArgs e)
        {
            PregledPićaExtd odabrano = dataGridViewPića.CurrentRow.DataBoundItem as PregledPićaExtd;
            textBoxNaziv.Text = odabrano.Naziv_Pića.ToString();
            textBoxKoličina.Text = odabrano.Količina1.ToString();
            textBoxPostotakAlkohola.Text = odabrano.Postotak_Alkohola.ToString();
            textBoxVrstaPića.Text = odabrano.Naziv_Vrste.ToString();
            textBoxProizvođać.Text = odabrano.Naziv_Proizvođaća.ToString();
            textBoxCijena.Text = odabrano.Cijena.ToString();
            textBoxOpis.Text = odabrano.Opis.ToString();
        }

        private void labelIzlaz_MouseHover(object sender, EventArgs e)
        {
            labelIzlaz.ForeColor = Color.Blue;
        }

        private void labelIzlaz_MouseLeave(object sender, EventArgs e)
        {
            labelIzlaz.ForeColor = Color.Black;
        }

        private void buttonDodaj_MouseHover(object sender, EventArgs e)
        {
            buttonDodaj.ForeColor = Color.Blue;
        }

        private void buttonDodaj_MouseLeave(object sender, EventArgs e)
        {
            buttonDodaj.ForeColor = Color.Black;
        }

        private void buttonAžuriraj_MouseHover(object sender, EventArgs e)
        {
            buttonAžuriraj.ForeColor = Color.Blue;
        }

        private void buttonAžuriraj_MouseLeave(object sender, EventArgs e)
        {
            buttonAžuriraj.ForeColor= Color.Black;
        }

        private void buttonIzbriši_MouseHover(object sender, EventArgs e)
        {
            buttonIzbriši.ForeColor = Color.Blue;
        }

        private void buttonIzbriši_MouseLeave(object sender, EventArgs e)
        {
            buttonIzbriši.ForeColor= Color.Black;
        }

       

        private void Pregled_pića_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "PregledPića.htm");
            }
        }
    }
}
