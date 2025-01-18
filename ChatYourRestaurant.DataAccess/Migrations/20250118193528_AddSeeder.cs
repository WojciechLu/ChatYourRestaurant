using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatYourRestaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lettuce" },
                    { 2, "Chicken" },
                    { 3, "Caesar Dressing" },
                    { 4, "Parmesan" },
                    { 5, "Croutons" },
                    { 6, "Mozzarella" },
                    { 7, "Tomato" },
                    { 8, "Basil" },
                    { 9, "Beef Patty" },
                    { 10, "Pickles" },
                    { 11, "Cheese" },
                    { 12, "Bun" },
                    { 13, "Pasta" },
                    { 14, "Pancetta" },
                    { 15, "Egg" },
                    { 16, "Parmesan" },
                    { 17, "Parsley" },
                    { 18, "Quinoa" },
                    { 19, "Chickpeas" },
                    { 20, "Avocado" },
                    { 21, "Roasted Vegetables" },
                    { 22, "Tahini Dressing" },
                    { 23, "Chicken" },
                    { 24, "Tomato Sauce" },
                    { 25, "Rice" },
                    { 26, "Naan" },
                    { 27, "Fish" },
                    { 28, "Fries" },
                    { 29, "Tartar Sauce" },
                    { 30, "Cucumber" },
                    { 31, "Mango" },
                    { 32, "Soy Sauce" },
                    { 33, "Wasabi" },
                    { 34, "Ginger" },
                    { 35, "Ribs" },
                    { 36, "Barbecue Sauce" },
                    { 37, "Carrots" },
                    { 38, "Olives" },
                    { 39, "Red Onions" },
                    { 40, "Lemon-Oregano Dressing" }
                });

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

            migrationBuilder.InsertData(
                table: "IngredientMeal",
                columns: new[] { "IngredientId", "MealId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 9 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 10 },
                    { 8, 2 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 11, 10 },
                    { 12, 3 },
                    { 13, 4 },
                    { 14, 4 },
                    { 15, 4 },
                    { 16, 4 },
                    { 17, 4 },
                    { 18, 5 },
                    { 19, 5 },
                    { 20, 5 },
                    { 20, 8 },
                    { 21, 5 },
                    { 22, 5 },
                    { 23, 6 },
                    { 24, 6 },
                    { 25, 6 },
                    { 26, 6 },
                    { 27, 7 },
                    { 28, 7 },
                    { 29, 7 },
                    { 30, 8 },
                    { 30, 10 },
                    { 31, 8 },
                    { 32, 8 },
                    { 33, 8 },
                    { 34, 8 },
                    { 35, 9 },
                    { 36, 9 },
                    { 37, 9 },
                    { 38, 10 },
                    { 39, 10 },
                    { 40, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 17, 4 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 18, 5 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 19, 5 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 20, 5 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 20, 8 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 22, 5 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 23, 6 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 24, 6 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 25, 6 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 26, 6 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 27, 7 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 28, 7 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 29, 7 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 30, 8 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 30, 10 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 31, 8 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 32, 8 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 33, 8 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 34, 8 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 35, 9 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 36, 9 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 37, 9 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 38, 10 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 39, 10 });

            migrationBuilder.DeleteData(
                table: "IngredientMeal",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 40, 10 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 40);

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
        }
    }
}
