public class ManejoDeArchivos
{
    public void LecturaDeArchivos(string NombreArchivo, List<string[]> ListaArreglo)
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