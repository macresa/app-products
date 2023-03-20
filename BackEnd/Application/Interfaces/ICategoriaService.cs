using Application.DTO;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IReadOnlyCollection<CategoryDTO>> GetAllCategories();
        Task<bool> ExistCategory(int id);
    }
}
