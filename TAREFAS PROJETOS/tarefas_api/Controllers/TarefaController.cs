using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tarefas_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace tarefas_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        
        private string BancoDados = "DadosTarefas.txt";

        private readonly ILogger<TarefaController> _logger;

        public TarefaController(ILogger<TarefaController> logger)
        {
            _logger = logger;
        }

        private List<Tarefa> CarregarTarefa()
        {
            if (!System.IO.File.Exists(BancoDados))
            {
                return new List<Tarefa>();
            }

            string[] conteudo = System.IO.File.ReadAllLines(BancoDados);

            List<Tarefa> listaTarefas = new List<Tarefa>();
            
            foreach(string linha in conteudo)
            {
                string[] campo = linha.Split('|');
                Tarefa tarefa = new Tarefa();
                tarefa.Id = Convert.ToInt32(campo[0]);
                tarefa.Descricao = campo[1];
                tarefa.IsConcluido = Convert.ToBoolean(campo[2]);

                listaTarefas.Add(tarefa);
            }

            return listaTarefas.ToList();
        }

        private void SalvarTarefa(List<Tarefa> listaTarefa)
        {
            var linhas = listaTarefa.Select(t => $"{t.Id}|{t.Descricao}|{t.IsConcluido}");
            System.IO.File.WriteAllLines(BancoDados, linhas);
        }

        [HttpGet]
        public IActionResult GetTarefas()
        {
            var tarefas = CarregarTarefa();
            return Ok (tarefas);
        }

        [HttpPost]
        public IActionResult InlcuirTarefa(Tarefa tarefa)
        {
            var tarefas = CarregarTarefa();
            tarefa.Id = tarefas.Last().Id + 1;
            tarefa.IsConcluido = false;
            tarefas.Add(tarefa);
            SalvarTarefa(tarefas);

            return Ok (tarefa);
        }

        [HttpGet("{id}")]

        public IActionResult GetTarefa(int id)
        {
            Tarefa? tarefa = new Tarefa();

            var listaTarefa = CarregarTarefa();
            tarefa = listaTarefa.FirstOrDefault(x => x.Id == id);
         
            if(tarefa == null)
            {
                return NotFound();
            }
            
            return Ok (tarefa);
        }

        [HttpPut("{id}")]

        public IActionResult AtualizarTarefa(int id)
        {
            Tarefa? tarefa = new Tarefa();
            var listaTarefa = CarregarTarefa();

            tarefa = listaTarefa.FirstOrDefault(x => x.Id == id);

            if(tarefa == null)
            {
                return NotFound();
            }
            tarefa.IsConcluido = true;
            SalvarTarefa(listaTarefa);

            return Ok (tarefa);
        }

        [HttpDelete("{id}")]

        public IActionResult DeletarTarefa(int id)
        {
            Tarefa? tarefa = new Tarefa();
            var listaTarefa = CarregarTarefa();

            tarefa = listaTarefa.FirstOrDefault(x => x.Id == id);

            if(tarefa == null)
            {
                return NotFound();
            }
            listaTarefa.Remove(tarefa);
            SalvarTarefa(listaTarefa);

            return NoContent();
        }
    }
}