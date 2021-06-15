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
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

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
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo T-Shirt thể thao nam", SeoTitle = "Sản phẩm áo T-Shirt thể thao nam" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men T-Shirt", LanguageId = "en-US", SeoAlias = "men-t-shirt", SeoDescription = "The t-shirt sport products for men", SeoTitle = "The t-shirt sport products for men" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo T-Shirt thể thao nữ", SeoTitle = "Sản phẩm áo T-Shirt thể thao women" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The t-shirt sport products for women", SeoTitle = "The t-shirt sport products for women" }
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
                     LanguageId = "vi-VN",
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
                        LanguageId = "en-US",
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
        }

        


    }
}
