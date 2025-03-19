using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeterSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class product_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.CreatedAt, x.Id });
                    table.UniqueConstraint("AK_Products_Code", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_ProductCode",
                table: "Consumptions",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_Products_ProductCode",
                table: "Consumptions",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Products_ProductCode",
                table: "Consumptions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_ProductCode",
                table: "Consumptions");
        }
    }
}
