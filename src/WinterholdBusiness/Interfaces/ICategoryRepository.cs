using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Interfaces;

public interface ICategoryRepository
{
    public List<Category> Get(int pageNumber, int pageSize, string name);
    public Category Get(string name);
    // public Category GetCategoryBooks (string name);
    public int Count(string name);
    public Category Insert(Category model);
    public Category Update(Category model);
    public void Delete(Category model);
}
