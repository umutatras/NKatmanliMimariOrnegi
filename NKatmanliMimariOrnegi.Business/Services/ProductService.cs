using NKatmanliMimariOrnegi.Business.Interfaces;
using NKatmanliMimariOrnegi.Business.Mappings;
using NKatmanliMimariOrnegi.DataAccess.Interfaces;
using NKatmanliMimariOrnegi.DTOs.Product;
using NKatmanliMimariOrnegi.Entities;

namespace NKatmanliMimariOrnegi.Business.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
  

    public async Task AddProductAsync(ProductAddDto dto)
    {
        var product = dto.ToEntity();
        await _productRepository.AddAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with Id {id} not found.");

        _productRepository.Remove(product);
    }

    public async Task<List<ProductListDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => p.ToListDto()).ToList();
    }

    public async Task<ProductGetByIdDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with Id {id} not found.");

        return product.ToGetByIdDto();
    }

    public async Task UpdateProduct(ProductUpdateDto dto)
    {
        var product = await _productRepository.GetById(dto.Id);
        if (product == null)
            throw new KeyNotFoundException($"Product with Id {dto.Id} not found.");

        product = dto.ToEntity(product);

        await _productRepository.UpdateAsync(product);
    }
}
