namespace WinterholdWeb.ViewModels.Book;

public class BookViewModel
{
    public string Code { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string Author { get; set; }
    public string IsBorrowed { get; set; }
    public string? Summary { get; set; }
    public string? ReleaseDate { get; set; }
    public int? TotalPage { get; set; }
}