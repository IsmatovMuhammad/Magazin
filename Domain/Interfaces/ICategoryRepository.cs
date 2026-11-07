namespace Domain.Models;

public interface ICategoryRepository
{
    Task<bool> AddCategory(Category category);
    Task<bool> DeleteCategory(int id);
    Task<bool> UpdateCategory(Category category);
    Task<Category> GetCategory(int id);
    Task<List<Category>> GetCategories();
}