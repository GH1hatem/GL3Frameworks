using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GL3Frameworks.Migrations
{
    /// <inheritdoc />
    public partial class AddNametoMembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Membershiptype",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Membershiptype");
        }
    }
}
