using BusinessObjects.DTOs;

namespace Services.Interface
{
    public interface IAdminReportService
    {
        Task<AdminReportDto> GetAdminReportAsync();
    }
}
