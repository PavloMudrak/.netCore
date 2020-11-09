using System;
using System.Collections.Generic;
using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Mapper.Category;
using BusinessLayer.Mapper.Product;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Mapper;
using PresentationLayer.Models.Category;
using PresentationLayer.Models.Product;

namespace WebAccounting.Controllers
{
    public class CategoryController : Controller
    {
        private DataManager _dataManager;
        public CategoryController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Index()
        {
            List<CategoryDTO> categoryDtos = _dataManager.Category.GetAllCategories();
            var categoies = CategorieMapper.MapCategoryDTOtoViewModelList(categoryDtos);
            foreach (var category in categoryDtos)
            {
                foreach (var productDto in category.ProductsDTO)
                {
                    var productView = ProductMapper.MapFromProductDTOToProductViewModel(productDto);
                    var categoryView = categoies.Find(x => x.Id == category.Id);
                    categoryView.Products.Add(productView);
                }
            }
            return View(categoies);
        }
        public IActionResult Details(int id)
        {
            var category = _dataManager.Category.GetCategoryById(id);
            var mappedCategory = CategorieMapper.MapCategorieDTOtoViewModelSingle(category);
            foreach (var productDto in category.ProductsDTO)
            {
                var productView = ProductMapper.MapFromProductDTOToProductViewModel(productDto);
                mappedCategory.Products.Add(productView);
            }
            return View(mappedCategory);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryCreateViewModel category)
        {
            var categoryDTO = CategorieMapper.MapCategoryViewModelToDTO(category);
            _dataManager.Category.SaveCategory(categoryDTO);
            return Redirect("~/Category/Index");
        }
        public ActionResult Delete(int id)
        {
            _dataManager.Category.DeleteCategory(id);
            return Redirect("~/Category/Index");
        }

        public ActionResult Edit(int id)
        {
            var category = _dataManager.Category.GetCategoryById(id);
            var mappedCategory = CategorieMapper.MapCategorieDTOtoEditModelCategorie(category);
            return View(mappedCategory);
        }
        [HttpPost]
        public ActionResult Edit(CategoryEditModel categoryModel)
        {
            var categoryDTO = CategorieMapper.MapEditModelCategoryToDTO(categoryModel);
            _dataManager.Category.SaveCategory(categoryDTO);
            return Redirect("~/Category/Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            _dataManager.Product.DeleteProduct(id);
            return Redirect("~/Product/Index");
        }

    }
}