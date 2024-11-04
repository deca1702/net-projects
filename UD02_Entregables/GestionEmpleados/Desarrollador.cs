using System;
using System.Collections.Generic;

namespace GestionEmpleados
{
    public enum NivelDesarrollador
    {
        Junior,
        Senior
    }

    public class Desarrollador : Empleado
    {
        public Dictionary<string, string> TareasDesarrollador { get; private set; }
        public NivelDesarrollador Nivel { get; set; }

        // Constructor
        public Desarrollador(string nombre, string apellidos, string dni, decimal salario, NivelDesarrollador nivel)
           : base(nombre, apellidos, dni, salario, TipoPuesto.Desarrollador)
        {
            Nivel = nivel;
            TareasDesarrollador = new Dictionary<string, string>();
        }

        public void AsignarTarea(Tarea tarea)
        {
            if (!tarea.Asignada)
            {
                TareasDesarrollador[tarea.ID] = tarea.Nombre;
                tarea.Asignada = true;
            }
            else
            {
                Console.WriteLine("La tarea ya está asignada a otro desarrollador.");
            }
        }

        public void DesAsignarTarea(Tarea tarea)
        {
            if (TareasDesarrollador.ContainsKey(tarea.ID))
            {
                TareasDesarrollador.Remove(tarea.ID);
                tarea.Asignada = false;
            }
            else
            {
                Console.WriteLine("La tarea no está asignada a este desarrollador.");
            }
        }
    }
}
