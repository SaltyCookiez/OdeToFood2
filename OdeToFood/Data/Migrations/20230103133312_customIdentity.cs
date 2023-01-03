using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdeToFood.Data.Migrations
{
    public partial class customIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Reviews",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FavoriteRestaurant",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteRestaurant",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);
        }
    }
}
