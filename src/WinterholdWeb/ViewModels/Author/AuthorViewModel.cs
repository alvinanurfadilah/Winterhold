using WinterholdWeb.ViewModels.Book;

namespace WinterholdWeb.ViewModels.Author;

public class AuthorViewModel
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Status { get; set; }
    public string? Education { get; set; }

    public List<BookViewModel> Books { get; set; }
}