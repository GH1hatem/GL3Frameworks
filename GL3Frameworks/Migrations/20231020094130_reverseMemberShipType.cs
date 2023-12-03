using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GL3Frameworks.Migrations
{
    /// <inheritdoc />
    public partial class reverseMemberShipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membershiptype_Customer_CustomerId",
                table: "Membershiptype");

            migrationBuilder.DropIndex(
                name: "IX_Membershiptype_CustomerId",
                table: "Membershiptype");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Membershiptype");

            migrationBuilder.AddColumn<int>(
                name: "MembershiptypeID",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_MembershiptypeID",
                table: "Customer",
                column: "MembershiptypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Membershiptype_MembershiptypeID",
                table: "Customer",
                column: "MembershiptypeID",
                principalTable: "Membershiptype",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Membershiptype_MembershiptypeID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_MembershiptypeID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MembershiptypeID",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Membershiptype",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membershiptype_CustomerId",
                table: "Membershiptype",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membershiptype_Customer_CustomerId",
                table: "Membershiptype",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
