public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> pedidos;
    private List<Pedido> pedidosEntregados;
    private Random random = new Random();

    public Cadete()
    {
        pedidos = new List<Pedido>();
        pedidosEntregados = new List<Pedido>();
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public float JornalACobrar()
    {
        return pedidosEntregados.Count() * 500;
    }

    public void TomarPedido(Pedido pedido)
    {
        pedidos.Add(pedido);
    }

    public void EntregarPedido()
    {
        pedidosEntregados.Add(pedidos[0]);

        pedidos.Remove(pedidos[0]);
    }

    public bool CambiarEstadoPedido(int NumeroPedidoBuscado)
    {
        for (int i = 0; i < pedidos.Count; i++)
        {
            if (pedidos[i].Numero == NumeroPedidoBuscado)
            {
                pedidos[i].Estado = (EstadoPedidos)random.Next(0, 5);

                if (pedidos[i].Estado == (EstadoPedidos)4)
                {
                    pedidosEntregados.Add(pedidos[i]);

                    pedidos.Remove(pedidos[i]);
                }

                return true;
            }
        }

        return false;
    }

    public Pedido ReasignarPedidos(int NumeroPedidoBuscado)
    {
        Pedido MoverPedido = null;

        for (int i = 0; i < pedidos.Count; i++)
        {
            if (pedidos[i].Numero == NumeroPedidoBuscado)
            {
                MoverPedido = pedidos[i];

                pedidos.Remove(pedidos[i]);

                break;
            }
        }

        return MoverPedido;
    }
}
