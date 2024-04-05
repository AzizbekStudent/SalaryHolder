using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;
using SalaryHolderDataBase.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
IConfiguration config = builder.Configuration;

string? _connStr = config.GetConnectionString("SalaryHolder_DB")
    .Replace("|DataDirectory|", builder.Environment.ContentRootPath); ;

// initializing repositories
builder.Services.AddScoped<IRepository<Bogcha>>(
   p =>
   {
       return new Bogcha_DapperRepository(_connStr);
   });

builder.Services.AddScoped<IRepository<SalTable>>(
   p =>
   {
       return new Sal_DapperRepository(_connStr);
   });

builder.Services.AddScoped<I_User_Repo>(provider =>
    new User_DapperRepository(_connStr));

//

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
    pattern: "{controller=Sal}/{action=Index}/{id?}");

app.Run();
