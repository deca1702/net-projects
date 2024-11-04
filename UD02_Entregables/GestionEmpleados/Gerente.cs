using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

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
        public Gerente(string nombre, string apellidos, string dni, decimal salario, decimal bonoAnual)
            : base(nombre, apellidos, dni, salario, TipoPuesto.Gerente)
        {
            _bonoAnual = bonoAnual >= 0 ? bonoAnual : throw new ArgumentException("Bono anual no puede ser negativo.");
            EquipoDesarrolladores = new List<Desarrollador>();
        }

        public override decimal CalcularSalarioAnual()
        {
            return base.CalcularSalarioAnual() + _bonoAnual;
        }

        public void AsignarDesarrollador(Desarrollador desarrollador)
        {
            if (!EquipoDesarrolladores.Contains(desarrollador))
                EquipoDesarrolladores.Add(desarrollador);
        }

        public void EliminarDesarrollador(Desarrollador desarrollador)
        {
            EquipoDesarrolladores.Remove(desarrollador);
        }
    }
}

