using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BarcoApplicatie.BibModels
{
    public partial class BibliotheekContext : DbContext
    {
        public BibliotheekContext()
        {
        }

        public BibliotheekContext(DbContextOptions<BibliotheekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auteur> Auteur { get; set; }
        public virtual DbSet<Boeken> Boeken { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Klant> Klant { get; set; }
        public virtual DbSet<Uitgever> Uitgever { get; set; }
        public virtual DbSet<Uitleen> Uitleen { get; set; }
        public virtual DbSet<VwLijstBoeken> VwLijstBoeken { get; set; }
        public virtual DbSet<VwLijstBoeken1> VwLijstBoeken1 { get; set; }
        public virtual DbSet<VwLijstBoeken2> VwLijstBoeken2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP\\VIVES;Database=Bibliotheek; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auteur>(entity =>
            {
                entity.Property(e => e.AuteurId)
                    .HasColumnName("Auteur_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Naam)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Boeken>(entity =>
            {
                entity.HasKey(e => e.BoekId);

                entity.HasIndex(e => e.Jaar)
                    .HasName("ix_boeken_jaar");

                entity.Property(e => e.BoekId)
                    .HasColumnName("boek_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuteurId).HasColumnName("auteur_id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.Jaar).HasColumnName("jaar");

                entity.Property(e => e.Titel)
                    .HasColumnName("titel")
                    .HasMaxLength(30);

                entity.Property(e => e.UitgId).HasColumnName("uitg_id");

                entity.HasOne(d => d.Auteur)
                    .WithMany(p => p.Boeken)
                    .HasForeignKey(d => d.AuteurId)
                    .HasConstraintName("FK_Boeken_Auteur1");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Boeken)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Boeken_Categorie");

                entity.HasOne(d => d.Uitg)
                    .WithMany(p => p.Boeken)
                    .HasForeignKey(d => d.UitgId)
                    .HasConstraintName("FK_Boeken_Uitgever");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId)
                    .HasColumnName("cat_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categorie1)
                    .IsRequired()
                    .HasColumnName("categorie")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Klant>(entity =>
            {
                entity.Property(e => e.KlantId)
                    .HasColumnName("klant_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Klantnaam)
                    .HasColumnName("klantnaam")
                    .HasMaxLength(30);

                entity.Property(e => e.Plaats)
                    .HasColumnName("plaats")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Uitgever>(entity =>
            {
                entity.HasKey(e => e.UitgId);

                entity.Property(e => e.UitgId)
                    .HasColumnName("uitg_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Uitgever1)
                    .IsRequired()
                    .HasColumnName("uitgever")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Uitleen>(entity =>
            {
                entity.HasKey(e => e.Uitlnr);

                entity.Property(e => e.Uitlnr)
                    .HasColumnName("uitlnr")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoekId).HasColumnName("boek_id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.KlantId).HasColumnName("klant_id");

                entity.HasOne(d => d.Boek)
                    .WithMany(p => p.Uitleen)
                    .HasForeignKey(d => d.BoekId)
                    .HasConstraintName("FK_Uitleen_Boeken");

                entity.HasOne(d => d.Klant)
                    .WithMany(p => p.Uitleen)
                    .HasForeignKey(d => d.KlantId)
                    .HasConstraintName("FK_Uitleen_Klant");
            });

            modelBuilder.Entity<VwLijstBoeken>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_lijstBoeken");

                entity.Property(e => e.Jaar).HasColumnName("jaar");

                entity.Property(e => e.Titel)
                    .HasColumnName("titel")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<VwLijstBoeken1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_LijstBoeken1");

                entity.Property(e => e.Categorie)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Jaar).HasColumnName("jaar");

                entity.Property(e => e.Naam)
                    .HasColumnName("naam")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasColumnName("titel")
                    .HasMaxLength(30);

                entity.Property(e => e.Uitgever)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<VwLijstBoeken2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_LijstBoeken2");

                entity.Property(e => e.Aantal).HasColumnName("aantal");

                entity.Property(e => e.Uitleendatum)
                    .HasColumnName("uitleendatum")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("auteurSequence").StartsAt(21010001);

            modelBuilder.HasSequence("TelPerDrie")
                .StartsAt(300)
                .IncrementsBy(3);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
