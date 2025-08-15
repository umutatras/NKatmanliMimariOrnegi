using NKatmanliMimariOrnegi.DTOs.Product;

namespace NKatmanliMimariOrnegi.Business.Interfaces;

public interface IProductService
{
    Task<List<ProductListDto>> GetAllProductsAsync();
    Task<ProductGetByIdDto> GetProductByIdAsync(int id);
    Task AddProductAsync(ProductAddDto product);
    Task UpdateProduct(ProductUpdateDto product);
    Task DeleteProductAsync(int id);

}
