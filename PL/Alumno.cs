using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        //CRUD
        //Add
        public static void Add()
        {
            //Capa.Clase    objeto   new Clase();
            ML.Alumno alumno = new ML.Alumno();//instancia de mi clase alumno

            Console.WriteLine("Inserte el nombre del alumno: ");
            //objeto.propiedades
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Inserte el apellido paterno del alumno: ");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Inserte el apellido materno del alumno: ");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Inserte la fecha nacimiento del alumno: ");
            alumno.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Inserte el id del semestre: ");
            alumno.Semestre = new ML.Semestre();
            alumno.Semestre.IdSemestre = byte.Parse(Console.ReadLine());

            //Capa.Clase.Metodo(parametros);
            // ML.Result result = BL.Alumno.Add(alumno); //Query
           // ML.Result result = BL.Alumno.AddSP(alumno); //SP
           // ML.Result result = BL.Alumno.AddEF(alumno); //EF
            ML.Result result = BL.Alumno.AddLINQ(alumno); //EF

            if (result.Correct)
            {
                Console.WriteLine("Alumno insertado correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }




        }
        //Update
        public static void Update()
        {
            //Capa.Clase    objeto   new Clase();
            ML.Alumno alumno = new ML.Alumno();//instancia de mi clase alumno

            Console.WriteLine("Inserte el nombre del alumno: ");
            //objeto.propiedades
            alumno.IdAlumno = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserte el nombre del alumno: ");
            //objeto.propiedades
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Inserte el apellido paterno del alumno: ");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Inserte el apellido materno del alumno: ");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Inserte la fecha nacimiento del alumno: ");
            alumno.FechaNacimiento = Console.ReadLine();

            //Capa.Clase.Metodo(parametros);
            ML.Result result = BL.Alumno.Update(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Alumno actualizado correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }




        }
        //Delete    
        //GetAll
        public static void GetAll()
        {
            //ML.Result result = BL.Alumno.GetAll(); //SP
            //ML.Result result = BL.Alumno.GetAllEF(); //EF
            //ML.Result result = BL.Alumno.GetAllLINQ(); //LINQ
            ML.Result result = ML.Result();
            if (result.Correct)
            {
                foreach (ML.Alumno alumno in result.Objects)
                {
                    Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                    Console.WriteLine("Nombre: " + alumno.Nombre);
                    Console.WriteLine("Apellido Paterno: " + alumno.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + alumno.ApellidoMaterno);
                    Console.WriteLine("Fecha de nacimiento:" + alumno.FechaNacimiento);
                    Console.WriteLine("IdSemestre :" + alumno.Semestre.IdSemestre);
                    Console.WriteLine("Semestre :" + alumno.Semestre.Nombre);

                    Console.WriteLine("-----------------------------------------------");

                }

            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }
        //GetById
        public static void GetById()
        {
            Console.WriteLine("Ingrese el id del alumno: ");
            //objeto.propiedades
            int idAlumno = int.Parse(Console.ReadLine());

            ML.Result result = BL.Alumno.GetById(idAlumno);

            if (result.Correct)
            {

                ML.Alumno alumno = (ML.Alumno)result.Object;//

                

                Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                Console.WriteLine("Nombre: " + alumno.Nombre);
                Console.WriteLine("Apellido Paterno: " + alumno.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + alumno.ApellidoMaterno);
                Console.WriteLine("Fecha de nacimiento:" + alumno.FechaNacimiento);
                Console.WriteLine("-----------------------------------------------");



            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

    }
}
