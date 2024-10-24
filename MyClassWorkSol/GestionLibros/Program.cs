namespace GestionLibros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Libro l1 = new Libro("Editorial", "El señor de los anillos", 100, "1234567890", "Desi");
            l1.SetPrecio(100.0f, "USD");
            Console.WriteLine(l1.ToString());
            l1.Publicar(DateTime.Now);
            Console.WriteLine("La fecha de publicacion es: " + l1.GetFechaPublicacion);
            Console.ReadLine();

            
        }
    }
}
