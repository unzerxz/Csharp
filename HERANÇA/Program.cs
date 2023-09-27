class Program
{
    static void Main(string[] args)
    {
        Cao cao = new Cao("Leona");
        Gato gato = new Gato("Miu");

        cao.Speak();
        cao.Bark();

        gato.Speak();
        gato.Meow();
    }
}
