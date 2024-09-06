public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> pedidos = new List<Pedido>();
    private Random random = new Random();

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    // public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    public float JornalACobrar()
    {
        return pedidos.Count() * 500;
    }

    public void TomarPedido(Pedido pedido)
    {
        pedidos.Add(pedido);
    }

    public void EntregarPedido()
    {
        pedidos.Remove(pedidos[0]);
    }

    public void CambiarEstadoPedido(int NumeroPedidoBuscado)
    {
        foreach (var pedido in pedidos)
        {
            if (pedido.Numero == NumeroPedidoBuscado)
            {
                pedido.Estado = (EstadoPedidos)random.Next(0, 6);
            }
        }
    }
}
