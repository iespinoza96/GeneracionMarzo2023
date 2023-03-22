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
            alumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());

          //Capa.Clase.Metodo(parametros);
           ML.Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Alumno insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage); 
            }




        }
        //Update
        //Delete    
        //GetAll
        //GetById

    }
}
