using System.ComponentModel.DataAnnotations;
using WinterholdAPI.Validation;

namespace WinterholdAPI.Categories;

public class CategoryFormDTO
{
    [Required]
    [StringLength(maximumLength:100)]
    // [UniqueCategoryName]
    public string Name { get; set; } = null!;
    [Required]
    public int Floor { get; set; }
    [Required]
    [StringLength(maximumLength:10)]
    public string Isle { get; set; } = null!;
    [Required]
    [StringLength(maximumLength:10)]
    public string Bay { get; set; } = null!;
}