using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLayer.DTO;

namespace BusinessLayer.Mapper.Product
{
    public static class ProductsMapper
    {
        public static ProductDTO MapFromProductToProductDTOSingle(DataLayer.Entities.Product product)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DataLayer.Entities.Product, ProductDTO>()).CreateMapper();
            var mappedData = mapper.Map<DataLayer.Entities.Product, ProductDTO>(product);
            return mappedData;
        }
        public static List<ProductDTO> MapFromProductToProductDTOList(List<DataLayer.Entities.Product> products)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DataLayer.Entities.Product, ProductDTO>())
                .CreateMapper();
            var mappedData = mapper.Map<IEnumerable<DataLayer.Entities.Product>, List<ProductDTO>>(products);
            return mappedData;
        }
        public static DataLayer.Entities.Product MapFromProductDTOToProductSingle(ProductDTO product)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, DataLayer.Entities.Product>())
                .CreateMapper();
            var mappedData = mapper.Map<ProductDTO, DataLayer.Entities.Product>(product);
            return mappedData;
        }
    }
}
