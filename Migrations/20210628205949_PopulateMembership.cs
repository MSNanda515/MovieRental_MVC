using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRental.Migrations
{
    public partial class PopulateMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate) VALUES (4, 300, 12, 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
