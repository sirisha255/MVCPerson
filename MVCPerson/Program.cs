using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using MVCPerson.Data;
using MVCPerson.Models.Repos;
using MVCPerson.Models.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<PeopleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
        builder.Services.AddScoped<IPeopleRepo, DataBasePeopleRepo>();
        builder.Services.AddScoped<IPeopleService, PeopleService>();

        builder.Services.AddControllersWithViews();
        builder.Services.AddMvc();

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

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}