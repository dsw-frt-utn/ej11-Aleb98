using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{

    private readonly Dictionary<int, Alumno> _alumnos = new Dictionary<int, Alumno>();

    public void AgregarAlumno(int id, Alumno alumno)
    {
        if (!_alumnos.ContainsKey(id))
        {
            _alumnos.Add(id, alumno);
        }
        else
        {
            Console.WriteLine($"El alumno con ID {id} ya existe.");
        }
    }

    public Alumno BuscarAlumno(int id)
    {
        if (_alumnos.TryGetValue(id, out Alumno alumnoEncontrado))
        {
            return alumnoEncontrado;
        }
        return null;
    }

    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return _alumnos;
    }

    public bool EliminarAlumno(int id)
    {
        return _alumnos.Remove(id);
    }
}
