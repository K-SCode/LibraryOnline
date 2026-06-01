using LibraryOnline.Core.DTOs.Author;
using LibraryOnline.Core.DTOs.Books;
using LibraryOnline.Core.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        public Task<AuthorResponseDto?> GetAuthorByIdAsync(Guid id);
        public Task<PagedResultDto<AuthorResponseDto>?> GetAllAuthorsAsync(int pageNumber, int pageSize);
        public Task DeleteAuthorAsync(Guid id);
        public Task CreateAuthorAsync(CreateAuthorDto createAuthor);
        public Task UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthor);
    }
}
