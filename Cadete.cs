public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private Random random = new Random();

    public Cadete()
    {
        
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public void CambiarEstadoPedido(Pedido PedidoACambiar)
    {
        PedidoACambiar.Estado = (EstadoPedidos)random.Next(0, 5);
    }
}
