// Classe base
class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} esta fazendo um som!");
    }
}