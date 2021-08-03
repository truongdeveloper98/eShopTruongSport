using eShopTruongSport.Data.Entities;
using eShopTruongSport.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTruongSport.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopTruongSport" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopTruongSport" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopTruongSport" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = 1,
                     SortOrder = 2,
                     Status = Status.Active
                 },
                new Category()
                {
                    Id = 3,
                    IsShowOnHome = true,
                    ParentId = 1,
                    SortOrder = 3,
                    Status = Status.Active
                },
                 new Category()
                 {
                     Id = 4,
                     IsShowOnHome = true,
                     ParentId = 2,
                     SortOrder = 4,
                     Status = Status.Active
                 },
                  new Category()
                  {
                      Id = 5,
                      IsShowOnHome = true,
                      ParentId = 3,
                      SortOrder = 5,
                      Status = Status.Active
                  });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Giày Đá Bóng", LanguageId = "vi", SeoAlias = "giay-da-bong", SeoDescription = "Sản phẩm giày đá bóng", SeoTitle = "Sản phẩm giày đá bóng" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "soccer shoes", LanguageId = "en", SeoAlias = "soccer-shoes", SeoDescription = "The soccer shoes", SeoTitle = "The soccer shoes" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Giày sân cỏ nhân tạo", LanguageId = "vi", SeoAlias = "giay-san-co-nhan-tao", SeoDescription = "Sản phẩm giày đá bóng sân cỏ nhân tạo", SeoTitle = "Sản phẩm giày đá bóng sân cỏ nhân tạo" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Artificial turf shoes", LanguageId = "en", SeoAlias = "artificial-turf-shoes", SeoDescription = "Products football shoes artificial turf", SeoTitle = "Products football shoes artificial turf" },
                  new CategoryTranslation() { Id = 5, CategoryId = 3, Name = "Giày sân cỏ tự nhiên", LanguageId = "vi", SeoAlias = "giay-san-co-tu-nhien", SeoDescription = "Sản phẩm giày đá bóng sân cỏ tự nhiên", SeoTitle = "Sản phẩm giày đá bóng sân cỏ tự nhiên" },
                  new CategoryTranslation() { Id = 6, CategoryId = 3, Name = "Natural turf shoes", LanguageId = "en", SeoAlias = "natural-turf-shoes", SeoDescription = "Natural turf soccer shoes", SeoTitle = "Natural turf soccer shoes" },
                  new CategoryTranslation() { Id = 7, CategoryId = 4, Name = "Giày TA11 sân cỏ nhân tạo", LanguageId = "vi", SeoAlias = "giay-ta11-san-co-nhan-tao", SeoDescription = "Sản phẩm giày đá bóng TA11 sân cỏ nhân tạo", SeoTitle = "Sản phẩm giày đá bóng TA11 sân cỏ nhân tạo" },
                  new CategoryTranslation() { Id = 8, CategoryId = 4, Name = "TA11 artificial turf shoes", LanguageId = "en", SeoAlias = "artificial-turf-shoes", SeoDescription = "Products TA11 football shoes artificial turf", SeoTitle = "Products TA11 football shoes artificial turf" },
                  new CategoryTranslation() { Id = 9, CategoryId = 5, Name = "Giày TA11 sân cỏ tự nhiên", LanguageId = "vi", SeoAlias = "giay-ta11-san-co-tu-nhien", SeoDescription = "Sản phẩm giày đá bóng TA11 sân cỏ tự nhiên", SeoTitle = "Sản phẩm giày đá bóng TA11 sân cỏ tự nhiên" },
                  new CategoryTranslation() { Id = 10, CategoryId = 5, Name = "TA11 shoes for natural grass", LanguageId = "en", SeoAlias = "TA11-shoes-for-natural-grass", SeoDescription = "Products TA11 shoes for natural grass courts", SeoTitle = "Products TA11 shoes for natural grass courts" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo t-shirt trắng thể thao nam Kamito",
                     LanguageId = "vi",
                     SeoAlias = "ao-t-shirt-the-thao-kamito",
                     SeoDescription = "Áo t-shirt trắng thể thao nam Kamito",
                     SeoTitle = "Áo t-shirt trắng thể thao nam Kamito",
                     Details = "Áo t-shirt trắng thể thao nam Kamito",
                     Description = "Áo t-shirt trắng thể thao nam Kamito"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Kamito Men sport T-Shirt",
                        LanguageId = "en",
                        SeoAlias = "kamito-men-sport-t-shirt",
                        SeoDescription = "kamito-men-sport-t-shirt",
                        SeoTitle = "kamito-men-sport-t-shirt",
                        Details = "kamito-men-sport-t-shirt",
                        Description = "kamito-men-sport-t-shirt"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "truongcntt98@gmail.com",
                NormalizedEmail = "truongcntt98@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "truonghust98"),
                SecurityStamp = string.Empty,
                FirstName = "Truong",
                LastName = "Dinh",
                Dob = new DateTime(2020,01,31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<Slide>().HasData(
             new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/products/p3.jpg", Status = Status.Active },
             new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/products/p2.jpg", Status = Status.Active },
             new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/products/p1.jpg", Status = Status.Active }
             );
        }

        


    }
}
