using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassWork
{
    internal class ActividadClase1
    {

        public static void Ejercicio1()
        {
            {
                int numNotas;
                const int notaMinima = 0;
                const int notaMaxima = 10;

                // Solicitar al usuario el número de notas
                do
                {
                    Console.Write("¿Cuántas notas deseas ingresar? (entre 1 y 10): ");
                    string input = Console.ReadLine();

                    // Validar que la entrada sea un número entero
                    if (!int.TryParse(input, out numNotas) || numNotas < 1 || numNotas > 10)
                    {
                        Console.WriteLine("Por favor, ingresa un número válido entre 1 y 10.");
                    }
                } while (numNotas < 1 || numNotas > 10);

                double sumaNotas = 0;

                // Ingreso de notas
                for (int i = 0; i < numNotas; i++)
                {
                    double nota;

                    do
                    {
                        Console.Write($"Ingresa la nota {i + 1} (entre {notaMinima} y {notaMaxima}): ");
                        string inputNota = Console.ReadLine();

                        // Validar que la nota sea un número entre 0 y 10
                        if (!double.TryParse(inputNota, out nota) || nota < notaMinima || nota > notaMaxima)
                        {
                            Console.WriteLine($"Por favor, ingresa una nota válida entre {notaMinima} y {notaMaxima}.");
                        }
                    } while (nota < notaMinima || nota > notaMaxima);

                    sumaNotas += nota;
                }

                // Calcular el promedio
                double promedio = sumaNotas / numNotas;
                Console.WriteLine($"El promedio es: {promedio:F2}");

                // Determinar si el estudiante ha aprobado o suspendido
                if (promedio >= 5)
                {
                    Console.WriteLine("¡Felicidades! Has aprobado.");
                }
                else
                {
                    Console.WriteLine("Lo siento, has suspendido.");
                }
            }
        }
        public static void cambiadorDeTemperaturas()
        {
            Console.Write("Ingresa la cantidad de grados Celsius: ");
            // Validar que la entrada sea un número válido y convertirlo a double si es el caso
            if (!double.TryParse(Console.ReadLine(), out double celsius))
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
                return;
            }

            Console.Write("¿A qué unidad deseas convertir? (K para Kelvin, F para Fahrenheit, A para ambas): ");
            string unidad = Console.ReadLine().ToUpper();

            switch (unidad)
            {
                case "K":
                    double kelvin = celsius + 273.15;
                    Console.WriteLine($"{celsius} son {kelvin} K");
                    break;
                case "F":
                    double fahrenheit = celsius * 18 / 10 + 32;
                    Console.WriteLine($"{celsius} son {fahrenheit} F");
                    break;
                case "A":
                    kelvin = celsius + 273.15;
                    fahrenheit = celsius * 18 / 10 + 32;
                    Console.WriteLine($"{celsius} son {fahrenheit} F y {kelvin} K");
                    break;
            }
        }
        public static void numerosRandom()
        {
            Random random = new Random();
            int numeroSecreto = random.Next(1, 101);
            int intentos = 0;
            int numeroUsuario;

            Console.WriteLine("Adivina el número secreto entre 1 y 100.");

            do
            {
                Console.Write("Ingresa tu número: ");
                string input = Console.ReadLine();

                // Validar que la entrada sea un número entero
                if (!int.TryParse(input, out numeroUsuario) || numeroUsuario < 1 || numeroUsuario > 100)
                {
                    Console.WriteLine("Por favor, ingresa un número válido entre 1 y 100.");
                    continue;
                }

                intentos++;

                if (numeroUsuario < numeroSecreto)
                {
                    Console.WriteLine("El número secreto es mayor.");
                }
                else if (numeroUsuario > numeroSecreto)
                {
                    Console.WriteLine("El número secreto es menor.");
                }
            } while (numeroUsuario != numeroSecreto);

            Console.WriteLine($"¡Felicidades! Adivinaste el número secreto en {intentos} intentos.");



        }
        public static void numerosPositivos()
        {
            int[] numeros = new int[5];  // Array para almacenar 5 números
            int i = 0;  // Índice del array

            while (i < 5)
            {
                Console.Write($"Ingresa el número {i + 1}: ");
                string input = Console.ReadLine();
                int numero;

                // Verifica si el valor ingresado es un número entero
                if (int.TryParse(input, out numero))
                {
                    // Verifica que el número sea positivo
                    if (numero > 0)
                    {
                        numeros[i] = numero;
                        i++;  // Pasa al siguiente número
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa un número mayor a 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingresa un número entero.");
                }
            }

            // Imprimir los números ingresados
            Console.WriteLine("Números ingresados:");
            foreach (int num in numeros)
            {
                Console.WriteLine(num);
            }
        }
    }
}