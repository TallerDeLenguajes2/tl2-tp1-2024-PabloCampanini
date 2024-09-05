public class ManejoDeArchivos
{
    private List<string[]> listaArreglo;

    public List<string[]> ListaArreglo { get => listaArreglo; set => listaArreglo = value; }

    public void LecturaDeArchivos(string NombreArchivo)
    {
        using (StreamReader sr = new StreamReader(NombreArchivo + ".csv"))   //Cargo el archivo csv usando StreamReader
        {
            string Linea;

            while ((Linea = sr.ReadLine()) != null) //Leo linea por linea hasta el final del archivo
            {
                string[] Valores = Linea.Split(',');    //Separo los datos unidos por ','

                ListaArreglo.Add(Valores);
            }
        }
    }
}