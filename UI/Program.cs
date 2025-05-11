using BLL.Interface;
using AutoMapper;
using BLL.Servies;
using DAL.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLL.Helper;
using DAL.ViewModel;
using BLL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Specify the assembly where your AutoMapper profiles are located
builder.Services.AddScoped<ApplicationDbContext>(); // Register the ApplicationDbContext as scoped

// Modify ImportRep to accept a service provider


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    
       options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("DAL"));

});


builder.Services.AddScoped<IHomepage, HomepageRepo>(); builder.Services.AddScoped<IRequest,RequestRepo>(); builder.Services.AddScoped<IRepliescostomercs, RepliescostomerRepo>();

builder.Services.AddScoped<IImportRep, ImportRep>();
builder.Services.AddScoped<Iusers, UserRep>();builder.Services.AddScoped<Icontect, ContactRepo>();
builder.Services.AddScoped<IServucesVM, sideRepo>();
builder.Services.AddScoped<IQuestions, CirclecsRepo>();builder.Services.AddScoped<IAbout, AboutRepo>();

builder.Services.AddScoped<IReadingRep, ReadingRep>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<DataSeeder>(); // Register DataSeeder// Required for session state
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Make the session cookie accessible only via HTTP
    options.Cookie.IsEssential = true; // Make the session cookie essential
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedDataAsync();
}
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
app.UseSession(); // Add session middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Viewcustomer}/{action=Index}/{id?}");

app.Run();
