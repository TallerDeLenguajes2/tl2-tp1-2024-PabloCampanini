// See https://aka.ms/new-console-template for more information

Cadeteria cadeteria = new Cadeteria();
ManejoDeArchivos archivos = null;

string ArchivoCadetes = "";
string ArchivoCadeteria = "";

List<string[]> ListaDatosCadetes = new List<string[]>();
List<string[]> ListaDatosCadeteria = new List<string[]>();

int ID = 10;
int NumeroPedido = 999;

string Menu;
bool ControlMenu = false;
string FormatoArchivos;
bool ControlFormato = false;

//Datos de pedidos
string ObservacionPedido;
string NombreCliente;
string DireccionCliente;
string TelefonoCliente;
string ReferenciaDireccion;


while (!ControlFormato)
{
    Console.Write("\n\nAcceso de datos a usar 0: CSV, 1: JSON\n Seleccione uno: ");
    FormatoArchivos = Console.ReadLine();

    if (int.TryParse(FormatoArchivos, out int Formato))
    {
        if (Formato == 0)
        {
            archivos = new ArchivosCSV();

            ArchivoCadeteria = @"ArchivosCSV\DatosCadeteria.csv";
            ArchivoCadetes = @"ArchivosCSV\DatosCadetes.csv";

            archivos.LecturaDeArchivos(ArchivoCadeteria, ListaDatosCadeteria);
            archivos.LecturaDeArchivos(ArchivoCadetes, ListaDatosCadetes);

            ControlFormato = true;
        }
        else
        {
            if (Formato == 1)
            {
                archivos = new ArchivosJson();

                ArchivoCadeteria = @"ArchivosJSON\DatosCadeteria.json";
                ArchivoCadetes = @"ArchivosJSON\DatosCadetes.json";

                archivos.LecturaDeArchivos(ArchivoCadeteria, ListaDatosCadeteria);
                archivos.LecturaDeArchivos(ArchivoCadetes, ListaDatosCadetes);

                ControlFormato = true;
            }
            else
            {
                Console.WriteLine("Debe ingresar un dato valido, 0 o 1");
            }
        }
    }
    else
    {
        Console.WriteLine("Debe ingresar un valor numerico");
    }
}

foreach (var arregloDatos in ListaDatosCadetes)
{
    Cadete cadete = new Cadete();

    cadete.Id = ID;
    cadete.Nombre = arregloDatos[0].Trim();
    cadete.Direccion = arregloDatos[1].Trim();
    cadete.Telefono = arregloDatos[2].Trim();

    cadeteria.ContratarCadete(cadete);

    ID++;
}

foreach (var arregloDatos in ListaDatosCadeteria)
{
    cadeteria.Nombre = arregloDatos[0];
    cadeteria.Telefono = arregloDatos[1];
}

Console.WriteLine("\n\n\t\t*----- MENU CADETERIA -----*\n\n");

Console.WriteLine($"BIENVENIDO CADETERIA {cadeteria.Nombre}: ");


while (!ControlMenu)
{
    Console.WriteLine("\n\t1 - Dar alta pedido\n\t2 - Mostrar Lista de Pedidos");
    Console.WriteLine("\t3 - Cambiar estado de pedido\n\t4 - Reasignar pedido a otro cadete\n\t5 - Pagar cadetes");
    Console.WriteLine("\t6 - Despedir cadete\n\n\t7 - Salir");

    Console.Write("Elija la operacion que quiere realizar: ");
    Menu = Console.ReadLine();

    switch (Menu)
    {
        case "1":
            Console.Write($"\nIngrese los datos del pedido numero: {NumeroPedido}");

            Console.Write("\n\tObservaciones del pedido: ");
            ObservacionPedido = Console.ReadLine();

            Console.Write("\nIngrese los datos del cliente: ");
            Console.Write("\n\tNombre: ");
            NombreCliente = Console.ReadLine();

            Console.Write("\n\tDireccion: ");
            DireccionCliente = Console.ReadLine();

            Console.Write("\n\tTelefono: ");
            TelefonoCliente = Console.ReadLine();

            Console.Write("\n\tReferencias al domicilio: ");
            ReferenciaDireccion = Console.ReadLine();

            cadeteria.AltaPedido(NumeroPedido, ObservacionPedido, NombreCliente, DireccionCliente, TelefonoCliente, ReferenciaDireccion);
            NumeroPedido++;
            cadeteria.AsignarCadeteAPedido(cadeteria.CadeteAleatorio(), NumeroPedido);
            break;
        case "2":
            string mostrarPedido;
            Console.Write("Ingrese el numero de pedido: ");
            mostrarPedido = Console.ReadLine();

            if (int.TryParse(mostrarPedido, out int NumeroPedidoBuscado))
            {
                if (!cadeteria.MostrarDatosPedido(NumeroPedidoBuscado))
                {
                    Console.WriteLine("El numero de pedido ingresado no existe");
                }
            }
            break;
        case "3":
            string cambiarEstado;
            Console.Write("Ingrese el numero de pedido: ");
            cambiarEstado = Console.ReadLine();

            if (int.TryParse(cambiarEstado, out int PedidoDebeCambiar))
            {
                if (!cadeteria.CambiarEstadoPedido(PedidoDebeCambiar))
                {
                    Console.WriteLine("El numero de pedido ingresado no existe");
                }
            }
            break;
        case "4":
            string reasignarPedido;
            Console.Write("Ingrese el numero de pedido: ");
            reasignarPedido = Console.ReadLine();

            if (int.TryParse(reasignarPedido, out int PedidoParaReasignar))
            {
                if (!cadeteria.ReasignarPedidos(cadeteria.CadeteAleatorio(), PedidoParaReasignar))
                {
                    Console.WriteLine("El numero de pedido ingresado no existe");
                }
            }
            break;
        case "5":
            int cadete = 10;

            for (int i = 0; i < cadeteria.CantidadCadetes(); i++)
            {
                Console.WriteLine(cadeteria.PagarJornal(cadete));
                cadete++;
            }
            break;
        case "6":
            int ControlCargaID = 0;

            while (ControlCargaID == 0)
            {
                Console.Write("Ingrese el ID del cadete que quiere despedir: ");
                string cargaID = Console.ReadLine();

                if (int.TryParse(cargaID, out int IdBorrar))
                {
                    if (!cadeteria.DespedirCadete(IdBorrar))
                    {
                        Console.WriteLine("El ID ingresado no existe");
                    }
                    else
                    {
                        ControlCargaID = 1;
                    }
                }
                else
                {
                    Console.WriteLine("El valor ingresado no corresponde a un numero");
                }
            }
            break;
        case "7":
            Console.WriteLine(cadeteria.ObtenerPromedioEnvios());

            cadete = 10;

            ListaDatosCadetes.Clear();

            for (int i = 0; i < cadeteria.CantidadCadetes(); i++)
            {
                Console.WriteLine("Cadete: " + cadeteria.NombreCadete(cadete));

                Console.WriteLine("Pedidos entregados: " + cadeteria.ObtenerCantidadPedidosEntregados(cadete));
                Console.WriteLine("Total ganado: $" + cadeteria.ObtenerMontoGanado(cadete));

                string[] DatosCadete = cadeteria.DatosCadete(i).Split(',');

                ListaDatosCadetes.Add(DatosCadete);

                cadete++;
            }

            archivos.EscrituraDeArchivos(ArchivoCadetes, ListaDatosCadetes);
            ControlMenu = true;
            break;
        default:
            Console.WriteLine("Ingrese un dato valido");
            break;
    }
}