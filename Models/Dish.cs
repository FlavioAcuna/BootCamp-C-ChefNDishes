#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ChefNDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1, 5)]
    public int Tastinness { get; set; }
    [Required]
    [Range(0, double.PositiveInfinity)]
    public int Calories { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public int ChefId { get; set; }

    public Chef? Creator { get; set; }
}