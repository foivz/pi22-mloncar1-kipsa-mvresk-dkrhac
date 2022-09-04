//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            this.Račun = new HashSet<Račun>();
            this.Raspored_rada = new HashSet<Raspored_rada>();
            this.Recenzije = new HashSet<Recenzije>();
        }
    
        public int Korisnik_Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int Broj_Mobitela { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }
        public string Korisničko_Ime { get; set; }
        public string Lozinka { get; set; }
        public string Ponovljena_Lozinka { get; set; }
        public int Uloga_Id { get; set; }
    
        public virtual Uloga Uloga { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Račun> Račun { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raspored_rada> Raspored_rada { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recenzije> Recenzije { get; set; }
    }
}
