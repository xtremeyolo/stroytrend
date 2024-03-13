using StroyTrend.Repositories.Projects;
using StroyTrend.Repositories.Reports;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<IReportsRepository, JsonReportsRepository>();
builder.Services.AddSingleton<IProjectsRepository, InMemoryProjectsRepository>();
builder.Services.AddCors(x =>
{
    x.AddPolicy("frontend", p => p.WithOrigins("http://localhost:5173"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseCors("frontend");
}

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("{**slug}", "index.html");
app.Run();