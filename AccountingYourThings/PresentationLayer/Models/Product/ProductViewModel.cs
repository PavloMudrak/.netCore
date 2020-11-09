using System;
using System.Collections.Generic;
using System.Text;
using PresentationLayer.Models.Category;

namespace PresentationLayer.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
