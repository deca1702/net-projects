namespace GestionLibros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Libro l1 = new Libro("Editorial", "Titulo", 100, "1234567890", "Autor");
            Console.WriteLine(l1);
        }
    }
}
