﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSTOK.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcDboStokEntities : DbContext
    {
        public MvcDboStokEntities()
            : base("name=MvcDboStokEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLKATEGORİLER> TBLKATEGORİLER { get; set; }
        public virtual DbSet<TBLMUSTERI> TBLMUSTERI { get; set; }
        public virtual DbSet<TBLSATIS> TBLSATIS { get; set; }
        public virtual DbSet<TBLURUN> TBLURUN { get; set; }
    }
}
