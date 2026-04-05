var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register controllers so CryptoController is discovered.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map controller routes (enables attribute routed controllers such as CryptoController)
app.MapControllers();

app.Run();
