using Application.DTO;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task<int> GetIdAsync(int id);
        Task CreateAsync(PostProductDTO entity);
        Task UpdatePartialAsync(PutProductDTO entity, int id);
        Task DeleteAsync(int id);
    }
}
