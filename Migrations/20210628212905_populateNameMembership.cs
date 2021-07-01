using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRental.Migrations
{
    public partial class populateNameMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update MembershipTypes Set Name = 'Pay as You Go' where Id = 1");
            migrationBuilder.Sql("Update MembershipTypes Set Name = 'Monthly' where Id = 2");
            migrationBuilder.Sql("Update MembershipTypes Set Name = 'Quarterly' where Id = 3");
            migrationBuilder.Sql("Update MembershipTypes Set Name = 'Yearly' where Id = 4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
