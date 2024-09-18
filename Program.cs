// See https://aka.ms/new-console-template for more information

Cadeteria cadeteria = new Cadeteria();

ManejoDeArchivos archivosCSV = new ManejoDeArchivos();

string ArchivoCadetes = "DatosCadetes";
string ArchivoCadeteria = "DatosCadeteria";

List<string[]> ListaDatosCadetes = new List<string[]>();
List<string[]> ListaDatosCadeteria = new List<string[]>();

int ID = 10;
int NumeroPedido = 999;

string Menu;
bool ControlMenu = false;

archivosCSV.LecturaDeArchivos(ArchivoCadetes, ListaDatosCadetes);
archivosCSV.LecturaDeArchivos(ArchivoCadeteria, ListaDatosCadeteria);

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
            cadeteria.AltaPedido(NumeroPedido);
            NumeroPedido++;
            cadeteria.AsignarCadeteAPedido(cadeteria.CadeteAleatorio(), NumeroPedido);
            break;
        case "2":
            string mostrarPedido;
            Console.Write("Ingrese el numero de pedido: ");
            mostrarPedido = Console.ReadLine();

            if (int.TryParse(mostrarPedido, out int NumeroPedidoBuscado))
            {
                cadeteria.MostrarDatosPedido(NumeroPedidoBuscado);
            }
            break;
        case "3":
            string cambiarEstado;
            Console.Write("Ingrese el numero de pedido: ");
            cambiarEstado = Console.ReadLine();

            if (int.TryParse(cambiarEstado, out int PedidoDebeCambiar))
            {
                cadeteria.CambiarEstadoPedido(PedidoDebeCambiar);
            }
            break;
        case "4":
            string reasignarPedido;
            Console.Write("Ingrese el numero de pedido: ");
            reasignarPedido = Console.ReadLine();

            if (int.TryParse(reasignarPedido, out int PedidoParaReasignar))
            {
                cadeteria.ReasignarPedidos(cadeteria.CadeteAleatorio(), PedidoParaReasignar);
            }
            break;
        case "5":
            cadeteria.PagarJornal();
            break;
        case "6":
            int ControlCargaID = 0;

            while (ControlCargaID == 0)
            {
                Console.Write("Ingrese el ID del cadete que quiere despedir: ");
                string cargaID = Console.ReadLine();

                if (int.TryParse(cargaID, out int IdBorrar))
                {
                    cadeteria.DespedirCadete(IdBorrar);

                    ControlCargaID = 1;
                }
                else
                {
                    Console.WriteLine("El valor ingresado no corresponde a un numero");
                }
            }
            break;
        case "7":
            cadeteria.GenerarInforme();
            ControlMenu = true;
            break;
        default:
            Console.WriteLine("Ingrese un dato valido");
            break;
    }
}