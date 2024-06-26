using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryOrders.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tablesNamesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModels_CityModels_CityId",
                table: "AddressModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_AddressModels_RecipientAddressId",
                table: "OrderModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_AddressModels_SenderAddressId",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityModels",
                table: "CityModels");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AddressModels_AddressLine_CityId",
                table: "AddressModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressModels",
                table: "AddressModels");

            migrationBuilder.RenameTable(
                name: "OrderModels",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "CityModels",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "AddressModels",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_SenderAddressId",
                table: "Orders",
                newName: "IX_Orders_SenderAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_RecipientAddressId",
                table: "Orders",
                newName: "IX_Orders_RecipientAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModels_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderCreationDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Addresses_AddressLine_CityId",
                table: "Addresses",
                columns: new[] { "AddressLine", "CityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_RecipientAddressId",
                table: "Orders",
                column: "RecipientAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_SenderAddressId",
                table: "Orders",
                column: "SenderAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_RecipientAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_SenderAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Addresses_AddressLine_CityId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderModels");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "CityModels");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "AddressModels");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SenderAddressId",
                table: "OrderModels",
                newName: "IX_OrderModels_SenderAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RecipientAddressId",
                table: "OrderModels",
                newName: "IX_OrderModels_RecipientAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "AddressModels",
                newName: "IX_AddressModels_CityId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderCreationDate",
                table: "OrderModels",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityModels",
                table: "CityModels",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AddressModels_AddressLine_CityId",
                table: "AddressModels",
                columns: new[] { "AddressLine", "CityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModels",
                table: "AddressModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModels_CityModels_CityId",
                table: "AddressModels",
                column: "CityId",
                principalTable: "CityModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModels_AddressModels_RecipientAddressId",
                table: "OrderModels",
                column: "RecipientAddressId",
                principalTable: "AddressModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModels_AddressModels_SenderAddressId",
                table: "OrderModels",
                column: "SenderAddressId",
                principalTable: "AddressModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
