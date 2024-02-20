using Shopping.API.Dto;

namespace Shopping.API.v1.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductById(Guid pid);
        Task<IEnumerable<ProductDTO>> GetProductList();
        Task<ProductDTO> AddProduct(ProductCreationDTO productDTO);
        Task DeleteProduct(Guid pid);
        Task UpdateProduct(ProductUpdateDTO productDTO);
    }
}
