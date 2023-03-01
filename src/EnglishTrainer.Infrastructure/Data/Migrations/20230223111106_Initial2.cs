using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTrainer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Example_Description_DescriptionId",
                table: "Example");

            migrationBuilder.DropForeignKey(
                name: "FK_Verbs_Description_DescriptionId",
                table: "Verbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Description",
                table: "Description");

            migrationBuilder.RenameTable(
                name: "Description",
                newName: "Descriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Example_Descriptions_DescriptionId",
                table: "Example",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "DescriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verbs_Descriptions_DescriptionId",
                table: "Verbs",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "DescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Example_Descriptions_DescriptionId",
                table: "Example");

            migrationBuilder.DropForeignKey(
                name: "FK_Verbs_Descriptions_DescriptionId",
                table: "Verbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions");

            migrationBuilder.RenameTable(
                name: "Descriptions",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Description",
                table: "Description",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Example_Description_DescriptionId",
                table: "Example",
                column: "DescriptionId",
                principalTable: "Description",
                principalColumn: "DescriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verbs_Description_DescriptionId",
                table: "Verbs",
                column: "DescriptionId",
                principalTable: "Description",
                principalColumn: "DescriptionId");
        }
    }
}
