using System;
using System.Text;
using System.Web.UI;

namespace Sena_TimeHub.vista
{
    public partial class master : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["usuario"] != null && Session["rol"] != null)
                {
                    string rol = Session["rol"].ToString();
                    GenerarMenu(rol);
                    lblUsuario.Text = "Bienvenido " + Session["usuario"];
                }
                else
                {
                    if (Session["aprendiz"] != null)
                    {
                        menuAprendiz();
                        lblUsuario.Text = "Bienvenido" + Session["aprendiz"];
                    }
                    else
                    {
                        Response.Redirect("error.aspx");

                    }
                }

            }
        }
        private void menuAprendiz()
        {
            StringBuilder menuAprendiz = new StringBuilder();
            menuAprendiz.Append(AprendizMenu());
            navMenu.InnerHtml = menuAprendiz.ToString();
        }
        private void GenerarMenu(string rol)
        {
            StringBuilder menuHtml = new StringBuilder();

            switch (rol)
            {
                case "Coordinador":
                    menuHtml.Append(CoordinadorMenu());
                    break;
                case "Instructor":
                    menuHtml.Append(InstructorMenu());
                    break;
                case "ApoyoCoordinacion":
                    menuHtml.Append(ApoyoCoordinacionMenu());
                    break;


            }

            navMenu.InnerHtml = menuHtml.ToString();
        }

        private string CoordinadorMenu()
        {
            return @"
<ul class='custom-navbar'>
    <li class='nav-item'>
        <a href='#'>Administración Usuarios</a>
        <ul class='dropdown-menu'>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Programas</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarPrograma.aspx'>Registrar Programa</a></li>
                    <li><a href='listarPrograma.aspx'>Listar Programa</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Fichas</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarFicha.aspx'>Registrar Ficha y Aprendiz</a></li>
                    <li><a href='listarFicha.aspx'>Listar Ficha</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Aprendices</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarAprendiz.aspx'>Registrar Aprendiz</a></li>
                    <li><a href='listarAprendices.aspx'>Listar, Editar/Eliminar Aprendiz</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Instructores</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarInstructor.aspx'>Registrar Instructores</a></li>
                    <li><a href='listarInstructor.aspx'>Listar, Editar/Eliminar Instructor</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Coordinación</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarApoyoCoordinacion.aspx'>Registrar Personal de Coordinación</a></li>
                    <li><a href='listarApoyoCoordinacion.aspx'>Listar, Editar/Eliminar Personal de Coordinación</a></li>
                </ul>
            </li>
        </ul>
    </li>
    <li class='nav-item'>
        <a href='#'>Gestión de Espacios</a>
        <ul class='dropdown-menu'>
            <li class='nav-item sub-item'>
                <a href='#'>Sedes</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarSede.aspx'>Registrar Sede</a></li>
                    <li><a href='listarSede.aspx'>Editar Sede</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Ambientes</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarAmbiente.aspx'>Registrar Ambiente</a></li>
                    <li><a href='listarAmbiente.aspx'>Listar Ambiente</a></li>
                </ul>
            </li>
<li class='nav-item sub-item'>
                <a href='#'>Areas</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarArea.aspx'>Registrar Area</a></li>
                </ul>
            </li>
        </ul>
    </li>
    <li class='nav-item'>
        <a href='#'>Gestión Horarios</a>
        <ul class='dropdown-menu'>
            <li><a href='insertarHorario.aspx'>Registrar Horarios</a></li>
            <li><a href='editarHorario.aspx'>Modificar Horarios</a></li>
            <li><a href='eliminarHorario.aspx'>Eliminar Horarios</a></li>
        </ul>
    </li>
</ul>";
        }

        private string InstructorMenu()
        {
            return @"
<ul class='navbar-nav'>
   <li class='nav-item'><a href='horariosInstructor.aspx'>Gestion Horarios</a></li>
</ul>";
        }

        private string ApoyoCoordinacionMenu()
        {
            return @"
<ul class='custom-navbar'>
    <li class='nav-item'>
        <a href='#'>Administración Usuarios</a>
        <ul class='dropdown-menu'>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Programas</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarPrograma.aspx'>Registrar Programa</a></li>
                    <li><a href='listarPrograma.aspx'>Listar Programa</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Fichas</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarFicha.aspx'>Registrar Ficha y Aprendiz</a></li>
                    <li><a href='listarFicha.aspx'>Editar Ficha</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Aprendices</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarAprendiz.aspx'>Registrar Aprendiz</a></li>
                    <li><a href='listarAprendices.aspx'>Listar, Editar/Eliminar Aprendiz</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Administrar Instructores</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarInstructor.aspx'>Registrar Instructores</a></li>
                    <li><a href='listarInstructor.aspx'>Listar, Editar/Eliminar Instructor</a></li>
                </ul>
            </li>
          
        </ul>
    </li>
    <li class='nav-item'>
        <a href='#'>Gestión de Espacios</a>
        <ul class='dropdown-menu'>
            <li class='nav-item sub-item'>
                <a href='#'>Sedes</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarSede.aspx'>Registrar Sede</a></li>
                    <li><a href='listarSede.aspx'>Editar Sede</a></li>
                </ul>
            </li>
            <li class='nav-item sub-item'>
                <a href='#'>Ambientes</a>
                <ul class='dropdown-submenu'>
                    <li><a href='insertarAmbiente.aspx'>Registrar Ambiente</a></li>
                    <li><a href='listarAmbiente.aspx'>Listar Ambiente</a></li>
                </ul>
            </li>
        </ul>
    </li>
    <li class='nav-item'>
        <a href='#'>Gestión Horarios</a>
        <ul class='dropdown-menu'>
            <li><a href='insertarHorario.aspx'>Registrar Horarios</a></li>
            <li><a href='editarHorario.aspx'>Modificar Horarios</a></li>
            <li><a href='eliminarHorario.aspx'>Eliminar Horarios</a></li>
        </ul>
    </li>
</ul>";
        }

        private string AprendizMenu()
        {
            return @"
<ul class='navbar-nav'>
   <li class='nav-item'><a href='verAprendiz.aspx'>Ver Horarios</a></li>
</ul>";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["aprendiz"] = null;
            Session["rol"] = null;
            Response.Redirect("../index.aspx");
        }


    }
}
