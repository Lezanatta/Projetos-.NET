using AlunosApi.Context;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Services;

public class AlunosService : IAlunoService
{
    private readonly AppDbContext _context;
    public AlunosService(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Aluno>> Getalunos()
    {
        try
        {
            return await _context.Alunos.ToListAsync();
        }
        catch
        {

            throw;
        }
        
    }
    public async Task<Aluno> GetAluno(int id) 
        => await _context.Alunos.FindAsync(id);

    public async Task<IEnumerable<Aluno>> GetAlunosByNome(string nome)
    {
        IEnumerable<Aluno> Alunos;
        if(!string.IsNullOrWhiteSpace(nome))
        {
            Alunos =  await _context.Alunos.Where(alu => alu.Nome.Contains(nome)).ToListAsync();
        }
        else
        {
            Alunos = await Getalunos();
        }
        return Alunos;
    }
    public async Task CreateAluno(Aluno aluno)
    {
        _context.Add(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAluno(Aluno aluno)
    {
        _context.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAluno(Aluno aluno)
    {
        _context.Remove(aluno);
        await _context.SaveChangesAsync();
    }
}

