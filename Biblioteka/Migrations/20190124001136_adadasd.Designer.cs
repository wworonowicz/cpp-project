﻿// <auto-generated />
using System;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biblioteka.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    [Migration("20190124001136_adadasd")]
    partial class adadasd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Biblioteka.Models.BibliotekaContext+Wypozyczenie", b =>
                {
                    b.Property<string>("UzytkownikID");

                    b.Property<int>("BookID");

                    b.HasKey("UzytkownikID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("Wypozyczenie");
                });

            modelBuilder.Entity("Biblioteka.Models.Books", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Genre");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Biblioteka.Models.Uzytkownicy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataUro");

                    b.Property<string>("Imie");

                    b.Property<string>("Nazwisko");

                    b.Property<bool>("Verified");

                    b.HasKey("ID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Biblioteka.Models.BibliotekaContext+Wypozyczenie", b =>
                {
                    b.HasOne("Biblioteka.Models.Books", "Book")
                        .WithMany("Wypozyczenie")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
