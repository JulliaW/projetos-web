using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlunoCursoIdentity.Migrations
{
    /// <inheritdoc />
    public partial class foreignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Curso_CursoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "Aluno",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Aluno",
                table: "Alunos",
                column: "Aluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Curso_Aluno",
                table: "Alunos",
                column: "Aluno",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Curso_Aluno",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_Aluno",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Aluno",
                table: "Alunos");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Curso_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id");
        }
    }
}
