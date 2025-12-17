using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class newmigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "TransactionNewsletters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransactionNewsletters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "TransactionContactUs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransactionContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "TransactionBookTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "TransactionBookTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransactionBookTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "SystemSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "SystemSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterWorkingHours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterWorkingHours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterWorkingHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterWorkingHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterSocialMedia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterSocialMedia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterSocialMedia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterSocialMedia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterSliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterSliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterSliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterSliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterPartners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterPartners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterPartners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterPartners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterPartners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterPartners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterItemMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterItemMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterItemMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterItemMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterItemMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterItemMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "MasterCategoryMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatUser",
                table: "MasterCategoryMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterCategoryMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterCategoryMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterCategoryMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MasterCategoryMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterPartners");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterPartners");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterPartners");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterPartners");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterPartners");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterPartners");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterMenus");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterMenus");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterMenus");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterMenus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterMenus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterMenus");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "CreatUser",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MasterCategoryMenus");
        }
    }
}
