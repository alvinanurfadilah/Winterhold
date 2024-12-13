using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterholdDataAccess.Migrations
{
    public partial class AddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CustomerNumber = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer",
                        column: x => x.CustomerNumber,
                        principalTable: "Customer",
                        principalColumn: "MembershipNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerNumber",
                table: "Address",
                column: "CustomerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
