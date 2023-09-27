
using System.Runtime.InteropServices;
//List<string> bandas = new List<string>();

//dicionarios!!
Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();
bandas.Add("Calypso", new List<int>(){5, 7, 8});
bandas.Add("Titans", new List<int>());
bandas.Add("Ac/Dc", new List<int>());


Console.WriteLine(@"Bem Vindo!!

██╗░░░██╗███╗░░██╗███████╗███████╗██████╗░███████╗██╗░░░██╗
██║░░░██║████╗░██║╚════██║██╔════╝██╔══██╗██╔════╝╚██╗░██╔╝
██║░░░██║██╔██╗██║░░███╔═╝█████╗░░██████╔╝█████╗░░░╚████╔╝░
██║░░░██║██║╚████║██╔══╝░░██╔══╝░░██╔══██╗██╔══╝░░░░╚██╔╝░░
╚██████╔╝██║░╚███║███████╗███████╗██║░░██║██║░░░░░░░░██║░░░
░╚═════╝░╚═╝░░╚══╝╚══════╝╚══════╝╚═╝░░╚═╝╚═╝░░░░░░░░╚═╝░░░
");

ExibirMenu();
//Inicio do Exibir Menu
void ExibirMenu()
{

Console.WriteLine("---------------------------");
Console.WriteLine("Escolha uma das opções!\n");
Console.WriteLine("[1] - Escolha uma banda");
Console.WriteLine("[2] - Mostrar bandas cadastradas");
Console.WriteLine("[3] - Para avaliar uma banda");
Console.WriteLine("[4] - Para exibir a media de uma das bandas");
Console.WriteLine("[0] - Para sair");
Console.WriteLine("\n Digite uma opção: ");

    string opcao = Console.ReadLine();
    int opcaoNumero = Convert.ToInt32(opcao);
    switch(opcaoNumero)
    {

        case 1:
            CadastroBanda();
            break;
        case 2:
            MostrarBanda();
            break;
        case 3:
            AvaliandoBanda();
            break;
        case 4:
            Console.WriteLine("Exibindo a media da banda...");
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
//Fim do Exibir Menu

//Inicio do primeiro caso
void CadastroBanda()
{
    Console.Clear();
    Console.WriteLine("Cadastrar uma nova banda...");
    Console.Write("\n Informe o nome da banda!! \n");

    string nomebanda = Console.ReadLine();
    bandas.Add(nomebanda, new List<int>());

    Console.Clear();
    Console.WriteLine($"A banda {nomebanda} foi adicionada com sucesso!!");

    Thread.Sleep(2000);
    ExibirMenu();
}
//Fim do primeiro caso

//Inicio do segundo caso
void MostrarBanda()
{
    Console.Clear();
    Console.WriteLine("Listar as bandas: ");
   
  //  for(int i=0; i < bandas.Count(); i++)
  //  {
  //       Console.WriteLine($"Bandas: {bandas[i]}");

    foreach(string item in bandas.Keys)
    {
        Console.WriteLine($"Bandas: {item}");
    }  

    Console.WriteLine("Pressione qualquer tecla para voltar...");
    Console.ReadKey();
    ExibirMenu();
}
//FIm do segundo caso

//Inicio do terceiro caso
void AvaliandoBanda()

{
    Console.Clear();
    Console.WriteLine("Avaliar uma Banda: \n");
    Console.WriteLine("Informe uma banda: ");
    string nomebanda = Console.ReadLine();
    bool resultado = bandas.ContainsKey(nomebanda);

    if(resultado)
    {
        Console.WriteLine($"Existe a banda {nomebanda} no cadastro!! ");
        Console.WriteLine($"Informe a nota da banda: ");
        int  notanumero = int.Parse(Console.ReadLine());
        bandas[nomebanda].Add(notanumero);
    }    
    else {
        Console.WriteLine($"Não tem a banda, {nomebanda}");
    }
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}
//Fim do terceiro caso 