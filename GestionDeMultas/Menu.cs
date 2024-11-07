using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMultas
{
    public class Menu
    {

        public static void MenuMultas()
        {

            int opcion = 0;
      
            do
            {
               
                Console.WriteLine("[Bienvenido al gestor de multas]");
                Console.WriteLine("");
                Console.WriteLine("1. Agregar multa ");
                Console.WriteLine("2. Agregar conductor ");
                Console.WriteLine("3. Gestionar multas ");
                Console.WriteLine("4. Mostrar informacion ");
                Console.WriteLine("0. Salir ");

                
            

                




            } while (opcion == 0);
        }

        public static void AgregarMulta()
        {
        List<string> multasGenerenales = new List<string>();   

            Console.WriteLine("Digame el numero de multa");
            int numMulta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digame el DNI para poner la multa");
            string dni = Console.ReadLine();

            Console.WriteLine("Digame el nombre para poner la multa");
            string nombre = Console.ReadLine();




        }
        public static void AgregarConductor()
        {
           List<string> conductores = new List<string>();


            Console.WriteLine("Indica el nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Apelldios a introducir");
            string apelldios = Console.ReadLine();

            Console.WriteLine("Introduce el DNI");
            string dni = Console.ReadLine();

            conductores.Add(nombre);
            conductores.Add(apelldios);
            conductores.Add(dni);

           
        }
        public static void GestionarMultas()
        {
            Console.WriteLine("A. Actualizar estado de la multa");
            string a;
            Console.WriteLine("B. Asignar una multa a un conductor");
            string b;
            Console.WriteLine("C. Eliminar una multa de un conductor");
            string c;
        }
        public void MostrarInformacion()
        {
            
        }
      }
   }
    

