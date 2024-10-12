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

    public int CantidadCadetes()
    {
        return cadetes.Count();
    }

    public string NombreCadete(int IdCadete)
    {
        var cadete = cadetes.FirstOrDefault(cadete => cadete.Id == IdCadete);

        if (cadete == null)
        {
            return "El ID ingresado no es valido";
        }
        
        return cadete.Nombre;
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

    public string PagarJornal(int IdCadete)
    {
        var CadeteBuscado = cadetes.FirstOrDefault(cadete => cadete.Id == IdCadete);

        if (CadeteBuscado == null)
        {
            return "Cadete no encontrado.";
        }

        return $"Pago cadete ID = {CadeteBuscado.Id}\n\tNombre = {CadeteBuscado.Nombre}\n\tPago = ${JornalACobrar(CadeteBuscado.Id)}";
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

    public float ObtenerCantidadPedidosEntregados(int IdCadete)
    {
        var CadeteBuscado = cadetes.FirstOrDefault(cadete => cadete.Id == IdCadete);
        if (CadeteBuscado == null)
        {
            return -1;
        }

        return JornalACobrar(IdCadete) / 500; 
    }

    public double ObtenerMontoGanado(int IdCadete)
    {
        var CadeteBuscado = cadetes.FirstOrDefault(cadete => cadete.Id == IdCadete);
        if (CadeteBuscado == null)
        {
            return -1; 
        }

        return JornalACobrar(IdCadete);
    }

    public double ObtenerPromedioEnvios()
    {
        return cadetes.Average(cadete => (JornalACobrar(cadete.Id) / 500));
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