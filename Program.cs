using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Portfolio.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Portfolio API", Version = "v1" });
    c.MapType<Projects>(() => new OpenApiSchema
    {
        Type = "object",
        Properties = new Dictionary<string, OpenApiSchema>
        {
            { "projectId", new OpenApiSchema { Type = "integer" } },
            { "projectName", new OpenApiSchema { Type = "string" } },
            { "projectDescription", new OpenApiSchema { Type = "string" } },
            { "userId", new OpenApiSchema { Type = "integer" } }
        },
        Required = new HashSet<string> { "projectName", "projectDescription", "userId" }
    });
});

builder.Services.AddDbContext<UserProjectContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
