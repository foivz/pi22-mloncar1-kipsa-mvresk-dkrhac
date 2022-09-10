using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registracija_i_Prijava.DodatneKlase
{
    public class NaručiExtd
    {
        public int Račun_Id { get; set; }
        // public int Korisnik_Id { get; set; }
        public int Piće_Id { get; set; }
        public string Naziv_Pića { get; set; }
        public string Količina { get; set; }
        public int Komada { get; set; }
        public string Cijena { get; set; }
        public string Ulica { get; set; }
        public int Grad_Id { get; set; }
        public string NazivGrada { get; set; }
        public System.DateTime Datum_Isporuke { get; set; }
        public bool Izvršeno { get; set; }
        public string rmail { get; set; }
        public string Naručeno { get; set; }
       
    }
}
