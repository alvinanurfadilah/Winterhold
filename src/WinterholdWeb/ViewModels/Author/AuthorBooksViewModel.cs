using WinterholdWeb.ViewModels.Book;

namespace WinterholdWeb.ViewModels;

public class AuthorBooksViewModel
{
    public string FullName { get; set; }
    public string BirthDate { get; set; }
    public string DeceasedDate { get; set; }
    public string Education { get; set; }
    public string Summary { get; set; }
    public List<BookViewModel> AuthorBooks { get; set; }
}