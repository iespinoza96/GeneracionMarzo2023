using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Semestre" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Semestre.svc or Semestre.svc.cs at the Solution Explorer and start debugging.
    public class Semestre : ISemestre
    {
        public SL.Result Add(ML.Semestre semestre)
        {
            ML.Result result = new ML.Result();

            result = BL.Semestre.Add(semestre);
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        public SL.Result GetAll()
        {
            ML.Result result = BL.Semestre.GetAll();
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public string Saludar(string nombre)
        {
            return "Hola " + nombre;
        }


    }
}
