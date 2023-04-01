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

        public ActionResult Form(int? idAlumno) 
        {
            //add o actualizar 
            if (idAlumno == null)
            {
                //add
            }
            else 
            {
                //getbyid(idAlumno)
                //actualizar

            }
            return View();
        }
    }
}