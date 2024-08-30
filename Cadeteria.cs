
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;

    
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

    public Cadeteria()
    {
        Cadetes = new List<Cadete>();
    }

    public void ContratarCadete(Cadete NuevoCadete)
    {
        Cadetes.Add(NuevoCadete);
    }

    public void DespedirCadete(int ID)
    {
        foreach (var Cadete in Cadetes)
        {   
            if (Cadete.Id == ID)
            {
                Cadetes.Remove(Cadete);
            }
            
        }
    }

    public void PagarJornal()
    {
        foreach (var Cadete in Cadetes)
        {
            Console.WriteLine($"Pago cadete ID = {Cadete.Id} -----> Nombre = {Cadete.Nombre} *-----* Pago = ${Cadete.JornalACobrar()}");
        }
    }
}