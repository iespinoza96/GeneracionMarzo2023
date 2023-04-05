﻿using System;
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
            ML.Result resultSemestres = BL.Semestre.GetAll();
            ML.Result resultPlanteles = BL.Plantel.GetAll();

            ML.Alumno alumno = new ML.Alumno();
            alumno.Semestre = new ML.Semestre();

            alumno.Horario = new ML.Horario();
            alumno.Horario.Grupo = new ML.Grupo();
            alumno.Horario.Grupo.Plantel = new ML.Plantel();

            if (resultSemestres.Correct)
            {
               alumno.Semestre.Semestres = resultSemestres.Objects;
               alumno.Horario.Grupo.Plantel.Planteles = resultPlanteles.Objects;
            }
            //add o update
            if (idAlumno == null)
            {
                //add
                //mostrar formulario vacio
                return View(alumno);
            }
            
            else
            {
                //bl.alumno.getbyid(idAlumno.value)
                ML.Result result = BL.Alumno.GetByIdEF(idAlumno.Value);

                if (result.Correct)
                {
                    //update
                    //muestra el formulario con la informacion del alumno
                    alumno = (ML.Alumno)result.Object;
                    alumno.Semestre.Semestres = resultSemestres.Objects;
                    return View(alumno);

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta del alumno " + result.ErrorMessage;
                    return View("Modal");
                }
                
                
            }


             
        }

        [HttpPost] //va a recibir la informacion que venga desde la vista  
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            //add o update
            if (alumno.IdAlumno == 0)
            {
                //add
                result = BL.Alumno.AddEF(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente el alumno";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el alumno" + result.ErrorMessage;
                }
               
            }
            else
            {

                //update
                result = BL.Alumno.UpdateEF(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el registro del alumno";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro del alumno" + result.ErrorMessage;
                }
            }

            return View("Modal");
        }

        public JsonResult GetGrupo(int idPlantel)
        {
            var result = BL.Grupo.GetByIdPlantel(idPlantel);

            return Json(result.Objects);
        }




    }
}