using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryvm)
        {
            postCategory.ID = postCategoryvm.ID;
            postCategory.Name = postCategoryvm.Name;
            postCategory.Alias = postCategoryvm.Alias;
            postCategory.Description = postCategoryvm.Description;
            postCategory.ParentID = postCategoryvm.ParentID;
            postCategory.DisplayOrder = postCategoryvm.DisplayOrder;
            postCategory.Image = postCategoryvm.Image;
            postCategory.HomeFlag = postCategoryvm.HomeFlag;

            postCategory.CreatedDate = postCategoryvm.CreatedDate;
            postCategory.CreatedBy = postCategoryvm.CreatedBy;
            postCategory.UpdatedDate = postCategoryvm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryvm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryvm.MetaKeyword;
            postCategory.MetaDescription = postCategoryvm.MetaDescription;
            postCategory.Status = postCategoryvm.Status;            

        }

        public static void UpdatePost(this Post post, PostViewModel postvm)
        {
            post.ID = postvm.ID;
            post.Name = postvm.Name;
            post.Alias = postvm.Alias;
            post.Description = postvm.Description;
            post.CategoryID = postvm.CategoryID;
            post.Content = postvm.Content;
            post.Image = postvm.Image;
            post.HomeFlag = postvm.HomeFlag;
            post.ViewCount = postvm.ViewCount;

            post.CreatedDate = postvm.CreatedDate;
            post.CreatedBy = postvm.CreatedBy;
            post.UpdatedDate = postvm.UpdatedDate;
            post.UpdatedBy = postvm.UpdatedBy;
            post.MetaKeyword = postvm.MetaKeyword;
            post.MetaDescription = postvm.MetaDescription;
            post.Status = postvm.Status;
        }
    }
}