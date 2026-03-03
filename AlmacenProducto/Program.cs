using System;

namespace AlmacenProducto
{
    class Program
    {
        static void Main()
        {
            Almacen almacen = new Almacen();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- SISTEMA DE ALMACÉN ---");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Listar productos");
                Console.WriteLine("5. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                    // registrar
                    case "2":
                        // buscar
                        break;

                    case "3":
                        // eliminar
                        break;

                    case "4":
                        // listar
                        break;

                    case "5":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}
