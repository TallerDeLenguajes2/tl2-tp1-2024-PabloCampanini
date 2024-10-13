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

    public string VerDireccionCliente()
    {
        return $"Domicilio: {Cliente.Direccion}";
    }

    public string VerDatosCliente()
    {
        string datos = $"Nombre: {Cliente.Nombre}\n" +
                       $"Telefono: {Cliente.Telefono}\n" +
                       VerDireccionCliente() + "\n" +
                       $"Referencias: {Cliente.DatosReferenciaDireccion}";
        return datos;
    }

    public void AsignarCadeteAPedido(Cadete cadete)
    {
        CadeteAsignado = cadete;
    }
}
