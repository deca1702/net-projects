using System;
using System.Text.RegularExpressions;

namespace GestionEmpleados
{
    public enum TipoPuesto
    {
        Gerente,
        Desarrollador
    }

    public abstract class Empleado
    {
        private string _dni;
        private decimal _salario;

        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        // Propiedad DNI con validación directa en el setter
        public string DNI
        {
            get => _dni;
            set
            {
                // Validación directa en el setter
                if (string.IsNullOrEmpty(value) || value.Length != 9 ||
                    !Regex.IsMatch(value.Substring(0, 8), @"^\d{8}$") ||
                    !char.IsLetter(value[8]))
                {
                    throw new ArgumentException("El DNI debe contener 8 números y una letra.");
                }
                _dni = value;
            }
        }

        public decimal Salario
        {
            get => _salario;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El salario debe ser positivo.");
                _salario = value;
            }
        }

        public TipoPuesto Puesto { get; set; }

        // Constructor
        public Empleado(string nombre, string apellidos, string dni, decimal salario, TipoPuesto puesto)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos))
                throw new ArgumentException("No pueden estar vacíos ni el nombre ni los apellidos");

            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni; 
            Salario = salario; 
            Puesto = puesto;
        }

        public virtual decimal CalcularSalarioAnual()
        {
            return Salario * 12;
        }
    }
}
