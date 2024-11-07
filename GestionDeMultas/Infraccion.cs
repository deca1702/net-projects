using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMultas
{
    public class Infraccion
    {
        public int CodigoInfraccion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInfraccion { get; set; }
        public decimal Sancion { get; set; }

        public Infraccion(int codigoInfraccion, string descripcion, DateTime fechaInfraccion, decimal sancion)
        {

            if (codigoInfraccion >= 0)
            {

            }
            else
            {
                Console.WriteLine("El numero no puede estar vacio");
            }

            if (descripcion != null)
            {
                Console.WriteLine("La descripcion no puede estar vacio");
            }


            FechaInfraccion = fechaInfraccion;

            if(sancion < 0)
            {

            }else
            {
                Console.WriteLine("El numero no puede ser negativo");
            }

        }
    }
    
}
