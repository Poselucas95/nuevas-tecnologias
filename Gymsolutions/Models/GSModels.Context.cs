﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymSolutions.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GymSolutionEntities1 : DbContext
    {
        public GymSolutionEntities1()
            : base("name=GymSolutionEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Dias_Rutina> Dias_Rutina { get; set; }
        public virtual DbSet<Ejercicio> Ejercicio { get; set; }
        public virtual DbSet<Ejercicio_Categoria> Ejercicio_Categoria { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Peso_Usuario> Peso_Usuario { get; set; }
        public virtual DbSet<Rutina> Rutina { get; set; }
        public virtual DbSet<Dia_Ejercicio> Dia_Ejercicio { get; set; }
    }
}