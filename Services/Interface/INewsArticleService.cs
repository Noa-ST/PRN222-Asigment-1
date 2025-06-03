using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface INewsArticleService
{
    Task<IEnumerable<GetNewsArticleDto>> GetAllAsync();
    Task<GetNewsArticleDto> GetByIdAsync(int id);
    Task CreateAsync(CreateNewsArticleDto dto);
    Task UpdateAsync(UpdateNewsArticleDto dto);
    Task DeleteAsync(int id);
}
