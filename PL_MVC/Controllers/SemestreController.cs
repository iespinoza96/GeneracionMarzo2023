using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Views
{
    public class SemestreController : Controller
    {
        // GET: Semestre
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Semestre.GetAll();
            ML.Semestre semestre = new ML.Semestre();
            
            //instaciamos al servicio
            ServiceReferenceSemestre.SemestreClient servicioSemestre = new ServiceReferenceSemestre.SemestreClient();
            //mandamos a llamar al servicio
            var result = servicioSemestre.GetAll();

            if (result.Correct)
            {
                semestre.Semestres = result.Objects.ToList();
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al consultar la información";
                return View();
            }

            return View(semestre);
        }
    }
}