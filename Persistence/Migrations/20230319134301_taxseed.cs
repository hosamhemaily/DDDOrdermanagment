using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class taxseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductID",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CatregoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CatregoryId",
                table: "Product",
                newName: "IX_Product_CatregoryId");

            migrationBuilder.AddColumn<decimal>(
                name: "SellPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TaxOrderConfigurations",
                columns: new[] { "Id", "TaxPercentage" },
                values: new object[] { new Guid("ec809e3d-d510-4a75-9df5-10ca438a3062"), 10 });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Product_ProductID",
                table: "OrderProducts",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CatregoryId",
                table: "Product",
                column: "CatregoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Product_ProductID",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CatregoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "TaxOrderConfigurations",
                keyColumn: "Id",
                keyValue: new Guid("ec809e3d-d510-4a75-9df5-10ca438a3062"));

            migrationBuilder.DropColumn(
                name: "SellPrice",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CatregoryId",
                table: "Products",
                newName: "IX_Products_CatregoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductID",
                table: "OrderProducts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CatregoryId",
                table: "Products",
                column: "CatregoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
