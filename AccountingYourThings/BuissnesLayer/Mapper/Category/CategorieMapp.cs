using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLayer.DTO;

namespace BusinessLayer.Mapper.Category
{
    public static class CategorieMapp
    {
        public static DataLayer.Entities.Category MapCategoryDTOtoCategory(CategoryDTO category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, DataLayer.Entities.Category>())
                .CreateMapper();
            var mappedData = mapper.Map<CategoryDTO, DataLayer.Entities.Category>(category);
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
        
    }
}
