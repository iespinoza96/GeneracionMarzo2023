using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        //CRUD
        //Add
        //public static void Add(ML.Alumno alumno)
        //{
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
        //        {
        //            string query = "INSERT INTO Alumno (Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento)VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento)";
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = context;
        //                cmd.CommandText = query;


        //                SqlParameter[] collection = new SqlParameter[4];

        //                collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
        //                collection[0].Value = alumno.Nombre;

        //                collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
        //                collection[1].Value = alumno.ApellidoPaterno;

        //                collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
        //                collection[2].Value = alumno.ApellidoMaterno;

        //                collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
        //                collection[3].Value = alumno.FechaNacimiento;

        //                cmd.Parameters.AddRange(collection);

        //                cmd.Connection.Open();

        //                int RowsAffected = cmd.ExecuteNonQuery();

        //                if (RowsAffected > 0)
        //                {
        //                    //result.Correct = true;


        //                }
        //                else
        //                {
        //                    //result.Correct = false;
        //                    //result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Producto";
        //                }
        //            }
        //        }




        //    }
        //    catch (Exception)
        //    {

        //        //throw;
        //    }
        //}

        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "INSERT INTO Alumno (Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento)VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;


                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = alumno.FechaNacimiento;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();///

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;


                        }

                    }
                }




            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }

            return result;
        }

        //Update
        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "UPDATE [Alumno] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[FechaNacimiento] = @FechaNacimiento WHERE IdAlumno = @IdAlumno";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;


                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[4].Value = alumno.FechaNacimiento;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;


                        }

                    }
                }




            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }

            return result;
        }

        //GetAll 

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "AlumnoGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable tableAlumno = new DataTable();

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);


                        dataAdapter.Fill(tableAlumno);

                        // dataAdapter.

                        if (tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                alumno.FechaNacimiento = row[4].ToString();

                                alumno.Semestre = new ML.Semestre();
                                alumno.Semestre.IdSemestre = byte.Parse(row[5].ToString());

                                result.Objects.Add(alumno);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
                        }

                    }
                }




            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result GetById(int idAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "AlumnoGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = idAlumno;
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tableAlumno = new DataTable();

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);


                        dataAdapter.Fill(tableAlumno);

                        // dataAdapter.

                        if (tableAlumno.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();

                            DataRow row = tableAlumno.Rows[0];

                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            alumno.FechaNacimiento = row[4].ToString();
                            //result.Objects.Add(alumno);
                            result.Object = alumno;//boxing


                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
                        }

                    }
                }




            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }
            return result;
        }

        //SP
        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "AlumnoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = alumno.FechaNacimiento;


                        collection[4] = new SqlParameter("IdSemestre", SqlDbType.TinyInt);
                        collection[4].Value = alumno.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);


                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();///

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;


                        }

                    }
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }

            return result;
        }

        //EF

        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {
                    int queryEF = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.FechaNacimiento, alumno.Semestre.IdSemestre);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }
        //public static ML.Result Delete(ML.Alumno alumno)//un objeto de tipo ML.Alumno
        //{

        //}
        public static ML.Result UpdateEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {
                    int queryEF = context.AlumnoUpdate(alumno.IdAlumno,alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.FechaNacimiento, alumno.Semestre.IdSemestre);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {
                    //var queryEF = context.AlumnoGetAll();
                    var queryEFList = context.AlumnoGetAll().ToList();


          

                    result.Objects = new List<object>();

                    foreach (var row in queryEFList)
                    {
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = row.IdAlumno;
                        alumno.Nombre = row.Nombre;
                        alumno.ApellidoPaterno = row.ApellidoPaterno;
                        alumno.ApellidoMaterno = row.ApellidoMaterno;
                        alumno.FechaNacimiento = row.FechaNacimiento;
                        alumno.NombreCompleto = alumno.Nombre + alumno.ApellidoPaterno + alumno.ApellidoMaterno;

                        alumno.Semestre = new ML.Semestre();
                        alumno.Semestre.IdSemestre = row.IdSemestre.Value;
                        alumno.Semestre.Nombre = row.SemestreNombre;

                        result.Objects.Add(alumno);
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {

                    var objAlumno = context.AlumnoGetById(IdAlumno).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objAlumno != null)
                    {

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = objAlumno.IdAlumno;
                        alumno.Nombre = objAlumno.Nombre;
                        alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                        alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;
                        alumno.FechaNacimiento = objAlumno.FechaNacimiento;

                        alumno.Semestre = new ML.Semestre();
                        alumno.Semestre.IdSemestre = objAlumno.IdSemestre.Value;
                        alumno.Semestre.Nombre = objAlumno.SemestreNombre;

                        result.Object = alumno; //boxing


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Alumno";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //LINQ

        public static ML.Result AddLINQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
                {
                    DL_EF.Alumno alumnoLINQ = new DL_EF.Alumno();

                    alumnoLINQ.Nombre = alumno.Nombre;
                    alumnoLINQ.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumnoLINQ.ApellidoMaterno = alumno.ApellidoMaterno;
                    alumnoLINQ.FechaNacimiento = DateTime.Parse(alumno.FechaNacimiento);
                    alumnoLINQ.IdSemestre = alumno.Semestre.IdSemestre;


                    context.Alumnoes.Add(alumnoLINQ);
                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //public static ML.Result GetAllLINQ()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
        //        {
        //            //var queryEF = context.AlumnoGetAll();
        //            //var queryLINQList = (from tablaUsuario in context.Alumnoes select tablaUsuario).ToList(); //SELECT * FROM Usuario

        //            var queryLINQList = (from tablaUsuario in context.Alumnoes
        //                                 join tablaSemestre in context.Semestres on tablaUsuario.IdSemestre equals tablaSemestre.IdSemestre
        //                                 //where tablaUsuario.IdSemestre == tablaSemestre.IdSemestre
        //                                 select new
        //                                 {

        //                                     IdAlumno = tablaUsuario.IdAlumno,
        //                                     Nombre = tablaUsuario.Nombre,
        //                                     ApellidoPaterno = tablaUsuario.ApellidoPaterno,
        //                                     ApellidoMaterno = tablaUsuario.ApellidoMaterno,
        //                                     FechaNacimiento = tablaUsuario.FechaNacimiento,
        //                                     IdSemestre = tablaUsuario.IdSemestre,
        //                                     SemestreNombre = tablaSemestre.Nombre
        //                                 }).ToList();// Select * from Usuario + inner join


        //            // dataAdapter.

        //            result.Objects = new List<object>();

        //            foreach (var row in queryLINQList)
        //            {
        //                ML.Alumno alumno = new ML.Alumno();
        //                alumno.IdAlumno = row.IdAlumno;
        //                alumno.Nombre = row.Nombre;
        //                alumno.ApellidoPaterno = row.ApellidoPaterno;
        //                alumno.ApellidoMaterno = row.ApellidoMaterno;
        //                alumno.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd/MM/yyyy");

        //                alumno.Semestre = new ML.Semestre();
        //                alumno.Semestre.IdSemestre = row.IdSemestre.Value;
        //                alumno.Semestre.Nombre = row.SemestreNombre;

        //                result.Objects.Add(alumno);
        //            }

        //            result.Correct = true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
        //        //throw;
        //    }
        //    return result;
        //}

        //public static ML.Result GetByIdlLINQ(int idAlumno)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.IEspinozaProgramacionNCapasGM2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGM2023Entities())
        //        {
        //            //var queryEF = context.AlumnoGetAll();
        //            //var queryLINQList = (from tablaUsuario in context.Alumnoes select tablaUsuario).ToList(); //SELECT * FROM Usuario

        //            var queryLINQList = (from tablaUsuario in context.Alumnoes 
        //                                 join tablaSemestre in context.Semestres on tablaUsuario.IdSemestre equals tablaSemestre.IdSemestre
        //                                 where tablaUsuario.IdAlumno == idAlumno
        //                                 select new
        //                                 {

        //                                     IdAlumno = tablaUsuario.IdAlumno,
        //                                     Nombre = tablaUsuario.Nombre,
        //                                     ApellidoPaterno = tablaUsuario.ApellidoPaterno,
        //                                     ApellidoMaterno = tablaUsuario.ApellidoMaterno,
        //                                     FechaNacimiento = tablaUsuario.FechaNacimiento,
        //                                     IdSemestre = tablaUsuario.IdSemestre,
        //                                     SemestreNombre = tablaSemestre.Nombre
        //                                 }).FirstOrDefault();// Select * from Usuario + inner join


        //            // dataAdapter.
        //            if (queryLINQList != null)
        //            {
 
        //                    ML.Alumno alumno = new ML.Alumno();
        //                    alumno.IdAlumno = queryLINQList.IdAlumno;
        //                    alumno.Nombre = queryLINQList.Nombre;
        //                    alumno.ApellidoPaterno = queryLINQList.ApellidoPaterno;
        //                    alumno.ApellidoMaterno = queryLINQList.ApellidoMaterno;
        //                    alumno.FechaNacimiento = queryLINQList.FechaNacimiento.Value.ToString("dd/MM/yyyy");

        //                    alumno.Semestre = new ML.Semestre();
        //                    alumno.Semestre.IdSemestre = queryLINQList.IdSemestre.Value;
        //                    alumno.Semestre.Nombre = queryLINQList.SemestreNombre;

        //                    result.Object = alumno;
                        

        //            }
              


        //            result.Correct = true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
        //        //throw;
        //    }
        //    return result;
        //}


    }
}
