<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="insertarHorario.aspx.cs" Inherits="Sena_TimeHub.vista.insertarHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            margin-top: 30px;
            padding-top: 10px;
        }

        #calendar {
            margin-top: 20px;
            background: white;
            border-radius: 10px;
            padding: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .ddl-con {
            display: flex;
            flex-direction: column;
            align-items: start;
            gap: 8px;
        }

            .ddl-con select {
                padding: 6px;
                border: 1px solid #ccc;
                border-radius: 5px;
                background-color: #f8f9fa;
                cursor: pointer;
                transition: all 0.3s ease-in-out;
                width: 100%;
            }

                .ddl-con select:hover {
                    transform: scale(1.05);
                    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
                }

        .checkbox-container input[type="checkbox"] {
            position: absolute;
            opacity: 0;
            width: 0;
            height: 0;
        }

        /* Crear un checkbox personalizado */
        .checkbox-custom {
            width: 20px;
            height: 20px;
            border: 2px solid #6c757d;
            border-radius: 5px;
            position: relative;
            display: inline-block;
            transition: all 0.3s ease-in-out;
        }

        /* Efecto cuando el checkbox está marcado */
        .checkbox-container input[type="checkbox"]:checked + .checkbox-custom {
            background-color: #007bff;
            border-color: #007bff;
        }

            /* Agregar una marca cuando está seleccionado */
            .checkbox-container input[type="checkbox"]:checked + .checkbox-custom::after {
                content: "✔";
                position: absolute;
                left: 50%;
                top: 50%;
                transform: translate(-50%, -50%);
                color: white;
                font-size: 14px;
                font-weight: bold;
            }

        /* Estilo base para los checkboxes */
        .checkbox-container {
            display: flex;
            align-items: center;
            gap: 8px;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 8px;
            background-color: #f8f9fa;
            transition: all 0.3s ease-in-out;
            cursor: pointer;
        }

            /* Animación al pasar el cursor */
            .checkbox-container:hover {
                background-color: #e9ecef;
                transform: scale(1.05);
                box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            }

        h2.text-center.text-primary {
            font-size: 2rem; /* Tamaño del texto */
            font-weight: 600; /* Negrita ligera */
            color: #00324D; /* Azul oscuro */
            text-transform: uppercase; /* Convertir a mayúsculas */
            letter-spacing: 1.5px; /* Espaciado entre letras */
            text-align: center; /* Asegura la alineación */
            opacity: 0; /* Inicia invisible */
            transform: translateY(-10px); /* Inicia levemente arriba */
            animation: fadeIn 1s ease-out forwards; /* Animación al cargar */
        }

        /* Definición de la animación */
        @keyframes fadeIn {
            from {
                opacity: 0;
                transform: translateY(-10px);
            }

            to {
                opacity: 1;
                transform: translateY(0);
            }
        }
    </style>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <!-- FullCalendar CSS -->
    <link href="https://cdn.jsdelivr.net/npm/fullcalendar@6.1.8/main.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <h2 class="text-center text-primary mb-4">Insertar Horario</h2>

        <div class="card shadow p-3 mb-4">
            <div class="card-body">

                <div class="row g-3">
                    <div class="col-md-4 ddl-con">
                        <label class="form-label">Instructor</label>
                        <asp:DropDownList ID="ddlInstructor" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 ddl-con">
                        <label class="form-label">Ficha</label>
                        <asp:DropDownList ID="ddlFicha" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 ddl-con">
                        <label class="form-label">Ambiente</label>
                        <asp:DropDownList ID="ddlAmbiente" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>

                <div class="row g-3 mt-3">
                    <div class="col-md-6">
                        <label class="form-label">Fecha Inicio</label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">Fecha Final</label>
                        <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="row g-3 mt-3">
                    <div class="col-md-6">
                        <label class="form-label">Hora Inicio</label>
                        <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">Hora Final</label>
                        <asp:TextBox ID="txtHoraFinal" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                    </div>
                </div>

                <div class="row g-3 mt-3">
                    <label class="form-label">Días de la Semana</label>

                    <div class="col-md-2">
                        <label class="checkbox-container">
                            <asp:CheckBox ID="chkLunes" runat="server" />
                            <span class="checkbox-custom"></span>Lunes
       
                        </label>
                    </div>

                    <div class="col-md-2">
                        <label class="checkbox-container">
                            <asp:CheckBox ID="chkMartes" runat="server" />
                            <span class="checkbox-custom"></span>Martes
       
                        </label>
                    </div>

                    <div class="col-md-2">
                        <label class="checkbox-container">
                            <asp:CheckBox ID="chkMiercoles" runat="server" />
                            <span class="checkbox-custom"></span>Miércoles
       
                        </label>
                    </div>

                    <div class="col-md-2">
                        <label class="checkbox-container">
                            <asp:CheckBox ID="chkJueves" runat="server" />
                            <span class="checkbox-custom"></span>Jueves
       
                        </label>
                    </div>

                    <div class="col-md-2">
                        <label class="checkbox-container">
                            <asp:CheckBox ID="chkViernes" runat="server" />
                            <span class="checkbox-custom"></span>Viernes
       
                        </label>
                    </div>

                    <div class="col-md-2">
                        <label class="checkbox-container">
                            <asp:CheckBox ID="chkSabado" runat="server" />
                            <span class="checkbox-custom"></span>Sábado
       
                        </label>
                    </div>
                </div>

                <div class="mt-4 text-center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Horario" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>


        <div id="calendar"></div>
    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/fullcalendar@6.1.8/main.min.js"></script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var calendarEl = document.getElementById('calendar');
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay,listYear'
                },
                events: 'CargarEventos.aspx'
            });
            calendar.render();
        });
    </script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
