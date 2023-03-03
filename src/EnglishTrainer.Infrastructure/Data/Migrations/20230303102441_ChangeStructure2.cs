using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTrainer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStructure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examples_dictionary_WordId",
                table: "Examples");

            migrationBuilder.DropForeignKey(
                name: "FK_various translation_dictionary_WordId",
                table: "various translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examples",
                table: "Examples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verbs",
                table: "Verbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_various translation",
                table: "various translation");

            migrationBuilder.RenameTable(
                name: "Examples",
                newName: "examples");

            migrationBuilder.RenameTable(
                name: "Verbs",
                newName: "irregular_verbs");

            migrationBuilder.RenameTable(
                name: "various translation",
                newName: "various_translations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "examples",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Examples_WordId",
                table: "examples",
                newName: "IX_examples_WordId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "dictionary",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "irregular_verbs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "various_translations",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_various translation_WordId",
                table: "various_translations",
                newName: "IX_various_translations_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_examples",
                table: "examples",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_irregular_verbs",
                table: "irregular_verbs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_various_translations",
                table: "various_translations",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_examples_dictionary_WordId",
                table: "examples",
                column: "WordId",
                principalTable: "dictionary",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_various_translations_dictionary_WordId",
                table: "various_translations",
                column: "WordId",
                principalTable: "dictionary",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_examples_dictionary_WordId",
                table: "examples");

            migrationBuilder.DropForeignKey(
                name: "FK_various_translations_dictionary_WordId",
                table: "various_translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_examples",
                table: "examples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_various_translations",
                table: "various_translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_irregular_verbs",
                table: "irregular_verbs");

            migrationBuilder.RenameTable(
                name: "examples",
                newName: "Examples");

            migrationBuilder.RenameTable(
                name: "various_translations",
                newName: "various translation");

            migrationBuilder.RenameTable(
                name: "irregular_verbs",
                newName: "Verbs");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Examples",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_examples_WordId",
                table: "Examples",
                newName: "IX_Examples_WordId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "dictionary",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "various translation",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_various_translations_WordId",
                table: "various translation",
                newName: "IX_various translation_WordId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Verbs",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examples",
                table: "Examples",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_various translation",
                table: "various translation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verbs",
                table: "Verbs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examples_dictionary_WordId",
                table: "Examples",
                column: "WordId",
                principalTable: "dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_various translation_dictionary_WordId",
                table: "various translation",
                column: "WordId",
                principalTable: "dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
