using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLayer.DTO;
using PresentationLayer.Models.Category;

namespace PresentationLayer.Mapper
{
    public static class CategorieMapper
    {
        public static DataLayer.Entities.Category MapCategoryDTOtoCategory(CategoryDTO category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, DataLayer.Entities.Category>())
                .CreateMapper();
            var mappedData = mapper.Map<CategoryDTO, DataLayer.Entities.Category>(category);
            return mappedData;
        }

        public static List<CategoryViewModel> MapCategoryDTOtoViewModelList(List<CategoryDTO> categories)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var categoiesViewModel = mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(categories);
            return categoiesViewModel;
        }

        public static CategoryViewModel MapCategorieDTOtoViewModelSingle(CategoryDTO category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var mappedData = mapper.Map<CategoryDTO, CategoryViewModel>(category);
            return mappedData;
        }

        public static CategoryEditModel MapCategorieDTOtoEditModelCategorie(CategoryDTO category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryEditModel>()).CreateMapper();
            var mappedData = mapper.Map<CategoryDTO, CategoryEditModel>(category);
            return mappedData;
        }

        public static List<CategoryDTO> MapCategoriesToDTOList(List<DataLayer.Entities.Category> categories)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DataLayer.Entities.Category, CategoryDTO>())
                .CreateMapper();
            var mappedData = mapper.Map<IEnumerable<DataLayer.Entities.Category>, List<CategoryDTO>>(categories);
            return mappedData;
        }

        public static CategoryDTO MapCategoryToDTOSingle(DataLayer.Entities.Category category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DataLayer.Entities.Category, CategoryDTO>())
                .CreateMapper();
            var mappedData = mapper.Map<DataLayer.Entities.Category, CategoryDTO>(category);
            return mappedData;
        }
        public static CategoryDTO MapCategoryViewModelToDTO(CategoryCreateViewModel category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryCreateViewModel, CategoryDTO>()).CreateMapper();
            var mappedData = mapper.Map<CategoryCreateViewModel, CategoryDTO>(category);
            return mappedData;
        }
        public static CategoryDTO MapEditModelCategoryToDTO(CategoryEditModel category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryEditModel, CategoryDTO>()).CreateMapper();
            var mappedData = mapper.Map<CategoryEditModel, CategoryDTO>(category);
            return mappedData;
        }
    }
}
