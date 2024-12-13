using System.ComponentModel.DataAnnotations;

namespace WinterholdWeb.ViewModels.Author;

public class AuthorFormViewModel
{
    public long Id { get; set; }
    [Required]
    [StringLength(maximumLength:10)]
    public string Title { get; set; } = null!;
    [Required]
    [StringLength(maximumLength:50)]
    public string FirstName { get; set; } = null!;
    [StringLength(maximumLength:50)]
    public string? LastName { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }

    [ValidationDate]
    public DateTime? DeceasedDate { get; set; }
    [StringLength(maximumLength:50)]
    public string? Education { get; set; }
    [StringLength(maximumLength:500)]
    public string? Summary { get; set; }
}