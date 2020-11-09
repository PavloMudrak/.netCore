using System;
using System.Collections.Generic;
using System.Text;
using PresentationLayer.Models.Product;

namespace PresentationLayer.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductViewModel> Products { get; set; }

        public CategoryViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}
