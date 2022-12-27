using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymmer.Infrastructure.Persistence.SqliteMigrations
{
    /// <inheritdoc />
    public partial class TrainingExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingDefinitionExerciseOption",
                columns: table => new
                {
                    TrainingDefinitionId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExerciseOptionId = table.Column<long>(type: "INTEGER", nullable: false),
                    Order = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDefinitionExerciseOption", x => new { x.TrainingDefinitionId, x.ExerciseOptionId });
                    table.ForeignKey(
                        name: "FK_TrainingDefinitionExerciseOption_ExerciseOption_ExerciseOptionId",
                        column: x => x.ExerciseOptionId,
                        principalTable: "ExerciseOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingDefinitionExerciseOption_TrainingDefinition_TrainingDefinitionId",
                        column: x => x.TrainingDefinitionId,
                        principalTable: "TrainingDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDefinitionExerciseOption_ExerciseOptionId",
                table: "TrainingDefinitionExerciseOption",
                column: "ExerciseOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingDefinitionExerciseOption");
        }
    }
}
