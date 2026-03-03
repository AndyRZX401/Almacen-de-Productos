public class Almacen
{
    private List<Producto> productos;

    public Almacen()
    {
        productos = new List<Producto>();
    }

    public bool AgregarProducto(Producto producto)
    {
        if (productos.Any(p => p.Codigo == producto.Codigo))
            return false;

        productos.Add(producto);
        return true;
    }

    public Producto BuscarProducto(string codigo)
    {
        return productos.FirstOrDefault(p => p.Codigo == codigo);
    }

    public bool EliminarProducto(string codigo)
    {
        Producto p = BuscarProducto(codigo);
        if (p != null)
        {
            productos.Remove(p);
            return true;
        }
        return false;
    }

    public List<Producto> ObtenerProductos()
    {
        return productos;
    }

    public int ObtenerCantidad()
    {
        return productos.Count;
    }
}