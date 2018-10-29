using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<PostTag, PostTagViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductTag, ProductTagViewModel>();
            CreateMap<Footer, FooterViewModel>();
        }
    }
}