using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

public class Almacen
{
    private List<Producto> productos;
    private string rutaArchivo = "productos.json";

    public Almacen()
    {
        CargarDatos();
    }

    // ✅ Agregar producto
    public bool AgregarProducto(Producto producto)
    {
        if (productos.Any(p => p.Codigo.Equals(producto.Codigo,
            System.StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        productos.Add(producto);
        GuardarDatos();
        return true;
    }

    // ✅ Buscar
    public Producto BuscarProducto(string codigo)
    {
        return productos
            .FirstOrDefault(p => p.Codigo.Equals(codigo,
            System.StringComparison.OrdinalIgnoreCase));
    }

    // ✅ Eliminar
    public bool EliminarProducto(string codigo)
    {
        Producto encontrado = BuscarProducto(codigo);

        if (encontrado != null)
        {
            productos.Remove(encontrado);
            GuardarDatos();
            return true;
        }

        return false;
    }

    // ✅ Obtener todos
    public List<Producto> ObtenerProductos()
    {
        return productos;
    }

    // ✅ Guardar en archivo
    private void GuardarDatos()
    {
        string json = JsonSerializer.Serialize(productos, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(rutaArchivo, json);
    }

    // ✅ Cargar desde archivo
    private void CargarDatos()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            productos = JsonSerializer.Deserialize<List<Producto>>(json);
        }
        else
        {
            productos = new List<Producto>();
        }
    }
}