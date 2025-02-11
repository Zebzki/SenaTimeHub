using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clObtenerAprendicesYUsuariosLcs
    {
        public clAprendizE ObtenerAprendizPorId(int idAprendiz)
        {
            clObtenerAprendicesYUsuarios datos = new clObtenerAprendicesYUsuarios();
            return datos.ObtenerAprendizPorId(idAprendiz); 
        }

        public clUsuarioE ObtenerUsuariosPorId(int idUsuario)
        {
            clObtenerAprendicesYUsuarios datos = new clObtenerAprendicesYUsuarios();
            return datos.ObtenerUsuarioPorId(idUsuario);
        }

    }
}