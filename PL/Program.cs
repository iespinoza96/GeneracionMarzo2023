using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hola, por favor seleccione una opcion: \n1.-Agregar alumno \n2.-Actualizar alumno \n3.-Eliminar alumno \n4.-Mostrar alumnos \n5.-Mostrar un alumno");
            int opcion =int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    //Capa.Clase.Metodo();
                    PL.Alumno.Add();
                    break;
                case 2:
                    //Capa.Clase.Metodo();
                    PL.Alumno.Update();
                    break;
                case 3:
                    //Capa.Clase.Metodo();
                    //PL.Alumno.Delete();
                    break;
                case 4:
                    //Capa.Clase.Metodo();
                    //PL.Alumno.GetAll();
                    break;
                case 5:
                    //Capa.Clase.Metodo();
                   // PL.Alumno.GetById();
                    break;
                default:
                    break;
            }
            
        }
    }
}
