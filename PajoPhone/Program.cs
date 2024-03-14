using Microsoft.EntityFrameworkCore;
using PajoPhone.DataLayer;
using PajoPhone.DataLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Context

builder.Services.AddDbContext<Context>(
    db=> db.UseSqlServer(
        builder.Configuration.GetConnectionString("Server")
        )
    
    );

#endregion

builder.Services.AddScoped<IProduct, Product>();

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
    pattern: "{controller=Store}/{action=Index}/{id?}");

app.Run();