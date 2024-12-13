using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinterholdWeb.Validation;
using WinterholdWeb.ViewModels.Category;

namespace WinterholdWeb.ViewModels.Book;

public class BookFormViewModel
{
    [Required]
    [StringLength(maximumLength:20)]
    // [UniqueBookCode]
    public string Code { get; set; } = null!;
    [Required]
    [StringLength(maximumLength:100)]
    public string Title { get; set; } = null!;
    [StringLength(maximumLength:100)]
    public string CategoryName { get; set; } = null!;
    [Required]
    public long AuthorId { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? TotalPage { get; set; }
    [StringLength(maximumLength:500)]
    public string? Summary { get; set; }

    public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();
}