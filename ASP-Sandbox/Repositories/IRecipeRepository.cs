using ASP_Sandbox.Entities;

namespace ASP_Sandbox.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<List<Recipe>> GetRecipesByTagsAsync(string? tags);
        Task<Recipe> CreateRecipeAsync(Recipe recipe);
        Task<Recipe> UpdateRecipeAsync(Recipe recipe);
        Task<Recipe> DeleteRecipeAsync(int id);
    }
}
