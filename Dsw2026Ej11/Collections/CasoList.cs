using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un campo que represente una lista de alumnos (List<>)
//Incluir un método para agregar alumnos a la lista
//Incluir un método para retornar la lista
//Incluir un método para buscar un alumno por nombre
//Incluir un método para eliminar un alumno (debe recibir un alumno)
//Incluir un método para eliminar un alumno en una determinada posición de la lista
public class CasoList
{
    private readonly List<Alumno> _alumnos = new List<Alumno>();

    public void AgregarAlumno(Alumno alumno)
    {
        if (alumno == null)
        {
            throw new ArgumentNullException(nameof(alumno), "El alumno no puede ser nulo.");
        }
        _alumnos.Add(alumno);
    }

    public List<Alumno> ObtenerLista()
    {
        return _alumnos;
    }

    public Alumno BuscarPorNombre(string nombre)
    {
        return _alumnos.FirstOrDefault(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public bool EliminarAlumno(Alumno alumno)
    {
        return _alumnos.Remove(alumno);
    }

    public void EliminarEnPosicion(int posicion)
    {
        if (posicion >= 0 && posicion < _alumnos.Count)
        {
            _alumnos.RemoveAt(posicion);
        }
        else
        {
            Console.WriteLine($"Error: La posición {posicion} está fuera de rango. Rango válido: 0 a {_alumnos.Count - 1}.");
        }
    }
}
