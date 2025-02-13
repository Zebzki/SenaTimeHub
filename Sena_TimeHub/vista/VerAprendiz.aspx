<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="VerAprendiz.aspx.cs" Inherits="Sena_TimeHub.vista.VerAprendiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <style>
        body {
            background-color: #f8f9fa;
        }

        #container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            gap: 20px;
        }

        .info-box {
            width: 30%;
            height: 70vh;
            background: linear-gradient(135deg, #f3f4f6, #ffffff);
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            text-align: center;
            font-size: 1.5rem;
            font-weight: bold;
            padding: 20px;
            transition: all 0.3s ease-in-out;
        }

            .info-box:hover {
                transform: scale(1.05);
                box-shadow: 0 6px 15px rgba(0, 0, 0, 0.15);
            }

        .info-header {
            background: #28a745;
            color: white;
            width: 100%;
            padding: 10px;
            font-size: 1.8rem;
            font-weight: bold;
            border-radius: 15px 15px 0 0;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 10px;
        }

        .info-content {
            flex-grow: 1;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            text-align: center;
            font-size: 1.2rem;
            color: #333;
            padding: 20px;
        }

        .info-icon {
            font-size: 2rem;
        }

        .calendar-wrapper {
            width: 70%;
            height: 80vh;
            background: white;
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            padding: 20px;
        }

        .fc-header-toolbar {
            background: #28a745;
            color: white;
            text-align: center;
            font-size: 1.5rem;
            font-weight: bold;
            padding: 15px;
            border-radius: 10px 10px 0 0;
        }

        .fc-daygrid-day-number {
            font-size: 1.2rem;
            color: #00324D;
        }

        .fc-event {
            background-color: #28a745 !important;
            color: white !important;
            border: none !important;
            border-radius: 5px;
        }

        /* Clase para eventos cancelados */
        .cancelada {
            background-color: #ff0000 !important; /* Red for canceled classes */
            color: #ffffff !important;
            font-weight: bolder;
            border-radius: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="container">
        <div class="info-box" id="info-box">
            <div class="info-header">
                <span class="info-icon">📅</span>
                <span id="selected-date">Seleccione una fecha</span>
            </div>
            <div class="info-content" id="info-content">
                No hay clases programadas.
            </div>
        </div>

        <div class="calendar-wrapper">
            <div id='calendar'></div>
        </div>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            let calendarEl = document.getElementById('calendar');
            let horarios = [];

            let calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                locale: 'es',
                selectable: true,
                dateClick: function (info) {
                    let clasesDelDia = horarios.filter(h => h.fecha === info.dateStr);
                    document.getElementById("selected-date").innerHTML = info.dateStr;
                    let detalles = "";
                    if (clasesDelDia.length > 0) {
                        clasesDelDia.forEach(clase => {
                            detalles += `Materia: ${clase.area}<br>Tipo: ${clase.tipoArea}<br>Ficha: ${clase.ficha}<br>Instructor: ${clase.instructor}<br>Ambiente: ${clase.ambiente}<br>Horario: ${clase.horaInicio} - ${clase.horaFin}<br><br>`;
                        });
                    } else {
                        detalles = "No hay clases programadas para este día.";
                    }
                    document.getElementById("info-content").innerHTML = detalles;
                },
                events: [],
                eventContent: function (arg) {
                    let content = document.createElement("div");
                    let eventTitle = arg.event.title;

                    // Si el evento está cancelado, agregamos la palabra "Cancelada" al título
                    if (arg.event.extendedProps.esCancelada) {
                        eventTitle = eventTitle + " (Cancelada)";
                    }

                    content.innerHTML = `<strong>${eventTitle}</strong><br>
                         <span style="font-size: 0.8rem; color: #fff; ">${arg.event.extendedProps.instructor}</span>`;
                    return { domNodes: [content] };
                }
            
            });

        $.ajax({
            type: "POST",
            url: "VerAprendiz.aspx/ObtenerFechas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                horarios = response.d || [];
                let events = horarios.map(h => {
                    let eventClass = h.esCancelada ? 'cancelada' : '';
                    return {
                        title: h.area,
                        start: h.fecha,
                        backgroundColor: '#28a745',
                        borderColor: '#28a745',
                        extendedProps: { instructor: `Instructor: ${h.instructor}`, esCancelada: h.esCancelada },
                        classNames: [eventClass]
                    };
                });
                calendar.addEventSource(events);
            }
        });

        calendar.render();
        });
    </script>
</asp:Content>
