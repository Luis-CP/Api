using proyectoef;
using proyectoef.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-H1PP7AG\\SQLEXPRESS;Trust Server Certificate = true;Initial Catalog=TareasDb;User id=sa;password=LolisNazis36;");
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareasService,TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddle();

app.MapControllers();

app.Run();
