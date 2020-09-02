using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Placa = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Placa);
                });

            migrationBuilder.CreateTable(
                name: "TemposPermanencia",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Tempo = table.Column<double>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Valor = table.Column<float>(nullable: true),
                    CarroPlaca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemposPermanencia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemposPermanencia_Carros_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carros",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemposPermanencia_CarroPlaca",
                table: "TemposPermanencia",
                column: "CarroPlaca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemposPermanencia");

            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
