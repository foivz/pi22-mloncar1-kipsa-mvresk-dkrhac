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

namespace Registracija_i_Prijava.Forme
{
    public partial class Pregled_pića : Form
    {
        bool mouseDown;
        private Point offset;
        public Pregled_pića()
        {
            InitializeComponent();
            DohvatiPodatke();
            textBoxNaziv.Enabled = false;
            textBoxKoličina.Enabled = false;
            textBoxPostotakAlkohola.Enabled = false;
            textBoxVrstaPića.Enabled = false;
            textBoxProizvođać.Enabled = false;
            textBoxCijena.Enabled = false;
        }

        private void DohvatiPodatke()
        {
            using (var context = new PI2257_DBEntities3())
            {
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


                dataGridViewPića.DataSource = query.ToList();
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
            Forme.PočetnaStranica početnaStranica = new PočetnaStranica();
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

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            DodajPića dodajPićaForm = new DodajPića();
            dodajPićaForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PregledPićaExtd odabrano = dataGridViewPića.CurrentRow.DataBoundItem as PregledPićaExtd;
            string Naziv_Pića = dataGridViewPića.CurrentRow.Cells[1].Value.ToString();
            AžurirajPića ažurirajPića = new AžurirajPića(odabrano, Naziv_Pića);
            Hide();
            ažurirajPića.ShowDialog();
            Close();
            DohvatiPodatke();
        }

        private void buttonIzbriši_Click(object sender, EventArgs e)
        {
            int Piće_Id = int.Parse(dataGridViewPića.CurrentRow.Cells[0].Value.ToString());
            string NazivPića = dataGridViewPića.CurrentRow.Cells[1].Value.ToString();
            string Količina = dataGridViewPića.CurrentRow.Cells[2].Value.ToString();
           // PićaExtd odaberi = dataGridViewPića.CurrentRow.DataBoundItem as PićaExtd;
            using (var context = new PI2257_DBEntities3())
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
                                Količina_Pića=količinaPića

                            };

                foreach (var item in query)
                {

                    context.Pića.Remove(item.Pića);
                    context.Količina_Pića.Remove(item.Količina_Pića);
                    


                }

                context.SaveChanges();
            }
            DohvatiPodatke();
        }

        private void textBoxPretraživanje_TextChanged(object sender, EventArgs e)
        {
            string sadržajPretraživanja = textBoxPretraživanje.Text;
            using (var context = new PI2257_DBEntities3())
            {
                var query = from pića in context.Pića
                            join vrstaPića in context.Vrsta_pića on pića.VrstaPića_Id equals vrstaPića.VrstaPića_Id
                            join proizvođać in context.Proizvođać on pića.Proizvođać_Id equals proizvođać.Proizvođać_Id
                            join količinaPića in context.Količina_Pića on pića.Piće_Id equals količinaPića.Piće_Id
                            join količina in context.Količina on količinaPića.Količina_Id equals količina.Količina_Id
                            where pića.Naziv_Pića.Contains(sadržajPretraživanja)
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


                dataGridViewPića.DataSource = query.ToList();
            }
        }

        private void panelDrag_Paint(object sender, PaintEventArgs e)
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
    }
}
