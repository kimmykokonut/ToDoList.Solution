using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ToDoList
{
  class Program
  {
    static void Main(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //appsettings implicitly loaded

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<ToDoListContext>(
        dbContextOptions => dbContextOptions
          .UseMySql(
            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
          )
        )
      );
      //new for Identity
      builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
      //this saves via efc user data to db
        .AddEntityFrameworkStores<ToDoListContext>()
        //this sets up Identity's providers for tokens
        .AddDefaultTokenProviders();

      builder.Services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 0;
        options.Password.RequiredUniqueChars = 0;
      });

      WebApplication app = builder.Build();

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();

      //new for identity
      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      app.Run();
    }
  }
}