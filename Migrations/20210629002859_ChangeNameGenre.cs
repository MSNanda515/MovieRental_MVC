using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRental.Migrations
{
    public partial class ChangeNameGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("alter table Genre rename to Genres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
