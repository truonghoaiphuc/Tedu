using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByAlias(string alias);
        IEnumerable<Product> GetListProductByTag(string tagid, int page, int pageSize, out int totalRow);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetByAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias);
        }

        public IEnumerable<Product> GetListProductByTag(string tagid, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Products
                        join pt in DbContext.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID == tagid
                        select p;
            totalRow = query.Count();

            return query.OrderByDescending(x=>x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
