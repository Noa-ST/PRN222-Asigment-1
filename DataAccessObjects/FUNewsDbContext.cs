using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using BusinessObjects.Entities;

namespace DataAccessObjects
{
    public class FUNewsDbContext : DbContext
    {
        public FUNewsDbContext(DbContextOptions<FUNewsDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<SystemAccount> SystemAccounts { get; set; }
        public DbSet<Taq> Taqs { get; set; }
        public DbSet<NewsTaq> NewsTaqs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsTaq>()
                .HasKey(nt => new { nt.NewsArticleID, nt.TaqID });

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryID)
                .OnDelete(DeleteBehavior.Restrict); // Tránh xóa dây chuyền
                                                    // Quan hệ CreatedBy
            modelBuilder.Entity<NewsArticle>()
                .HasOne(n => n.CreatedBy)
                .WithMany(a => a.CreatedNewsArticles)
                .HasForeignKey(n => n.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict); // tránh xóa cascade nếu cần

            // Quan hệ UpdatedBy
            modelBuilder.Entity<NewsArticle>()
                .HasOne(n => n.UpdatedBy)
                .WithMany(a => a.UpdatedNewsArticles)
                .HasForeignKey(n => n.UpdatedByID)
                .OnDelete(DeleteBehavior.Restrict); // tránh lỗi xóa vòng lặp


            base.OnModelCreating(modelBuilder);
        }
    }
}
