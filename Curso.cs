using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseProfesor
{
    public class Curso
    {
        private string nombre;
        private Profesor profesorACargo;
        private List<Alumno> alumnosInscritos;

        // Constructor privado para evitar la creación directa de objetos
        public Curso(string nombre)
        {
            this.nombre = nombre;
            alumnosInscritos = new List<Alumno>();
        }

        // Método público para crear una instancia de Curso
        public static Curso CrearCurso(string nombre)
        {
            return new Curso(nombre);
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
            
        }
        // Método para asignar un profesor al curso
        public void AsignarProfesor(Profesor profesor)
        {
            // Verificar si el profesor no es nulo
            if (profesor != null)
            {
                // Asignar el profesor al curso
                profesorACargo = profesor;

                // Agregar el curso a la lista de cursos a cargo del profesor
                profesor.agregarCursos(this);
            }
        }

        // Método para agregar un alumno al curso
        public void AgregarAlumno(Alumno alumno)
        {
            // Verificar si el alumno no es nulo y no está inscrito en el curso
            if (alumno != null && !alumnosInscritos.Contains(alumno))
            {
                // Agregar el alumno a la lista de alumnos inscritos en el curso
                alumnosInscritos.Add(alumno);

                // Agregar el curso a la lista de cursos inscritos del alumno
                alumno.inscribirCurso(this);
            }
        }

        // Método para obtener una lista de alumnos inscritos en el curso (solo lectura)
        public IReadOnlyList<Alumno> ObtenerAlumnosInscritos()
        {
            return alumnosInscritos.AsReadOnly();
        }

        // Método para obtener el profesor a cargo del curso (solo lectura)
        public Profesor Profesor
        {
            get { return profesorACargo; }
        }
    }
}
