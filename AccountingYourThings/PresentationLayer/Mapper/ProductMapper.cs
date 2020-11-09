using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.DTO;
using PresentationLayer.Models.Product;

namespace PresentationLayer.Mapper
{
    public static class ProductMapper
    {
        public static ProductViewModel MapFromProductDTOToProductViewModel(ProductDTO product)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var mappedData = mapper.Map<ProductDTO, ProductViewModel>(product);
            return mappedData;
        }
        public static ProductEditViewModel MapFromProductDTOToProductEditViewModel(ProductDTO product)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductEditViewModel>()).CreateMapper();
            var mappedData = mapper.Map<ProductDTO, ProductEditViewModel>(product);
            return mappedData;
        }
        public static List<ProductViewModel> MapFromProductDTOToProductViewModelList(List<ProductDTO> products)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>())
                .CreateMapper();
            var mappedData = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(products);
            return mappedData;
        }
        public static ProductDTO MapFromProductViewModelToProductDTO(ProductViewModel product)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, ProductDTO>()).CreateMapper();
            var mappedData = mapper.Map<ProductViewModel, ProductDTO>(product);
            return mappedData;
        }
        public static ProductDTO MapFromProductEditViewModelToProductDTO(ProductEditViewModel product)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductEditViewModel, ProductDTO>()).CreateMapper();
            var mappedData = mapper.Map<ProductEditViewModel, ProductDTO>(product);
            return mappedData;
        }
    }
}
