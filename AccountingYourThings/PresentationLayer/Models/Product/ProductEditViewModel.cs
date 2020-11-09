using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models.Product
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ControllerForRedirect { get; set; }

    }
}
