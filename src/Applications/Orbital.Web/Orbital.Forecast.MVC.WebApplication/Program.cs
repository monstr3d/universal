using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable;

var builder = WebApplication.CreateBuilder(args);
Init();
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void Init()
{
    AssemblyService.StaticExtensionAssemblyService.Init();
    DifferentialEquationProcessor.Processor = RungeProcessor.Processor;

 
    /*var orbital = new Orbital.Forecast.MVC.WebApplication.Models.ForecastWeb();

    var x = orbital.X;
    x = orbital.Y;
    x = orbital.Z;
    x = orbital.Vx;
    x = orbital.Vy;
    x = orbital.Vz;
    x = orbital.S;
    x = orbital.F107;
    x = orbital.F107A;
    x = orbital.Ap;*/


}
