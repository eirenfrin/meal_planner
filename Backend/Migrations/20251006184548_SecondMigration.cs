using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "ShoppingListIngredients",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListIngredients_UnitId",
                table: "ShoppingListIngredients",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListIngredients_Units_UnitId",
                table: "ShoppingListIngredients",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListIngredients_Units_UnitId",
                table: "ShoppingListIngredients");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListIngredients_UnitId",
                table: "ShoppingListIngredients");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "ShoppingListIngredients");
        }
    }
}
