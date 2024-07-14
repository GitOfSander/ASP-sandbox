using System.ComponentModel.DataAnnotations;

namespace ASP_Sandbox.Entities;

public sealed class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
}