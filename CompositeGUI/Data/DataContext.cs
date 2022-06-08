using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CompositeGUI.Data
{
    class DataContext: DbContext
    {
        public DataContext()
            : base("DbConnection")
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<GA_Settings> GA_Settings { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Limits> Limits { get; set; }
        public DbSet<Composite> Composites { get; set; }
    }
}
