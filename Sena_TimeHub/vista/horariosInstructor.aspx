<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="horariosInstructor.aspx.cs" Inherits="Sena_TimeHub.vista.horariosInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <style>
        body {
            background-color: #f8f9fa;
        }

        #calendar-container {
            width: 80%;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        #titulo-horario {
            text-align: center;
            font-size: 2rem;
            color: #333;
            margin-bottom: 20px;
        }

        .fc-event {
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="calendar-container">
        <h2 id="titulo-horario">¡Tu horario!</h2>
        <div id='calendar'></div>
    </div>
    
    <script>
        $(document).ready(function () {
            let calendarEl = document.getElementById('calendar');
            let calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                locale: 'es',
                headerToolbar: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                events: function (fetchInfo, successCallback, failureCallback) {
                    $.ajax({
                        type: "POST",
                        url: "horariosInstructor.aspx/ObtenerFechas",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            let horarios = response.d || [];
                            let eventos = horarios.map(h => ({
                                id: h.idHorario,
                                title: `Ficha: ${h.ficha}, Ambiente: ${h.ambiente}`,
                                start: h.fecha + 'T' + h.horaInicio,
                                end: h.fecha + 'T' + h.horaFin,
                                color: h.esCancelada ? '#ff0000' : '#28a745',
                                extendedProps: {
                                    esCancelada: h.esCancelada,
                                    motivo: h.motivo || "No se especificó motivo"
                                }
                            }));

                            successCallback(eventos);
                        },
                        error: function (xhr, status, error) {
                            console.error("Error al cargar las fechas: " + xhr.responseText);
                            alert("No se pudieron cargar las fechas.");
                            failureCallback([]);
                        }
                    });
                },
                eventClick: function (info) {
                    if (info.event.extendedProps.esCancelada) {
                        alert(`Esta clase ha sido cancelada. Motivo: ${info.event.extendedProps.motivo}`);
                    } else {
                        if (confirm("¿Deseas cancelar esta clase?")) {
                            let motivo = prompt("Ingresa el motivo de la cancelación:");
                            if (motivo) {
                                cancelarClase(clasesDelDia[0].idHorario, dateText, motivo);
                            }
                        }
                    }
                }
            });
            calendar.render();
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
    </script>
</asp:Content>
