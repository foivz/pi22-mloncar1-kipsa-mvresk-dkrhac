using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using Registracija_i_Prijava.Forme;
using Registracija_i_Prijava.DodatneKlase;
using UserHelp;

namespace Registracija_i_Prijava.Forme
{

    public partial class NaručiPića : Form
    {
        public NaručiExtd dohvatisDrugeForme;
        bool mouseDown;
        private Point offset;
        public string email;

        public int korisnikId;
        public int količinaId = 1;
        public string Cijena;
        public bool postoji = false;
        int Komada = 6;
        string ulica = "";






        public NaručiPića(string Email)
        {

            InitializeComponent();
            DohvatiPića();
            DohvatiKoličinu();
            DohvatiNaručeno();
            DohvatiGradove();
            DohvatiPićazaProvjeru();
            email = Email;
            DohvatiUlogu();
            this.KeyPreview = true;



            using (var context = new ModelPodataka())
            {
                foreach (var item in context.Korisnik)
                {
                    if (email == (item.Email).ToString())
                    {
                        korisnikId = item.Korisnik_Id;
                    }
                }

                var query = from r in context.Račun
                            join nk in context.Narudžba_Kupac.AsEnumerable() on r.Račun_Id equals nk.Račun_Id
                            join p in context.Pića.AsEnumerable() on nk.Piće_Id equals p.Piće_Id
                            join g in context.Grad.AsEnumerable() on r.Grad_Id equals g.Grad_Id
                            join kp in context.Količina_Pića.AsEnumerable() on p.Piće_Id equals kp.Piće_Id
                            join k in context.Količina.AsEnumerable() on kp.Količina_Id equals k.Količina_Id
                            join ko in context.Korisnik on r.Korisnik_Id equals ko.Korisnik_Id
                            where r.Izvršeno == false && ko.Email == email && nk.Količina_Id == kp.Količina_Id
                            orderby r.Datum_Isporuke
                            select new NaručiExtd
                            {
                                Račun_Id = r.Račun_Id,
                                Piće_Id = p.Piće_Id,
                                Naziv_Pića = p.Naziv_Pića,
                                Količina = k.Količina1,
                                Komada = nk.Količina,
                                Cijena = kp.Cijena,
                                Ulica = r.Ulica,
                                rmail = ko.Email,
                                Grad_Id = g.Grad_Id,
                                NazivGrada = g.Ime_Grada,
                                Datum_Isporuke = r.Datum_Isporuke,
                                Izvršeno = r.Izvršeno,
                                Naručeno = nk.Naručeno



                            };

                dataGridViewNaručiPića.DataSource = query.ToList();
                dataGridViewNaručiPića.Columns["Račun_Id"].Visible = false;
                dataGridViewNaručiPića.Columns["Piće_Id"].Visible = false;
                dataGridViewNaručiPića.Columns["Grad_Id"].Visible = false;




            }
        }

        private Korisnik DohvatiUlogu()
        {
            using (var context = new ModelPodataka())
            {
                var query = from i in context.Korisnik
                            where i.Email == email
                            select i;
                return query.FirstOrDefault();
            }
        }

        private void DohvatiPićazaProvjeru()
        {
            string Količina = comboBoxKoličina.SelectedItem.ToString();
            string NazivPića = comboBoxNazivPića.SelectedItem.ToString();
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Pića
                            join kp in context.Količina_Pića on p.Piće_Id equals kp.Piće_Id
                            join k in context.Količina on kp.Količina_Id equals k.Količina_Id
                            select new
                            {
                                p,
                                kp,
                                k
                            };


                foreach (var item2 in query)
                {


                    if (item2.p.Naziv_Pića == NazivPića && item2.k.Količina1 == Količina)
                    {

                        postoji = true;
                    }
                }


            }


        }

