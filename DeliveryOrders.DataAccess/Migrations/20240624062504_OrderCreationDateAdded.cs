using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryOrders.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderCreationDateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCreationDate",
                table: "OrderModels",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CityModels",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "AddressModels",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AddressModels_AddressLine_CityId",
                table: "AddressModels",
                columns: new[] { "AddressLine", "CityId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AddressModels_AddressLine_CityId",
                table: "AddressModels");

            migrationBuilder.DropColumn(
                name: "OrderCreationDate",
                table: "OrderModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CityModels",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "AddressModels",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
