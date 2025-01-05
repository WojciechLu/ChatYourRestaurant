using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatYourRestaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMealQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Meals_MealId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MealId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "MealQuantity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderOder = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealQuantity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealQuantity_Orders_OrderOder",
                        column: x => x.OrderOder,
                        principalTable: "Orders",
                        principalColumn: "Oder");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealQuantity_OrderOder",
                table: "MealQuantity",
                column: "OrderOder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealQuantity");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MealId",
                table: "Orders",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Meals_MealId",
                table: "Orders",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
