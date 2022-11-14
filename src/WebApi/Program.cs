using DocConverter.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
AppSettings.WorkingDirectory = Path.Combine(app.Environment.ContentRootPath, app.Configuration["TemporaryFolder"] ?? string.Empty);
AppSettings.AppConverter = app.Configuration["AppConverter"] ?? "libreoffice";
Directory.CreateDirectory(AppSettings.WorkingDirectory);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
