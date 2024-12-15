using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visiotech_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "vineyards");

            migrationBuilder.CreateTable(
                name: "Grapes",
                schema: "vineyards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                schema: "vineyards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxNumber = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vineyards",
                schema: "vineyards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vineyards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                schema: "vineyards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    YearPlanted = table.Column<int>(type: "integer", nullable: false),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    ManagerEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    VineyardEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrapeEntityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcels_Grapes_GrapeEntityId",
                        column: x => x.GrapeEntityId,
                        principalSchema: "vineyards",
                        principalTable: "Grapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcels_Managers_ManagerEntityId",
                        column: x => x.ManagerEntityId,
                        principalSchema: "vineyards",
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcels_Vineyards_VineyardEntityId",
                        column: x => x.VineyardEntityId,
                        principalSchema: "vineyards",
                        principalTable: "Vineyards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_GrapeEntityId",
                schema: "vineyards",
                table: "Parcels",
                column: "GrapeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ManagerEntityId",
                schema: "vineyards",
                table: "Parcels",
                column: "ManagerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_VineyardEntityId",
                schema: "vineyards",
                table: "Parcels",
                column: "VineyardEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels",
                schema: "vineyards");

            migrationBuilder.DropTable(
                name: "Grapes",
                schema: "vineyards");

            migrationBuilder.DropTable(
                name: "Managers",
                schema: "vineyards");

            migrationBuilder.DropTable(
                name: "Vineyards",
                schema: "vineyards");
        }
    }
}
