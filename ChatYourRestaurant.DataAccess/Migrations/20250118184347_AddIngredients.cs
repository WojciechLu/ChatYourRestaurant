using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatYourRestaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientMeal",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeal", x => new { x.IngredientId, x.MealId });
                    table.ForeignKey(
                        name: "FK_IngredientMeal_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMeal_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeal_MealId",
                table: "IngredientMeal",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMeal");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Crispy romaine lettuce, grilled chicken, and Caesar dressing topped with parmesan and croutons.", "Grilled Chicken Caesar Salad", 12.99m },
                    { 2, "Classic pizza topped with fresh mozzarella, tomatoes, and basil on a thin crust.", "Margherita Pizza", 10.50m },
                    { 3, "Juicy beef patty with lettuce, tomato, pickles, and cheddar cheese on a toasted bun.", "Beef Burger", 9.75m },
                    { 4, "Creamy pasta with pancetta, egg, and parmesan, garnished with parsley.", "Spaghetti Carbonara", 13.45m },
                    { 5, "A nutritious mix of quinoa, chickpeas, avocado, and roasted vegetables with a tahini dressing.", "Vegan Buddha Bowl", 11.25m },
                    { 6, "Tender chicken in a spiced tomato-based sauce served with basmati rice and naan.", "Chicken Tikka Masala", 14.00m },
                    { 7, "Crispy battered fish served with golden fries and tartar sauce.", "Fish and Chips", 12.50m },
                    { 8, "Assorted vegetable sushi rolls with soy sauce, wasabi, and pickled ginger.", "Vegetarian Sushi Platter", 15.00m },
                    { 9, "Slow-cooked ribs smothered in tangy barbecue sauce, served with coleslaw.", "BBQ Ribs", 17.95m },
                    { 10, "A refreshing mix of cucumbers, tomatoes, olives, feta cheese, and red onions with a lemon-oregano dressing.", "Greek Salad", 8.75m }
                });
        }
    }
}
