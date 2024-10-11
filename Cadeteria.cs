using System.Reflection.Metadata.Ecma335;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;
    private List<Pedido> pedidos;
    private Random rand = new Random();

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public Cadeteria()
    {
        cadetes = new List<Cadete>();
        pedidos = new List<Pedido>();
    }

    public void ContratarCadete(Cadete NuevoCadete)
    {
        cadetes.Add(NuevoCadete);
    }

    public bool DespedirCadete(int ID)
    {
        for (int i = 0; i < cadetes.Count; i++)
        {
            if (cadetes[i].Id == ID)
            {
                cadetes.Remove(cadetes[i]);
                return true;
            }
        }

        return false;
    }

    public bool AltaPedido(int NumeroPedido, string ObservacionPedido, string NombreCliente, string DireccionCliente, string TelefonoCliente, string ReferenciaDireccion)
    {
        Pedido NuevoPedido = new Pedido();

        NuevoPedido.Numero = NumeroPedido;

        NuevoPedido.Observacion = ObservacionPedido;

        NuevoPedido.Cliente.Nombre = NombreCliente;

        NuevoPedido.Cliente.Direccion = DireccionCliente;

        NuevoPedido.Cliente.Telefono = TelefonoCliente;

        NuevoPedido.Cliente.DatosReferenciaDireccion = ReferenciaDireccion;

        int CantidadAntesCargar = pedidos.Count();

        pedidos.Add(NuevoPedido);

        return pedidos.Count() > CantidadAntesCargar;
    }

    public int CadeteAleatorio()
    {
        return cadetes[rand.Next(0, cadetes.Count)].Id;
    }
    public bool AsignarCadeteAPedido(int IdCadete, int NumeroPedido)
    {
        //Hay dos formas de hacer una busqueda mejor que un foreach
        //Ambas devuelven el primer elemento que se busca o null


        //Expresion lambda generica item => item.Propiedad == ValorBuscado


        //Metodo de listas Find pero necesita una expresion lambda o funcion
        var PedidoBuscado = pedidos.Find(pedido => pedido.Numero == NumeroPedido);
        
        //Consulta Linq y necesita una expresion lambda
        var CadeteBuscado = cadetes.FirstOrDefault(cadete => cadete.Id == IdCadete);

        if (PedidoBuscado == null && CadeteBuscado == null)
        {
            return false;
        }

        PedidoBuscado.AsignarCadeteAPedido(CadeteBuscado);

        return true;
    }

    public float JornalACobrar(int IdCadete)
    {
        int contadorPedidos = 0;

        contadorPedidos = pedidos.Count(pedido => pedido.CadeteAsignado.Id == IdCadete);

        return contadorPedidos * 500;   
    }

    public void PagarJornal()
    {
        foreach (var Cadete in cadetes)
        {
            Console.WriteLine($"\n\nPago cadete ID = {Cadete.Id} \n\t-----> Nombre = {Cadete.Nombre} *-----* Pago = ${JornalACobrar(Cadete.Id)}");
        }
    }

    public bool CambiarEstadoPedido(int NumeroPedidoBuscado)
    {
        var PedidoBuscado = pedidos.FirstOrDefault(pedido => pedido.Numero == NumeroPedidoBuscado);

        if (PedidoBuscado == null)
        {
            return false;
        }

        PedidoBuscado.CadeteAsignado.CambiarEstadoPedido(PedidoBuscado);

        return true;
    }

    public bool ReasignarPedidos(int IdCadeteNuevo, int NumeroPedidoBuscado)
    {
        var PedidoBuscado = pedidos.FirstOrDefault(pedido => pedido.Numero == NumeroPedidoBuscado);
        var CadeteBuscado = cadetes.FirstOrDefault(cadete => cadete.Id == IdCadeteNuevo);

        if (PedidoBuscado == null || CadeteBuscado == null)
        {
            return false;
        }

        PedidoBuscado.AsignarCadeteAPedido(CadeteBuscado);

        return true;
    }

    public void GenerarInforme()
    {
        // Total de envíos por cadete y monto total ganado
        var informe = cadetes.Select(cadete => new
        {
            Cadete = cadete.Nombre,
            CantidadPedidosEntregados = (JornalACobrar(cadete.Id)) / 500,
            MontoGanado = JornalACobrar(cadete.Id)
        });

        // Mostrar el informe de cada cadete
        foreach (var item in informe)
        {
            Console.WriteLine($"Cadete: {item.Cadete}, Pedidos Entregados: {item.CantidadPedidosEntregados}, Monto Ganado: {item.MontoGanado}");
        }

        // Calcular el promedio de envíos por cadete
        double promedioEnvios = cadetes.Average(cadete => ((JornalACobrar(cadete.Id)) / 500));
        Console.WriteLine($"\nPromedio de envíos por cadete: {promedioEnvios}");
    }

    public bool MostrarDatosPedido(int NumeroPedidoBuscado)
    {
        var PedidoBuscado = pedidos.FirstOrDefault(pedido => pedido.Numero == NumeroPedidoBuscado);

        if (PedidoBuscado == null)
        {
            return false;
        }

        PedidoBuscado.VerDatosCliente();

        return true;
    }

    public List<string[]> DatosCadetes()
    {
        List<string[]> Datos = new List<string[]>();

        foreach (var cadete in cadetes)
        {
            string[] DatosCadetes = { cadete.Nombre, cadete.Direccion, cadete.Telefono };

            Datos.Add(DatosCadetes);
        }

        return Datos;
    }
}