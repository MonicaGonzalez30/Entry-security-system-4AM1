using ProyectoBack.Context;
using QRCoder;

var builder = WebApplication.CreateBuilder(args);

ContextoAPP Contexto_app = new ContextoAPP();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add QRCoder library
builder.Services.AddTransient<QRCodeGenerator>(); // Register QRCodeGenerator as a transient service

// Configuración para que no salga el error de seguridad de CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("MiPolitica", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Contexto_app.Database.EnsureCreated();

app.UseHttpsRedirection();

// Configuración para que no salga el error de seguridad de CORS
app.UseCors("MiPolitica");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
