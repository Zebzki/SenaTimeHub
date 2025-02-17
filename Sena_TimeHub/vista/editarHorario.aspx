<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="editarHorario.aspx.cs" Inherits="Sena_TimeHub.vista.editarHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #calendar {
            margin-top: 20px;
            background: white;
            border-radius: 10px;
            padding: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
    </style>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <!-- FullCalendar CSS -->
    <link href="https://cdn.jsdelivr.net/npm/fullcalendar@6.1.8/main.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <h2 class="text-center text-warning mb-4">Editar Horario</h2>

        <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info text-center d-block"></asp:Label>

        <div class="card shadow p-3 mb-4">
            <div class="card-body">
                <div class="row g-3">
                    <div class="col-md-4">
                        <label class="form-label">Instructor</label>
                        <asp:DropDownList ID="ddlInstructor" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Ficha</label>
                        <asp:DropDownList ID="ddlFicha" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
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
                        <asp:CheckBox ID="chkLunes" runat="server" Text="Lunes" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkMartes" runat="server" Text="Martes" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkMiercoles" runat="server" Text="Miércoles" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkJueves" runat="server" Text="Jueves" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkViernes" runat="server" Text="Viernes" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkSabado" runat="server" Text="Sábado" />
                    </div>
                </div>

                <div class="mt-4 text-center">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Horario" CssClass="btn btn-warning" OnClick="btnActualizar_Click" OnClientClick="return alert('Horario Actualizado Correctamente!!!');"  />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClientClick="window.history.back(); return false;" />
                </div>
            </div>
        </div>

        <div id="calendar"></div>
    </div>

    <!-- Scripts -->
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
</asp:Content>