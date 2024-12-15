using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace DefaultNamespace;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class TarefaRepository
{
    private readonly OrganizadorContext _context;

    public TarefaRepository(OrganizadorContext context)
    {
        _context = context;
    }

    public async Task<List<Tarefa>> GetAllAsync() => await _context.Tarefas.ToListAsync();

    public async Task<Tarefa> GetByIdAsync(long id) => await _context.Tarefas.FindAsync(id);

    public async Task<Tarefa> GetByTituloAsync(string titulo) => await _context.Tarefas.FirstOrDefaultAsync(t => t.Titulo == titulo);

    public async Task<bool> ExistsByTituloAsync(string titulo) => await _context.Tarefas.AnyAsync(t => t.Titulo == titulo);

    public async Task<List<Tarefa>> GetAllByDataAsync(DateTime data) => await _context.Tarefas.Where(t => t.Data.Date == data.Date).ToListAsync();

    public async Task<List<Tarefa>> GetAllByStatusAsync(EnumStatusTarefa status) => await _context.Tarefas.Where(t => t.Status == status).ToListAsync();

    public async Task CreateAsync(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tarefa tarefa)
    {
        _context.Entry(tarefa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var tarefa = await GetByIdAsync(id);
        if (tarefa != null)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
