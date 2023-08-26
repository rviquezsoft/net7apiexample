using API.Context;
using API.Services;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;


builder.Services.AddDbContextFactory<APIContext>(opt =>
    opt.UseSqlServer(config.GetConnectionString(SharedLibrary.Constants.CONNECTIONSTRINGNAME)));

builder.Services.AddTransient(typeof(IDBService<>),typeof(DBService<>));

builder.Services.AddControllers().AddOData(op=>op.Count().Filter().OrderBy().Expand().SetMaxTop(SharedLibrary.Constants.MAXTOP));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

