using ProductInventoryAPI.Models;

namespace ProductInventoryAPI.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(ProductInventoryDbContext context) : base(context)
        {
        }
    }
}
