using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    public enum TipoPuesto
    {
        Gerente,
        Desarrollador
    }
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public decimal Salario { get; set; }
        public TipoPuesto Puesto { get; set; }

        // Constructor
        public Empleado(string nombre, string apellidos, string dni, decimal salario, TipoPuesto puesto)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni;
            Salario = salario;
            Puesto = puesto;
        }

        public static void calcularSalarioAnual(Tarea tarea)
        {
            decimal salarioAnual = tarea.Salario * 12;
            Console.WriteLine("El salario anual de " + tarea.Nombre + " " + tarea.Apellidos + " es de " + salarioAnual + " euros.");
        }
        
    }
}
