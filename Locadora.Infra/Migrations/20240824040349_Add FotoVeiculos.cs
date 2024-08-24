using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFotoVeiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Fotos",
                table: "TBVeiculos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fotos",
                table: "TBVeiculos");
        }
    }
}
