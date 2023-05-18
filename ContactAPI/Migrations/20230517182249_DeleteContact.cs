using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactAPI.Migrations
{
    public partial class DeleteContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE DeleteContact
                            @ContactId INT
                        AS
                        BEGIN
                            DELETE FROM Contacts
                            WHERE ContactId = @ContactId;
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE DeleteContact";
            migrationBuilder.Sql(sp);
        }
    }
}
