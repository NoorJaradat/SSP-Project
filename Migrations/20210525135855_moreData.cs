using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3.Migrations
{
    public partial class moreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "Id", "Email", "Name", "Section" },
                values: new object[] { 2, "ahmad@nurses.com", "Ahmad", 3 });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "Id", "Email", "Name", "Section" },
                values: new object[] { 3, "muna@nurses.com", "Muna", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
