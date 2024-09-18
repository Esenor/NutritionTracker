using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;
using NutritionTracker.Infrastructure.Authentication.Services;
using NutritionTracker.Domain.Entities;

#nullable disable

namespace NutritionTracker.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Hash = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", maxLength: 128, nullable: false),
                    Role = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            IPasswordService passwordService = new PasswordService();
            byte[] salt = passwordService.GenerateSalt();

            migrationBuilder.InsertData(
                table: "Users",
                columns: ["Email", "Hash", "Salt", "Role", "Enabled"],
                values: ["admin@localhost", passwordService.HashPassword("admin", salt), salt, User.AdminRole, true]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
