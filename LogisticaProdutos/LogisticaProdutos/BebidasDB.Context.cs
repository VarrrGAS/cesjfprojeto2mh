﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogisticaProdutos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BebidasDB : DbContext
    {
        public BebidasDB()
            : base("name=BebidasDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Bebida> Bebida { get; set; }
        public DbSet<TipoBebida> TipoBebida { get; set; }
        public DbSet<TipoTransacao> TipoTransacao { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}