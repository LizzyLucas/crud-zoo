using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//Proveedor de SQL SERVER

namespace dll_Zoologico
{
    //Clase protegida solo se puede ver en cualquier proyecto del namespace: sin public y private
    //Datos de conexiones en el menor número de lugares posibles: por motivos de seguridad y actualización de codigo
    public class Especie : IOperacionesCRUD
    {
        //Metodos, Propiedades, Atributos, Eventos, Funciones
        //Clase que no debe ser instanciada static

        #region Atributos
        private byte _Id;//Variables se empiezan con _
        private string _Nombre;
        private string _Conexion;
        #endregion
        #region Propiedades

        public byte Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Funciones

        public Especie()
        {
            _Id = 0;
            _Nombre ="";
            _Conexion = Conexion.conexionWin();
        }
        public bool actualizar()
        {

            bool resultado = false;
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_Actualizar", cn);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = _Nombre;
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                }
                cn.Close();
            }
            return resultado;
        }

        public bool agregar()
        {
            bool resultado=false;
            using (SqlConnection cn = new SqlConnection(_Conexion)) {
                SqlCommand cmd = new SqlCommand("usp_AgregarEspecies", cn);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = _Nombre;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                if (cmd.ExecuteNonQuery()>0)
                {
                    resultado = true;
                }
                cn.Close();
            }
            return resultado;
        }

        public DataTable buscarxID()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_Buscar", cn);
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
               
            }
            return dt;
        }

        public DataTable consultar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn=new SqlConnection(_Conexion))//Libera conexión de memoria: Cunaod se acabe d eusar la conexión el archivo se destruya
            {
                SqlCommand cmd = new SqlCommand("usp_Consultar", cn);
                //ExecuteReader -- Hacer consultas de datos
                //ExecuteScalar --Cuando ejecutamos consuktas que devuelven coomo res. un valor único
                //ExecuteNonQuery -- Cualquier instrucción que no sea un select
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }//El using en automático hace el dispose
            return dt;
        }

        public bool Eliminar()
        {
            bool resultado = false;

            
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_Eliminar", cn);
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                }
                cn.Close();
            }
            return resultado;
        }
        #endregion
    }

}
