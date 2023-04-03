using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAllEF();
            ML.Alumno alumno = new ML.Alumno();


            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
               
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de alumnos" + result.ErrorMessage;
            }

            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? idAlumno) 
        {
            //add o update
            if (idAlumno == null)
            {
                //add
                //mostrar formulario vacio
                return View();
            }
            
            else
            {
                //bl.alumno.getbyid(idAlumno)
                //update
                //muestra el formulario con la informacion del alumno
                
                return View();
            }

             
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            //add o update
            if (alumno.IdAlumno == 0)
            {
                //add
                result = BL.Alumno.AddEF(alumno);
               
            }
            else
            {

                //update
                result = BL.Alumno.Update(alumno);
            }

            return View();
        }


    }
}