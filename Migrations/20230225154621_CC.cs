using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterCreator.Migrations
{
    public partial class CC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityObject",
                columns: table => new
                {
                    QualityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityObject", x => x.QualityID);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<long>(type: "bigint", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Backstory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatePoints = table.Column<long>(type: "bigint", nullable: false),
                    QualityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Characters_QualityObject_QualityID",
                        column: x => x.QualityID,
                        principalTable: "QualityObject",
                        principalColumn: "QualityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillObject",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: true),
                    CharacterID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillObject", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_SkillObject_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID");
                    table.ForeignKey(
                        name: "FK_SkillObject_Characters_CharacterID1",
                        column: x => x.CharacterID1,
                        principalTable: "Characters",
                        principalColumn: "CharacterID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_QualityID",
                table: "Characters",
                column: "QualityID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillObject_CharacterID",
                table: "SkillObject",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillObject_CharacterID1",
                table: "SkillObject",
                column: "CharacterID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillObject");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "QualityObject");
        }
    }
}
