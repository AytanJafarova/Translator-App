using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslatorApp.Migrations
{
    /// <inheritdoc />
    public partial class addUnChecked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnSelected",
                table: "Words",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnSelected",
                table: "Words");
        }
    }
}
