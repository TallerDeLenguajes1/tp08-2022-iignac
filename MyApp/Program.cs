// Console.WriteLine("Ingrese la ruta de una carpeta:");
// string path = Console.ReadLine();

string path = Directory.GetCurrentDirectory(); // ruta: C:\Taller1\TP08\tp08-2022-iignac\MyApp
string archivoCSV = path + @"\index.csv";      // ruta: C:\Taller1\TP08\tp08-2022-iignac\MyApp\index.csv
 
// creo el archivo index.csv en caso de que no exista
if (!File.Exists(archivoCSV))
{
    File.Create(archivoCSV);
}

// listo las carpetas y archivos que estan dentro del directorio path
List<string> listaCarpetas = Directory.GetDirectories(path).ToList(); 
List<string> listaArchivos = Directory.GetFiles(path).ToList();

// muestro las carpetas y archivos
Console.WriteLine("----- Carpetas -----");
foreach (string carpetaX in listaCarpetas)
{
    DirectoryInfo carpetaXinfo = new DirectoryInfo(carpetaX);
    Console.WriteLine(carpetaXinfo.Name);
}
Console.WriteLine("\n----- Archivos -----");
foreach (string archivoX in listaArchivos)
{
    Console.WriteLine(Path.GetFileNameWithoutExtension(archivoX));
}


// guardo el listado de archivos en index.csv
FileStream fs = new FileStream(archivoCSV, FileMode.Open);
StreamWriter sw = new StreamWriter(fs);
int i = 0;
sw.WriteLine("NRO;NOMBRE;EXTENSION");
foreach (string archivoX in listaArchivos)
{
    i++;
    FileInfo archivoXinfo = new FileInfo(archivoX); // creo un objeto FileInfo para obterner la extensión del archivo
    sw.WriteLine(i.ToString() + ";" + Path.GetFileNameWithoutExtension(archivoX) + ";" + archivoXinfo.Extension);
}
sw.Close();
fs.Close();