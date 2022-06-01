using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaAsp.Migrations
{
    public partial class adicionandorelaçãoentreGerenteeCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteId",
                table: "Lojas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lojas_GerenteId",
                table: "Lojas",
                column: "GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lojas_Gerentes_GerenteId",
                table: "Lojas",
                column: "GerenteId",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lojas_Gerentes_GerenteId",
                table: "Lojas");

            migrationBuilder.DropIndex(
                name: "IX_Lojas_GerenteId",
                table: "Lojas");

            migrationBuilder.DropColumn(
                name: "GerenteId",
                table: "Lojas");
        }
    }
}
