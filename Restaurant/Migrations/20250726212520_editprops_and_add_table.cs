using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class editprops_and_add_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactUsEmail",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactUsLocation",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactUsPhone",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MasterFeedBacks",
                columns: table => new
                {
                    MasterFeedBackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterFeedBackTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterCustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterFeedBackDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterFeedBackImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterFeedBackCustomerBreef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFeedBacks", x => x.MasterFeedBackId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterFeedBacks");

            migrationBuilder.DropColumn(
                name: "ContactUsEmail",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsLocation",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsPhone",
                table: "SystemSettings");
        }
    }
}
