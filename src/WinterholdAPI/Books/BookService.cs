using WinterholdBusiness.Interfaces;

namespace WinterholdAPI.Books;

public class BookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public BookDTO GetSummary(string code)
    {
        var model =  _repository.GetSummary(code);

        return new BookDTO()
        {
            Code = model.Code,
            Summary = model.Summary
        };
    }
}
