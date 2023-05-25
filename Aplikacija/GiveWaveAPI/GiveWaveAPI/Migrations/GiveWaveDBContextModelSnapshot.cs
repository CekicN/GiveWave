﻿// <auto-generated />
using System;
using GiveWaveAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GiveWaveAPI.Migrations
{
    [DbContext(typeof(GiveWaveDBContext))]
    partial class GiveWaveDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GiveWaveAPI.Models.Donacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumDonacije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("ProfilKorisnikaId")
                        .HasColumnType("int");

                    b.Property<string>("TipDonacije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProfilKorisnikaId");

                    b.ToTable("Donacijas");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Hrana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIsteka")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Hranas");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Igracka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Igrackas");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PorodicaId")
                        .HasColumnType("int");

                    b.Property<int?>("parentID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PorodicaId");

                    b.HasIndex("parentID");

                    b.ToTable("Kategorijas");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Krv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumDoniranja")
                        .HasColumnType("datetime2");

                    b.Property<double>("KolicinaDoniraneKrvi")
                        .HasColumnType("float");

                    b.Property<string>("KrvnaGrupa")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("LokacijaDoniranja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Krvs");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Novac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrojTransakcije")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumDonacije")
                        .HasColumnType("datetime2");

                    b.Property<int>("Iznos")
                        .HasColumnType("int");

                    b.Property<string>("IzvorNovca")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Novacs");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Obuca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Namena")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stanje")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Velicina")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Obucas");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Odeca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Namena")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Stanje")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Uzrast")
                        .HasColumnType("int");

                    b.Property<string>("Velicina")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VrstaOdece")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Odecas");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Ostalo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Elektronika")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HigijenskiProizvodi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Knjige")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Kozmetika")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KucniAparati")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KucniLjubimac")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lekovi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MuzickiInstrumenti")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Namestaj")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SportskaOprema")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Vozila")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZdravstvenaOprema")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Ostalos");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Porodica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BrClanova")
                        .HasColumnType("int");

                    b.Property<string>("NajpotrebnijeStvari")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Opis")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Porodice");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.ProfilKorisnika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BrojLajkova")
                        .HasColumnType("int");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pol")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StatusAktivnosti")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProfilKorisnikas");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KategorijeId")
                        .HasColumnType("int");

                    b.Property<string>("Mesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Opis")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("PorodicaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfilKorisnikaId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategorijeId");

                    b.HasIndex("PorodicaId");

                    b.HasIndex("ProfilKorisnikaId");

                    b.ToTable("Proizvods");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Tehnika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GodinaProizvodnje")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Specifikacije")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Stanje")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Vrsta")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("kategorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategorijaId");

                    b.ToTable("Tehnikas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Donacija", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.ProfilKorisnika", "ProfilKorisnika")
                        .WithMany("Donacije")
                        .HasForeignKey("ProfilKorisnikaId");

                    b.Navigation("ProfilKorisnika");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Hrana", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Igracka", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Kategorija", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Porodica", null)
                        .WithMany("Kategorije")
                        .HasForeignKey("PorodicaId");

                    b.HasOne("GiveWaveAPI.Models.Kategorija", "parentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("parentID");

                    b.Navigation("parentCategory");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Krv", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Novac", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Obuca", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Odeca", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Ostalo", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Proizvod", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "Kategorije")
                        .WithMany()
                        .HasForeignKey("KategorijeId");

                    b.HasOne("GiveWaveAPI.Models.Porodica", null)
                        .WithMany("Proizvodi")
                        .HasForeignKey("PorodicaId");

                    b.HasOne("GiveWaveAPI.Models.ProfilKorisnika", "ProfilKorisnika")
                        .WithMany("Proizvodi")
                        .HasForeignKey("ProfilKorisnikaId");

                    b.Navigation("Kategorije");

                    b.Navigation("ProfilKorisnika");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Tehnika", b =>
                {
                    b.HasOne("GiveWaveAPI.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorijaId");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Kategorija", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.Porodica", b =>
                {
                    b.Navigation("Kategorije");

                    b.Navigation("Proizvodi");
                });

            modelBuilder.Entity("GiveWaveAPI.Models.ProfilKorisnika", b =>
                {
                    b.Navigation("Donacije");

                    b.Navigation("Proizvodi");
                });
#pragma warning restore 612, 618
        }
    }
}
