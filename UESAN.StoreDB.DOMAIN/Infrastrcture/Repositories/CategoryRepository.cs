using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.StoreDB.DOMAIN.Infrastrcture.Data;

namespace UESAN.StoreDB.DOMAIN.Infrastrcture.Repositories
{
    public class CategoryRepository
    {

        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public string getApellido()
        {
            return "";
        }
        //Método Sincrono
        //public IEnumerable<Category> getCategories() { 
        //var categories= _dbContext.Category.ToList();
        //    return categories;
        //}

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dbContext.Category.ToListAsync();
            return categories;
        }
        // Get Category by ID
        public async Task<Category> getCategoryById(int id)
        {
            var category = await _dbContext.
                Category.
                Where(
                c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();

            return category;
        }
        // Create category
        public async Task<int> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            //confirmar la transaccion  
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? category.Id : -1;

        }
        //Update category
        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        //Delete category
        public async Task<bool> Delete(int id)
        {
            var category = await _dbContext.Category.FirstOrDefaultAsync(C => C.Id == id);
            //int rows= await _dbContext.Category.Remove(category);
            //return rows>0;

            if (category != null) return false;

            category.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }
    }
}
