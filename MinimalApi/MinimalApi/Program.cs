using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TarefasDb"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/tarefa/{id:int}", async (int id, AppDbContext db) 
    => await db.Tarefas.FindAsync(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound());

app.MapGet("/tarefas/concluidas", async (AppDbContext db)
    => await db.Tarefas.Where(t => t.isConcluida == true).ToListAsync());

app.MapGet("/tarefas", async (AppDbContext db) => await db.Tarefas.ToListAsync());

app.MapPost("/tarefas", async (Tarefa tarefa, AppDbContext db) => {
    db.Tarefas.Add(tarefa);
    await db.SaveChangesAsync();
    return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
});

app.MapPut("/tarefas/{id:int}", async(int id, Tarefa tarefa, AppDbContext db) =>
{
    var tar = await db.Tarefas.FindAsync(id);
    if(tar is null) return Results.NotFound("Tarefa não encontrada...");
    
    tar.Nome = tarefa.Nome;
    tar.isConcluida = tarefa.isConcluida;

    db.Tarefas.Entry(tar).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.Ok(tar);
});

app.MapDelete("tarefas/{id:int}", async (int id, AppDbContext db) =>
{
    if(await db.Tarefas.FindAsync(id) is Tarefa tarefa)
    {
        db.Tarefas.Remove(tarefa);
        await db.SaveChangesAsync();
        return Results.Ok(tarefa);
    }
    return Results.NotFound("Tarefa não encontrada...");
    
});

app.Run();

class Tarefa{
    public int Id { get; set; }
    public string?  Nome{ get; set; }
    public bool isConcluida { get; set; }
}

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Tarefa> Tarefas => Set<Tarefa>();
}

