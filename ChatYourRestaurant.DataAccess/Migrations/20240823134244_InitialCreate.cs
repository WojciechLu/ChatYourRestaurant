using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatYourRestaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Oder = table.Column<Guid>(type: "TEXT", nullable: false),
                    MealId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Oder);
                    table.ForeignKey(
                        name: "FK_Orders_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Description", "Name", "Price" },
                values: new object[,]
                {
                    { "Crispy romaine lettuce, grilled chicken, and Caesar dressing topped with parmesan and croutons.", "Grilled Chicken Caesar Salad", 12.99m },
                    { "Classic pizza topped with fresh mozzarella, tomatoes, and basil on a thin crust.", "Margherita Pizza", 10.50m },
                    { "Juicy beef patty with lettuce, tomato, pickles, and cheddar cheese on a toasted bun.", "Beef Burger", 9.75m },
                    { "Creamy pasta with pancetta, egg, and parmesan, garnished with parsley.", "Spaghetti Carbonara", 13.45m },
                    { "A nutritious mix of quinoa, chickpeas, avocado, and roasted vegetables with a tahini dressing.", "Vegan Buddha Bowl", 11.25m },
                    { "Tender chicken in a spiced tomato-based sauce served with basmati rice and naan.", "Chicken Tikka Masala", 14.00m },
                    { "Crispy battered fish served with golden fries and tartar sauce.", "Fish and Chips", 12.50m },
                    { "Assorted vegetable sushi rolls with soy sauce, wasabi, and pickled ginger.", "Vegetarian Sushi Platter", 15.00m },
                    { "Slow-cooked ribs smothered in tangy barbecue sauce, served with coleslaw.", "BBQ Ribs", 17.95m },
                    { "A refreshing mix of cucumbers, tomatoes, olives, feta cheese, and red onions with a lemon-oregano dressing.", "Greek Salad", 8.75m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MealId",
                table: "Orders",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
