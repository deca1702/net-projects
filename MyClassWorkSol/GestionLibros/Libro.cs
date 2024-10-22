using System;

namespace GestionLibros
{
    public sealed class Libro : Publicacion
    {
        public ulong ISBN { get; private set; }
        public string Autor { get; private set; }
        public float Precio { get; private set; }
        public string Moneda { get; private set; }

        public Libro(string editorial, string titulo,  int paginas, string isbn, string autor)
            : base(titulo, editorial, TipoPublicacion.Libro, paginas)
        {
            if (string.IsNullOrWhiteSpace(autor))
            {
                throw new ArgumentException("El autor no puede ser nulo o vacío.");
            }

            if (!(isbn.Length >= 10 || isbn.Length <= 13))
            {
                throw new ArgumentException("El ISBN debe tener 10 o 13 dígitos");
            }

            if (!ulong.TryParse(isbn, out ulong nISBN))
            {
                throw new ArgumentException("El ISBN debe ser un número válido.");
            }
            ISBN = nISBN;
            Autor = autor;
           
        }

        public void SetPrecio(float precio, string moneda)
        {
            if (precio <= 0)
            {
                throw new ArgumentException("El precio debe ser mayor a 0");
            }
           
            Precio = precio;
            Moneda = moneda;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Autor: {Autor}, Precio: {Precio} {Moneda}";
        }

        public override bool Equals(object obj)
        {
            return obj is Libro libro && libro.ISBN == ISBN;
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }
    }
}
