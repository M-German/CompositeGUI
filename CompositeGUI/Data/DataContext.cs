using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CompositeGUI.Data
{
    class DataContext: DbContext
    {
        public DataContext()
            : base("DbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<GA_Settings> GA_Settings { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Limits> Limits { get; set; }
        public DbSet<Composite> Composites { get; set; }
        public DbSet<CstResult> CstResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<CstResult>()
                .HasRequired<Composite>(r => r.Composite)
                .WithMany(c => c.CstResults)
                .HasForeignKey<int>(r => r.CompositeId);
        }
    }
}

