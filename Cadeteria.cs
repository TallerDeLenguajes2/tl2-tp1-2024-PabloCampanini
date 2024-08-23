public enum EstdadoPedidos
{
    
}

public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDireccion;

    
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

}

public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private EstdadoPedidos estado;

    public Pedido()
    {
        
    }

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public EstdadoPedidos Estado { get => estado; set => estado = value; }

    public void VerDireccionCliente()
    {

    }

    public void VerDatosCliente()
    {

    }
}

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> pedidos = new List<Pedido>();

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    public void JornalACobrar()
    {

    }
}

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes = new List<Cadete>();


}