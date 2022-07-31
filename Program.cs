using Microsoft.EntityFrameworkCore;
using Shipments.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000/",
                                              "http://localhost:3000").AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                      });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<ShipmentsContext>(opt =>
    opt.UseInMemoryDatabase("Shipments"));

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();