
// Classe derivada
class Gato : Animal
{
    public Gato(string name) : base(name)
    {
    }

    public void Meow()
    {
        Console.WriteLine($"{Name} esta miando...");
    }
}
