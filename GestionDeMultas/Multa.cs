using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMultas
{
    public enum EstadoMulta
    {
        pendiente,
        pagada,
        cancelada
    };
    public class Multa
    {
        public int NumMulta;
        public EstadoMulta Estado { get; private set; }
        public bool Asignada;

       

        public Multa(int numMulta, EstadoMulta estado, bool asiganda) 
        {
           NumMulta = numMulta;
           Estado = estado;
           Asignada = asiganda;
        }

       

        public void ActualizarNumeroMulta(string estado)
        {
           
        }
    }

}
