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
    
    public partial class Raspored_rada
    {
        public int Raspored_Id { get; set; }
        public System.DateTime Datum { get; set; }
        public System.TimeSpan VrijemePočetka_Smjene { get; set; }
        public System.TimeSpan VrijemeZavršetka_Smjene { get; set; }
        public int Korisnik_Id { get; set; }
    
        public virtual Korisnik Korisnik { get; set; }
    }
}