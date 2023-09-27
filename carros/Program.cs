using System.Reflection.Metadata.Ecma335;

class veiculo
{
   private string _Marca;
 
   private string _Modelo;

   private int _Ano;
    private string _Cor;
   public string Marca{
                          get{return _Marca;}
                          set{_Marca = value;}
                             }
    public string Modelo{
                          get{return _Modelo; }
                          set{_Modelo = value; }
                             }

    public int Ano{
                          get{return _Ano; }
                          set{_Ano = value; }
                             }
    public string Cor{
                          get{return _Cor; }
                          set{_Cor = value; }
                             }
    private int Idade{
                          get{return DateTime.Now.Year - Ano;}
    }

    public void MostrarVeiculo()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Carro: {Modelo}");
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Ano: {Ano}");
        Console.WriteLine($"Idade: {Idade}");
        Console.WriteLine("-----------------------------");
    }
}

 
 class Program
 {
    static void Main(string[] args)
    {
        veiculo carro1 = new veiculo(); //instanciar uma classe
 
    carro1.Marca = "Volkswagem"; //Atribuir valores para classe
    carro1.Modelo = "Gol";
    carro1.Ano =2010;
    carro1.Cor = "Rosa";

        carro1.MostrarVeiculo();

        veiculo carro2 = new veiculo();

        carro2.Marca = "Skyline GT-R"; //Atribuir valores para classe
        carro2.Modelo = "R34";
        carro2.Ano = 1999;
        carro2.Cor = "Branco";

        carro2.MostrarVeiculo();

        veiculo carro3 = new veiculo();

        carro3.Marca = "Toyota"; //Atribuir valores para classe
        carro3.Modelo = "Supra";
        carro3.Ano = 1979;
        carro3.Cor = "Ouro";

        carro3.MostrarVeiculo();
    }
}