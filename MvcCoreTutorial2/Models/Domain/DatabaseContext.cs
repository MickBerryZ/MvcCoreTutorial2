﻿using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MvcCoreTutorial2.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) :base(opts) 
        {
            
        }

        public DbSet<Person> Person { get; set; }  
    }
}
