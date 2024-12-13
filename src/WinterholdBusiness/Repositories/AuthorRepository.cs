using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace WinterholdBusiness.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly WinterholdContext _dbContext;

    public AuthorRepository(WinterholdContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Author> Get()
    {
        return _dbContext.Authors.ToList();
    }

    public List<Author> Get(int pageNumber, int pageSize, string name)
    {
        return _dbContext.Authors
        .Where(author => author.FirstName.ToLower().Contains(name??"".ToLower()) || author.LastName.ToLower().Contains(name??"".ToLower()))
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    }

    public Author Get(long id)
    {
        return _dbContext.Authors.Find(id);
    }

    public Author GetAuthorBooks(long id)
    {
        return _dbContext.Authors
        .Include(author => author.Books)
        .Where(author => author.Id == id)
        .FirstOrDefault();
    }

    public int Count(string name)
    {
        return _dbContext.Authors
        .Where(author => author.FirstName.ToLower().Contains(name??"".ToLower()) || author.LastName.ToLower().Contains(name??"".ToLower()))
        .Count();
    }

    public void Insert(Author model)
    {
        _dbContext.Authors.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(Author model)
    {
        _dbContext.Authors.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(Author model)
    {
        _dbContext.Authors.Remove(model);
        _dbContext.SaveChanges();
    }
}
