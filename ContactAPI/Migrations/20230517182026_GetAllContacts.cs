using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactAPI.Migrations
{
    public partial class GetAllContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE GetAllContacts
            AS
            BEGIN
                SET NOCOUNT ON;
                SELECT *
                FROM Contacts
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE GetAllContacts";
            migrationBuilder.Sql(sp);
        }
    }
}
