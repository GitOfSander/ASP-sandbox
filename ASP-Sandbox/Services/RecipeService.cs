using ASP_Sandbox.Controllers;
using ASP_Sandbox.Entities;
using ASP_Sandbox.Repositories;

namespace ASP_Sandbox.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _recipeRepository.GetRecipeByIdAsync(id);
        }

        public async Task<List<Recipe>> GetRecipesByTagsAsync(string? tags)
        {
            return await _recipeRepository.GetRecipesByTagsAsync(tags);
        }

        public async Task<Recipe> CreateRecipeAsync(RecipeCreateDto recipeDto)
        {
            var recipe = new Recipe
            {
                Title = recipeDto.Title,
                Description = recipeDto.Description,
                Ingredients = recipeDto.Ingredients,
                Tags = recipeDto.Tags
            };

            return await _recipeRepository.CreateRecipeAsync(recipe);
        }

        public async Task<Recipe> UpdateRecipeAsync(int id, RecipeUpdateDto recipeDto)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return null;
            }

            recipe.Title = recipeDto.Title;
            recipe.Description = recipeDto.Description;
            recipe.Ingredients = recipeDto.Ingredients;
            recipe.Tags = recipeDto.Tags;

            return await _recipeRepository.UpdateRecipeAsync(recipe);
        }

        public async Task<Recipe> DeleteRecipeAsync(int id)
        {
            return await _recipeRepository.DeleteRecipeAsync(id);
        }
    }
}