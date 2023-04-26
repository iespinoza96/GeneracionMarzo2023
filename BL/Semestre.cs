using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAll() 
        { 
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {
                    var semestreList = context.SemestreGetAll().ToList();

                    result.Objects = new List<object>();

                    foreach (var row in semestreList)
                    {
                        ML.Semestre semestre = new ML.Semestre();

                        semestre.IdSemestre = row.IdSemestre;
                        semestre.Nombre = row.Nombre;

                        result.Objects.Add(semestre);

                    }

                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                
            }
            return result; 
        }

        public static ML.Result Add(ML.Semestre semestre)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {
                    int queryEF = context.SemestreAdd(semestre.Nombre);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el semestre" + ex;
            }
            return result;
        }

    }
}