        private void DohvatiGradove()
        {
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Grad
                            select p.Ime_Grada.ToString();
                comboBoxGrad.DataSource = query.Distinct().ToList();

            }
        }

        private void DohvatiNaručeno()
        {
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Narudžba_Kupac
                            select p.Naručeno.ToString();
                comboBoxNaručeno.DataSource = query.Distinct().ToList();

            }
        }


        private void DohvatiPića()
        {
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Pića
                            select p.Naziv_Pića.ToString();
                comboBoxNazivPića.DataSource = query.Distinct().ToList();

            }
        }
        private void DohvatiKoličinu()
        {
            using (var context = new ModelPodataka())
            {
                var query = from p in context.Količina
                            select p.Količina1.ToString();
                comboBoxKoličina.DataSource = query.Distinct().ToList();
            }
        }
       

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point trenutnaPozicijaEkrana = PointToScreen(e.Location);
                Location = new Point(trenutnaPozicijaEkrana.X - offset.X, trenutnaPozicijaEkrana.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void buttonSpremi_Click(object sender, EventArgs e)
        {


            string Količina = comboBoxKoličina.SelectedItem.ToString();
            string NazivPića = comboBoxNazivPića.SelectedItem.ToString();
            int piće_Id = 1;
            int grad_id = 1;


            DateTime datumIsporuke = dateTimePickerDatumIsporuke.Value;
            string status = "U pripremi";

            string NazivGrada = comboBoxGrad.SelectedItem.ToString();
            try
            {
                Komada = int.Parse(textBoxKomada.Text);
                ulica = textBoxUlica.Text;
            }
            catch { MessageBox.Show("Niste popunili sva polja"); }
            using (var context = new ModelPodataka())
            {
                foreach (var item in context.Grad)
                {
                    if ((item.Ime_Grada).ToString() == NazivGrada)
                    {
                        grad_id = item.Grad_Id;
                    }
                }



                foreach (var item in context.Pića.ToList())
                {
                    if (NazivPića == (item.Naziv_Pića).ToString())
                    {
                        piće_Id = item.Piće_Id;
                    }
                }

                foreach (var item in context.Količina.ToList())
                {
                    if (Količina == (item.Količina1).ToString())
                    {
                        količinaId = item.Količina_Id;
                    }
                }

                var query = from r in context.Račun
                            join nk in context.Narudžba_Kupac.AsEnumerable() on r.Račun_Id equals nk.Račun_Id
                            join p in context.Pića.AsEnumerable() on nk.Piće_Id equals p.Piće_Id
                            join g in context.Grad.AsEnumerable() on r.Grad_Id equals g.Grad_Id
                            join kp in context.Količina_Pića.AsEnumerable() on p.Piće_Id equals kp.Piće_Id
                            join k in context.Količina.AsEnumerable() on kp.Količina_Id equals k.Količina_Id
                            join ko in context.Korisnik on r.Korisnik_Id equals ko.Korisnik_Id
                            where r.Izvršeno == false && ko.Email == email && nk.Količina_Id == količinaId
                            select new NaručiExtd
                            {

                                Račun_Id = r.Račun_Id,
                                Piće_Id = p.Piće_Id,
                                Naziv_Pića = p.Naziv_Pića,
                                Količina = k.Količina1,
                                Komada = nk.Količina,
                                Cijena = kp.Cijena,
                                Ulica = r.Ulica,
                                rmail = ko.Email,
                                Grad_Id = g.Grad_Id,
                                NazivGrada = g.Ime_Grada,
                                Datum_Isporuke = r.Datum_Isporuke,
                                Izvršeno = r.Izvršeno,
                                Naručeno = nk.Naručeno



                            };


                DohvatiPićazaProvjeru();


                if (postoji == false)
                {
                    MessageBox.Show("Odabrano piće ne postoji u toj količini");
                }
                else
                {

                    Račun ra = new Račun()
                    {
                        Korisnik_Id = korisnikId,
                        Ulica = ulica,
                        Grad_Id = grad_id,
                        Država_Id = 1,
                        Datum_Isporuke = datumIsporuke,
                        Izvršeno = false,
                        Plaćanje_Id = 1
                    };
                    Narudžba_Kupac n = new Narudžba_Kupac()
                    {
                        Piće_Id = piće_Id,
                        Količina_Id = količinaId,
                        Količina = Komada,
                        Naručeno = status

                    };

                    context.Račun.Add(ra);
                    context.Narudžba_Kupac.Add(n);

                    context.SaveChanges();
                    MessageBox.Show("Uspješno ste unjeli piće");

                }
            }
            postoji = false;

        }


        private void labelIzlaz_Click(object sender, EventArgs e)
        {
            PočetnaStranica početnaStranica = new PočetnaStranica(email);
            Hide();
            početnaStranica.ShowDialog();
            Close();
        }

        private void pictureBoxIzlaz_Click(object sender, EventArgs e)
        {
            Forme.PočetnaStranica početnaStranica = new PočetnaStranica(email);
            Hide();
            početnaStranica.ShowDialog();
            Close();
        }

        private void buttonPretraži_Click(object sender, EventArgs e)
        {
            using (var context = new ModelPodataka())
            {
                string cmbnaručeno = comboBoxNaručeno.SelectedItem.ToString();
                
                var query = from r in context.Račun
                            join nk in context.Narudžba_Kupac.AsEnumerable() on r.Račun_Id equals nk.Račun_Id
                            join p in context.Pića.AsEnumerable() on nk.Piće_Id equals p.Piće_Id
                            join g in context.Grad.AsEnumerable() on r.Grad_Id equals g.Grad_Id
                            join kp in context.Količina_Pića.AsEnumerable() on p.Piće_Id equals kp.Piće_Id
                            join k in context.Količina.AsEnumerable() on kp.Količina_Id equals k.Količina_Id
                            join ko in context.Korisnik on r.Korisnik_Id equals ko.Korisnik_Id
                            where r.Izvršeno == false && ko.Email == email && nk.Naručeno == cmbnaručeno && nk.Količina_Id == kp.Količina_Id
                            select new NaručiExtd
                            {
                                Račun_Id = r.Račun_Id,
                                Piće_Id = p.Piće_Id,
                                Naziv_Pića = p.Naziv_Pića,
                                Količina = k.Količina1,
                                Komada = nk.Količina,
                                Cijena = kp.Cijena,
                                Ulica = r.Ulica,
                                rmail = ko.Email,
                                Grad_Id = g.Grad_Id,
                                NazivGrada = g.Ime_Grada,
                                Datum_Isporuke = r.Datum_Isporuke,
                                Izvršeno = r.Izvršeno,
                                Naručeno = nk.Naručeno



                            };


                dataGridViewNaručiPića.DataSource = query.ToList();
                dataGridViewNaručiPića.Columns["Račun_Id"].Visible = false;
                dataGridViewNaručiPića.Columns["Piće_Id"].Visible = false;
                dataGridViewNaručiPića.Columns["Grad_Id"].Visible = false;




            }
        }
       

        private void buttonNaruči_Click(object sender, EventArgs e)
        {
            NaručiExtd odaberi = dataGridViewNaručiPića.CurrentRow.DataBoundItem as NaručiExtd;
           
            if (odaberi != null && odaberi.Naručeno == "U pripremi")
            {
                using (var context = new ModelPodataka())
                {
                    
                    var query = from ko in context.Korisnik
                                join r in context.Račun on ko.Korisnik_Id equals r.Korisnik_Id
                                join nk in context.Narudžba_Kupac on r.Račun_Id equals nk.Račun_Id
                                where r.Izvršeno == false && ko.Email == email && nk.Naručeno == "U pripremi" && r.Datum_Isporuke == odaberi.Datum_Isporuke
                                select new
                                {
                                    ko,
                                    r,
                                    nk
                                };
                    foreach (var k in query)
                    {
                        k.nk.Naručeno = "Naručeno";

                    }
                    context.SaveChanges();


                }
                
                MessageBox.Show("Uspješno ste naručili pića");

            }


            else
            {
                MessageBox.Show("Ovo ste već naručili");
            }

        }

        private void buttonDodajuIzvršene_Click(object sender, EventArgs e)

        {

                NaručiExtd odaberi = dataGridViewNaručiPića.CurrentRow.DataBoundItem as NaručiExtd;
             
                if (odaberi != null && odaberi.Izvršeno == false)
                {
                    using (var context = new ModelPodataka())
                    {
                        
                        var query = from ko in context.Korisnik
                                    join r in context.Račun on ko.Korisnik_Id equals r.Korisnik_Id
                                    join nk in context.Narudžba_Kupac on r.Račun_Id equals nk.Račun_Id
                                    where r.Izvršeno == false && ko.Email == email && nk.Naručeno == "Naručeno" && r.Datum_Isporuke == odaberi.Datum_Isporuke
                                    select new
                                    {
                                        ko,
                                        r,
                                        nk
                                    };
                        foreach (var k in query)
                        {
                            k.r.Izvršeno = true;



                        }
                        context.SaveChanges();


                    }
                   

                    MessageBox.Show("Uspješno dodano u izvršene");
                }


                else
                {
                    MessageBox.Show("Ovo ste već naručili");
                }
            }

        private void buttonPretraži_MouseHover(object sender, EventArgs e)
        {
            buttonPretraži.ForeColor= Color.Blue;
        }

        private void buttonPretraži_MouseLeave(object sender, EventArgs e)
        {
            buttonPretraži.ForeColor = Color.Black;
        }

        private void buttonSpremi_MouseHover(object sender, EventArgs e)
        {
            buttonSpremi.ForeColor= Color.Blue;
        }

        private void buttonSpremi_MouseLeave(object sender, EventArgs e)
        {
            buttonSpremi.ForeColor = Color.Black;
        }

        private void buttonNaruči_MouseHover(object sender, EventArgs e)
        {
            buttonNaruči.ForeColor= Color.Blue; 
        }

        private void buttonNaruči_MouseLeave(object sender, EventArgs e)
        {
            buttonNaruči.ForeColor=Color.Black;
        }

        private void buttonDodajuIzvršene_MouseHover(object sender, EventArgs e)
        {
            buttonDodajuIzvršene.ForeColor= Color.Blue; 
        }

        private void buttonDodajuIzvršene_MouseLeave(object sender, EventArgs e)
        {
            buttonDodajuIzvršene.ForeColor = Color.Black;
        }

        private void labelIzlaz_MouseHover(object sender, EventArgs e)
        {
            labelIzlaz.ForeColor= Color.Blue;
        }

        private void labelIzlaz_MouseLeave(object sender, EventArgs e)
        {
            labelIzlaz.ForeColor = Color.Black;
        }

        private void NaručiPića_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F1)
            {

                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "Naruči.htm");
            }
        }
    }
    }

