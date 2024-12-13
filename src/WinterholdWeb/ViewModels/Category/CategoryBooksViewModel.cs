using WinterholdWeb.ViewModels.Book;

namespace WinterholdWeb.ViewModels.Category;

public class CategoryBooksViewModel
{
    // public string Title { get; set; }
    // public string Author { get; set; }
    // public bool IsBorrowed { get; set; }
    public string Name { get; set; }
    public List<BookViewModel> CategoryBooks { get; set; } = new List<BookViewModel>();
}