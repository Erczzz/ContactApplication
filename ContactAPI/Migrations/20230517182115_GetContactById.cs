using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactAPI.Migrations
{
    public partial class GetContactById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE GetContactById
                    @ContactId INT
                    AS
                    BEGIN
                        SELECT *
                        FROM Contacts
                        WHERE ContactId = @ContactId
                    END
                    ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE GetContactById";
            migrationBuilder.Sql(sp);
        }
    }
}
