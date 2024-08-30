
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

}