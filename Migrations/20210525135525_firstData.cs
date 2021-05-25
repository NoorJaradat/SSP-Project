using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3.Migrations
{
    public partial class firstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "Id", "Email", "Name", "Section" },
                values: new object[] { 1, "ali@nurses.com", "Ali", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
