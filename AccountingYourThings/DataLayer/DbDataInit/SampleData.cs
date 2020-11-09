using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataLayer.DbDataInit
{
    public static class SampleData
    {
        public static void InitData(EfDbContext context)
        {
            if (!context.Category.Any())
            {
                context.Category.Add(new Category { Name = "Main", Description = "Category for all products" });
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                var id = context.Category.ToList();
                context.Products.Add(new Product { Name = "First product", Description = "Our first product", CategoryId = id[0].Id });
                context.Products.Add(new Product { Name = "Test product 1", Description = "Test", CategoryId = id[0].Id });
                context.Products.Add(new Product { Name = "Test product 2", Description = "Test", CategoryId = id[0].Id });
                context.Products.Add(new Product { Name = "Test product 3", Description = "Test", CategoryId = id[0].Id });
                context.SaveChanges();
            }
        }
    }
}
