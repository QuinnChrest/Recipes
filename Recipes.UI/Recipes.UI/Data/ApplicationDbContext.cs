using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipes.UI.Models;

namespace Recipes.UI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { ID = 1, Name = "Peanut Butter Round-Up Cookies", Author = "Virginia Wahus", CreatedDate = DateTime.Now, Content = "# Peanut Butter Round-Up Cookies\r\n\r\n**By:** Virginia Wahus\r\n\r\n## Ingredients\r\n\r\n- 1 cup shortening\r\n- 2 cups flour\r\n- 1 cup brown sugar\r\n- 3/4 cup sugar\r\n- 2 teaspoons baking soda\r\n- 1/2 teaspoon salt\r\n- 2 eggs\r\n- 1 cup oatmeal\r\n- 1 cup creamy peanut butter\r\n\r\n## Instructions\r\n\r\n1. Preheat the oven to 350°F (175°C).\r\n2. Shape the dough into 1-inch balls.\r\n3. Place the balls on an ungreased cookie sheet.\r\n4. Press each ball with a fork to create a crisscross pattern.\r\n5. Bake for 8 to 10 minutes." }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Salad"},
                new Category { ID = 2, Name = "Snack" },
                new Category { ID = 3, Name = "Dessert" },
                new Category { ID = 4, Name = "Beverage" },
                new Category { ID = 5, Name = "Soup" },
                new Category { ID = 6, Name = "Appetizer" },
                new Category { ID = 7, Name = "Main Dish" },
                new Category { ID = 8, Name = "Cocktail" }
            );
        }
    }
}
