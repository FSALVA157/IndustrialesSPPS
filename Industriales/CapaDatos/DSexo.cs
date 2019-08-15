using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSexo
    {
        private int _Clave;
        private string _Sexo;
        #region propiedades
        public int Clave
        {
            get
            {
                return _Clave;
            }

            set
            {
                _Clave = value;
            }
        }

        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
            }
        }

        #endregion propiedades

        #region constructores
        public DSexo() { }


        #endregion constructores

        #region metodos
        public string Insertar(DSexo sexo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_estado_civil";

                //parametros
                SqlParameter ParClave = new SqlParameter();
                ParClave.ParameterName = "@clave";
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@estado_civil";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 50;
                ParSexo.Value = sexo.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                rpta = (SqlCmd.ExecuteNonQuery() == 1) ? "OK" : "NO SE AGREGADO LA CATEGORIA DE LA TABLA ESTADO_CIVIL";


            }
            catch (Exception ex)
            {

                rpta = ex.Message + ex.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }

        //metodo editar

        public string Editar(DEstado_Civil Estado_Civil)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "speditar_estado_civil";

                //parametros
                SqlParameter ParClave = new SqlParameter();
                ParClave.ParameterName = "@clave";
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.Value = Estado_Civil.Clave;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParEstado_Civil = new SqlParameter();
                ParEstado_Civil.ParameterName = "@estado_civil";
                ParEstado_Civil.SqlDbType = SqlDbType.VarChar;
                ParEstado_Civil.Size = 50;
                ParEstado_Civil.Value = Estado_Civil.Estado_Civil;
                SqlCmd.Parameters.Add(ParEstado_Civil);

                rpta = (SqlCmd.ExecuteNonQuery() == 1) ? "OK" : "HA FALLADO LA ACTUALIZACION DEL ESTADO CIVIL";


            }
            catch (Exception ex)
            {

                rpta = ex.Message + ex.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }

        //metodo eliminar
        public string Eliminar(DEstado_Civil Estado_Civil)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "speliminar_estado_civil";

                //parametros
                SqlParameter ParClave = new SqlParameter();
                ParClave.ParameterName = "@clave";
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.Value = Estado_Civil.Clave;
                SqlCmd.Parameters.Add(ParClave);


                rpta = (SqlCmd.ExecuteNonQuery() == 1) ? "OK" : "NO SE ELIMINADO LA CATEGORIA SELECCIONADA";


            }
            catch (Exception ex)
            {

                rpta = ex.Message + ex.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }

        //metodo mostrar
        public DataTable Mostrar()
        {
            SqlConnection SqlCon = new SqlConnection();
            DataTable DtResultado = new DataTable("estado_civil");
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostar_estado_civil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch (Exception)
            {

                DtResultado = null;
            }
            return DtResultado;
        }

        //metodo buscar
        public DataTable Buscar(DEstado_Civil Estado_Civil)
        {
            SqlConnection SqlCon = new SqlConnection();
            DataTable DtResultado = new DataTable("estado_civil");
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_estado_civil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Estado_Civil.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch (Exception)
            {

                DtResultado = null;
            }
            return DtResultado;
        }



        #endregion metodos
    }
}
