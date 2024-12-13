using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Interfaces;

public interface IAuthorRepository
{
    public List<Author> Get();
    public List<Author> Get(int pageNumber, int pageSize, string name);
    public Author Get(long id);
    public Author GetAuthorBooks(long id);
    public int Count(string name);
    public void Insert(Author model);
    public void Update(Author model);
    public void Delete(Author model);
}