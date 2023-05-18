using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactAPI.Migrations
{
    public partial class UpdateContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE UpdateContact
                        @ContactId INT,
                        @FirstName NVARCHAR(50),
                        @LastName NVARCHAR(50),
                        @ContactNo NVARCHAR(20),
                        @Email NVARCHAR(100) = NULL,
                        @Relation NVARCHAR(50) = NULL
                    AS
                    BEGIN
                        UPDATE Contacts
                        SET FirstName = @FirstName,
                            LastName = @LastName,
                            ContactNo = @ContactNo,
                            Email = @Email,
                            Relation = @Relation
                        WHERE ContactId = @ContactId;
                    END
                    ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE UpdateContact";
            migrationBuilder.Sql(sp);
        }
    }
}
