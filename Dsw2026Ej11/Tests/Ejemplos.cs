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
        CasoLinq casoLinq = new CasoLinq();

        List<Libro> listaLibros = Libro.CrearLista();
        Console.WriteLine($"Se procesarán {listaLibros.Count} libros usando consultas LINQ.\n");

        Console.WriteLine($"1. GetPrimero: {casoLinq.GetPrimero(listaLibros)?.Titulo}");
        Console.WriteLine($"2. GetUltimo: {casoLinq.GetUltimo(listaLibros)?.Titulo}");
        Console.WriteLine($"3. GetTotalPrecios: {casoLinq.GetTotalPrecios(listaLibros):C}");

        double promedio = casoLinq.GetPromedioPrecios(listaLibros);
        Console.WriteLine($"4. GetPromedioPrecios: {promedio:C}");

        Console.WriteLine("\n5. GetListById (Libros con ID > 15 - Muestra de los 3 primeros):");
        var porId = casoLinq.GetListById(listaLibros);
        for (int i = 0; i < Math.Min(3, porId.Count); i++)
        {
            Console.WriteLine($"   - [ID: {porId[i].Id}] {porId[i].Titulo}");
        }

        Console.WriteLine("\n6. GetLibros (Lista de strings en formato moneda - Primeros 3):");
        var formateados = casoLinq.GetLibros(listaLibros);
        for (int i = 0; i < Math.Min(3, formateados.Count); i++)
        {
            Console.WriteLine($"   - {formateados[i]}");
        }

        Console.WriteLine($"\n7. GetMayorPrecio: {casoLinq.GetMayorPrecio(listaLibros)?.Titulo} ({casoLinq.GetMayorPrecio(listaLibros)?.Precio:C})");
        Console.WriteLine($"8. GetMenorPrecio: {casoLinq.GetMenorPrecio(listaLibros)?.Titulo} ({casoLinq.GetMenorPrecio(listaLibros)?.Precio:C})");

        Console.WriteLine($"\n9. GetMayorPromedio (Libros caros que superan el promedio de {promedio:C} - Muestra de 3):");
        var mayorProm = casoLinq.GetMayorPromedio(listaLibros);
        for (int i = 0; i < Math.Min(3, mayorProm.Count); i++)
        {
            Console.WriteLine($"   - {mayorProm[i].Titulo} ({mayorProm[i].Precio:C})");
        }

        Console.WriteLine("\n10. Libros ordenados por título desc (Z a A - Muestra de 3):");
        var ordenados = casoLinq.GetLibrosOrdenadosPorTituloDesc(listaLibros);
        for (int i = 0; i < Math.Min(3, ordenados.Count); i++)
        {
            Console.WriteLine($"    - {ordenados[i].Titulo}");
        }
    }
}
