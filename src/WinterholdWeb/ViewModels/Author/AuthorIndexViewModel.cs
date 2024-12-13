namespace WinterholdWeb.ViewModels.Author;

public class AuthorIndexViewModel
{
    public List<AuthorViewModel> Authors { get; set; }
    public PaginationViewModel Pagination { get; set; }
    public string Name { get; set; }
}