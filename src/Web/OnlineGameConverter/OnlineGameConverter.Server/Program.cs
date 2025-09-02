using OnlineGameConverter.Server;
using OnlineGameConverter.Server.Classes;
using OnlineGameConverter.Server.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var cf = configuration.GetChildren();
var ff = (from c in cf where c.Path == "Frontend" select c).ToArray();
var fc = ff[0].GetChildren();
var fe = (from cc in  fc select cc.Value).ToArray();


var services = builder.Services;

// Add services to the container.

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
// In your ASP.NET Core Program.cs


// Add services to the container.
builder.Services.AddControllers();
// ... other services

// Configure CORS
/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "http://localhost:57169") // Replace with your React app's origin
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
*/
services.AddHttpClient();



services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
          builder
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithOrigins(fe)));

services.AddControllers();

services.AddRazorPages();


services.AddMvc(x => x.EnableEndpointRouting = false);


var app = builder.Build();

// Configure the HTTP request pipeline.
// ... other middleware
app.UseRouting();

app.UseCors("CorsPolicy"); // Enable CORS for your app


app.UseAuthorization();

app.UseEndpoints(static endpoints =>
{
    endpoints.MapControllers();
});



//==========================================



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


app.MapRazorPages();

app.UseMvcWithDefaultRoute();

//app.UseSession();


//app.UseMvc();


StaticExtension.Init();
app.Run();
