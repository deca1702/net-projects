using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    
    public class Tarea
    {
        private string ID { get; set; }
        public string nombre{ get; set; }
        public string descripcion { get; set; }

        public DateTime _fechaEntrega;
        public DateTime FechaEntrega { get; set; }
        public bool Asignada { get; set; }

        // Constructor
        public Tarea(string nombre, string descripcion, DateTime fechaEntrega)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            FechaEntrega = fechaEntrega;
            Asignada = false;
        }


    }
}
