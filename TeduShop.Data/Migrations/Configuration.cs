﻿namespace TeduShop.Data.Migrations
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
                    new Slide(){
                        Name ="Slide 1"
                        , DisplayOrder=1,Status=true
                        ,URL="#"
                        ,Image="/Asset/client/images/bag.jpg"
                        ,Content=@"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>					
								<span class=""on-get"">GET NOW</span>" },
                    new Slide(){
                        Name ="Slide 2"
                        , DisplayOrder=1
                        ,Status=true
                        ,URL="#"
                        ,Image="/Asset/client/images/bag1.jpg"
                        ,Content=@"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>					
								<span class=""on-get"">GET NOW</span>"
                    }
                };
                context.Slides.AddRange(listslide);
                context.SaveChanges();

            }
        }

        private void CreateContactDetail(TeduShopDbContext context)
        {
            if(context.ContactDetails.Count()==0)
            {
                try
                {
                    var contact = new TeduShop.Model.Models.ContactDetail()
                    {
                        Name = "Shop Trương Hoài Phúc",
                        Phone = "0979778828",
                        Email = "phucth@vsd.vn",
                        Address = "151 Nguyễn Đình Chiểu P6 Q3 TPHCM",
                        Lat = 10.7761264,
                        Lng = 106.6858901,
                        Website = "vsd.vn",
                        Other = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contact);
                    context.SaveChanges();
                }
                catch
                { }
            }
        }
    }
}
