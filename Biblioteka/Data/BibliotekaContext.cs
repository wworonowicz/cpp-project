﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Models
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext (DbContextOptions<BibliotekaContext> options)
            : base(options)
        {
        }

        public DbSet<Biblioteka.Models.Uzytkownicy> Uzytkownicy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uzytkownicy>().ToTable("Course");
        }
    }
}
