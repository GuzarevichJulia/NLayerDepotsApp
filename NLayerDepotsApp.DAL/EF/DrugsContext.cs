namespace NLayerDepotsApp.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using NLayerDepotsApp.DAL.Entities;

    public partial class DrugsContext : DbContext
    {
        public DrugsContext()
            : base("name=DrugsContext")
        {
            Database.SetInitializer<DrugsContext>(new CreateDatabaseIfNotExists<DrugsContext>());
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Depot> Depot { get; set; }
        public virtual DbSet<DrugType> DrugType { get; set; }
        public virtual DbSet<DrugUnit> DrugUnit { get; set; }
        public virtual DbSet<SupplyCountry> SupplyCountry { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(e => e.SupplyCountry)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Depot>()
                .HasMany(e => e.SupplyCountry)
                .WithRequired(e => e.Depot)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DrugType>()
                .HasMany(e => e.DrugUnit)
                .WithRequired(e => e.DrugType)
                .WillCascadeOnDelete(false);
        }
    }
}
