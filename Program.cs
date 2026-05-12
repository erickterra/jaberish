using Jaberish.Middlewares;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    builder.WebHost.UseUrls($"http://*:{port}");
}

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Services
//builder.Services.AddScoped<IProdutoService, ProdutoService>();

// Repositories
// builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("default");

app.MapControllers();

app.Run();
