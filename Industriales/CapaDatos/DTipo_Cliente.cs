using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    class DTipo_Cliente
    {//inicio de clase
        private int _Id_tipo_cliente;
        private string _Tipo_cliente;
        #region Propiedades
        public int Id_tipo_cliente
        {
            get
            {
                return _Id_tipo_cliente;
            }

            set
            {
                _Id_tipo_cliente = value;
            }
        }

        public string Tipo_cliente
        {
            get
            {
                return _Tipo_cliente;
            }

            set
            {
                _Tipo_cliente = value;
            }
        }
        #endregion Propiedades

        #region Constructores
        DTipo_Cliente()
        {

        }

        DTipo_Cliente(int id_tipo_cliente, string tipo_cliente)
        {
            this.Id_tipo_cliente = id_tipo_cliente;
            this.Tipo_cliente = tipo_cliente;
        }
        #endregion Constructores


    }//fin de clase
}
