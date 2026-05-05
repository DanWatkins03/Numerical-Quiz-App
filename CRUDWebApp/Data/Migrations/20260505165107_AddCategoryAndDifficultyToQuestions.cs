using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndDifficultyToQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "NumericalQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "NumericalQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "NumericalQuestions");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "NumericalQuestions");
        }
    }
}
