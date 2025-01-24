<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="insertarHorario.aspx.cs" Inherits="Sena_TimeHub.vista.insertarHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
    body {
        justify-content: center;
        align-items: center;
        min-height: 100vh;
        margin: 0;
        background-color: #f8f9fa;
        font-family: Arial, sans-serif;
    }

    .container {
        width: 80%;
        max-width: 1000px;
        margin: auto;
        padding: 20px;
    }

    h1 {
        text-align: center;
        color: #333;
    }

    .form-container {
        background-color: #F8F9FA;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        width: 100%;
        margin: 50px auto 20px auto;
        overflow: hidden;
        box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1), 0 6px 6px rgba(0, 0, 0, 0.1);
    }

    .form-title {
        background-color: #28a745;
        color: white;
        padding: 20px;
        text-align: center;
        border-radius: 12px 12px 0 0;
        font-size: 1.5em;
        font-weight: bold;
        width: 100%;
        margin: 0;
        box-sizing: border-box;
    }

    .form-group {
        margin-bottom: 20px;
        position: relative;
    }

    .form-label {
        display: block;
        margin-bottom: 8px;
        font-weight: bold;
        color: #495057;
    }

    .form-control {
        width: 100%;
        padding: 10px 10px 10px 40px;
        border: 1px solid #ced4da;
        border-radius: 6px;
        font-size: 1em;
        transition: all 0.3s;
    }

    .form-control:focus {
        border-color: #28a745;
        box-shadow: 0 0 6px rgba(40, 167, 69, 0.25);
        outline: none;
    }

    .calendar-table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .calendar-table th, .calendar-table td {
        padding: 15px;
        text-align: center;
        border: 1px solid #ddd;
    }

    .calendar-table th {
        background-color: #28a745;
        color: white;
    }

    .calendar-table td {
        background-color: #fff;
    }

    .calendar-table td:nth-child(odd) {
        background-color: #f1f1f1;
    }

    .calendar-table td:hover {
        background-color: #f4f4f4;
    }

    .calendar-table td .class-name {
        display: block;
        padding: 5px;
        margin-top: 10px;
        font-size: 14px;
        color: #333;
        background-color: #28a745;
        color: white;
        border-radius: 5px;
    }

    .calendar-table td .info-btn {
        margin-top: 10px;
        padding: 5px 10px;
        background-color: #2196F3;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

    .calendar-table td .info-btn:hover {
        background-color: #0b7dda;
    }

    /* Estilo para los selectores */
    .form-control, .editable-input, .register-button {
        width: 100%;
        padding: 10px;
        border-radius: 6px;
        border: 1px solid #ced4da;
        font-size: 1em;
    }

    .register-button {
        background-color: #28a745;
        color: white;
        cursor: pointer;
        margin-top: 20px;
    }

    .register-button:hover {
        background-color: #218838;
    }

    footer {
        text-align: center;
        padding: 20px;
        margin-top: 30px;
        position: relative;
        bottom: 0;
        width: 100%;
        color: #6c757d;
        font-size: 0.9em;
        box-shadow: 0px -4px 10px rgba(0, 0, 0, 0.1);
    }

</style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

        <div class="container">
        <table class="calendar-table">
            <thead>
                <tr>
                    <th>Hora</th>
                    <th>Lunes</th>
                    <th>Martes</th>
                    <th>Miércoles</th>
                    <th>Jueves</th>
                    <th>Viernes</th>
                    <th>Sábado</th>
                </tr>
            </thead>
            <tbody id="horarioTabla">
                <% 
                    string[] horarios = { "6:00 - 7:00 AM", "7:00 - 8:00 AM", "8:00 - 9:00 AM", "9:00 - 10:00 AM", "10:00 - 11:00 AM", "11:00 - 12:00 AM"};
                    string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
                    string[,] clases = new string[6, 6] {
                        { "", "", "", "", "", "" },
                        { "", "", "", "", "", "" },
                        { "", "", "", "", "", "" },
                        { "", "", "", "", "", "" },
                        { "", "", "", "", "", "" },
                        { "", "", "", "", "", "" }
                    };
                    
                    for (int i = 0; i < horarios.Length; i++) {
                        Response.Write("<tr>");
                        Response.Write("<td>" + horarios[i] + "</td>");
                        for (int j = 0; j < dias.Length; j++) {
                            Response.Write("<td class='editable' onclick='editCell(this, " + i + ", " + j + ")'>");
                            Response.Write(clases[i, j] != "" ? "<div class='class-name'>" + clases[i, j] + "</div>" : "");
                            Response.Write("</td>");
                        }
                        Response.Write("</tr>");
                    }
                %>
            </tbody>
    
        </table>
    <div class="form-container">
    <h2 class="form-title">Registrar Clase</h2>

        <!-- Selección de hora y día -->
        <div class="form-group">
            <label for="horaSelect" class="form-label">Seleccionar hora:</label>
            <select id="horaSelect" class="form-control">
                <option value="6:00 - 7:00 AM">6:00 - 7:00 AM</option>
                <option value="7:00 - 8:00 AM">7:00 - 8:00 AM</option>
                <option value="8:00 - 9:00 AM">8:00 - 9:00 AM</option>
                <option value="9:00 - 10:00 AM">9:00 - 10:00 AM</option>
                <option value="10:00 - 11:00 AM">10:00 - 11:00 AM</option>
                <option value="11:00 - 12:00 AM">11:00 - 12:00 AM</option>
            </select>

            <label for="diaSelect" class="form-label">Seleccionar día:</label>
            <select id="diaSelect" class="form-control">
                <option value="Lunes">Lunes</option>
                <option value="Martes">Martes</option>
                <option value="Miércoles">Miércoles</option>
                <option value="Jueves">Jueves</option>
                <option value="Viernes">Viernes</option>
                <option value="Sábado">Sábado</option>
            </select>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPrograma" runat="server" Text="Programa" CssClass="form-label" AssociatedControlID="ddlPrograma"></asp:Label>
            <asp:DropDownList ID="ddlPrograma" runat="server" CssClass="form-control" AutoPostBack="false">
                <asp:ListItem Text="Seleccione un programa" Value="" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="instructor" class="form-label">Instructor:</label>
            <input type="text" id="instructor" class="form-control" placeholder="Ingrese el nombre del instructor">
        </div>

        <div class="form-group">
            <label for="tipo" class="form-label">Tipo de clase:</label>
            <select id="tipo" class="form-control">
                <option value="">Seleccionar Tipo</option>
                <option value="Tecnica">Tecnica</option>
                <option value="Transversal">Transversal</option>
            </select>
        </div>

        <button type="button" class="register-button" onclick="registrarClase()">Registrar</button>

</div>
    <footer>© 2024 Sena TimeHub</footer>

    </div>
    <script>
        function registrarClase() {
            var hora = document.getElementById("horaSelect").value;
            var dia = document.getElementById("diaSelect").value;
            var programa = document.getElementById("<%= ddlPrograma.ClientID %>").value;
            var instructor = document.getElementById("instructor").value;
            var tipo = document.getElementById("tipo").value;

            if (!programa || !instructor) {
                alert("Por favor, complete todos los campos.");
                return;
            }

            var filas = document.querySelectorAll("#horarioTabla tr");
            var horaSeleccionada = -1;
            for (var i = 0; i < filas.length; i++) {
                var celdas = filas[i].getElementsByTagName("td");
                if (celdas[0].innerText === hora) {
                    horaSeleccionada = i;
                    break;
                }
            }

            if (horaSeleccionada === -1) {
                alert("No se encontró la hora seleccionada.");
                return;
            }

            var dias = ["Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"];
            var columnaSeleccionada = dias.indexOf(dia);

            if (columnaSeleccionada === -1) {
                alert("Día inválido.");
                return;
            }

            var celda = filas[horaSeleccionada].getElementsByTagName("td")[columnaSeleccionada + 1];

            celda.innerHTML = "<div class='class-name'>" + programa + "<br>Instructor: " + instructor + "<br>Tipo: " + tipo + "</div>";

            document.getElementById("ddlPrograma").value = "";
            document.getElementById("instructor").value = "";
            document.getElementById("tipo").value = "";
        }
    </script>
</asp:Content>


