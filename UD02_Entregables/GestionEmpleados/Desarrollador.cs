using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    public enum NivelDesrrollador
    {
        Junior,
        Senior
    }
    public class Desarrollador : Empleado
    {
        public Dictionary<int,string> TareasDesarrollador { get; private set; }
        public NivelDesrrollador Nivel { get; set; }

        // Constructor
        public Desarrollador(string nombre, string apellidos, string dni, decimal salario, TipoPuesto puesto, NivelDesrrollador nivel)
            : base(nombre, apellidos, dni, salario, puesto)
        {
            Nivel = nivel;
            TareasDesarrollador = new Dictionary<int, string>();

        }
        public static bool AsignarTarea(Tarea tarea)
        {
            return true;
        }
        public static bool EliminarTarea(Tarea tarea)
        {
            return true;
        }
    }
}
