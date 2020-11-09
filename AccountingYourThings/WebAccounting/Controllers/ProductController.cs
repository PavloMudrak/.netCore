using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Mapper;
using PresentationLayer.Models.Category;
using PresentationLayer.Models.Product;

namespace WebAccounting.Controllers
{
    public class ProductController : Controller
    {
        private DataManager _dataManager;
        public ProductController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Index()
        {
            var productsDto = _dataManager.Product.GetAllProducts();
            var productsViewModel = ProductMapper.MapFromProductDTOToProductViewModelList(productsDto);
            return View(productsViewModel);
        }

        public IActionResult Create(string controllerForRedirect, int categoryId)
        {
            ProductEditViewModel model = new ProductEditViewModel();
            if (categoryId != null)
            {
                model.CategoryId = categoryId;
            }
            model.ControllerForRedirect = controllerForRedirect;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ProductEditViewModel product)
        {
            var productDTO = ProductMapper.MapFromProductEditViewModelToProductDTO(product);
            _dataManager.Product.SaveProduct(productDTO);
            if (product.ControllerForRedirect == "Category")
            {
                return Redirect($"~/Category/Details/{product.CategoryId}");
            }
            return Redirect("~/Product/Index");
        }
        public ActionResult Delete(int id, string controllerForRedirect)
        {
            var categoryId = _dataManager.Product.GetProductById(id).CategoryId;
            _dataManager.Product.DeleteProduct(id);
            if (controllerForRedirect == "Category")
            {
                return Redirect($"~/Category/Details/{categoryId}");
            }
            return Redirect("~/Product/Index");
        }
        public ActionResult Edit(int id, string controllerForRedirect)
        {
            var product = _dataManager.Product.GetProductById(id);
            var mappedProduct = ProductMapper.MapFromProductDTOToProductEditViewModel(product);

            return View(mappedProduct);
        }
        [HttpPost]
        public ActionResult Edit(ProductEditViewModel productViewModel)
        {
            var productDTO = ProductMapper.MapFromProductEditViewModelToProductDTO(productViewModel);
            _dataManager.Product.SaveProduct(productDTO);
            if (productViewModel.ControllerForRedirect == "Category")
            {
                return Redirect($"~/Category/Details/{productViewModel.CategoryId}");
            }
            return Redirect("~/Product/Index");
        }
    }
}