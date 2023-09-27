internal class Program
{
    private static void Main(string[] args)
    {
        AcoesLista acoesLista = new AcoesLista();
        acoesLista.CarregarLista();


        Console.WriteLine("Hello, World!");
        acoesLista.MostrarTarefas();

        Console.WriteLine("\nOpções");
        Console.WriteLine("1 - Adicionar uma tarefa!!");
        Console.WriteLine("2 - Alterar uma tarfea!!");
        Console.WriteLine("3 - Excluir tarefa!!");
        Console.WriteLine("4 - Sair");

        Console.Write("Informe a opção: ");
        string opção = Console.ReadLine();

        while(true){
        switch (opção){

            case "1":
                Console.WriteLine("Nova tarfa ");
                Console.Write("Descreva a tarefa: ");
                string descricao = Console.ReadLine();
                acoesLista.AdicionarTarefa(descricao);
            break;
            
            case "2":
                Console.WriteLine("Alterar tarefa ");
            break;
            
            case "3":
                Console.WriteLine("Excluir tarefa ");
            break;
            
            case "4":
                Console.WriteLine("Finalizar programa ");
                Thread.Sleep(2000);
                Environment.Exit(0);
            break;

        }

        }
       
    }
}