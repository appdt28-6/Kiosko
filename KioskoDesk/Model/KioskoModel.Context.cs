﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KioskoDesk.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KoiscoEntities : DbContext
    {
        public KoiscoEntities()
            : base("name=KoiscoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BUSCA_FOLIOS> BUSCA_FOLIOS { get; set; }
        public virtual DbSet<POLIZAS> POLIZAS { get; set; }
        public virtual DbSet<POLIZA_INTGRANTES> POLIZA_INTGRANTES { get; set; }
        public virtual DbSet<vis_POLIZA_INTEGRANTE> vis_POLIZA_INTEGRANTE { get; set; }
    }
}
