using LibraryOnline.Core.DTOs.Author;
using LibraryOnline.Core.DTOs.Categories;
using LibraryOnline.Core.DTOs.Common;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Core.Interfaces.Services;
using Mapster;
using MapsterMapper;

namespace LibraryOnline.API.Services
{
    public class CategoryService(IUnitOfWorks unitOfWorks,
        IMapper mapper) : ICategoryService
    {
        public async Task CreateCategoryAsync(CategoryDto categoryDto)
        {
            Dictionary<string, string> propertiesToCheck = new()
            {
                {nameof(CategoryDto.Name), categoryDto.Name }
            };
            var isExists = await unitOfWorks.Categories.ExistsAsync(propertiesToCheck);
            if (isExists)
            {
                throw new ArgumentException($"{nameof(CategoryDto.Name)}: {categoryDto.Name} is already exists");
            }

            var category = mapper.Map<Category>(categoryDto);
            
            await unitOfWorks.Categories.AddAsync(category);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task DeleteCategoryByIdAsync(Guid id)
        {
            var category = await unitOfWorks.Categories.GetByIdAsync(id) ??
                throw new ArgumentException($"Category with ID: {id} not exists");
            unitOfWorks.Categories.Delete(category);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task<PagedResultDto<CategoryResponseDto>?> GetAllCategoriesAsync(int pageNumber, int pageSize)
        {
            (IEnumerable<Category> items, int totalCount) = await unitOfWorks.Categories.GetAllAsync(pageNumber, pageSize);

            return new PagedResultDto<CategoryResponseDto>
            {
                Items = items.Adapt<IEnumerable<CategoryResponseDto>>(),
                TotalCount = totalCount,
                Page = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task UpdateCategoryAsync(Guid id, CategoryDto categoryDto)
        {
            var category = await unitOfWorks.Categories.GetByIdAsync(id) ??
                throw new ArgumentException($"Category with ID: {id} not exists");
            mapper.Map(categoryDto, category);

            unitOfWorks.Categories.Update(category);

            await unitOfWorks.SaveChangesAsync();
        }
    }
}
