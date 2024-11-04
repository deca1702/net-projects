using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace GestionEmpleados
{
    
    public class Tarea
    {
        public string ID { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Asignada { get; set; } = false;

        public Tarea(string id, string nombre, string descripcion, DateTime fechaEntrega)
        {
            ID = !string.IsNullOrEmpty(id) ? id : throw new ArgumentException("El ID no puede ser nulo.");
            Nombre = nombre ?? throw new ArgumentException("El nombre de la tarea no puede ser nulo.");
            Descripcion = descripcion;
            FechaEntrega = fechaEntrega;
        }
    }
}