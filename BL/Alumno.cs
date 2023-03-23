using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        //CRUD
        //Add
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
                result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }

            return result;
        }

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

    }
}
