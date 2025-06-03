namespace BusinessObjects.DTOs
{
    public class AdminReportDto
    {
        public int TotalArticles { get; set; }
        public int TotalUsers { get; set; }
        public List<CategoryReportDto> ArticlesByCategory { get; set; } = new();
    }

    public class CategoryReportDto
    {
        public string CategoryName { get; set; } = "";
        public int ArticleCount { get; set; }
    }
}
