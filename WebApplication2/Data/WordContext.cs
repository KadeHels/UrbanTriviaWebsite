using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Data
{
    public class WordContext : DbContext
    {
        public WordContext() 
            //Switch the connection string based on where the program is running
            : base("WordDatabase")
        {
            //Don't want to load lazy load
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<WordContext, WordConfigurationMigration>()
                );

        }
        public DbSet<Word> Words { get; set; }
    }
}