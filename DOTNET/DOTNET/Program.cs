using DOTNET.BLL.Interfaces;
using DOTNET.BLL.Repositories;
using DOTNET.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DOTNET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MemoryDbContext>();
            //builder.Services.AddScoped<IStudentRepository, MockStudentRepository>();
            builder.Services.AddScoped<IStudentRepository, SQLStudentRepository>();
            builder.Services.AddScoped<IEnrollmentRespository, EnrollmentRespository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();

            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

