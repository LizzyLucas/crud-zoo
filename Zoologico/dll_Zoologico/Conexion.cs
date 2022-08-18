using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll_Zoologico
{
    static class Conexion
    {
        public static string conexionWin()
        {
            string cad = "Data Source=LAPTOP-F9VT67M5;" +//Nombre de servidor
                "Initial Catalog=BD_Zoologico;"+//Nombre de la BD
                "Integrated Security=true";//Autenticación de Windows
        return cad;
        }
    public static string conexionSQL()
    {
            string cad = "Data Source=LAPTOP-F9VT67M5;" +//Nombre de servidor
                    "Initial Catalog=BD_Zoologico;" +//Nombre de la BD
                    "User Id=TBD;"+ //Usuario//Autenticación
                    "Password=ABCD"; //Contraseña
            return cad;

        }

    }
}
