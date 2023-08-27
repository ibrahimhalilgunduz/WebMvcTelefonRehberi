using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Domain.PostgresMigration
{
    public partial class initPostgresDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Adi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gsm = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kisiler",
                columns: new[] { "Id", "Adi", "CreateDate", "Email", "Gsm", "Soyadi" },
                values: new object[] { 1, "Ali", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali@veli.com", "5551112233", "Veli" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
