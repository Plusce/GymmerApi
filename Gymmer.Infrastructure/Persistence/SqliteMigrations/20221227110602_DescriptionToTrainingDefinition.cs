using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymmer.Infrastructure.Persistence.SqliteMigrations
{
    /// <inheritdoc />
    public partial class DescriptionToTrainingDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingDefinition",
                type: "TEXT",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingDefinition");
        }
    }
}
