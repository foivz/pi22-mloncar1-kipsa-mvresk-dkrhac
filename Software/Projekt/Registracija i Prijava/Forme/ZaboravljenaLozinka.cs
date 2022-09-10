using Registracija_i_Prijava.DodatneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserHelp;

namespace Registracija_i_Prijava.Forme
{
    

    public partial class ZaboravljenaLozinka : Form
    {
        string randomCode;
        public static string to;
        bool mouseDown;
        private Point offset;
        public ZaboravljenaLozinka()
        {
            InitializeComponent();
            this.KeyPreview = true;
            
        }

        private void paneldrag_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void paneldrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point trenutnaPozicijaEkrana = PointToScreen(e.Location);
                Location = new Point(trenutnaPozicijaEkrana.X - offset.X, trenutnaPozicijaEkrana.Y - offset.Y);
            }
        }

        private void paneldrag_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void labelNatrag_Click(object sender, EventArgs e)
        {
            Prijava prijava = new Prijava();
            Hide();
            prijava.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (randomCode == (textBoxKodPoslannaMail.Text).ToString())
            {
                to=textBoxEmail.Text;
                UnosNoveLozinke novaLozinka = new UnosNoveLozinke(to);
                Hide();
                novaLozinka.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Unjeli ste krivi kod");
            }
        }

        private void buttonPošaljinaMail_Click(object sender, EventArgs e)
        {
            
            string from, pass, messagebody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message=new MailMessage();
            from = "viksluzbazakorisnike@gmail.com";
            pass = "zxveotmtvpevetss";
            messagebody = $"Vaš kod za resetiranje lozinke je {randomCode}. ";
            to = textBoxEmail.Text;
            try
            {
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messagebody;
                message.Subject = "Kod za resetiranje lozinke";
            }
            catch {
                MessageBox.Show("Krivi format e-mail adrese");
            }
            SmtpClient smtp=new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Kod je uspješno poslan");
            }
            catch
            {
               
            }

        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "";
        }

        private void textBoxKodPoslannaMail_Click(object sender, EventArgs e)
        {
            textBoxKodPoslannaMail.Text = "";
        }

        private void buttonPošaljinaMail_MouseHover(object sender, EventArgs e)
        {
            buttonPošaljinaMail.ForeColor = Color.Blue;
        }

        private void buttonPošaljinaMail_MouseLeave(object sender, EventArgs e)
        {
            buttonPošaljinaMail.ForeColor = Color.Black;
        }

        private void buttonVerificirajKod_MouseHover(object sender, EventArgs e)
        {
            buttonVerificirajKod.ForeColor = Color.Blue;
        }

        private void buttonVerificirajKod_MouseLeave(object sender, EventArgs e)
        {
            buttonVerificirajKod.ForeColor = Color.Black;
        }

        private void labelNatrag_MouseHover(object sender, EventArgs e)
        {
            labelNatrag.ForeColor = Color.Blue;
        }

        private void labelNatrag_MouseLeave(object sender, EventArgs e)
        {
            labelNatrag.ForeColor = Color.Black;
        }

        private void pictureBoxLogoVIK_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "E-mail";
            textBoxKodPoslannaMail.Text = "Kod poslan na E-mail";
        }

        private void ZaboravljenaLozinka_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                UserHelpp help = new UserHelpp();
                help.OtvoriUserHelp(this, "ZaboravljenaLozinka.htm");

            }
        }
    }
}
