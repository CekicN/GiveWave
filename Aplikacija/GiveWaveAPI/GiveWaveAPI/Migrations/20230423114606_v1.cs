using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiveWaveAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
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
                name: "Kategorijas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorijas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilKorisnikas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrojTelefona = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StatusAktivnosti = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrojLajkova = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Hranas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategorijaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Vrsta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hranas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hranas_Kategorijas_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Igrackas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategorijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Vrsta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrackas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Igrackas_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Krvs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategorijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KrvnaGrupa = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DatumDoniranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KolicinaDoniraneKrvi = table.Column<double>(type: "float", nullable: false),
                    LokacijaDoniranja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Krvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Krvs_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Novacs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrojTransakcije = table.Column<int>(type: "int", nullable: false),
                    KategorijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Iznos = table.Column<int>(type: "int", nullable: false),
                    IzvorNovca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DatumDonacije = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novacs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novacs_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Obucas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategorijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Stanje = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Velicina = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Namena = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obucas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obucas_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Odecas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategorijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VrstaOdece = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stanje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Velicina = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Namena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Uzrast = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odecas_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ostalos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategorijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    ZdravstvenaOprema = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ostalos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ostalos_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tehnikas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategorijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Vrsta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stanje = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GodinaProizvodnje = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Specifikacije = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tehnikas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tehnikas_Kategorijas_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id");
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
                name: "IX_Hranas_KategorijaId",
                table: "Hranas",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Igrackas_KategorijeId",
                table: "Igrackas",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Krvs_KategorijeId",
                table: "Krvs",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Novacs_KategorijeId",
                table: "Novacs",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Obucas_KategorijeId",
                table: "Obucas",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Odecas_KategorijeId",
                table: "Odecas",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ostalos_KategorijeId",
                table: "Ostalos",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tehnikas_KategorijeId",
                table: "Tehnikas",
                column: "KategorijeId");
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
                name: "ProfilKorisnikas");

            migrationBuilder.DropTable(
                name: "Tehnikas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Kategorijas");
        }
    }
}
