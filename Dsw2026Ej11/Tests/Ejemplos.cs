using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("=== PROBANDO CASO LIST ===");
        CasoList casoList = new CasoList();

        Alumno alu1 = new Alumno(45001, "Juan Perez", 7.5);
        Alumno alu2 = new Alumno(45002, "Maria Rodriguez", 9.2);
        Alumno alu3 = new Alumno(45003, "Lucas Gomez", 6.8);

        casoList.AgregarAlumno(alu1);
        casoList.AgregarAlumno(alu2);
        casoList.AgregarAlumno(alu3);

        Console.WriteLine("Lista de alumnos inicial:");
        foreach (var alu in casoList.ObtenerLista())
        {
            Console.WriteLine($"- {alu}");
        }

        Console.WriteLine("\nBuscando a 'Maria Rodriguez' (Existe):");
        Alumno encontradoExiste = casoList.BuscarPorNombre("Maria Rodriguez");
        if (encontradoExiste != null)
        {
            Console.WriteLine($"Encontrado -> {encontradoExiste}");
        }
        else
        {
            Console.WriteLine("No existe");
        }

        Console.WriteLine("\nBuscando a 'Carlos Tevez' (No existe):");
        Alumno encontradoNoExiste = casoList.BuscarPorNombre("Carlos Tevez");
        if (encontradoNoExiste != null)
        {
            Console.WriteLine($"Encontrado -> {encontradoNoExiste}");
        }
        else
        {
            Console.WriteLine("No existe");
        }

        Console.WriteLine("\nEliminando a 'Juan Perez'...");
        casoList.EliminarAlumno(alu1);
        Console.WriteLine("Lista tras eliminar un alumno:");
        foreach (var alu in casoList.ObtenerLista())
        {
            Console.WriteLine($"- {alu}");
        }

        Console.WriteLine("\nEliminando el primer elemento de la lista (Posición 0)...");
        casoList.EliminarEnPosicion(0);
        Console.WriteLine("Lista final de alumnos:");
        foreach (var alu in casoList.ObtenerLista())
        {
            Console.WriteLine($"- {alu}");
        }
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("=== PROBANDO CASO DICTIONARY ===");
        CasoDictionary casoDict = new CasoDictionary();

        Alumno alu1 = new Alumno(10001, "Lionel Messi", 10.0);
        Alumno alu2 = new Alumno(10002, "Angel Di Maria", 9.5);
        Alumno alu3 = new Alumno(10003, "Rodrigo De Paul", 7.2);

        casoDict.AgregarAlumno(alu1.Id, alu1);
        casoDict.AgregarAlumno(alu2.Id, alu2);
        casoDict.AgregarAlumno(alu3.Id, alu3);

        Console.WriteLine("Contenido del diccionario:");
        foreach (KeyValuePair<int, Alumno> entrada in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave [ID: {entrada.Key}] -> {entrada.Value}");
        }

        Console.WriteLine("\nBuscando alumno con ID 10002 (Existe):");
        Alumno buscadoExiste = casoDict.BuscarAlumno(10002);
        if (buscadoExiste != null)
        {
            Console.WriteLine($"Encontrado: {buscadoExiste}");
        }
        else
        {
            Console.WriteLine("No existe");
        }

        Console.WriteLine("\nBuscando alumno con ID 99999 (No existe):");
        Alumno buscadoNoExiste = casoDict.BuscarAlumno(99999);
        if (buscadoNoExiste != null)
        {
            Console.WriteLine($"Encontrado: {buscadoNoExiste}");
        }
        else
        {
            Console.WriteLine("No existe");
        }

        Console.WriteLine("\nEliminando al alumno con ID 10001...");
        casoDict.EliminarAlumno(10001);
        Console.WriteLine("Contenido del diccionario final:");
        foreach (KeyValuePair<int, Alumno> entrada in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave [ID: {entrada.Key}] -> {entrada.Value}");
        }
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("=== PROBANDO CASO LINQ ===");

        // Obtenemos los 30 libros reales del dominio
        List<Libro> listaLibros = Libro.CrearLista();

        // Instanciamos pasándole la lista al constructor tal como lo necesitás
        CasoLinq casoLinq = new CasoLinq(listaLibros);

        // Llamadas a cada método e impresión por consola
        Console.WriteLine($"1. Primer libro: {casoLinq.GetPrimero()?.Titulo ?? "N/A"}");
        Console.WriteLine($"2. Último libro: {casoLinq.GetUltimo()?.Titulo ?? "N/A"}");
        Console.WriteLine($"3. Suma de precios: {casoLinq.GetTotalPrecios():C}");
        Console.WriteLine($"4. Promedio de precios: {casoLinq.GetPromedioPrecios():C}");

        Console.WriteLine("\nLibros con Id > 15:");
        foreach (var libro in casoLinq.GetListById())
            Console.WriteLine($"   - {libro.Titulo} (Id: {libro.Id})");

        Console.WriteLine("\nLibros formato moneda:");
        foreach (var texto in casoLinq.GetLibros())
            Console.WriteLine($"   - {texto}");

        Console.WriteLine($"\nLibro con mayor precio: {casoLinq.GetMayorPrecio()?.Titulo} ({casoLinq.GetMayorPrecio()?.Precio:C})");
        Console.WriteLine($"8. Libro con menor precio: {casoLinq.GetMenorPrecio()?.Titulo} ({casoLinq.GetMenorPrecio()?.Precio:C})");

        Console.WriteLine("\nLibros con precio > promedio:");
        foreach (var libro in casoLinq.GetMayorPromedio())
            Console.WriteLine($"   - {libro.Titulo}");

        Console.WriteLine("\nLibros ordenados descendente:");
        foreach (var libro in casoLinq.GetLibrosOrdenados())
            Console.WriteLine($"   - {libro.Titulo}");
    }
}
