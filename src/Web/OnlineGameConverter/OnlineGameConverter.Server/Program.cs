using OnlineGameConverter.Server;
using OnlineGameConverter.Server.Classes;
using OnlineGameConverter.Server.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///      ============ RAZOR ================

builder.Services.AddSingleton(typeof(IBytesSingleton), 
    typeof(BytesSingleton));

builder.Services.AddSingleton(typeof(IExceptionSingleton), typeof(ExceptionSingleton));

builder.Services.AddSingleton(typeof(IForecastConditionSingleton), 
    typeof(ForecastConditionSingleton));

builder.Services.AddSingleton(typeof(IOrbitalCalculationResultSingleton), 
    typeof(OrbitalCalculationResultSingleton));


builder.Services.AddSingleton(typeof(IHttpContextAccessor), 
    typeof(HttpContextAccessor));


builder.Services.AddRazorPages();


builder.Services.AddMvc(x => x.EnableEndpointRouting = false);



//==========================================


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapFallbackToFile("/index.html");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseMvcWithDefaultRoute();

//app.UseSession();


//app.UseMvc();


StaticExtension.Init();
app.Run();
