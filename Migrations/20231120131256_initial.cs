using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TranslatorApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Azerbaycan = table.Column<string>(type: "text", nullable: false),
                    Turk = table.Column<string>(type: "text", nullable: true),
                    Latin = table.Column<string>(type: "text", nullable: true),
                    Ozbek = table.Column<string>(type: "text", nullable: true),
                    Qazax = table.Column<string>(type: "text", nullable: true),
                    Rus = table.Column<string>(type: "text", nullable: true),
                    UnSelected = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_Azerbaycan",
                table: "Words",
                column: "Azerbaycan",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
