using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapper.Category;
using BusinessLayer.Mapper.Product;
using DataLayer.Context;
using DataLayer.Entities;

namespace BusinessLayer.Implementations
{
    public class EFProductRepository : IProductRepository
    {
        private EfDbContext context;

        public EFProductRepository(EfDbContext context)
        {
            this.context = context;
        }
        public List<ProductDTO> GetAllProducts()
        {
            var products = context.Products.ToList();
            var productsDTO = ProductsMapper.MapFromProductToProductDTOList(products);
            return productsDTO;
        }

        public ProductDTO GetProductById(int productId)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == productId);
            var mappedProduct = ProductsMapper.MapFromProductToProductDTOSingle(product);
            return mappedProduct;
        }

        public void SaveProduct(ProductDTO product)
        {
            var productInDatabase = context.Products.FirstOrDefault(x => x.Id == product.Id);
            var mappedProduct = ProductsMapper.MapFromProductDTOToProductSingle(product);
            if (productInDatabase == null)
            {
                context.Products.Add(mappedProduct);
            }
            else
            {
                productInDatabase.Name = product.Name;
                productInDatabase.Description = product.Description;
                productInDatabase.CategoryId = product.CategoryId;
            }
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
                context.Products.Remove(context.Products.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
        }
    }
}
