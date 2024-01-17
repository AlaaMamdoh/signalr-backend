using WebApplication2.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddSignalR();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();



app.UseDefaultFiles();
app.UseStaticFiles();
app.MapHub<ChatHub>("/hub");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
  options => options.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("http://localhost:4200")//.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
      );

app.UseAuthorization();


app.MapControllers();

app.Run();
