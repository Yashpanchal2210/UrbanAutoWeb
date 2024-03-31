using Microsoft.EntityFrameworkCore;
using UrbanAutoWeb;
using UrbanAutoWeb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connetionString = builder.Configuration.GetConnectionString("dbConn");
builder.Services.AddDbContext<UrbanAutoMasterContext>(options => options.UseSqlServer(connetionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//For session factory start
builder.Services.AddHttpContextAccessor();
SessionFactory.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
//For session factory end

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "adminlogin",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
