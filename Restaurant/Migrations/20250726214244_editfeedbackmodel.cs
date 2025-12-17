using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class editfeedbackmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterFeedBackDesc",
                table: "MasterFeedBacks");

            migrationBuilder.RenameColumn(
                name: "MasterFeedBackTitle",
                table: "MasterFeedBacks",
                newName: "MasterFeedBackContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MasterFeedBackContent",
                table: "MasterFeedBacks",
                newName: "MasterFeedBackTitle");

            migrationBuilder.AddColumn<string>(
                name: "MasterFeedBackDesc",
                table: "MasterFeedBacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
