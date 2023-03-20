using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> repo;
        private readonly IMapper mapper;

        public CategoryService(IMapper mapper, IGenericRepository<Category> repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<IReadOnlyCollection<CategoryDTO>> GetAllCategories()
         => await mapper.ProjectTo<CategoryDTO>(repo.GetAll()).AsNoTracking().ToListAsync();

        public Task<bool> ExistCategory(int id)
         => repo.GetAll().Where(c => c.Id == id).AnyAsync();



    }
}
