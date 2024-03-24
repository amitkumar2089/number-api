using Microsoft.EntityFrameworkCore;
using NumberApi.Data;
using NumberApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("NumberDb"));

var app = builder.Build();


app.UseHttpsRedirection();

app.MapGet("api/numbers", async (AppDbContext dbContext) =>
{
    var items=await dbContext.Numbers.ToListAsync();

    return Results.Ok(items);
});

app.MapPost("api/numbers",async(AppDbContext dbContext,NumItem numItem)=>
{
    await dbContext.AddAsync(numItem);
    await dbContext.SaveChangesAsync();

    return Results.Created($"api/numbers/{numItem.Id}",numItem);
});


app.Run();

