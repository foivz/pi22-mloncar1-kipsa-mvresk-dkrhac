using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validacija
{
    public class ValidacijaRegistracije
    {
        private string Poruka { get; set; }
        public string ValidirajKorisnika(string[] PodatakKorisnika)
        {
            Poruka = "";
            if (PodatakKorisnika[0].Length == 0)
            {
                Poruka += "Polje za unos imena je prazno.Morate unjeti ime!!!\n";
            }
            if (PodatakKorisnika[1].Length == 0)
            {
                Poruka += "Polje za unos prezimena je prazno.Morate unjeti prezime!!!\n";
            }
            
            if (!Regex.IsMatch(PodatakKorisnika[2], "^.+@.+\\..+$"))
            {
                Poruka += "Pogrešan format e-maila.E-mail mora biti formata korisničkoime@nazivdomene.ekstenzija!!!\n";
                
            }
            if (PodatakKorisnika[3].Length == 0 && PodatakKorisnika[3].Length<9 && PodatakKorisnika[3].Length>14)
            {
                Poruka += "Neispravan broj mobitela.Broj mobitela mora sadržavati između 10 i 13 znamenki!!!\n";
            }
            if (PodatakKorisnika[4].Length == 0)
            {
                Poruka += "Polje za unos adrese je prazno.Morate unjeti adresu!!!\n";
            }
            if ((PodatakKorisnika[5] != "muški") && (PodatakKorisnika[5] != "ženski") && (PodatakKorisnika[5] != "Ne želim reći") && (PodatakKorisnika[5] != "Muški") && (PodatakKorisnika[5] != "Ženski") && (PodatakKorisnika[5] != "ne želim reći")) 
            {
                Poruka += "Neispravan unos.Spol može biti muški , ženski ili ne želim reći!!!\n";
            }
            if (PodatakKorisnika[6].Length < 5) 
            {
                Poruka += "Neispravan unos.Korisničko ime mora biti najmanje 5 znakova!!!\n";
            }
            if (PodatakKorisnika[7].Length < 7) { 
                Poruka += "Neispravan unos.Lozinka mora biti najmanje 7 znakova!!!\n"; 
            }
            if (PodatakKorisnika[8] != PodatakKorisnika[7]) { 
                Poruka+= "Lozinka i ponovljena lozinka nisu identične!!!\n"; 
            }
            return Poruka;
        }

    }
}
