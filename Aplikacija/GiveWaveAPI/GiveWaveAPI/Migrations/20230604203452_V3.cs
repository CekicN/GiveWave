using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GiveWaveAPI.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porodice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BrClanova = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NajpotrebnijeStvari = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porodice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilKorisnikas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StatusAktivnosti = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrojLajkova = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRegistracije = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilKorisnikas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kategorijas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentID = table.Column<int>(type: "int", nullable: true),
                    PorodicaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorijas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategorijas_Kategorijas_parentID",
                        column: x => x.parentID,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kategorijas_Porodice_PorodicaId",
                        column: x => x.PorodicaId,
                        principalTable: "Porodice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donacijas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipDonacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumDonacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProfilKorisnikaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donacijas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donacijas_ProfilKorisnikas_ProfilKorisnikaId",
                        column: x => x.ProfilKorisnikaId,
                        principalTable: "ProfilKorisnikas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hranas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hranas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hranas_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Igrackas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrackas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Igrackas_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Krvs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KrvnaGrupa = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DatumDoniranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KolicinaDoniraneKrvi = table.Column<double>(type: "float", nullable: false),
                    LokacijaDoniranja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Krvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Krvs_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Novacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojTransakcije = table.Column<int>(type: "int", nullable: false),
                    Iznos = table.Column<int>(type: "int", nullable: false),
                    IzvorNovca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DatumDonacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novacs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novacs_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Obucas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stanje = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Velicina = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Namena = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obucas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obucas_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Odecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaOdece = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stanje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Velicina = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Namena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Uzrast = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odecas_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ostalos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kozmetika = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HigijenskiProizvodi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Elektronika = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Knjige = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Namestaj = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Alat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MuzickiInstrumenti = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SportskaOprema = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KucniLjubimac = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lekovi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KucniAparati = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Vozila = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZdravstvenaOprema = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ostalos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ostalos_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proizvods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProfilKorisnikaId = table.Column<int>(type: "int", nullable: true),
                    KategorijeId = table.Column<int>(type: "int", nullable: true),
                    PorodicaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proizvods_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proizvods_Porodice_PorodicaId",
                        column: x => x.PorodicaId,
                        principalTable: "Porodice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proizvods_ProfilKorisnikas_ProfilKorisnikaId",
                        column: x => x.ProfilKorisnikaId,
                        principalTable: "ProfilKorisnikas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tehnikas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stanje = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GodinaProizvodnje = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Specifikacije = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tehnikas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tehnikas_Kategorijas_kategorijaId",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f4c4c8e-8298-43ba-aa4b-5f3de6054315", "2", "User", "User" },
                    { "873bdbb4-f17b-4d9f-8591-25de891fc381", "1", "Admin", "Admin" },
                    { "92a97a3f-7f0b-4caa-8e75-5dbdef6c490e", "3", "Friend", "Friend" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Donacijas_ProfilKorisnikaId",
                table: "Donacijas",
                column: "ProfilKorisnikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hranas_kategorijaId",
                table: "Hranas",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Igrackas_kategorijaId",
                table: "Igrackas",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorijas_parentID",
                table: "Kategorijas",
                column: "parentID");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorijas_PorodicaId",
                table: "Kategorijas",
                column: "PorodicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Krvs_kategorijaId",
                table: "Krvs",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Novacs_kategorijaId",
                table: "Novacs",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obucas_kategorijaId",
                table: "Obucas",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Odecas_kategorijaId",
                table: "Odecas",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ostalos_kategorijaId",
                table: "Ostalos",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvods_KategorijeId",
                table: "Proizvods",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvods_PorodicaId",
                table: "Proizvods",
                column: "PorodicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvods_ProfilKorisnikaId",
                table: "Proizvods",
                column: "ProfilKorisnikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tehnikas_kategorijaId",
                table: "Tehnikas",
                column: "kategorijaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Donacijas");

            migrationBuilder.DropTable(
                name: "Hranas");

            migrationBuilder.DropTable(
                name: "Igrackas");

            migrationBuilder.DropTable(
                name: "Krvs");

            migrationBuilder.DropTable(
                name: "Novacs");

            migrationBuilder.DropTable(
                name: "Obucas");

            migrationBuilder.DropTable(
                name: "Odecas");

            migrationBuilder.DropTable(
                name: "Ostalos");

            migrationBuilder.DropTable(
                name: "Proizvods");

            migrationBuilder.DropTable(
                name: "Tehnikas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProfilKorisnikas");

            migrationBuilder.DropTable(
                name: "Kategorijas");

            migrationBuilder.DropTable(
                name: "Porodice");
        }
    }
}
