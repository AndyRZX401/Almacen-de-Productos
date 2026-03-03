
public class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Marca { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }


    public Producto(string codigo, string nombre, string marca, decimal precio, int cantidad)
    {
        Codigo = codigo;
        Nombre = nombre;
        Marca = marca;
        Precio = precio;
        Cantidad = cantidad;
    }
}