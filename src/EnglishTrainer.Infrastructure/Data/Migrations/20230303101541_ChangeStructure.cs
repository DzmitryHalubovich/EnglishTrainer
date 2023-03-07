using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTrainer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Example_Descriptions_DescriptionId",
                table: "Example");

            migrationBuilder.DropForeignKey(
                name: "FK_Verbs_Descriptions_DescriptionId",
                table: "Verbs");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Verbs_DescriptionId",
                table: "Verbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Example",
                table: "Example");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Verbs");

            migrationBuilder.RenameTable(
                name: "Example",
                newName: "Examples");

            migrationBuilder.RenameColumn(
                name: "Infinitive",
                table: "Verbs",
                newName: "infinitive");

            migrationBuilder.RenameColumn(
                name: "ShortTranslate",
                table: "Verbs",
                newName: "short_translate");

            migrationBuilder.RenameColumn(
                name: "PastSimple",
                table: "Verbs",
                newName: "past_simple");

            migrationBuilder.RenameColumn(
                name: "PastParticiple",
                table: "Verbs",
                newName: "past_participle");

            migrationBuilder.RenameColumn(
                name: "RussianExample",
                table: "Examples",
                newName: "russian_translate");

            migrationBuilder.RenameColumn(
                name: "EnglishExample",
                table: "Examples",
                newName: "engliish_example");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "Examples",
                newName: "WordId");

            migrationBuilder.RenameIndex(
                name: "IX_Example_DescriptionId",
                table: "Examples",
                newName: "IX_Examples_WordId");

            migrationBuilder.AlterColumn<string>(
                name: "russian_translate",
                table: "Examples",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examples",
                table: "Examples",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    word = table.Column<string>(type: "varchar(max)", nullable: false),
                    translate = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "various translation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    adverb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conjunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interjection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preposition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pronoun = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_various translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_various translation_dictionary_WordId",
                        column: x => x.WordId,
                        principalTable: "dictionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_various translation_WordId",
                table: "various translation",
                column: "WordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Examples_dictionary_WordId",
                table: "Examples",
                column: "WordId",
                principalTable: "dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examples_dictionary_WordId",
                table: "Examples");

            migrationBuilder.DropTable(
                name: "various translation");

            migrationBuilder.DropTable(
                name: "dictionary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examples",
                table: "Examples");

            migrationBuilder.RenameTable(
                name: "Examples",
                newName: "Example");

            migrationBuilder.RenameColumn(
                name: "infinitive",
                table: "Verbs",
                newName: "Infinitive");

            migrationBuilder.RenameColumn(
                name: "short_translate",
                table: "Verbs",
                newName: "ShortTranslate");

            migrationBuilder.RenameColumn(
                name: "past_simple",
                table: "Verbs",
                newName: "PastSimple");

            migrationBuilder.RenameColumn(
                name: "past_participle",
                table: "Verbs",
                newName: "PastParticiple");

            migrationBuilder.RenameColumn(
                name: "russian_translate",
                table: "Example",
                newName: "RussianExample");

            migrationBuilder.RenameColumn(
                name: "engliish_example",
                table: "Example",
                newName: "EnglishExample");

            migrationBuilder.RenameColumn(
                name: "WordId",
                table: "Example",
                newName: "DescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Examples_WordId",
                table: "Example",
                newName: "IX_Example_DescriptionId");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Verbs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RussianExample",
                table: "Example",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Example",
                table: "Example",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllTranslateVariants = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbs_DescriptionId",
                table: "Verbs",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Example_Descriptions_DescriptionId",
                table: "Example",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verbs_Descriptions_DescriptionId",
                table: "Verbs",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id");
        }
    }
}
