using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TbGrupoVeiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupoVeiculos",
                columns: table => new
                {
                    @int = table.Column<int>(name: "int", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    varchar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoVeiculos", x => x.@int);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBGrupoVeiculos");
        }
    }
}
