using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class DAnticipo
    {

        private int _id_anticipo;
        private string _numero_anticipo;
        private decimal _cantidad_dinero;
        private DateTime _fecha_recibido;
        private string _textobuscar;

        #region Propiedades
        public int Id_anticipo
        {
            get
            {
                return _id_anticipo;
            }

            set
            {
                _id_anticipo = value;
            }
        }

        public string Numero_anticipo
        {
            get
            {
                return _numero_anticipo;
            }

            set
            {
                _numero_anticipo = value;
            }
        }

        public decimal Cantidad_dinero
        {
            get
            {
                return _cantidad_dinero;
            }

            set
            {
                _cantidad_dinero = value;
            }
        }

        public DateTime Fecha_recibido
        {
            get
            {
                return _fecha_recibido;
            }

            set
            {
                _fecha_recibido = value;
            }
        }

        public string Textobuscar
        {
            get
            {
                return _textobuscar;
            }

            set
            {
                _textobuscar = value;
            }
        }
        #endregion Propiedades

        #region Constructores

        //Constructor vacio
        public DAnticipo()
        {

        }

        //Constructor con parametros
        public DAnticipo(int id_anticipo, string numero_anticipo, decimal cantidad_dinero, DateTime fecha_recibido)
        {
            this.Id_anticipo = id_anticipo;
            this.Numero_anticipo = numero_anticipo;
            this.Cantidad_dinero = cantidad_dinero;
            this.Fecha_recibido = fecha_recibido;
        }
        #endregion Constructores

        #region Metodos

        //metodos

        //metodo insertar   
        public string Insertar(DAnticipo Anticipo)
        {//inicio insertar
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_anticipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParAnticipo = new SqlParameter();
                ParAnticipo.ParameterName = "@id_anticipo";
                ParAnticipo.SqlDbType = SqlDbType.Int;
                ParAnticipo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParAnticipo);

                SqlParameter ParNumero_Anticipo = new SqlParameter();
                ParNumero_Anticipo.ParameterName = "@numero_anticipo";
                ParNumero_Anticipo.SqlDbType = SqlDbType.VarChar;
                ParNumero_Anticipo.Value = Anticipo.Numero_anticipo;
                SqlCmd.Parameters.Add(ParNumero_Anticipo);

                SqlParameter ParCantidad_Dinero = new SqlParameter();
                ParCantidad_Dinero.ParameterName = "@cantidad_dinero";
                ParCantidad_Dinero.SqlDbType = SqlDbType.Decimal;
                ParCantidad_Dinero.Value = Anticipo.Cantidad_dinero;
                SqlCmd.Parameters.Add(ParCantidad_Dinero);

                SqlParameter ParFecha_Recibido = new SqlParameter();
                ParFecha_Recibido.ParameterName = "@fecha_recibido";
                ParFecha_Recibido.SqlDbType = SqlDbType.VarChar;
                ParFecha_Recibido.Size = 50;
                ParFecha_Recibido.Value = Anticipo.Fecha_recibido;
                SqlCmd.Parameters.Add(ParFecha_Recibido);

                //ejecutar el codigo
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "EL REGISTRO NO HA SIDO AGREGADO";


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

        }//fin insertar

        //metodo editar
        public string Editar(DAnticipo Anticipo)
        {//inicio editar
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_anticipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros

                SqlParameter ParId_Anticipo = new SqlParameter();
                ParId_Anticipo.ParameterName = "@id_anticipo";
                ParId_Anticipo.SqlDbType = SqlDbType.Int;
                ParId_Anticipo.Value = Anticipo.Id_anticipo;
                SqlCmd.Parameters.Add(ParId_Anticipo);

                SqlParameter ParNumero_Anticipo = new SqlParameter();
                ParNumero_Anticipo.ParameterName = "@numero_anticipo";
                ParNumero_Anticipo.SqlDbType = SqlDbType.VarChar;
                ParNumero_Anticipo.Value = Anticipo.Numero_anticipo;
                SqlCmd.Parameters.Add(ParNumero_Anticipo);

                SqlParameter ParCantidad_Dinero = new SqlParameter();
                ParCantidad_Dinero.ParameterName = "@cantidad_dinero";
                ParCantidad_Dinero.SqlDbType = SqlDbType.Decimal;
                ParCantidad_Dinero.Value = Anticipo.Cantidad_dinero;
                SqlCmd.Parameters.Add(ParCantidad_Dinero);

                SqlParameter ParFecha_Recibido = new SqlParameter();
                ParFecha_Recibido.ParameterName = "@fecha_recibido";
                ParFecha_Recibido.SqlDbType = SqlDbType.VarChar;
                ParFecha_Recibido.Size = 50;
                ParFecha_Recibido.Value = Anticipo.Fecha_recibido;
                SqlCmd.Parameters.Add(ParFecha_Recibido);

                //ejecutar el codigo
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "HA FALLADO LA EDICION DEL REGISTRO";



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
        }//fin editar

        //metodo eliminar
        public string Eliminar(DAnticipo Anticipo)
        {//inicio eliminar
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_anticipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Anticipo = new SqlParameter();
                ParId_Anticipo.ParameterName = "@id_anticipo";
                ParId_Anticipo.SqlDbType = SqlDbType.Int;
                ParId_Anticipo.Value = Anticipo.Id_anticipo;
                SqlCmd.Parameters.Add(ParId_Anticipo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE HA ELIMINADO EL REGISTRO";



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
        }//fin eliminar

        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("anticipo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_anticipo";

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);




            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin mostrar

        //metodo buscar 
        public DataTable Buscar_Compulsa_Clave(DAnticipo Anticipo)
        {//inicio buscar x clave
            DataTable DtResultado = new DataTable("anticipo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_anticipo";

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Anticipo.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar 

        #endregion Metodos

    }
}
