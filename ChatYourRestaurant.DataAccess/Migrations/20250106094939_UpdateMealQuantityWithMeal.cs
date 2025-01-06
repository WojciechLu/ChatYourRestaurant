using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatYourRestaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealQuantityWithMeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealQuantity_Orders_OrderOder",
                table: "MealQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealQuantity",
                table: "MealQuantity");

            migrationBuilder.DropIndex(
                name: "IX_MealQuantity_OrderOder",
                table: "MealQuantity");

            migrationBuilder.DropColumn(
                name: "OrderOder",
                table: "MealQuantity");

            migrationBuilder.RenameColumn(
                name: "Oder",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MealQuantity",
                newName: "MealId");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "MealQuantity",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "MealQuantity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealQuantity",
                table: "MealQuantity",
                columns: new[] { "MealId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_MealQuantity_OrderId",
                table: "MealQuantity",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealQuantity_Meals_MealId",
                table: "MealQuantity",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealQuantity_Orders_OrderId",
                table: "MealQuantity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealQuantity_Meals_MealId",
                table: "MealQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_MealQuantity_Orders_OrderId",
                table: "MealQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealQuantity",
                table: "MealQuantity");

            migrationBuilder.DropIndex(
                name: "IX_MealQuantity_OrderId",
                table: "MealQuantity");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MealQuantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "Oder");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "MealQuantity",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MealQuantity",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderOder",
                table: "MealQuantity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealQuantity",
                table: "MealQuantity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MealQuantity_OrderOder",
                table: "MealQuantity",
                column: "OrderOder");

            migrationBuilder.AddForeignKey(
                name: "FK_MealQuantity_Orders_OrderOder",
                table: "MealQuantity",
                column: "OrderOder",
                principalTable: "Orders",
                principalColumn: "Oder");
        }
    }
}
