using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imobiliaria.Api.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Alugado",
                table: "Imoveis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CorretorId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProprietarioId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_CorretorId",
                table: "Imoveis",
                column: "CorretorId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ProprietarioId",
                table: "Imoveis",
                column: "ProprietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Corretores_CorretorId",
                table: "Imoveis",
                column: "CorretorId",
                principalTable: "Corretores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Proprietarios_ProprietarioId",
                table: "Imoveis",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Corretores_CorretorId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Proprietarios_ProprietarioId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_CorretorId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_ProprietarioId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Alugado",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "CorretorId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "ProprietarioId",
                table: "Imoveis");
        }
    }
}
