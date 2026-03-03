using System;

class Program
{
    static void Main()
    {
        Almacen almacen = new Almacen();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.WriteLine("      SISTEMA DE GESTIÓN DE PRODUCTOS");
            Console.WriteLine("==========================================");
            Console.ResetColor();

            Console.WriteLine("\n[1.] Registrar producto");
            Console.WriteLine("[2.] Buscar producto");
            Console.WriteLine("[3.] Eliminar producto");
            Console.WriteLine("[4.] Listar productos");
            Console.WriteLine("[5.] Salir");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarProducto(almacen);
                    break;

                case "2":
                    BuscarProducto(almacen);
                    break;

                case "3":
                    EliminarProducto(almacen);
                    break;

                case "4":
                    ListarProductos(almacen);
                    break;

                case "5":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Pausa();
                    break;
            }
        }
    }

    static void RegistrarProducto(Almacen almacen)
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR PRODUCTO ===\n");

        Console.Write("Código: ");
        string codigo = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(codigo))
        {
            Console.WriteLine("El código no puede estar vacío.");
            Pausa();
            return;
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            Pausa();
            return;
        }

        Console.Write("Marca: ");
        string marca = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(marca))
        {
            Console.WriteLine("La marca no puede estar vacía.");
            Pausa();
            return;
        }

        Console.Write("Precio: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio <= 0)
        {
            Console.WriteLine("Precio inválido.");
            Pausa();
            return;
        }

        Console.Write("Cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 0)
        {
            Console.WriteLine("Cantidad inválida.");
            Pausa();
            return;
        }

        Producto nuevo = new Producto(codigo, nombre, marca, precio, cantidad);

        if (almacen.AgregarProducto(nuevo))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProducto registrado correctamente.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYa existe un producto con ese código.");
        }

        Console.ResetColor();
        Pausa();
    }

    static void BuscarProducto(Almacen almacen)
    {
        Console.Clear();
        Console.WriteLine("=== BUSCAR PRODUCTO ===\n");

        Console.Write("Ingrese el código: ");
        string codigo = Console.ReadLine().Trim();

        Producto encontrado = almacen.BuscarProducto(codigo);

        if (encontrado != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCódigo: {encontrado.Codigo}");
            Console.WriteLine($"Nombre: {encontrado.Nombre}");
            Console.WriteLine($"Marca: {encontrado.Marca}");
            Console.WriteLine($"Precio: RD${encontrado.Precio:F2}");
            Console.WriteLine($"Cantidad: {encontrado.Cantidad}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nProducto no encontrado.");
        }

        Console.ResetColor();
        Pausa();
    }

    static void EliminarProducto(Almacen almacen)
    {
        Console.Clear();
        Console.WriteLine("=== ELIMINAR PRODUCTO ===\n");

        Console.Write("Ingrese el código: ");
        string codigo = Console.ReadLine().Trim();

        if (almacen.EliminarProducto(codigo))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProducto eliminado correctamente.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nProducto no encontrado.");
        }

        Console.ResetColor();
        Pausa();
    }

    static void ListarProductos(Almacen almacen)
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE PRODUCTOS ===\n");

        var lista = almacen.ObtenerProductos();

        if (lista.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay productos registrados.");
        }
        else
        {
            foreach (var p in lista)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Código: {p.Codigo}");
                Console.WriteLine($"Nombre: {p.Nombre}");
                Console.WriteLine($"Marca: {p.Marca}");
                Console.WriteLine($"Precio: RD${p.Precio:F2}");
                Console.WriteLine($"Cantidad: {p.Cantidad}");
            }
        }

        Console.ResetColor();
        Pausa();
    }

    static void Pausa()
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }
}