using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseProfesor
{


    public class Alumno
    {

        private string nombre;
        private int edad;
        private List<Curso> cursosInscritos;


        public Alumno(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
            cursosInscritos = new List<Curso>();
        }

        public string Nombre { get {  return nombre; } }
        public int Edad { get {  return edad; } }

        public List<Curso> Cursos { get {  return cursosInscritos; } }

        public void inscribirCurso(Curso curso)
        {
            cursosInscritos.Add(curso);
        }




    }
}

    

