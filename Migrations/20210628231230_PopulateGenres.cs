using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRental.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into Genre (Id, Name) VAlUES (1, 'Action')");
            migrationBuilder.Sql("INSERT into Genre (Id, Name) VAlUES (2, 'Mystery')");
            migrationBuilder.Sql("INSERT into Genre (Id, Name) VAlUES (3, 'Romance')");
            migrationBuilder.Sql("INSERT into Genre (Id, Name) VAlUES (4, 'Thriller')");
            migrationBuilder.Sql("INSERT into Genre (Id, Name) VAlUES (5, 'Comedy')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
