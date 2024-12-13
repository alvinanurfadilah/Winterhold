using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterholdDataAccess.Migrations
{
    public partial class InitialConfigWinterhold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Account",
            //     columns: table => new
            //     {
            //         Username = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //         Password = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Account", x => x.Username);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Author",
            //     columns: table => new
            //     {
            //         Id = table.Column<long>(type: "bigint", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Title = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //         FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //         LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //         BirthDate = table.Column<DateTime>(type: "date", nullable: false),
            //         DeceasedDate = table.Column<DateTime>(type: "date", nullable: true),
            //         Education = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //         Summary = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Author", x => x.Id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Category",
            //     columns: table => new
            //     {
            //         Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //         Floor = table.Column<int>(type: "int", nullable: false),
            //         Isle = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //         Bay = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Category", x => x.Name);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Customer",
            //     columns: table => new
            //     {
            //         MembershipNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //         FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //         LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //         BirthDate = table.Column<DateTime>(type: "date", nullable: false),
            //         Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //         Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //         Address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //         MembershipExpireDate = table.Column<DateTime>(type: "date", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Customer", x => x.MembershipNumber);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Book",
            //     columns: table => new
            //     {
            //         Code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //         Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //         CategoryName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //         AuthorId = table.Column<long>(type: "bigint", nullable: false),
            //         IsBorrowed = table.Column<bool>(type: "bit", nullable: false),
            //         Summary = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //         ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
            //         TotalPage = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Book", x => x.Code);
            //         table.ForeignKey(
            //             name: "FK_Book_Author",
            //             column: x => x.AuthorId,
            //             principalTable: "Author",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FK_Book_Category",
            //             column: x => x.CategoryName,
            //             principalTable: "Category",
            //             principalColumn: "Name");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Loan",
            //     columns: table => new
            //     {
            //         Id = table.Column<long>(type: "bigint", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         CustomerNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //         BookCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //         LoanDate = table.Column<DateTime>(type: "date", nullable: false),
            //         DueDate = table.Column<DateTime>(type: "date", nullable: false),
            //         ReturnDate = table.Column<DateTime>(type: "date", nullable: true),
            //         Note = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Loan", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Loan_Book",
            //             column: x => x.BookCode,
            //             principalTable: "Book",
            //             principalColumn: "Code");
            //         table.ForeignKey(
            //             name: "FK_Loan_Customer",
            //             column: x => x.CustomerNumber,
            //             principalTable: "Customer",
            //             principalColumn: "MembershipNumber");
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Book_AuthorId",
            //     table: "Book",
            //     column: "AuthorId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Book_CategoryName",
            //     table: "Book",
            //     column: "CategoryName");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Loan_BookCode",
            //     table: "Loan",
            //     column: "BookCode");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Loan_CustomerNumber",
            //     table: "Loan",
            //     column: "CustomerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "Account");

            // migrationBuilder.DropTable(
            //     name: "Loan");

            // migrationBuilder.DropTable(
            //     name: "Book");

            // migrationBuilder.DropTable(
            //     name: "Customer");

            // migrationBuilder.DropTable(
            //     name: "Author");

            // migrationBuilder.DropTable(
            //     name: "Category");
        }
    }
}
