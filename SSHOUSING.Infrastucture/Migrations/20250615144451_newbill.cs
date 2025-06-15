using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSHOUSING.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class newbill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rent",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Billings");
        }
    }
}
