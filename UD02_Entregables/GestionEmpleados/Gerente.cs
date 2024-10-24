using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    public class Gerente : Empleado
    {
        public List<Desarrollador> EquipoDesarrolladores { get; set; }
        private decimal _bonoAnual;
        public decimal BonoAnual
        {
            get { return _bonoAnual; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El bono anual no puede ser negativo.");
                }
                _bonoAnual = value;
            }
        }
        //Constructor
        public Gerente(string nombre, string apellidos, string dni, decimal salario, TipoPuesto puesto, List<Desarrollador> equipoDesarrolladores, decimal bonoAnual)
            : base(nombre, apellidos, dni, salario, puesto)
        {
            EquipoDesarrolladores = equipoDesarrolladores;
            BonoAnual = bonoAnual;
        }
        public override decimal CalcularSalarioAnual()
        {
            return base.CalcularSalarioAnual() + _bonoAnual;
        }
        
        public static void AsignarDesarrollador(Desarrollador desarrollador, Gerente gerente)
        {
            gerente.EquipoDesarrolladores.Add(desarrollador);
        }
        public static void EliminarDesarrollador(Desarrollador desarrollador, Gerente gerente)
        {
            gerente.EquipoDesarrolladores.Remove(desarrollador);
        }
    }
}   
