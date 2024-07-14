using ASP_Sandbox.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_Sandbox.Repositories
{
  public class RecipeRepository : IRecipeRepository
  {
    private readonly SandboxContext _context;

    public RecipeRepository(SandboxContext context)
    {
      _context = context;
    }

    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
      return await _context.Recipes.FindAsync(id);
    }

    public async Task<List<Recipe>> GetRecipesByTagsAsync(string? tags)
    {
      var query = _context.Recipes.AsQueryable();

      if (!string.IsNullOrEmpty(tags))
      {
        var tagsList = tags.Split(',').ToList();
        query = query.Where(recipe => tagsList.All(tag => recipe.Tags.Contains(tag)));
      }

      return await query.ToListAsync();
    }

    public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
    {
      _context.Recipes.Add(recipe);
      await _context.SaveChangesAsync();
      return recipe;
    }

    public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
    {
      _context.Recipes.Update(recipe);
      await _context.SaveChangesAsync();
      return recipe;
    }

    public async Task<Recipe> DeleteRecipeAsync(int id)
    {
      var recipe = await _context.Recipes.FindAsync(id);
      if (recipe == null)
      {
        return null;
      }

      _context.Recipes.Remove(recipe);
      await _context.SaveChangesAsync();

      return recipe;
    }
  }
}