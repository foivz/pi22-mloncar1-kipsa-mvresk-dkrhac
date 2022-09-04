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

namespace Registracija_i_Prijava.Forme
{
    public partial class DodajPića : Form
    {
        bool mouseDown;
        private Point offset;
        public DodajPića()
        {
            InitializeComponent();
            comboBoxVrstaPićaPodaci();
            comboBoxKoličinaPodaci();
            comboBoxDohvatiProizvođaće();
           
        }

        private void comboBoxDohvatiProizvođaće()
        {
            using (var context = new PI2257_DBEntities3())
            {
                var query = from p in context.Proizvođać
                            select p.Naziv_Proizvođaća.ToString();
                comboBoxProizvođać.DataSource = query.Distinct().ToList();
            }
        }

        private void comboBoxKoličinaPodaci()
        {
            using (var context = new PI2257_DBEntities3())
            {
                var query = from p in context.Količina
                            select p.Količina1.ToString();
               comboBoxKoličina.DataSource = query.Distinct().ToList();
            }
        }

        private void comboBoxVrstaPićaPodaci()
        {
            using(var context=new PI2257_DBEntities3())
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
            using (var context = new PI2257_DBEntities3())
            {
                int VrstaPića_Id =1;
                int Proizvođać_Id = 1;
                int KoličinaPića_Id=1;
                
                string Cijena=textBoxCijena.Text;
                string NazivPića = textBoxNaziv.Text;
                string Količina = comboBoxKoličina.SelectedItem.ToString();
                Convert.ToDecimal(Količina);
                MessageBox.Show(Količina.ToString());
                foreach (var item in context.Količina)
                {
                    if (Količina == (item.Količina1).ToString())
                    {
                        KoličinaPića_Id = item.Količina_Id;
                        
                    }
                 
                }

                MessageBox.Show(KoličinaPića_Id.ToString());
                string PostotakAlkohola=textBoxPostotakAlkohola.Text;
                
                string VrstaPića=comboBoxVrstaPića.SelectedItem.ToString();
                foreach(var item in context.Vrsta_pića)
                {
                    if (VrstaPića == (item.Naziv_Vrste).ToString())
                    {
                         VrstaPića_Id = item.VrstaPića_Id;
                    }
                    
                }

                string Proizvođač = comboBoxProizvođać.SelectedItem.ToString();
                
                    foreach(var item in context.Proizvođać)
                    {
                        if (Proizvođač == (item.Naziv_Proizvođaća).ToString())
                        {
                            Proizvođać_Id = item.Proizvođać_Id;
                        }
                    }
                
               
                
                string Opis=textBoxOpis.Text;

                Pića novo = new Pića()
                {
                    Naziv_Pića = NazivPića,
                    Postotak_Alkohola = PostotakAlkohola,
                    VrstaPića_Id=VrstaPića_Id,
                    Proizvođać_Id=Proizvođać_Id,
                    Opis = Opis
                };
                Količina_Pića novi = new Količina_Pića()
                {
                    
                    Količina_Id=KoličinaPića_Id,
                    Cijena=Cijena
                    
                    
                    
                    
                    

                };
              
                context.Pića.Add(novo);
                context.Količina_Pića.Add(novi);
                context.SaveChanges();
            }

            Pregled_pića pregledPića = new Pregled_pića();
            Hide();
            pregledPića.ShowDialog();
            Close();
        }
    }
}
