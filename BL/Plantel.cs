﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {
                    var semestreList = context.PlantelGetAll().ToList();

                    result.Objects = new List<object>();

                    foreach (var row in semestreList)
                    {
                        ML.Plantel plantel = new ML.Plantel();

                        plantel.IdPlantel = row.IdPlantel;
                        plantel.Nombre = row.Nombre;

                        result.Objects.Add(plantel);

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

    }
}
