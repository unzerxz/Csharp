

// Classe derivada
class Cao : Animal
{
    public Cao(string name) : base(name)
    {
    }

    public void Bark()
    {
        Console.WriteLine($"{Name} esta latindo...");
    }
}