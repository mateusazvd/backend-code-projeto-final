using Backend_UniFinal.Contextos;
using Backend_UniFinal.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Configurações do serviço e do aplicativo
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Contexto do Mongodb
//builder.Services.AddSingleton<MongoDbContext>();

//Dependencias do repositorio
builder.Services.AddScoped<PesquisaRepositorio>();
builder.Services.AddScoped<RespostaRepositorio>();

//mikael
builder.Services.Configure<MongoDbContext>
    (builder.Configuration.GetSection("Database"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
