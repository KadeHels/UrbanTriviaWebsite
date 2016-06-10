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
            : base("WordConnection")
        {

        }
        public DbSet<Word> Words { get; set; }
    }
}