using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseProfesor
{
     public class Profesor
    {
        private string nombre;
        private string especialidad;
        private List<Curso> cursos;

        public Profesor (string nombre, string especialidad)
        {
            this.nombre = nombre;
            this.especialidad = especialidad;
            cursos = new List<Curso>();
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

   

        public void agregarCursos(Curso curso)
        {
            cursos.Add(curso);
        }

        public List<string> mostrarCursos()
        {
            List<string> mostrarCursos = new List<string>();

            for (int i = 0; i < cursos.Count; i++)
            {
                mostrarCursos.Add(cursos[i].Nombre);
            }

            return mostrarCursos;
        }
    }
}
