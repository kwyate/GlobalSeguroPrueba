﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlobalSegurosPrueba.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pruebaGloblaSegurosEntities : DbContext
    {
        public pruebaGloblaSegurosEntities()
            : base("name=pruebaGloblaSegurosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Empleado_Tienda> Empleado_Tienda { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Tienda> Tiendas { get; set; }
    }
}
