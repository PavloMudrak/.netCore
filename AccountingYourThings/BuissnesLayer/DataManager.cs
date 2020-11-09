using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public DataManager(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public ICategoryRepository Category => _categoryRepository;
        public IProductRepository Product => _productRepository;
    }
}
