
public class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }

    public Producto(string codigo, string nombre, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
    }
}