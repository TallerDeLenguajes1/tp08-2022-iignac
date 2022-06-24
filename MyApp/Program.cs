// Console.WriteLine("Ingrese la ruta de una carpeta:");
// string path = Console.ReadLine();

string path = Directory.GetCurrentDirectory(); // ruta: C:\Taller1\TP08\tp08-2022-iignac\MyApp
string archivoCSV = path + @"\index.csv";       // ruta: C:\Taller1\TP08\tp08-2022-iignac\MyApp\index.csv
 
// creo el archivo index.csv en caso de que no exista
if (!File.Exists(archivoCSV))
{
    File.Create(archivoCSV);
}

// listo las subcarpetas y archivos que estan dentro del directorio path
List<string> listaCarpetas = Directory.GetDirectories(path).ToList(); 
List<string> listaArchivos = Directory.GetFiles(path).ToList();

// muestro las carpetas y archivos
Console.WriteLine("----- Carpetas -----");
foreach (string item in listaCarpetas)
{
    Console.WriteLine(item);
}
Console.WriteLine("\n----- Archivos -----");
foreach (string item in listaArchivos)
{
    Console.WriteLine(item);
}


// guardo el listado de archivos en index.csv
FileStream fs = new FileStream(archivoCSV, FileMode.Open);
StreamWriter sw = new StreamWriter(fs);

int i = 0;
sw.WriteLine("NRO;NOMBRE;EXTENSION");
foreach (string archivoX in listaArchivos)
{
    i++;
    FileInfo archivoXinfo = new FileInfo(archivoX);
    sw.WriteLine(i.ToString() + ";" + archivoXinfo.Name + ";" + archivoXinfo.Extension);
}
sw.Close();
fs.Close();