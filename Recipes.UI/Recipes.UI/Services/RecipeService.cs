using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Recipes.UI.Data;
using Recipes.UI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Recipes.UI.Services;

public class RecipeService
{
    private readonly ApplicationDbContext _dbContext;

    public RecipeService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(List<Recipe> recipes, int pageCount)> GetRecipes(string search, List<int> categories, int pageNumber, int pageSize)
    {
        // Base query
        var query = _dbContext.Recipes.AsQueryable();

        // Apply filters
        if (categories != null && categories.Any())
        {
            query = query.Where(r => categories.Contains(r.Category));
        }
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(r => r.Name.Contains(search));
        }

        // Paginate the query
        var recipes = await query
            .OrderBy(r => r.ID) // Ensure consistent ordering
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (recipes, (int)Math.Ceiling((double)recipes.Count() / pageSize));
    }

    [Authorize(Roles = "Admin")]
    public async Task<bool> AddRecipe(Recipe recipe)
    {
        try
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    [Authorize(Roles = "Admin")]
    public async Task<bool> DeleteRecipe(int ID)
    {
        try
        {
            Recipe record = await _dbContext.Recipes.Where(recipe => recipe.ID == ID).FirstOrDefaultAsync();

            if(record != null)
            {
                _dbContext.Recipes.Remove(record);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    [Authorize(Roles = "Admin")]
    public async Task<bool> UpdateRecipe(Recipe recipe)
    {
        try
        {
            _dbContext.Recipes.Update(recipe);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<Dictionary<int, string>> GetCategories()
    {
        return await _dbContext.Categories
            .ToDictionaryAsync(category => category.ID, category => category.Name);
    }
}
