using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> repo;
        private readonly IMapper mapper;
        private readonly ICategoryService catService;
        public ProductService(IMapper mapper, IGenericRepository<Product> repo, ICategoryService catService)
        { 
          this.mapper = mapper;
          this.repo = repo;
          this.catService = catService;
        }

        public async Task<IReadOnlyCollection<ProductDTO>> GetAllAsync()      
            => await mapper.ProjectTo<ProductDTO>(repo.GetAll()).AsNoTracking().ToListAsync();

        public async Task<int> GetIdAsync(int id)
             => await repo.GetAll().Where(p => p.Id == id).AsNoTracking().Select(p => p.Id).FirstOrDefaultAsync();

        public async Task<ProductDTO> GetByIdAsync(int id)
        => await mapper.ProjectTo<ProductDTO>(repo.GetAll())
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        public async Task CreateAsync(PostProductDTO entity)
        {
            var mappedEntity = mapper.Map<Product>(entity);

            bool existingProduct = await repo.GetAll()
                .Where(p => (p.Name == entity.Name) && (p.Brand == entity.Brand))
                .AsNoTracking().AnyAsync();

            if (existingProduct)
            {
                int entityId = await repo.GetAll()
                   .Where(p => (p.Name == entity.Name) && (p.Brand == entity.Brand))
                   .Select(p => p.Id).FirstAsync();

                var entityDto = mapper.Map<PutProductDTO>(entity); 

                await UpdatePartialAsync(entityDto, entityId);
            }
            else
            {
                mappedEntity.CreatedAt = DateTime.Now;
                mappedEntity.Stock = 1;
                repo.Create(mappedEntity);
                await repo.SaveChangesAsync();
            }
        }

        public async Task UpdatePartialAsync(PutProductDTO entity, int id)
        {
            var existingEntity = await repo.GetAll()
                .Where(p => p.Id == id).IgnoreAutoIncludes()
                .FirstAsync();

            bool existCategoryId;

            if(entity.Stock != null)
            {
                existingEntity.Stock += 1;
            }

            if (entity.Name != null)
            {
                existingEntity.Name = entity.Name;
            }

            if (entity.Brand != null)
            {
                existingEntity.Brand = entity.Brand;
            }
            if (entity.Description != null)
            {
                existingEntity.Description = entity.Description;
            }
            if (entity.Price != 0)
            {
                existingEntity.Price = entity.Price;
            }
            
            if (entity.CategoryId != 0)
            {
                existCategoryId = await catService.ExistCategory(entity.CategoryId);

                if (existCategoryId)
                {
                    existingEntity.CategoryId = entity.CategoryId;
                }
                else
                    throw new ArgumentException($"Category Id: {entity.CategoryId} was not found");
            } 
             
            existingEntity.UpdatedAt = DateTime.UtcNow;
            existingEntity.Stock += 1;

            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await repo.Delete(id);
        }
    }
}
