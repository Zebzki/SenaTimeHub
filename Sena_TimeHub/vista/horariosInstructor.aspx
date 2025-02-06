<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="horariosInstructor.aspx.cs" Inherits="Sena_TimeHub.vista.horariosInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>
<style>
    #datepicker-container {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        background-color: #f9f9f9;
        margin-top: -100px;
        padding-top: 10px;
        flex-direction: column;
    }

    #datepicker {
        width: 900px;
        padding: 15px;
        background-color: #fff;
        border: 1px solid #ddd;
        border-radius: 20px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    }

    .ui-datepicker {
        font-size: 1.4rem;
        width: 100%;
        text-align: center;
    }

    .ui-datepicker-title {
        font-size: 1.6rem;
        font-weight: bold;
        margin-bottom: 10px;
    }

    .ui-datepicker th {
        font-size: 1.2rem;
    }

    .ui-datepicker td {
        height: 60px;
    }

    .ui-datepicker td a {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100%;
        border-radius: 5px;
        font-size: 1.2rem;
    }

    .ui-datepicker td a:hover {
        background-color: #f0c674;
        color: #000;
    }

    #titulo-horario {
        font-size: 2rem;
        font-weight: bold;
        text-align: center;
        color: #ffffff;
        margin-bottom: 20px;
        text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);
    }

   .highlight {
        background-color: #28a745 !important; /* Green for active classes */
        color: #ffffff !important;
        font-weight: bold;
        border-radius: 5px;
    }

    .cancelada {
        background-color: #ff0000 !important; /* Red for canceled classes */
        color: #ffffff !important;
        font-weight: bolder;
        border-radius: 5px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

  <div id="datepicker-container">
        <h2 id="titulo-horario">¡Tu horario! </h2>
        <div id="datepicker"></div>
    </div>

   <script>
       $(document).ready(function () {
           let horarios = [];
           let highlightedDates = {};

           $.datepicker.regional["es"] = {
               closeText: "Cerrar",
               prevText: "&#x3C;Ant",
               nextText: "Sig&#x3E;",
               currentText: "Hoy",
               monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                   "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
               dayNames: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
               dayNamesShort: [
                   "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"
               ],
               dayNamesMin: [
                   "Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"
               ],
               dateFormat: "yy-mm-dd",
               firstDay: 1
           };
           $.datepicker.setDefaults($.datepicker.regional["es"]);

           $("#datepicker").datepicker({
               defaultDate: new Date(),
               beforeShowDay: function (date) {
                   const dateString = $.datepicker.formatDate("yy-mm-dd", date);
                   if (highlightedDates[dateString]) {
                       const detallesClases = highlightedDates[dateString];
                       const esCancelada = detallesClases.some(d => d.esCancelada);
                       const claseCss = esCancelada ? 'cancelada' : 'highlight';
                       const tooltip = detallesClases.map(d => {
                           let detalle = `Ficha: ${d.ficha}, Ambiente: ${d.ambiente}, ${d.horaInicio} - ${d.horaFin}`;
                           if (d.esCancelada) detalle += ' (Cancelada)';
                           return detalle;
                       }).join('; ');

                       return [true, claseCss, tooltip];
                   }
                   return [true, ''];
               },
               onSelect: function (dateText) {
                   const clasesDelDia = horarios.filter(h => h.fecha === dateText);
                   if (clasesDelDia.length > 0) {
                       let detalles = `Clases para el día ${dateText}:\n`;
                       clasesDelDia.forEach(clase => {
                           detalles += `- Ficha: ${clase.ficha}, Ambiente: ${clase.ambiente}, Horario: ${clase.horaInicio} - ${clase.horaFin}`;
                           if (clase.esCancelada) {
                               detalles += " (Cancelada)";
                           }
                           detalles += "\n";
                       });

                       if (clasesDelDia.some(clase => !clase.esCancelada)) {
                           if (confirm(detalles + "\n¿Deseas cancelar estas clases?")) {
                               let motivo = prompt("Ingresa el motivo de la cancelación:");
                               if (motivo) {
                                   cancelarClase(clasesDelDia[0].idHorario, dateText, motivo);
                               }
                           }
                       } else {
                           alert(detalles);
                       }
                   } else {
                       alert("No hay clases programadas para este día.");
                   }
               }
           });
           $("#datepicker").datepicker("setDate", new Date());
           $.ajax({
               type: "POST",
               url: "horariosInstructor.aspx/ObtenerFechas",
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               success: function (response) {
                   horarios = response.d || [];
                   horarios.forEach(h => {
                       if (!highlightedDates[h.fecha]) {
                           highlightedDates[h.fecha] = [];
                       }
                       highlightedDates[h.fecha].push({
                           ficha: h.ficha,
                           ambiente: h.ambiente,
                           horaInicio: h.horaInicio,
                           horaFin: h.horaFin,
                           idHorario: h.idHorario,
                           esCancelada: h.esCancelada
                       });
                   });
                   $("#datepicker").datepicker("refresh");
               },
               error: function (xhr, status, error) {
                   console.error("Error al cargar las fechas: " + xhr.responseText);
                   alert("No se pudieron cargar las fechas.");
               }
           });

           function cancelarClase(idHorario, fecha, motivo) {
               $.ajax({
                   type: "POST",
                   url: "horariosInstructor.aspx/CancelarClases",
                   contentType: "application/json; charset=utf-8",
                   data: JSON.stringify({ idHorario: idHorario, fecha: fecha, motivo: motivo }),
                   success: function (response) {
                       alert(response.d ? "Clases canceladas correctamente." : "Hubo un error al cancelar las clases.");
                       location.reload();
                   },
                   error: function (xhr, status, error) {
                       console.error("Error al procesar la solicitud: " + xhr.responseText);
                       alert("Error al procesar la solicitud.");
                   }
               });
           }
       });
   </script>



</asp:Content>
