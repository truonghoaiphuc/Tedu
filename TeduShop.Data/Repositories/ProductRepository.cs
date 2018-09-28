using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetByAlias(string alias);
    }
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetByAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias);
        }
    }
}
