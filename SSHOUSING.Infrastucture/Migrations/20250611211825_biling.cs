using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSHOUSING.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class biling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceFees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dues = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");
        }
    }
}
