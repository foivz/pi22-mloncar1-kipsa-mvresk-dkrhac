﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelPodataka : DbContext
    {
        public ModelPodataka()
            : base("name=ModelPodataka")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dobavljač> Dobavljač { get; set; }
        public virtual DbSet<Država> Država { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Količina> Količina { get; set; }
        public virtual DbSet<Količina_Pića> Količina_Pića { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Način_Plaćanja> Način_Plaćanja { get; set; }
        public virtual DbSet<Narudžba> Narudžba { get; set; }
        public virtual DbSet<Narudžba_Dobavljač> Narudžba_Dobavljač { get; set; }
        public virtual DbSet<Narudžba_Kupac> Narudžba_Kupac { get; set; }
        public virtual DbSet<Pića> Pića { get; set; }
        public virtual DbSet<Proizvođać> Proizvođać { get; set; }
        public virtual DbSet<Račun> Račun { get; set; }
        public virtual DbSet<Raspored_rada> Raspored_rada { get; set; }
        public virtual DbSet<Recenzije> Recenzije { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Vrsta_pića> Vrsta_pića { get; set; }
    }
}
