using Abstract3DConverters;
using Conversion3D.WebApplication.Classes;
using Conversion3D.WebApplication.Interfacers;
using Conversion3D.WebApplication.Pages;
using Conversion3D.WebApplication.Pages.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton(typeof(IHyperLinkTransient), typeof(Data));

builder.Services.AddSingleton(typeof(IBytesSingleton), typeof(BytesSingleton));

builder.Services.AddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));


//builder.Services.AddMvc();
builder.Services.AddMvc(x => x.EnableEndpointRouting = false);
//builder.Services.AddScoped(typeof(IHyperLink), typeof(HyperLinkModel));

//builder.Services.AddScoped<IHyperLink>(_ => new HyperLinkModel());

var app = builder.Build();

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

StaticExtensionAbstract3DConverters.CheckFile = CheckFile.None;

app.Run();
