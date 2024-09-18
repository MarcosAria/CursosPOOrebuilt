using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseProfesor
{
   
    
        public class Operacion
        {
           
            public List<Alumno> Alumnos { get; private set; }
            public List<Curso> Cursos { get; private set; }
            public List<Profesor> Profesores { get; private set; }

            public Operacion()
            {
                Alumnos = new List<Alumno>();
                Cursos = new List<Curso>();
                Profesores = new List<Profesor>();
            }

            public void AgregarAlumno(Alumno alumno)
            {
                Alumnos.Add(alumno);
            }

            public void AgregarCurso(Curso curso)
            {
                Cursos.Add(curso);
            }

            public void AgregarProfesor(Profesor profesor)
            {
                Profesores.Add(profesor);
            }
        }

    }

