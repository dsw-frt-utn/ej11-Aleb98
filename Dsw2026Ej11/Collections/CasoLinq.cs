using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{
    private readonly List<Libro> _libros;

    // Nuevo Constructor que recibe la lista de libros
    public CasoLinq(List<Libro> libros)
    {
        _libros = libros;
    }

    // 1. Retornar el primer elemento de la colección
    public Libro GetPrimero()
    {
        return _libros.FirstOrDefault();
    }

    // 2. Retornar el último elemento de la colección
    public Libro GetUltimo()
    {
        return _libros.LastOrDefault();
    }

    // 3. Retornar la suma de los precios de todos los libros
    public decimal GetTotalPrecios()
    {
        return _libros.Sum(l => l.Precio);
    }

    // 4. Retornar el promedio de los precios de todos los libros
    public double GetPromedioPrecios()
    {
        return _libros.Count > 0 ? (double)_libros.Average(l => l.Precio) : 0;
    }

    // 5. Retornar una lista de libros cuyo Id sea mayor a 15
    public List<Libro> GetListById()
    {
        return _libros.Where(l => l.Id > 15).ToList();
    }

    // 6. Retornar una lista de strings con el formato: "{Titulo} - {Precio:C}"
    public List<string> GetLibros()
    {
        return _libros.Select(l => $"{l.Titulo} - {l.Precio:C}").ToList();
    }

    // 7. Retornar el libro con el mayor precio
    public Libro GetMayorPrecio()
    {
        return _libros.OrderByDescending(l => l.Precio).FirstOrDefault();
    }

    // 8. Retornar el libro con el menor precio
    public Libro GetMenorPrecio()
    {
        return _libros.OrderBy(l => l.Precio).FirstOrDefault();
    }

    // 9. Retornar los libros cuyo precio sea mayor al promedio de precios de toda la colección
    public List<Libro> GetMayorPromedio()
    {
        decimal promedio = _libros.Count > 0 ? _libros.Average(l => l.Precio) : 0;
        return _libros.Where(l => l.Precio > promedio).ToList();
    }

    // 10. Retornar los libros ordenados por Título de forma descendente
    public List<Libro> GetLibrosOrdenados()
    {
        return _libros.OrderByDescending(l => l.Titulo).ToList();
    }
}
