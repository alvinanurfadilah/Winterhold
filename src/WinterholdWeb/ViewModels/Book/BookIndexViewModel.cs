namespace WinterholdWeb.ViewModels.Book;

public class BookIndexViewModel
{
    public List<BookViewModel> Books { get; set; } = new List<BookViewModel>();
    public PaginationViewModel Pagination { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; }
    public string Name { get; set; }
}