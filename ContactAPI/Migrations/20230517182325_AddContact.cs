using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactAPI.Migrations
{
    public partial class AddContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE AddContact
                        @FirstName NVARCHAR(50),
                        @LastName NVARCHAR(50),
                        @ContactNo NVARCHAR(50),
                        @Email NVARCHAR(100) = NULL,
                        @Relation NVARCHAR(50) = NULL
                    AS
                    BEGIN
                        INSERT INTO Contacts (FirstName, LastName, ContactNo, Email, Relation)
                        VALUES (@FirstName, @LastName, @ContactNo, @Email, @Relation)
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE AddContact";
            migrationBuilder.Sql(sp);
        }
    }
}
