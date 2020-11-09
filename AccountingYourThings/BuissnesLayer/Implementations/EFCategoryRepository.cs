using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapper;
using BusinessLayer.Mapper.Category;
using BusinessLayer.Mapper.Product;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private EfDbContext context;

        public EFCategoryRepository(EfDbContext context)
        {
            this.context = context;
        }
        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var data = await context.Category.Include(x => x.Products).AsNoTracking().ToListAsync();
            var categoriesDTO = CategorieMapp.MapCategoriesToDTOList(data);
            SetProductDTOtoCategoryDTO(data, categoriesDTO);
            return categoriesDTO;
        }

        public CategoryDTO GetCategoryById(int categoryId)
        {
            var category = context.Category.Include(x => x.Products).FirstOrDefault(x => x.Id == categoryId);
            var categoryDTO = CategorieMapp.MapCategoryToDTOSingle(category);
            foreach (var product in category.Products)
            {
                var productDTO = ProductsMapper.MapFromProductToProductDTOSingle(product);
                categoryDTO.ProductsDTO.Add(productDTO);
            }
            return categoryDTO;
        }

        public void SaveCategory(CategoryDTO category)
        {
            var categoryForDb = CategorieMapp.MapCategoryDTOtoCategory(category);
            var categoryInDatabase = context.Category.FirstOrDefault(x => x.Id == category.Id);
            if(categoryInDatabase == null)
            {
                context.Category.Add(categoryForDb);
            }
            else
            {
                categoryInDatabase.Name = categoryForDb.Name;
                categoryInDatabase.Description = categoryForDb.Description;
            }
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            context.Category.Remove(context.Category.FirstOrDefault(x => x.Id == categoryId));
            context.SaveChanges();
        }

        public void SetProductDTOtoCategoryDTO(List<Category> data, List<CategoryDTO> categoryDTO)
        {
            foreach (var category in data)
            {
                foreach (var product in category.Products)
                {
                    var productDTO = ProductsMapper.MapFromProductToProductDTOSingle(product);
                    var categoryDto = categoryDTO.Find(dto => dto.Id == category.Id);
                    categoryDto.ProductsDTO.Add(productDTO);
                }
            }
        }
    }
}
