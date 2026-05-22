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
    public Libro GetPrimero(List<Libro> libros)
    {
        return libros.FirstOrDefault();
    }

    public Libro GetUltimo(List<Libro> libros)
    {
        return libros.LastOrDefault();
    }

    public decimal GetTotalPrecios(List<Libro> libros)
    {
        return libros.Sum(l => l.Precio);
    }

    public double GetPromedioPrecios(List<Libro> libros)
    {
        return libros.Any() ? (double)libros.Average(l => l.Precio) : 0.0;
    }

    public List<Libro> GetListById(List<Libro> libros)
    {
        return libros.Where(l => l.Id > 15).ToList();
    }

    public List<string> GetLibros(List<Libro> libros)
    {
        return libros.Select(l => $"{l.Titulo} - {l.Precio:C}").ToList();
    }

    public Libro GetMayorPrecio(List<Libro> libros)
    {
        return libros.OrderByDescending(l => l.Precio).FirstOrDefault();
    }

    public Libro GetMenorPrecio(List<Libro> libros)
    {
        return libros.OrderBy(l => l.Precio).FirstOrDefault();
    }

    public List<Libro> GetMayorPromedio(List<Libro> libros)
    {
        if (!libros.Any()) return new List<Libro>();

        decimal promedio = libros.Average(l => l.Precio);
        return libros.Where(l => l.Precio > promedio).ToList();
    }

    public List<Libro> GetLibrosOrdenadosPorTituloDesc(List<Libro> libros)
    {
        return libros.OrderByDescending(l => l.Titulo).ToList();
    }
}
