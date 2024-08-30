public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private EstadoPedidos estado;

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public EstadoPedidos Estado { get => estado; set => estado = value; }

    public Pedido()
    {
        cliente = new Cliente();
    }

    public void VerDireccionCliente()
    {

    }

    public void VerDatosCliente()
    {

    }
}
