using InDesingEntity.CC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace InDesignModel
{
    public class InDesignContext : DbContext
    {
        public InDesignContext(DbContextOptions<InDesignContext> options)
            : base(options)
        {
           
        }

        public InDesignContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=14.0.2027.2; Database=InDesign; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Client_Contact> Client_Contact { get; set; }
    }
}
