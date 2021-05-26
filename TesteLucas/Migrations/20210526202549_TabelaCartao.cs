using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteLucas.Migrations
{
    public partial class TabelaCartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    N_Cartao = table.Column<string>(nullable: true),
                    Nome_Titular = table.Column<string>(nullable: true),
                    Cpf_Titular = table.Column<string>(nullable: true),
                    Cod_seguranca = table.Column<int>(nullable: false),
                    Validade_Cartao = table.Column<string>(nullable: true),
                    N_parcelas = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartaos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartaos_ClienteId",
                table: "Cartaos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartaos");
        }
    }
}
