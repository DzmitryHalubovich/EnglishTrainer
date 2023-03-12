using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTrainer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeletePartsOfSpeech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "various_translations");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "dictionary",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "dictionary");

            migrationBuilder.CreateTable(
                name: "various_translations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    adjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adverb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conjunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interjection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preposition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pronoun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_various_translations", x => x.id);
                    table.ForeignKey(
                        name: "FK_various_translations_dictionary_WordId",
                        column: x => x.WordId,
                        principalTable: "dictionary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_various_translations_WordId",
                table: "various_translations",
                column: "WordId",
                unique: true);
        }
    }
}
