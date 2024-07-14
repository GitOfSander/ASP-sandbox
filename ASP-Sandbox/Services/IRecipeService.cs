using ASP_Sandbox.Controllers;
using ASP_Sandbox.Entities;

namespace ASP_Sandbox.Services
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<List<Recipe>> GetRecipesByTagsAsync(string? tags);
        Task<Recipe> CreateRecipeAsync(RecipeCreateDto recipeDto);
        Task<Recipe> UpdateRecipeAsync(int id, RecipeUpdateDto recipeDto);
        Task<Recipe> DeleteRecipeAsync(int id);
    }
}
