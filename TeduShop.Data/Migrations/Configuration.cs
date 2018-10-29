namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeduShop.Common;
    using TeduShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            //CreateProductCategorySample(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            CreateUser(context);
            CreateProductCategorySample(context);
            CreateSlide(context);
            
        }

        private void CreateUser(TeduShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "phucth",
                Email = "phucvsd@gmail.com",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName = "Trương Hoài Phúc"

            };
            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("phucvsd@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory(){Name="Điện lạnh", Alias="dien-lanh", Status=true},
                new ProductCategory(){Name="Viễn thông", Alias="vien-thong", Status=true},
                new ProductCategory(){Name="Đồ gia dụng", Alias="do-gia-dung", Status=true},
                new ProductCategory(){Name="Mỹ phẩm", Alias="my-pham", Status=true}
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        //private void CreateFooter(TeduShopDbContext context)
        //{
        //    if(context.Footers.Where(x=>x.ID== commonConstanst.DefaultFooterId).Count()==0)
        //    {
        //        context.Footers.Add(new Footer() { ID=commonConstant})
        //    }
        //}

        private void CreateSlide(TeduShopDbContext context)
        {
            if(context.Slides.Count()==0)
            {
                List<Slide> listslide = new List<Slide>()
                {
                    new Slide(){ Name="Slide 1", DisplayOrder=1,Status=true,Image="" }
                };
                context.Slides.AddRange(listslide);
                context.SaveChanges();

            }
        }
    }
}
