<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="listarHorario.aspx.cs" Inherits="Sena_TimeHub.vista.listarHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #calendar {
            margin-top: 20px;
            background: white;
            border-radius: 10px;
            padding: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th, td {
            border: 2px solid #333;
            padding: 10px;
            text-align: center;
        }

        th {
            background-color: #f4f4f4;
            font-weight: bold;
        }

        tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        td {
            font-size: 14px;
        }


        .check {
            font-size: 18px;
            color: black;
        }
    </style>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <!-- FullCalendar CSS -->
    <link href="https://cdn.jsdelivr.net/npm/fullcalendar@6.1.8/main.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 class="text-center text-primary mb-4">Seleccione una ficha:</h2>
    <br />
    <asp:DropDownList ID="ddlFicha" runat="server" class="form-select text-center text-bg-info" AutoPostBack="true" OnSelectedIndexChanged="ddlFicha_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <br />

    <div id="lblMensaje"></div>

    <h2 class="text-center text-primary mb-4">Calendario Semanal</h2>
    <br />
    <table class="text-center text-bg-secundary mb-4" border="2">

        <thead>
            <tr>

                <th border="2">Editar</th>
                <th border="2">Eliminar</th>
                <th border="2">Instructor</th>
                <th border="2">Programa</th>
                <th border="2">Ambiente</th>
                <th border="2">Fecha Inicio</th>
                <th border="2">Fecha Final</th>
                <th border="2">Hora Inicio</th>
                <th border="2">Hora Fin</th>
                <th border="2">Días</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptHorarios" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" CommandArgument='<%# Eval("idHorario") %>' OnClick="btnEditar_Click" />
</td>
<td>
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandArgument='<%# Eval("idHorario") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Estás seguro de eliminar este horario?');" />
</td>

                        <td><%# Eval("nombre") + " " + Eval("apellido") %></td>
                        <td><%# Eval("nombrePrograma") %></td>
                        <td><%# Eval("nombreAmbiente") %></td>
                        <td><%# Eval("fechaInicio", "{0:yyyy-MM-dd}")%></td>
                        <td><%# Eval("fechaFinal", "{0:yyyy-MM-dd}") %></td>
                        <td><%# Eval("horaInicio") %></td>
                        <td><%# Eval("horaFinal") %></td>
                        <td class="check">
                            <%# Convert.ToBoolean(Eval("lunes")) ? "Lunes " : ""%>
                            <%# Convert.ToBoolean(Eval("martes")) ? "Martes " : "" %>
                            <%# Convert.ToBoolean(Eval("miercoles")) ? "Miércoles " : "" %>
                            <%# Convert.ToBoolean(Eval("jueves")) ? "Jueves " : "" %>
                            <%# Convert.ToBoolean(Eval("viernes")) ? "Viernes " : "" %>
                            <%# Convert.ToBoolean(Eval("sabado")) ? "Sábado " : "" %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
