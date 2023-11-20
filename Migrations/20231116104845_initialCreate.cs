using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TranslatorApp.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
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
                    Azerbaycanca = table.Column<string>(type: "text", nullable: false),
                    Turkce = table.Column<string>(type: "text", nullable: false),
                    Ozbekce = table.Column<string>(type: "text", nullable: false),
                    Qirgizca = table.Column<string>(type: "text", nullable: false),
                    Tatarca = table.Column<string>(type: "text", nullable: false),
                    Qazaxca = table.Column<string>(type: "text", nullable: false),
                    Uygurca = table.Column<string>(type: "text", nullable: false),
                    Turkmence = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_Azerbaycanca",
                table: "Words",
                column: "Azerbaycanca",
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
