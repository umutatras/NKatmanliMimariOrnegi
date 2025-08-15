using NKatmanliMimariOrnegi.DTOs.Product;
using NKatmanliMimariOrnegi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKatmanliMimariOrnegi.Business.Mappings;

public static class ProductMapping
{
    public static Product ToEntity(this ProductAddDto dto) =>
        new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

    public static Product ToEntity(this ProductUpdateDto dto, Product existing)
    {
        existing.Name = dto.Name;
        existing.Price = dto.Price;
        return existing;
    }

    public static ProductListDto ToListDto(this Product entity) =>
        new ProductListDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price
        };

    public static ProductGetByIdDto ToGetByIdDto(this Product entity) =>
        new ProductGetByIdDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price
        };
}
