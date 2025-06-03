using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Implement;
using Repositories.Interface;
using Services.Implement;
using Services.Interface;
using Services.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FUNewsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FUNewsDb")));
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<INewsArticleRepository, NewsArticleRepository>(); 
builder.Services.AddScoped<INewsArticleService, NewsArticleService>();

builder.Services.AddScoped<ITaqRepository, TaqRepository>();
builder.Services.AddScoped<ITaqService, TaqService>();

builder.Services.AddScoped<IAdminReportRepository, AdminReportRepository>();
builder.Services.AddScoped<IAdminReportService, AdminReportService>();

builder.Services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
   pattern: "{controller=Login}/{action=Login}/{id?}");
app.Run();
