using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Controllers.exception;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaRepository _tarefaRepository;
        public TarefaController(TarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> ObterPorId(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            // caso contrário retornar OK com a tarefa encontrada
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null) throw new NaoEncontradoException();
            return tarefa;
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterTodos()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF
            return await _tarefaRepository.GetAllAsync();
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<ActionResult<Tarefa>> ObterPorTitulo([FromQuery] string titulo)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            var tarefa = await _tarefaRepository.GetByTituloAsync(titulo);
            if (tarefa == null) throw new NaoEncontradoException();
            return tarefa;
        }

        [HttpGet("ObterPorData")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterPorData([FromQuery] DateTime data)
        {
            return await _tarefaRepository.GetAllByDataAsync(data);
        }

        [HttpGet("ObterPorStatus")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterPorStatus([FromQuery] string status)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
            if (!Enum.TryParse<EnumStatusTarefa>(status, out var statusEnum))
            {
                return BadRequest("Status deve ser 'Pendente' ou 'Finalizado'.");
            }
            return await _tarefaRepository.GetAllByStatusAsync(statusEnum);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Criar([FromBody] TarefaRequest tarefaRequest)
        {
          
            if (await _tarefaRepository.ExistsByTituloAsync(tarefaRequest.Titulo))
            {
                throw new JaExisteException();
            }
        
            var tarefa = new Tarefa(tarefaRequest);
            await _tarefaRepository.CreateAsync(tarefa);
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tarefa>> Atualizar(long id, [FromBody] TarefaRequest tarefaRequest)
        {
            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null) throw new NaoEncontradoException();
        
            tarefa.Atualizar(tarefaRequest);
            await _tarefaRepository.UpdateAsync(tarefa);
            return tarefa;

        }

        [HttpDelete("{id}")]
        public  async Task<IActionResult> Deletar(int id)
        {
            // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null) throw new NaoEncontradoException();
            await _tarefaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
