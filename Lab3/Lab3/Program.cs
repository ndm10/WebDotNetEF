using Lab3.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //builder.Services.AddDbContext<NorthwindContext>(opt => opt.UseSqlServer(
        //    builder.Configuration.GetConnectionString("NorthwindCS")));

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Orders}/{action=List}/{Id=0}"
            );

        app.Run();
    }
}