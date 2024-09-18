using System.Text.Json;
public abstract class ManejoDeArchivos
{
    public abstract void LecturaDeArchivos(string NombreArchivo, List<string[]> ListaArreglo);
    public abstract void EscrituraDeArchivos(string NombreArchivo, List<string[]> ListaArreglo);
}


public class ArchivosCSV : ManejoDeArchivos
{
    public override void LecturaDeArchivos(string NombreArchivo, List<string[]> ListaArreglo)
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

    public override void EscrituraDeArchivos(string NombreArchivo, List<string[]> ListaArreglo)
    {
        using (StreamWriter escribir = new StreamWriter((NombreArchivo + ".csv"), false))
        {
            foreach (var datos in ListaArreglo)
            {
                escribir.WriteLine(string.Join(",", datos));
            }
        }
    }
}

public class ArchivosJson : ManejoDeArchivos
{
    // Leer archivo de texto y devolver su contenido
    public string AbrirArchivoTexto(string nombreArchivo)
    {
        string documento;
        using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
        }
        return documento;
    }

    // Guardar contenido de texto en un archivo
    public void GuardarArchivoTexto(string nombreArchivo, string datos)
    {
        using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
        {
            using (var strWriter = new StreamWriter(archivo))
            {
                strWriter.WriteLine("{0}", datos);
                strWriter.Close();
            }
        }
    }

    public override void LecturaDeArchivos(string nombreArchivo, List<string[]> listaArreglo)
    {
        string datosJson = AbrirArchivoTexto(nombreArchivo);

        List<string[]> listaDeserializada = JsonSerializer.Deserialize<List<string[]>>(datosJson);

        listaArreglo.AddRange(listaDeserializada);
    }

    public override void EscrituraDeArchivos(string nombreArchivo, List<string[]> listaArreglo)
    {
        string datosJson = JsonSerializer.Serialize(listaArreglo, new JsonSerializerOptions { WriteIndented = true });

        GuardarArchivoTexto(nombreArchivo, datosJson);
    }


}