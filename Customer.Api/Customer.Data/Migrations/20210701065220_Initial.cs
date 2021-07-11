using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokezon.CustomerApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    PokeCollection = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Age", "Birthday", "FirstName", "LastName", "PokeCollection", "Total" },
                values: new object[] { new Guid("9f35b48d-cb87-4783-bfdb-21e36012930a"), 30, new DateTime(1989, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wolfgang", "Ofner", 0, 60 });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Age", "Birthday", "FirstName", "LastName", "PokeCollection", "Total" },
                values: new object[] { new Guid("654b7573-9501-436a-ad36-94c5696ac28f"), 43, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darth", "Vader", 0, 6 });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Age", "Birthday", "FirstName", "LastName", "PokeCollection", "Total" },
                values: new object[] { new Guid("971316e1-4966-4426-b1ea-a36c9dde1066"), 83, new DateTime(1937, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son", "Goku", 0, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
