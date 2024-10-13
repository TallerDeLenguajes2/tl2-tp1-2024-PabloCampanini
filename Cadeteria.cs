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

    public void DespedirCadete(int ID)
    {
        int controlExito = 0;

        while (controlExito == 0)
        {
            int controlID = 0;

            for (int i = 0; i < cadetes.Count; i++)
            {
                if (cadetes[i].Id == ID)
                {
                    cadetes.Remove(cadetes[i]);
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
    }

    public void AltaPedido(int NumeroPedido)
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


        pedidos.Add(NuevoPedido);
    }

    public int CadeteAleatorio()
    {
        return cadetes[rand.Next(0, cadetes.Count)].Id;
    }
    public bool AsignarCadeteAPedido(int IdCadete, int NumeroPedido)
    {
        bool controlAsignado = false;
        int controlID = 0;

        foreach (var cadete in cadetes)
        {
            if (cadete.Id == IdCadete)
            {
                controlID = 1;

                for (int i = 0; i < pedidos.Count; i++)
                {
                    if (NumeroPedido == pedidos[i].Numero)
                    {
                        pedidos[i].AsignarCadeteAPedido(cadete);

                        controlAsignado = true;

                        break;
                    }
                }

                break;
            }
        }

        if (controlAsignado)
        {
            Console.WriteLine("Pedido asignado correctamente");
        }
        else
        {
            if (controlID == 1)
            {
                Console.WriteLine("El numero de pedido ingresado no es correcto");
            }
            else
            {
                Console.WriteLine("El ID ingresado no corresponde a un cadete activo");
            }
        }

        return controlAsignado;
    }

    public float JornalACobrar(int IdCadete)
    {
        int contadorPedidos = 0;

        foreach (var pedido in pedidos)
        {
            if (IdCadete == pedido.CadeteAsignado.Id)
            {
                contadorPedidos++; ;
            }
        }

        return contadorPedidos * 500;   //En caso de que no se encuentre el ID buscado
    }

    public void PagarJornal()
    {
        foreach (var Cadete in cadetes)
        {
            Console.WriteLine($"\n\nPago cadete ID = {Cadete.Id} \n\t-----> Nombre = {Cadete.Nombre} *-----* Pago = ${JornalACobrar(Cadete.Id)}");
        }
    }

    public void CambiarEstadoPedido(int NumeroPedidoBuscado)
    {
        int control = 0;

        for (int i = 0; i < pedidos.Count; i++)
        {
            if (pedidos[i].Numero == NumeroPedidoBuscado)
            {
                pedidos[i].CadeteAsignado.CambiarEstadoPedido(pedidos[i]);

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

    public void ReasignarPedidos(int IdCadeteNuevo, int NumeroPedidoBuscado)
    {
        int controlReasignado = 0;
        int controlNumero = 0;

        foreach (var pedido in pedidos)
        {
            if (pedido.Numero == NumeroPedidoBuscado)
            {
                controlNumero = 1;

                foreach (var cadete in cadetes)
                {
                    if (cadete.Id == IdCadeteNuevo)
                    {
                        pedido.AsignarCadeteAPedido(cadete);

                        controlReasignado = 1;

                        break;
                    }
                }

                break;
            }
        }

        if (controlReasignado == 1)
        {
            Console.WriteLine("Pedido reasignado");
        }
        else
        {
            if (controlNumero == 0)
            {
                Console.WriteLine("El numero de pedido cargado no es correcto");
            }
            else
            {
                Console.WriteLine("El ID ingresado no pertenece a un cadete activo");
            }
        }
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

    public void MostrarDatosPedido(int NumeroPedidoBuscado)
    {
        foreach (var pedido in pedidos)
        {
            if (NumeroPedidoBuscado == pedido.Numero)
            {
                pedido.VerDatosCliente();
            }
        }
    }

    public List<string[]> DatosCadetes()
    {
        List<string[]> Datos = new List<string[]>();

        foreach (var cadete in cadetes)
        {
            string[] DatosCadetes = {cadete.Nombre, cadete.Direccion, cadete.Telefono};

            Datos.Add(DatosCadetes);
        }

        return Datos;
    }
}