
using Microsoft.EntityFrameworkCore.Design;

Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal.MySqlCodeGenerator.ReferenceEquals(null, null);
PropertyAccessorCodeFragment.ReferenceEquals(null, null);

var builder = WebApplication.CreateBuilder(args);

/*
 dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold "Server=localhost;Port=3306;Database=your_database_name;Uid=your_user_id;Pwd=your_password;" Pomelo.EntityFrameworkCore.MySql -o Models -n MyWebApp.Models --force
Server=localhost;User ID=root;Password=SQj0Myhnks!12;Database=mysqlwarehouse"
dotnet ef dbcontext scaffold "Server=localhost;Port=3306;Database=mysqlwarehouse;Uid=root;Pwd=SQj0Myhnks!12;" Pomelo.EntityFrameworkCore.MySql -o Models -n MyWebApp.Models --force

 */

// Add services to the container.
builder.Services.AddControllersWithViews();

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
/*
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
*/

app.Run();
