using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Models;

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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uzytkownicy>().ToTable("Course");
            modelBuilder.Entity<Wypozyczenie>().ToTable("Wypozyczenie");
            modelBuilder.Entity<Wypozyczenie>()
               .HasKey(t => new { t.UzytkownikID, t.BookID });

            //modelBuilder.Entity<Wypozyczenie>()
              //  .HasOne(w => w.Uzytkownik)
                //.WithMany(u => u.Wypozyczenie)
                //.HasForeignKey(w => w.UzytkownikID);

            modelBuilder.Entity<Wypozyczenie>()
                .HasOne(w => w.Book)
                .WithMany(b => b.Wypozyczenie)
                .HasForeignKey(w => w.BookID);
        }

        public DbSet<Biblioteka.Models.Books> Books { get; set; }

        public class Wypozyczenie
        {
            public string UzytkownikID { get; set; }

            public int BookID { get; set; }
            public Books Book { get; set; }
        }
    }
}
