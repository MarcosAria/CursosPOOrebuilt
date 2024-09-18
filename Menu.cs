using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseProfesor
{

    

    
    public class Menu
    {
        private Operacion operacion;
        private List<Opcion> opciones;

        public Menu(Operacion operacion)
        {
            this.operacion = operacion;

            opciones = new List<Opcion>()
        {
            new Opcion("Agregar Alumno", AgregarAlumno),
            new Opcion("Agregar Curso", AgregarCurso),
            new Opcion("Agregar Profesor", AgregarProfesor),
            new Opcion("Asignar Alumno a Curso", AsignarAlumnoACurso),
            new Opcion("Asignar Profesor a Curso", AsignarProfesorACurso),
            new Opcion("Mostrar Cursos", MostrarCursos),
            new Opcion("Salir", () => Environment.Exit(0))
        };

            while (true)
            {
                MostrarMenu();
                SeleccionarOpcion();
            }
        }

        public void MostrarMenu()
        {
            Console.Clear();
            foreach (Opcion opcion in opciones)
            {
                Console.WriteLine($"{opciones.IndexOf(opcion)}. {opcion.Message}");
            }
            Console.Write("Seleccione una opción: ");
        }

        public void SeleccionarOpcion()
        {
            if (int.TryParse(Console.ReadLine(), out int numOpcion) && numOpcion >= 0 && numOpcion < opciones.Count)
            {
                Console.Clear();
                opciones[numOpcion].Action.Invoke();
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                Console.ReadKey();
            }
        }

      
        private void AgregarAlumno()
        {
            Console.Write("Ingrese el nombre del alumno: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la edad del alumno: ");
            int edad = int.Parse(Console.ReadLine());

            operacion.AgregarAlumno(new Alumno(nombre, edad));
            Console.WriteLine($"Alumno '{nombre}' agregado exitosamente.");
            Console.ReadKey();
        }

        private void AgregarProfesor()
        {
            Console.Write("Ingrese el nombre del Profesor: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la especialidad del Profesor: ");
            string especialidad = Console.ReadLine();

            operacion.AgregarProfesor(new Profesor(nombre, especialidad));
            Console.WriteLine($"Alumno '{nombre}' agregado exitosamente.");
            Console.ReadKey();
        }

        private void AgregarCurso()
        {
            Console.Write("Ingrese el nombre del curso: ");
            string nombre = Console.ReadLine();

            operacion.AgregarCurso(new Curso(nombre));
            Console.WriteLine($"Curso '{nombre}' agregado exitosamente.");
            Console.ReadKey();
        }

        
        private void AsignarAlumnoACurso()
        {
            Console.WriteLine("\n--- Asignar Alumno a Curso ---");
            if (operacion.Alumnos.Count == 0 || operacion.Cursos.Count == 0)
            {
                Console.WriteLine("No hay alumnos o cursos disponibles.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Seleccione un alumno:");
            for (int i = 0; i < operacion.Alumnos.Count; i++)
            {
                Console.WriteLine($"{i}. {operacion.Alumnos[i].Nombre}");
            }
            int alumnoIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione un curso:");
            for (int i = 0; i < operacion.Cursos.Count; i++)
            {
                Console.WriteLine($"{i}. {operacion.Cursos[i].Nombre}");
            }
            int cursoIndex = int.Parse(Console.ReadLine());

            operacion.Cursos[cursoIndex].AgregarAlumno(operacion.Alumnos[alumnoIndex]);
            Console.WriteLine($"Alumno '{operacion.Alumnos[alumnoIndex].Nombre}' asignado al curso '{operacion.Cursos[cursoIndex].Nombre}'.");
            Console.ReadKey();
        }

        
        private void AsignarProfesorACurso()
        {
            Console.WriteLine("\n--- Asignar Profesor a Curso ---");
            if (operacion.Profesores.Count == 0 || operacion.Cursos.Count == 0)
            {
                Console.WriteLine("No hay profesores o cursos disponibles.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Seleccione un profesor:");
            for (int i = 0; i < operacion.Profesores.Count; i++)
            {
                Console.WriteLine($"{i}. {operacion.Profesores[i].Nombre}");
            }
            int profesorIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione un curso:");
            for (int i = 0; i < operacion.Cursos.Count; i++)
            {
                Console.WriteLine($"{i}. {operacion.Cursos[i].Nombre}");
            }
            int cursoIndex = int.Parse(Console.ReadLine());

            operacion.Cursos[cursoIndex].AsignarProfesor(operacion.Profesores[profesorIndex]);
            Console.WriteLine($"Profesor '{operacion.Profesores[profesorIndex].Nombre}' asignado al curso '{operacion.Cursos[cursoIndex].Nombre}'.");
            Console.ReadKey();
        }


           
            
            private void MostrarCursos()
            {
                Console.WriteLine("\n--- Cursos ---");

                if (operacion.Cursos == null || operacion.Cursos.Count == 0)
                {
                    Console.WriteLine("No hay cursos disponibles.");
                }
                else
                {
                    foreach (var curso in operacion.Cursos)
                    {
                        Console.WriteLine($"Curso: {curso.Nombre}");

                        // Verificar si el profesor está asignado
                        if (curso.Profesor != null)
                        {
                            Console.WriteLine($"Profesor: {curso.Profesor.Nombre}");
                        }
                        else
                        {
                            Console.WriteLine("Profesor: Sin asignar");
                        }

                        // Verificar si la lista de alumnos está disponible
                        var alumnos = curso.ObtenerAlumnosInscritos();
                        if (alumnos != null && alumnos.Count > 0)
                        {
                            Console.WriteLine("Alumnos inscritos:");
                            foreach (var alumno in alumnos)
                            {
                                Console.WriteLine($"- {alumno.Nombre}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay alumnos inscritos.");
                        }

                        Console.WriteLine();
                    }
                }
                Console.ReadKey();
            }

        }

    }
    


