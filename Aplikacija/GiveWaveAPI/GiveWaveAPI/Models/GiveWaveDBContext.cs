using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GiveWaveAPI.Models;

public class GiveWaveDBContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Hrana> Hranas { get; set; }
    public DbSet<Igracka> Igrackas { get; set; }
    public DbSet<Kategorija> Kategorijas { get; set; }
    public DbSet<Krv> Krvs { get; set; }
    public DbSet<Novac> Novacs { get; set; }
    public DbSet<Obuca> Obucas { get; set; }
    public DbSet<Odeca> Odecas { get; set; }
    public DbSet<Ostalo> Ostalos { get; set; }
    public DbSet<ProfilKorisnika> ProfilKorisnikas { get; set; }
    public DbSet<Tehnika> Tehnikas { get; set; }
    public DbSet<Porodica> Porodice { get; set; }
    public DbSet<Proizvod> Proizvods { get; set; }
    public DbSet<Donacija> Donacijas { get; set; }

    public GiveWaveDBContext(DbContextOptions<GiveWaveDBContext> options) : base(options)
    {

    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Kategorija>()
    //            .HasOne(k => k.parentCategory)
    //            .WithMany(p => p.Subcategories)
    //            .HasForeignKey(k => k.parentCategoryId)
    //            .OnDelete(DeleteBehavior.NoAction);
    //}


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Data Source=(localdb)\\BazaSWE;Initial Catalog=GiveWaveData;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");
        //            }
        //        }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Hrana>(entity =>
        //        {
        //            entity.ToTable("Hrana");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.DatumIsteka).HasColumnType("date");

        //            entity.Property(e => e.Vrsta)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Igracka>(entity =>
        //        {
        //            entity.ToTable("Igracka");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.Opis).IsRequired();

        //            entity.Property(e => e.Stanje)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Vrsta)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Kategorija>(entity =>
        //        {
        //            entity.ToTable("Kategorija");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.Ime)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Krv>(entity =>
        //        {
        //            entity.ToTable("Krv");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.DatumDoniranja).HasColumnType("date");

        //            entity.Property(e => e.KrvnaGrupa)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.LokacijaDoniranja)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Novac>(entity =>
        //        {
        //            entity.HasKey(e => e.BrojTransakcije);

        //            entity.ToTable("Novac");

        //            entity.Property(e => e.BrojTransakcije).ValueGeneratedNever();

        //            entity.Property(e => e.DatumDonacije).HasColumnType("date");

        //            entity.Property(e => e.IzvorNovca)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Obuca>(entity =>
        //        {
        //            entity.ToTable("Obuca");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.Namena)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Stanje)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Odeca>(entity =>
        //        {
        //            entity.ToTable("Odeca");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.Namena)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Stanje)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Velicina)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.VrstaOdece)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Ostalo>(entity =>
        //        {
        //            entity.ToTable("Ostalo");

        //            entity.Property(e => e.ID).ValueGeneratedNever();
        //        });

        //        modelBuilder.Entity<ProfilKorisnika>(entity =>
        //        {
        //            entity.ToTable("ProfilKorisnika");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.Adresa)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.DatumRegistracije).HasColumnType("date");

        //            entity.Property(e => e.DatumRodjenja).HasColumnType("date");

        //            entity.Property(e => e.Email)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Ime)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Pol)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Prezime)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.StatusAktivnosti)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Tehnika>(entity =>
        //        {
        //            entity.ToTable("Tehnika");

        //            entity.Property(e => e.ID).ValueGeneratedNever();

        //            entity.Property(e => e.Marka).HasMaxLength(50);

        //            entity.Property(e => e.Model).HasMaxLength(50);

        //            entity.Property(e => e.Stanje)
        //                .IsRequired()
        //                .HasMaxLength(50);

        //            entity.Property(e => e.Vrsta)
        //                .IsRequired()
        //                .HasMaxLength(50);
        //        });


        //        OnModelCreating(modelBuilder);
        //    }

        //    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
