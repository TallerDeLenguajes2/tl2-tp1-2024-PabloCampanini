public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private EstadoPedidos estado;
    private Cadete cadeteAsignado;

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public EstadoPedidos Estado { get => estado; set => estado = value; }
    public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

    public Pedido()
    {
        cliente = new Cliente();
        CadeteAsignado = null;
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine("Domicilio: " + Cliente.Direccion);
    }

    public void VerDatosCliente()
    {
        Console.WriteLine("Nombre: " + Cliente.Nombre);
        Console.WriteLine("Telefono: " + Cliente.Telefono);
        VerDireccionCliente();
        Console.WriteLine("Referencias: " + Cliente.DatosReferenciaDireccion);
    }

    public void AsignarCadeteAPedido(Cadete cadete)
    {
        CadeteAsignado = cadete;
    }
}
