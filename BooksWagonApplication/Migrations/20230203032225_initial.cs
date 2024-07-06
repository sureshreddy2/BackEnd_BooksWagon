using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksWagonApplication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arts_PhotographyData",
                columns: table => new
                {
                    BookTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeOfBook = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    SubTypeOfBook = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Arts_Pho__259BDEF3FA763D7F", x => x.BookTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ArtsPhotography",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookName = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Author = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                   TotalPrice = table.Column<int>(type: "int", nullable: true),
                    Publisher = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    Languagetype = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Bindingtype = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    TypeOfBook = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    SubTypeOfBook = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    BookTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ArtsPhot__3DE0C207F2C47ACD", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_ArtsBookType",
                        column: x => x.BookTypeId,
                        principalTable: "Arts_PhotographyData",
                        principalColumn: "BookTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtsPhotography_BookTypeId",
                table: "ArtsPhotography",
                column: "BookTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtsPhotography");

            migrationBuilder.DropTable(
                name: "Arts_PhotographyData");
        }
    }
}
