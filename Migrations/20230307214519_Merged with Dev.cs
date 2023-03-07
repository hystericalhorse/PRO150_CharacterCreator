using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterCreator.Migrations
{
    public partial class MergedwithDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "acuityAtt",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "acuityBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "brawnAtt",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "brawnBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "finesseAtt",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "finesseBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "intellectAtt",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "intellectBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "personAtt",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "personBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "toughAtt",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "toughBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharacterID",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "acuityAtt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "acuityBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "brawnAtt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "brawnBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "finesseAtt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "finesseBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "intellectAtt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "intellectBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "personAtt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "personBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "toughAtt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "toughBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterID",
                table: "Accounts");
        }
    }
}
