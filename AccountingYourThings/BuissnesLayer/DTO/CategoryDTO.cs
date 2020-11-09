using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductDTO> ProductsDTO { get; set; }

        public CategoryDTO()
        {
            ProductsDTO = new List<ProductDTO>();
        }
    }
}
