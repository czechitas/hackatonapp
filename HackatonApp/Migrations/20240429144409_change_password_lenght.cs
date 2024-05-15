using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackatonApp.Migrations
{
    /// <inheritdoc />
    public partial class change_password_lenght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Users",
                type: "longblob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(30)",
                oldMaxLength: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Users",
                type: "varbinary(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob");
        }
    }
}
