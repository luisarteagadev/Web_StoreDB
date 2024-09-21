using UESAN.StoreDB.DOMAIN.Infrastrcture.Data;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> getCategoryById(int id);
        Task<int> Insert(Category category);
        Task<bool> Update(Category category);
    }
}