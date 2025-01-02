using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Recipes.UI.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Salad" },
                    { 2, "Snack" },
                    { 3, "Dessert" },
                    { 4, "Beverage" },
                    { 5, "Soup" },
                    { 6, "Appetizer" },
                    { 7, "Main Dish" },
                    { 8, "Cocktail" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "ID", "Author", "Category", "Content", "CreatedDate", "Name", "UpdateBy", "UpdatedDate" },
                values: new object[] { 1, "Virginia Wahus", 0, "# Peanut Butter Round-Up Cookies\r\n\r\n**By:** Virginia Wahus\r\n\r\n## Ingredients\r\n\r\n- 1 cup shortening\r\n- 2 cups flour\r\n- 1 cup brown sugar\r\n- 3/4 cup sugar\r\n- 2 teaspoons baking soda\r\n- 1/2 teaspoon salt\r\n- 2 eggs\r\n- 1 cup oatmeal\r\n- 1 cup creamy peanut butter\r\n\r\n## Instructions\r\n\r\n1. Preheat the oven to 350°F (175°C).\r\n2. Shape the dough into 1-inch balls.\r\n3. Place the balls on an ungreased cookie sheet.\r\n4. Press each ball with a fork to create a crisscross pattern.\r\n5. Bake for 8 to 10 minutes.", new DateTime(2025, 1, 1, 22, 17, 3, 680, DateTimeKind.Local).AddTicks(3061), "Peanut Butter Round-Up Cookies", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
