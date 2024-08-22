using intelectah.Application;
using intelectah.Application.Commands.UsuarioCommands;
using intelectah.Infrastructure;
using intelectah.MVC;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddMVC();
builder.Services.AddApplication();
builder.Services.AddMediatR(typeof(CreateUsuarioCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseStatusCodePages(async context =>
{
    var statusCode = context.HttpContext.Response.StatusCode;
    if (statusCode == 404)
    {
        context.HttpContext.Response.Redirect("/Error404");
    }
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
