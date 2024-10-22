using System;
using System.Collections.Generic;

namespace Entregable
{
    internal class GestionContacto
    {
        //Diccionario que almacena los contactos
        //La clave es el nombre del contacto y el valor es otro diccionario
        private static Dictionary<string, Dictionary<string, string>> contactos = new Dictionary<string, Dictionary<string, string>>();

        public static void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú de Gestión de Contactos");
                Console.WriteLine("1. Agregar un nuevo contacto");
                Console.WriteLine("2. Buscar un contacto por nombre");
                Console.WriteLine("3. Eliminar un contacto");
                Console.WriteLine("4. Mostrar todos los contactos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarContacto();
                        break;
                    case 2:
                        BuscarContacto();
                        break;
                    case 3:
                        EliminarContacto();
                        break;
                    case 4:
                        MostrarTodosLosContactos();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 5);
        }

        //Método para agregar un contacto
        public static void AgregarContacto()
        {
            Console.Write("Ingrese el nombre del contacto: ");
            string nombre = Console.ReadLine(); 
            if (contactos.ContainsKey(nombre)) //Verifica si el contacto ya existe
            {
                Console.WriteLine("El contacto ya existe.");
                return;
            }
            //Si el contacto no existe, se solicita el teléfono y el correo
            Console.Write("Ingrese el teléfono del contacto: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese el correo electrónico del contacto: ");
            string correo = Console.ReadLine();

            //Se agrega el contacto al diccionario
            contactos[nombre] = new Dictionary<string, string> //
            {
                { "Telefono", telefono },
                { "Correo", correo }
            };

            Console.WriteLine("Contacto agregado exitosamente.");
        }

        //Método para buscar un contacto
        public static void BuscarContacto()
        {
            Console.Write("Ingrese el nombre del contacto a buscar: ");
            string nombre = Console.ReadLine();
            //Se busca el contacto en el diccionario y se muestra la información
            if (contactos.TryGetValue(nombre, out var infoContacto)) 
            {
                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine($"Teléfono: {infoContacto["Telefono"]}");
                Console.WriteLine($"Correo: {infoContacto["Correo"]}");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
        //Método para eliminar un contacto
        public static void EliminarContacto()
        {
            Console.Write("Ingrese el nombre del contacto a eliminar: ");
            string nombre = Console.ReadLine();
            //Se elimina el contacto del diccionario y se muestra un mensaje
            if (contactos.Remove(nombre))
            {
                Console.WriteLine("Contacto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
        //Método para mostrar todos los contactos
        public static void MostrarTodosLosContactos()
        {
            //Se verifica si hay contactos para mostrar 
            if (contactos.Count == 0)
            {
                Console.WriteLine("No hay contactos para mostrar.");
                return;
            }
            //Se recorre el diccionario y se muestra la información de cada contacto
            foreach (var contacto in contactos)
            {
                Console.WriteLine($"Nombre: {contacto.Key}");
                Console.WriteLine($"Teléfono: {contacto.Value["Telefono"]}");
                Console.WriteLine($"Correo: {contacto.Value["Correo"]}");
                Console.WriteLine("-------------------------");
            }
        }
    }
}