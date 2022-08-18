using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll_Zoologico
{
    public interface IOperacionesCRUD
    {
        bool actualizar();
        bool agregar();
        DataTable buscarxID();
        DataTable consultar();
        bool Eliminar();

    }
}
