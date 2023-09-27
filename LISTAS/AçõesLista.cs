class AcoesLista
{

    List<tarefa> ListaTarefas = new List<tarefa>();

    private string BancoDados = "DadosTarefas.txt";

    private int NovoRegistro()
    {
        
        return ListaTarefas.Count() + 1;
    }

    public void CarregarLista()
    {
       if(File.Exists(BancoDados)) //para descobir se o arquivo exite ou nao 
       {
            string[] linhas = File.ReadAllLines(BancoDados);

            foreach(string linha in linhas)
            {
                string[] itens = linha.Split('|');
                tarefa tarefa = new tarefa();
                tarefa.Id = Convert.ToInt32(itens[0]);
                tarefa.Descricao = itens[1];
                tarefa.IsConcluido = Convert.ToBoolean(itens[2]);

                ListaTarefas.Add(tarefa);
            }
       }
    }

    private void Salvar()
    {
        using (StreamWriter escreve = new StreamWriter(BancoDados))
        {
            foreach(tarefa tarefa in ListaTarefas)
            {
                escreve.WriteLine($"{tarefa.Id} | {tarefa.Descricao} | {tarefa.IsConcluido}");
            }
        }
    }

    public void AdicionarTarefa(string descricao)
    {
        tarefa tarefa = new tarefa();
        tarefa.Id = NovoRegistro();
        tarefa.Descricao = descricao;
        tarefa.IsConcluido = false;
    }

   public void MostrarTarefas()
    {
    Console.WriteLine("Lista de Tarefas");
    if(ListaTarefas.Count() > 0){

    foreach(tarefa item in ListaTarefas) {
    Console.WriteLine($"{item.Id} - {item.IsConcluido} - {item.Descricao}");
            
    }
        
    }
        
    else{
    Console.WriteLine("Nenhuma tarefa realizada");
    
    }

    }

   public  void AlterarTarefa()
    {
  

    }

    public void ExcluirTarefa()
    {
        //logica excluir
    }

    
}