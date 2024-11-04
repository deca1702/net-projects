using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    internal class Menu
    {
        public static List<Gerente> gerentes = new List<Gerente>();
        public static List<Desarrollador> desarrolladores = new List<Desarrollador>();
        public static List<Tarea> tareas = new List<Tarea>();

        public static void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Agregar Empleado");
                Console.WriteLine("2. Asignar Desarrollador a Gerente");
                Console.WriteLine("3. Crear Tareas");
                Console.WriteLine("4. Gestionar Tareas de Desarrollador");
                Console.WriteLine("5. Mostrar Información de Empleados");
                Console.WriteLine("0. Salir");

                switch (Console.ReadLine())
                {
                    case "1":
                        AgregarEmpleado();
                        break;
                    case "2":
                        AsignarDesarrollador();
                        break;
                    case "3":
                        CrearTareas();
                        break;
                    case "4":
                        GestionTareas();
                        break;
                    case "5":
                        MostrarInformacionEmpleados();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        public static void AgregarEmpleado()
        {
            Console.WriteLine("Agregar Empleado:");
            Console.WriteLine("1. Desarrollador");
            Console.WriteLine("2. Gerente");
            string opcion = Console.ReadLine();

            string dni;
            while (true)
            {
                Console.Write("DNI (8 números y una letra): ");
                dni = Console.ReadLine();

                // Validación del formato del DNI
                if (dni.Length == 9 && Regex.IsMatch(dni.Substring(0, 8), @"^\d{8}$") && char.IsLetter(dni[8]))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Error: El DNI debe contener 8 números y una letra.");
                }
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            string apellidos = Console.ReadLine();
            Console.Write("Salario: ");
            decimal salario = decimal.Parse(Console.ReadLine());

            if (opcion == "1")
            {
                Console.WriteLine("Nivel del Desarrollador (1 = Junior, 2 = Senior): ");
                string nivel = Console.ReadLine();
                NivelDesarrollador nivelDev = nivel == "1" ? NivelDesarrollador.Junior : NivelDesarrollador.Senior;
                Desarrollador desarrollador = new Desarrollador(nombre, apellidos, dni, salario, nivelDev);
                desarrolladores.Add(desarrollador);
                Console.WriteLine("Desarrollador agregado con éxito.");
            }
            else if (opcion == "2")
            {
                Console.Write("Bono Anual: ");
                decimal bonoAnual = decimal.Parse(Console.ReadLine());
                Gerente gerente = new Gerente(nombre, apellidos, dni, salario, bonoAnual);
                gerentes.Add(gerente);
                Console.WriteLine("Gerente agregado con éxito.");
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }

        public static void AsignarDesarrollador()
        {
            Console.WriteLine("\nAsignar Desarrollador a Gerente:");
            if (gerentes.Count == 0 || desarrolladores.Count == 0)
            {
                Console.WriteLine("No hay gerentes o desarrolladores disponibles para asignar.");
                return;
            }

            Console.WriteLine("Lista de Gerentes:");
            for (int i = 0; i < gerentes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {gerentes[i].Nombre} {gerentes[i].Apellidos}");
            }
            Console.Write("Seleccione un Gerente (número): ");
            if (!int.TryParse(Console.ReadLine(), out int gerenteIndex) || gerenteIndex < 1 || gerenteIndex > gerentes.Count)
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            Console.WriteLine("Lista de Desarrolladores:");
            for (int i = 0; i < desarrolladores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {desarrolladores[i].Nombre} {desarrolladores[i].Apellidos}");
            }
            Console.Write("Seleccione un Desarrollador (número): ");
            if (!int.TryParse(Console.ReadLine(), out int desarrolladorIndex) || desarrolladorIndex < 1 || desarrolladorIndex > desarrolladores.Count)
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            Gerente gerenteSeleccionado = gerentes[gerenteIndex - 1];
            Desarrollador desarrolladorSeleccionado = desarrolladores[desarrolladorIndex - 1];
            gerenteSeleccionado.AsignarDesarrollador(desarrolladorSeleccionado);
            Console.WriteLine("Desarrollador asignado al gerente con éxito.");
        }

        public static void CrearTareas()
        {
            Console.Write("\nID de la tarea: ");
            string id = Console.ReadLine();
            Console.Write("Nombre de la tarea: ");
            string nombre = Console.ReadLine();
            Console.Write("Descripción de la tarea: ");
            string descripcion = Console.ReadLine();
            Console.Write("Fecha de entrega (yyyy-mm-dd): ");
            DateTime fechaEntrega;

            while (!DateTime.TryParse(Console.ReadLine(), out fechaEntrega))
            {
                Console.WriteLine("Formato de fecha no válido. Intente de nuevo.");
            }

            Tarea tarea = new Tarea(id, nombre, descripcion, fechaEntrega);
            tareas.Add(tarea);
            Console.WriteLine("Tarea creada con éxito.");
        }

        public static void GestionTareas()
        {
            Console.WriteLine("\nGestionar Tareas de Desarrollador:");
            if (desarrolladores.Count == 0)
            {
                Console.WriteLine("No hay desarrolladores disponibles para gestionar tareas.");
                return;
            }

            Console.WriteLine("Lista de Desarrolladores:");
            for (int i = 0; i < desarrolladores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {desarrolladores[i].Nombre} {desarrolladores[i].Apellidos}");
            }
            Console.Write("Seleccione un Desarrollador: ");
            if (!int.TryParse(Console.ReadLine(), out int desarrolladorIndex) || desarrolladorIndex < 1 || desarrolladorIndex > desarrolladores.Count)
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            Desarrollador desarrolladorSeleccionado = desarrolladores[desarrolladorIndex - 1];

            Console.WriteLine("1. Asignar Tarea");
            Console.WriteLine("2. Desasignar Tarea");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.WriteLine("Lista de Tareas Disponibles:");
                List<Tarea> tareasDisponibles = tareas.FindAll(t => !t.Asignada);
                if (tareasDisponibles.Count == 0)
                {
                    Console.WriteLine("No hay tareas disponibles para asignar.");
                    return;
                }

                for (int i = 0; i < tareasDisponibles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tareasDisponibles[i].Nombre} (ID: {tareasDisponibles[i].ID})");
                }
                Console.Write("Seleccione una Tarea: ");
                if (!int.TryParse(Console.ReadLine(), out int tareaIndex) || tareaIndex < 1 || tareaIndex > tareasDisponibles.Count)
                {
                    Console.WriteLine("Opción no válida.");
                    return;
                }

                Tarea tareaSeleccionada = tareasDisponibles[tareaIndex - 1];
                desarrolladorSeleccionado.AsignarTarea(tareaSeleccionada);
                Console.WriteLine("Tarea asignada con éxito.");
            }
            else if (opcion == "2")
            {
                if (desarrolladorSeleccionado.TareasDesarrollador.Count == 0)
                {
                    Console.WriteLine("No hay tareas asignadas para desasignar.");
                    return;
                }

                Console.WriteLine("Tareas asignadas al Desarrollador:");
                foreach (var tarea in desarrolladorSeleccionado.TareasDesarrollador)
                {
                    Console.WriteLine($"ID: {tarea.Key}, Nombre: {tarea.Value}");
                }
                Console.Write("Ingrese el ID de la Tarea a desasignar: ");
                string idTarea = Console.ReadLine();

                if (desarrolladorSeleccionado.TareasDesarrollador.ContainsKey(idTarea))
                {
                    Tarea tarea = tareas.Find(t => t.ID == idTarea);
                    desarrolladorSeleccionado.DesAsignarTarea(tarea);
                    Console.WriteLine("Tarea desasignada con éxito.");
                }
                else
                {
                    Console.WriteLine("ID de tarea no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }

        public static void MostrarInformacionEmpleados()
        {
            Console.WriteLine("\nInformación de Empleados:");
            Console.WriteLine("1. Mostrar Gerentes");
            Console.WriteLine("2. Mostrar Desarrolladores");
            Console.WriteLine("3. Mostrar Todos");
            string opcion = Console.ReadLine();

            if (opcion == "1" || opcion == "3")
            {
                Console.WriteLine("Gerentes:");
                foreach (var gerente in gerentes)
                {
                    Console.WriteLine($"Nombre: {gerente.Nombre}, Apellidos: {gerente.Apellidos}, DNI: {gerente.DNI}, Salario Anual: {gerente.CalcularSalarioAnual()}");
                }
            }
            if (opcion == "2" || opcion == "3")
            {
                Console.WriteLine("Desarrolladores:");
                foreach (var desarrollador in desarrolladores)
                {
                    Console.WriteLine($"Nombre: {desarrollador.Nombre}, Apellidos: {desarrollador.Apellidos}, DNI: {desarrollador.DNI}, Salario Anual: {desarrollador.CalcularSalarioAnual()}");
                }
            }
        }
    }
}