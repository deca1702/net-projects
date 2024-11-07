using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMultas
{
    public class Conductor
    {
        public string DNI;
        public string Nombre;
        public string Apellidos;
        public List<Multa> MultasConductores;

        public Conductor(string dNI, string nombre, string apellidos)
        {
            DNI = dNI;
            Nombre = nombre;
            Apellidos = apellidos;
           
        }
        public void AgregarMultaConductor(Multa multa)
        {
            List<Multa> conductores = new List<Multa>();

            if (multa == null)
            {
                conductores.Add(multa);
            }
            else
            {
                Console.WriteLine("No tienes multas que pagar");
            }
        }
        public void EliminarMulta(Multa multa)
        {
            List<Multa> conductores = new List<Multa>();

            if (multa != null)
            {
                conductores.Remove(multa);
            }
        }
    }
    

}
