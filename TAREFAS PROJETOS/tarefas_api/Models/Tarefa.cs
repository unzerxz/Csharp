namespace tarefas_api.Models
{
    public class Tarefa
    {

       public int Id { get; set; }

       public string? Descricao { get; set; }

       public bool IsConcluido { get; set; }       

    }
}