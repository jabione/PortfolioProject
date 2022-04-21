using Azure.Storage.Blobs;
using PortfolioProject.IServices;
using PortfolioProject.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services.
builder.Services.AddControllersWithViews();

// Add Singletons ( Blob Service Client )
builder.Services.AddSingleton(s => new BlobServiceClient(builder.Configuration.GetValue<string>("BlobStorage:BlobConnectionString")));

// Add Scoped Interface Services
builder.Services.AddScoped<ILinkedinService<LinkedinService>, LinkedinService>();
builder.Services.AddScoped<IBlobService<BlobService>, BlobService>();

// Add Transient ( Cosmos Service)
builder.Services.AddTransient<ICosmosService<CosmosService>, CosmosService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
