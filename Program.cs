using TranslatorApp.DataAccessLayer.TranslatorDbContext;
using Microsoft.EntityFrameworkCore;
using TranslatorApp.DataAccessLayer.Abstract;
using TranslatorApp.BusinessLogicLayer.Concrete;
using TranslatorApp.BusinessLogicLayer.Abstract;
using TranslatorApp.DataAccessLayer.Concrete;
using TranslatorApp.BusinessLogicLayer.Mappers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TranslateDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TranslatorDB"));
});

builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddScoped<IWordService, WordManager>();

builder.Services.AddAutoMapper(typeof(AutoMapperWord));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
