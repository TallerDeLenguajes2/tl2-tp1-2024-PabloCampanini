
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
        int controlExito = 0;

        while (controlExito == 0)
        {
            int controlID = 0;
    
            foreach (var Cadete in cadetes)
            {
                if (Cadete.Id == ID)
                {
                    cadetes.Remove(Cadete);
                    controlID = 1;
                }
            }
    
            if (controlID == 1)
            {
                Console.WriteLine("Cadete borrado con exito");

                controlExito = 1;
            }
            else
            {
                Console.WriteLine("El ID ingresado no pertenece a un cadete activo");
            }
        }

        List<string[]> DatosCadetes = new List<string[]>();

        foreach (var Cadete in cadetes)
        {
            string[] Datos = {Cadete.Nombre, Cadete.Direccion, Cadete.Telefono};

            DatosCadetes.Add(Datos);
        }
    }

    public void PagarJornal()
    {
        foreach (var Cadete in cadetes)
        {
            Console.WriteLine($"\n\nPago cadete ID = {Cadete.Id} \n\t-----> Nombre = {Cadete.Nombre} *-----* Pago = ${Cadete.JornalACobrar()}");
        }
    }

    public Pedido AltaPedido(int NumeroPedido)
    {
        Pedido NuevoPedido = new Pedido();

        NuevoPedido.Numero = NumeroPedido;

        Console.Write($"\nIngrese los datos del pedido numero: {NuevoPedido.Numero}");


        Console.Write("\n\tObservaciones del pedido: ");
        NuevoPedido.Observacion = Console.ReadLine();

        Console.Write("\nIngrese los datos del cliente: ");
        Console.Write("\n\tNombre: ");
        NuevoPedido.Cliente.Nombre = Console.ReadLine();

        Console.Write("\n\tDireccion: ");
        NuevoPedido.Cliente.Direccion = Console.ReadLine();

        Console.Write("\n\tTelefono: ");
        NuevoPedido.Cliente.Telefono = Console.ReadLine();

        Console.Write("\n\tReferencias al domicilio: ");
        NuevoPedido.Cliente.DatosReferenciaDireccion = Console.ReadLine();


        return NuevoPedido;
    }

    public void AsignarPedido(Pedido PedidoParaAsignar)
    {
        int IdAleatorio = random.Next(10, 10 + cadetes.Count);

        foreach (var cadete in cadetes)
        {
            if (cadete.Id == IdAleatorio)
            {
                cadete.TomarPedido(PedidoParaAsignar);
            }
        }
    }

    public void CambiarEstadoPedido(int NumeroPedidoBuscado)
    {
        int control = 0;

        foreach (var cadete in cadetes)
        {
            if (cadete.CambiarEstadoPedido(NumeroPedidoBuscado))
            {
                control = 1;

                break;
            }
        }

        if (control == 1)
        {
            Console.WriteLine("Cambiado con exito");
        }
        else
        {
            Console.WriteLine("El numero de pedido cargado no es correcto");
        }
    }

    public void ReasignarPedidos(int NumeroPedidoBuscado)
    {
        int control = 0;
        Pedido MoverPedido = null;

        foreach (var cadete in cadetes)
        {
            MoverPedido = cadete.ReasignarPedidos(NumeroPedidoBuscado);

            if (MoverPedido != null)
            {
                control = 1;

                break;
            }
        }

        if (control == 1)
        {
            AsignarPedido(MoverPedido);

            Console.WriteLine("Pedido reasignado");
        }
        else
        {
            Console.WriteLine("El numero de pedido cargado no es correcto");
        }
    }

    public void GenerarInforme()
    {
        // Total de envíos por cadete y monto total ganado
        var informe = cadetes.Select(cadete => new
        {
            Cadete = cadete.Nombre,
            CantidadPedidosEntregados = (cadete.JornalACobrar()) / 500,
            MontoGanado = cadete.JornalACobrar()
        });

        // Mostrar el informe de cada cadete
        foreach (var item in informe)
        {
            Console.WriteLine($"Cadete: {item.Cadete}, Pedidos Entregados: {item.CantidadPedidosEntregados}, Monto Ganado: {item.MontoGanado}");
        }

        // Calcular el promedio de envíos por cadete
        double promedioEnvios = cadetes.Average(cadete => ((cadete.JornalACobrar()) / 500));
        Console.WriteLine($"\nPromedio de envíos por cadete: {promedioEnvios}");
    }

    public void MostrarDatosPedido()
    {
        foreach (var cadete in cadetes)
        {
            cadete.MostrarDatosPedido();
        }
    }
}