//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Narudžba_Kupac
    {
        public int Račun_Id { get; set; }
        public int Piće_Id { get; set; }
        public int Količina { get; set; }
    
        public virtual Pića Pića { get; set; }
        public virtual Račun Račun { get; set; }
    }
}
