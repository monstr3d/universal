using Abstract3DConverters;
using Conversion3D.WebApplication.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddScoped(typeof(IHyperLink), typeof(HyperLinkModel));

builder.Services.AddScoped<IHyperLink>(_ => new HyperLinkModel());

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

StaticExtensionAbstract3DConverters.Init();

app.Run();
