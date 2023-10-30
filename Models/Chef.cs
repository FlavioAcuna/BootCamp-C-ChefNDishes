#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using DateValidator.Models;

namespace ChefNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required(ErrorMessage = "El Campo es obligatorio")]
    [MinLength(5, ErrorMessage = "El nombre debe ser de minimo 5 caracteres")]
    public string Name { get; set; }
    [Required(ErrorMessage = "El Campo es obligatorio")]
    [MinLength(5, ErrorMessage = "El apellido debe ser de minimo 5 caracteres")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "El Campo es obligatorio")]
    [FutureDate]
    [MayorDeEdad]
    public DateTime Age { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public List<Dish> CreatedDishes { get; set; } = new List<Dish>();
}