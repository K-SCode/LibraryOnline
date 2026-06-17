
using LibraryOnline.Core.DTOs.Categories;
using LibraryOnline.Core.DTOs.Common;

namespace LibraryOnline.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<PagedResultDto<CategoryResponseDto>?> GetAllCategoriesAsync(int pageNumber, int pageSize);
        Task DeleteCategoryByIdAsync(Guid id);
        Task UpdateCategoryAsync(Guid id, CategoryDto categoryUpdate);
        Task CreateCategoryAsync(CategoryDto category);
    }
}
