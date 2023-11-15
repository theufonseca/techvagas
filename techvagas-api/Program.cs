using Application.Interfaces;
using Infra.Data;
using Infra.Data.Repositories;
using Infra.Elasticsearch;
using Infra.Elasticsearch.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Mediatr
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddTransient<DataContext>();
builder.Services.AddTransient<IJobRepository, JobRepository>();

//elasticsearch config
builder.Services.AddElasticSearch(builder.Configuration);
builder.Services.AddTransient<IJobIndexService, JobIndexService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
