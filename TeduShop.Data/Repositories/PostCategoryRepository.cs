﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
        
    }
    public class PostCategoryRepository : RepositoryBase<PostCategory>
    {
        public PostCategoryRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {
        }
    }
}
