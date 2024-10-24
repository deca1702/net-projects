using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros
{
    public enum TipoPublicacion
    {
        Libro,
        Revista,
        Articulo
    }
    public abstract class Publicacion
    {

        private int _totalPaginas;
        private bool _publicado;
        private DateTime _fechaPublicacion;
        public String Editorial { get; set; }
        public String Titulo { get; set; }
        public TipoPublicacion Tipo { get; set; }
        public int Paginas
        {

            get { return _totalPaginas; }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("El número de páginas debe ser mayor a 0");
                }
                else
                {
                    _totalPaginas = value;
                }
            }


        }
        public Publicacion(string editorial, string titulo, TipoPublicacion tipo, int paginas)
        {
            if (String.IsNullOrWhiteSpace(editorial))
            {
                throw new Exception("La editorial no puede estar vacía");
            }

            Editorial = editorial;
            if (String.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("El título no puede estar vacío");
            }
            Titulo = titulo;
            Tipo = tipo;
            Paginas = paginas;
        }
        public void Publicar(DateTime fechaPublicacion)
        {
            if (!_publicado)
            {

                _publicado = true;
                _fechaPublicacion = fechaPublicacion;


                Console.Write("Añade un fecha de publicacion ");
                _fechaPublicacion = Convert.ToDateTime(Console.ReadLine());








            }
            else
            {
                Console.WriteLine("La publicación ya ha sido publicada");
            }
        }
        public void GetFechaPublicacion()
        {
            if (_publicado)
            {

                Console.Write(_fechaPublicacion.ToString());
            }
        }




        public override string ToString()
        {
            return $"Editorial: {Editorial}\nTitulo: {Titulo}\nTipo: {Tipo}\nPaginas: {Paginas}\nFecha de publicación: {_fechaPublicacion}";
        }
    }
}
