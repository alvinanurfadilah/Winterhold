using Microsoft.EntityFrameworkCore;
using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly WinterholdContext _dbContext;

    public CategoryRepository(WinterholdContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Category> Get(int pageNumber, int pageSize, string name)
    {
        return _dbContext.Categories
        .Where(category => category.Name.ToLower().Contains(name??"".ToLower()))
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    }

    public Category Get(string name)
    {
        return _dbContext.Categories.Find(name);
    }

    // public Category GetCategoryBooks(string name)
    // {
    //     return _dbContext.Categories
    //     .Include(category => category.Books)
    //     .Where(category => category.Name == name)
    //     .FirstOrDefault();
    // }

    public int Count(string name)
    {
        return _dbContext.Categories
        .Where(category => category.Name.ToLower().Contains(name??"".ToLower()))
        .Count();
    }

    public Category Insert(Category model)
    {
        _dbContext.Categories.Add(model);
        _dbContext.SaveChanges();
        return model;
    }

    public Category Update(Category model)
    {
        _dbContext.Categories.Update(model);
        _dbContext.SaveChanges();
        return model;
    }

    public void Delete(Category model)
    {
        _dbContext.Categories.Remove(model);
        _dbContext.SaveChanges();
    }
}