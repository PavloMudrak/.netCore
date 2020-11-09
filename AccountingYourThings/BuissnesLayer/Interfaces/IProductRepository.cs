using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.DTO;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IProductRepository
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int productId);
        void SaveProduct(ProductDTO product);
        void DeleteProduct(int id);

    }
}
