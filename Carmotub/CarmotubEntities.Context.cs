﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Carmotub
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarmotubEntities : DbContext
    {
        public CarmotubEntities()
            : base("name=CarmotubEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BackupDatabase> BackupDatabase { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Intervention> Intervention { get; set; }
        public virtual DbSet<PhotoClient> PhotoClient { get; set; }
    }
}