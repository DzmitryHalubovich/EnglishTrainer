using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTrainer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerbId",
                table: "Verbs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExampleId",
                table: "Example",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "Descriptions",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Verbs",
                newName: "VerbId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Example",
                newName: "ExampleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Descriptions",
                newName: "DescriptionId");
        }
    }
}
