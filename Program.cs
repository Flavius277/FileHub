using FileHub.Controllers;
using FileHub.Controllers.DocumentsController;
using FileHub.Controllers.UsersController;
using FileHub.Database.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FileHubDb>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<FoldersService>();
builder.Services.AddScoped<DocumentsService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FileHubDb>();

    //dbContextFolders.Folders.AddRange(new Folders { Name = "test1" }, new Folders { Name = "test2" }, new Folders { Name = "test3" });
    //dbContext.Documents.AddRange(new Documents { Name = "doc1" }, new Documents { Name = "doc2" });
    //await dbContext.SaveChangesAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
