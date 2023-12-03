using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GL3Frameworks.Migrations
{
    /// <inheritdoc />
    public partial class hey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "signUpFee",
                table: "Membershiptype",
                newName: "SignUpFee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SignUpFee",
                table: "Membershiptype",
                newName: "signUpFee");
        }
    }
}
