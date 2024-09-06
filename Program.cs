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

Pedido NuevoPedido = null;

archivosCSV.LecturaDeArchivos(ArchivoCadetes, ListaDatosCadetes);
archivosCSV.LecturaDeArchivos(ArchivoCadeteria, ListaDatosCadeteria);

foreach (var arregloDatos in ListaDatosCadetes)
{
    Cadete cadete = new Cadete();

    cadete.Id = ID;
    cadete.Nombre = arregloDatos[0].Trim();
    cadete.Direccion = arregloDatos[1].Trim();
    cadete.Telefono = arregloDatos[2].Trim();

    cadeteria.Cadetes.Add(cadete);

    ID++;
}

foreach (var arregloDatos in ListaDatosCadeteria)
{
    cadeteria.Nombre = arregloDatos[0];
    cadeteria.Telefono = arregloDatos[1];
}

Console.WriteLine("\n\n\t\t*----- MENU CADETERIA -----*\n\n");

Console.WriteLine("BIENVENIDO CADETERIA MOTOEXPRESS: ");


while (!ControlMenu)
{

    Console.WriteLine("\n\t1 - Dar alta pedido\n\t2 - Asignar pedido a cadete");
    Console.WriteLine("\n\t3 - Cambiar estado de pedido\n\t4 - Reasignar pedido a otro cadete\n\n\t5 - Salir");

    Console.WriteLine($"Elija la operacion que quiere realizar: {Menu = Console.ReadLine()}");

    switch (Menu)
    {
        case "1":
            NuevoPedido = cadeteria.AltaPedido(NumeroPedido);
            NumeroPedido++;
            break;
        case "2":
            if (NuevoPedido != null)
            {
                cadeteria.AsignarPedido(NuevoPedido);
            }
            else
            {
                Console.WriteLine("Debe dar de alta un pedido antes de asignarlo.");
            }
            break;
        case "3":
            
            break;
        case "4":

            break;
        case "5":

            ControlMenu = true;
            break;
        default:
            Console.WriteLine("Ingrese un dato valido");
            break;
    }
}