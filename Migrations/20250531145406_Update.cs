using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Cars",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaxSpeed",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WarrantyYears",
                table: "Cars",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "XDrive",
                table: "Cars",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxSpeed",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "WarrantyYears",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "XDrive",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);
        }
    }
}
