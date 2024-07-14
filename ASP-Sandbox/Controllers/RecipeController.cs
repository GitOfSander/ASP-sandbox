using ASP_Sandbox.Entities;
using ASP_Sandbox.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Sandbox.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> Get(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound(new { Message = "Recipe not found." });
            }
            return Ok(recipe);
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetList([FromQuery] string? tags)
        {
            var recipes = await _recipeService.GetRecipesByTagsAsync(tags);
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> Post([FromBody] RecipeCreateDto recipeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipe = await _recipeService.CreateRecipeAsync(recipeDto);
            return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Recipe>> Put(int id, [FromBody] RecipeUpdateDto recipeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipe = await _recipeService.UpdateRecipeAsync(id, recipeDto);
            if (recipe == null)
            {
                return NotFound(new { Message = "Recipe not found." });
            }

            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> Delete(int id)
        {
            var recipe = await _recipeService.DeleteRecipeAsync(id);
            if (recipe == null)
            {
                return NotFound(new { Message = "Recipe not found." });
            }

            return Ok(recipe);
        }
    }

    public class RecipeCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Tags { get; set; }
    }

    public class RecipeUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Tags { get; set; }
    }
}