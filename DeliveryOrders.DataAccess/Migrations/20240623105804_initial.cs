using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryOrders.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressLine = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressModels_CityModels_CityId",
                        column: x => x.CityId,
                        principalTable: "CityModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    CargoWeight = table.Column<double>(type: "double precision", nullable: true),
                    CargoPickupDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderModels_AddressModels_RecipientAddressId",
                        column: x => x.RecipientAddressId,
                        principalTable: "AddressModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderModels_AddressModels_SenderAddressId",
                        column: x => x.SenderAddressId,
                        principalTable: "AddressModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressModels_CityId",
                table: "AddressModels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModels_RecipientAddressId",
                table: "OrderModels",
                column: "RecipientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModels_SenderAddressId",
                table: "OrderModels",
                column: "SenderAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderModels");

            migrationBuilder.DropTable(
                name: "AddressModels");

            migrationBuilder.DropTable(
                name: "CityModels");
        }
    }
}
