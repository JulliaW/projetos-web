using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlunoCursoIdentity.Migrations
{
    /// <inheritdoc />
    public partial class ajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "IdAluno",
                table: "Curso",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId",
                unique: true,
                filter: "[CursoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Curso_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Curso_CursoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "IdAluno",
                table: "Curso");

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
    }
}
