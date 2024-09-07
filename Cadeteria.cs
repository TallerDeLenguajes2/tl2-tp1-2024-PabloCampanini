
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;
    private Random random = new Random();

    
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public Cadeteria()
    {
        cadetes = new List<Cadete>();
    }

    public void ContratarCadete(Cadete NuevoCadete)
    {
        cadetes.Add(NuevoCadete);
    }

    public void DespedirCadete(int ID)
    {
        foreach (var Cadete in cadetes)
        {   
            if (Cadete.Id == ID)
            {
                cadetes.Remove(Cadete);
            }
            
        }
    }

    public void PagarJornal()
    {
        foreach (var Cadete in cadetes)
        {
            Console.WriteLine($"Pago cadete ID = {Cadete.Id} -----> Nombre = {Cadete.Nombre} *-----* Pago = ${Cadete.JornalACobrar()}");
        }
    }

    public Pedido AltaPedido(int NumeroPedido)
    {
        Pedido NuevoPedido = new Pedido();

        Console.WriteLine("\nIngrese los datos del pedido: ");

        NuevoPedido.Numero = NumeroPedido;
        Console.WriteLine($"\n\tObservaciones del pedido: {NuevoPedido.Observacion = Console.ReadLine()}");

        Console.WriteLine("\nIngrese los datos del cliente: ");
        Console.WriteLine($"\n\tNombre: {NuevoPedido.Cliente.Nombre = Console.ReadLine()}");
        Console.WriteLine($"\tDireccion: {NuevoPedido.Cliente.Direccion = Console.ReadLine()}");
        Console.WriteLine($"\tTelefono: {NuevoPedido.Cliente.Telefono = Console.ReadLine()}");
        Console.WriteLine($"\tReferencias al domicilio: {NuevoPedido.Cliente.DatosReferenciaDireccion = Console.ReadLine()}");
        

        return NuevoPedido;
    }

    public void AsignarPedido(Pedido PedidoParaAsignar)
    {
        int IdAleatorio = random.Next(10, 10 + cadetes.Count);

        foreach (var cadete in cadetes)
        {
            if(cadete.Id == IdAleatorio)
            {
                cadete.TomarPedido(PedidoParaAsignar);
            }
        }
    }

    public void CambiarEstadoPedido(int NumeroPedidoBuscado)
    {
        foreach (var cadete in cadetes)
        {
            cadete.CambiarEstadoPedido(NumeroPedidoBuscado);
        }
    }
}