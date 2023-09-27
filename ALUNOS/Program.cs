using System.Data;
using System.Runtime.InteropServices;
//List<double> notas = new List<double>();

Dictionary<string, List<double>> ListaAlunos = new Dictionary<string, List<double>>();

ListaAlunos.Add("Carlos", new List<double>(){5, 6, 7, 8});


ExibirMenu();
void ExibirMenu()
{

Console.WriteLine("---------------------------");
Console.WriteLine("Escolha uma das opções!\n");
Console.WriteLine("[1] - Cadastrar Alunos");
Console.WriteLine("[0] - Para sair");
Console.WriteLine("\n Digite uma opção: ");

    string opcao = Console.ReadLine();
    int opcaoNumero = Convert.ToInt32(opcao);
    switch(opcaoNumero)
    {

        case 1:
            CadastrarMedia();
            break;
        case 0:
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("ERRO, opção incorreta, selecione novamente");
            ExibirMenu();
            break;
    
    }
}

void CadastrarMedia()
{

    Console.Clear();
Console.WriteLine("Informe o total de Alunos: ");
int totalAlunos = int.Parse(Console.ReadLine()); 

for(int i=0; i<totalAlunos; i++)
{
    Console.WriteLine("Indique o Aluno: ");
    string nome = Console.ReadLine();
    Console.Clear();

    ListaAlunos.Add(nome, new List<double>());

    for(int j=0; j<4; j++)
    {
        Console.WriteLine("Indique a nota: ");
        string nota = Console.ReadLine();
        ListaAlunos[nome].Add(double.Parse(nota));
      

    }
    
}

foreach(string  aluno in ListaAlunos.Keys)
{
    string situacao = "";

    if (ListaAlunos[aluno].Average() >= 5)
    {
        situacao = "APROVADO";
    }
    else
    {
        situacao = "REPROVADO";

    }
    Console.WriteLine($"Nome: {aluno} Média - {ListaAlunos[aluno].Average()} - {situacao}");

}
}