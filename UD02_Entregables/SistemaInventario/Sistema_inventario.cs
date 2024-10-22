using System;
using System.Collections.Generic;

internal class Sistema_inventario
{
    //Lista que almacena los productos
    //Cada producto es un diccionario con tres claves: Nombre, Cantidad y Precio
    private static List<Dictionary<string, object>> productos = new List<Dictionary<string, object>>();

    public static void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("Menú de Gestión de Inventario:");
            Console.WriteLine("1. Agregar un producto");
            Console.WriteLine("2. Modificar la cantidad de un producto");
            Console.WriteLine("3. Buscar un producto por nombre");
            Console.WriteLine("4. Eliminar un producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir del programa");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarProducto();
                    break;
                case "2":
                    ModificarCantidadProducto();
                    break;
                case "3":
                    BuscarProducto();
                    break;
                case "4":
                    EliminarProducto();
                    break;
                case "5":
                    MostrarTodosLosProductos();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
    //Método para agregar un producto
    private static void AgregarProducto()
    {
        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la cantidad en stock: ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el precio: ");
        double precio = double.Parse(Console.ReadLine());

        //Se crea un diccionario con los datos del producto y se agrega a la lista
        var producto = new Dictionary<string, object>
                {
                    { "Nombre", nombre },
                    { "Cantidad", cantidad },
                    { "Precio", precio }
                };
        //Se agrega el producto a la lista
        productos.Add(producto);
        Console.WriteLine("Producto agregado exitosamente.");
    }

    private static void ModificarCantidadProducto()
    {
        Console.Write("Ingrese el nombre del producto a modificar: ");
        string nombre = Console.ReadLine();
        //Se busca el producto por nombre en la lista
        var producto = productos.FirstOrDefault(p => p["Nombre"].ToString() == nombre);

        //Si el producto existe, se solicita la nueva cantidad en stock
        if (producto != null)
        {
            Console.Write("Ingrese la nueva cantidad en stock: ");
            int nuevaCantidad = int.Parse(Console.ReadLine());
            producto["Cantidad"] = nuevaCantidad;
            Console.WriteLine("Cantidad modificada exitosamente.");
        }
        //Si el producto no existe, se muestra un mensaje
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
    //Método para buscar un producto
    private static void BuscarProducto()
    {
        Console.Write("Ingrese el nombre del producto a buscar: ");
        string nombre = Console.ReadLine();
        //Se busca el producto por nombre en la lista y se muestra la información
        var producto = productos.FirstOrDefault(p => p["Nombre"].ToString() == nombre);

        //Si el producto existe, se muestra la información
        if (producto != null)
        {
            Console.WriteLine($"Nombre: {producto["Nombre"]}, Cantidad: {producto["Cantidad"]}, Precio: {producto["Precio"]}");
        }
        //Si el producto no existe, se muestra un mensaje
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
    //Método para eliminar un producto
    private static void EliminarProducto()
    {
        Console.Write("Ingrese el nombre del producto a eliminar: ");
        string nombre = Console.ReadLine();
        //Se elimina el producto de la lista y se muestra un mensaje
        var producto = productos.FirstOrDefault(p => p["Nombre"].ToString() == nombre);

        //Si el producto existe, se elimina de la lista
        if (producto != null)
        {
            productos.Remove(producto);
            Console.WriteLine("Producto eliminado exitosamente.");
        }
        //Si el producto no existe, se muestra un mensaje
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
    //Método para mostrar todos los productos
    private static void MostrarTodosLosProductos()
    {
        //Se verifica si hay productos para mostrar y si es así, se muestra la información de cada uno
        if (productos.Count > 0)
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto["Nombre"]}, Cantidad: {producto["Cantidad"]}, Precio: {producto["Precio"]}");
            }
        }
        //Si no hay productos, se muestra un mensaje
        else
        {
            Console.WriteLine("No hay productos en el inventario.");
        }
    }
}