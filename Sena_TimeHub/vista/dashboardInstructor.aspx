<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="dashboardInstructor.aspx.cs" Inherits="Sena_TimeHub.vista.dashboardInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .carousel-item img {
            width: 100%;
            height: 500px;
            object-fit: cover;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container mt-5">
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="../icons/sena-aprendizaje-1.jpg" class="d-block w-100" alt="Gestión de Horarios">
                    <div class="carousel-caption d-none d-md-block">
                        <h2>Optimiza tu tiempo de enseñanza</h2>
                        <p style="font-size: 25px">La aplicación SenaTimeHub te permite gestionar tus horarios de manera eficiente y sin complicaciones.</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="../icons/bienestar_SENA_600.jpg" class="d-block w-100" alt="Planificación Flexible">
                    <div class="carousel-caption d-none d-md-block">
                        <h2>Planificación flexible de clases</h2>
                        <p style="font-size: 25px">Con la interfaz intuitiva, puedes ajustar tus horarios de clases según tu disponibilidad y las necesidades de tus aprendices.</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="../icons/Directorio-.jpg" class="d-block w-100" alt="Accesibilidad">
                    <div class="carousel-caption d-none d-md-block">
                        <h2>Accesibilidad en todo momento</h2>
                        <p style="font-size: 25px">Accede a tu horario desde cualquier dispositivo, ya sea computadora, tablet o teléfono móvil.</p>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="text-center">
                    <br />
                    <h1 style="color: #28a745">¡Bienvenido, Instructor!</h1>
                </div>
                <div class="card-body">
                    <p class="lead" style="font-size: 22px">Como instructor, puedes gestionar tus horarios de clases, revisar el progreso de tus aprendices y acceder a materiales útiles para la enseñanza.</p>
                    <p style="font-size: 20px">Usa las opciones disponibles en el menú para empezar a organizar tu jornada educativa.</p>
                    <hr />
                    <h3>¿Qué puedes hacer?</h3>
                    <ul style="font-size: 20px">
                        <li>Consultar y actualizar tu horario de clases.</li>
                        <li>Revisar el progreso de los aprendices.</li>
                        <li>Gestionar materiales de estudio y recursos para tus clases.</li>
                        <li>Acceder a la plataforma de comunicación con los aprendices.</li>
                    </ul>
                </div>
            </div>
        </div>
        <br />
    </div>
    <div style="background-color: #f9f9f9; padding: 20px; text-align: center;">
        <div style="display: flex; justify-content: center; gap: 20px; flex-wrap: wrap;">

            <a href="https://elblogcga.blogspot.com/" target="_blank" style="text-decoration: none;">
                <div style="text-align: center;">
                    <div style="width: 100px; height: 100px; border-radius: 50%; background: linear-gradient(135deg, #28a745 40%, #4db111 60%); display: flex; align-items: center; justify-content: center; color: white;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="48" height="48" viewBox="0 0 24 24" fill="white">
                            <path d="M19 5v14H5V5zm2-2H3v18h18zm-4 14H7v-1h10zm0-2H7v-1h10zm0-3H7V7h10z" />
                        </svg>
                    </div>
                    <p style="margin-top: 10px; color: #333;"><strong>BlogSena</strong></p>
                </div>
            </a>


            <a href="https://zajuna.sena.edu.co/" target="_blank" style="text-decoration: none;">
                <div style="text-align: center;">
                    <div style="width: 100px; height: 100px; border-radius: 50%; background: linear-gradient(135deg, #28a745 40%, #4db111 60%); display: flex; align-items: center; justify-content: center; color: white;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" viewBox="0 0 512 512">
                            <path fill="white" d="M85.16 16.84c-29.3.38-53.4 25.41-42.7 70.22l40.3 11.46c3.92-16.7 20.04-27.12 35.34-29.94l1.9-40.46c-11.2-7.76-23.44-11.43-34.84-11.28m87.64 1.79c-10.2-.1-21.8 3.62-34.2 12.26l-1.8 38.02c14.7 3.29 27.5 13.58 33.4 28.11l32.4-11.85c14.8-35.76-1.3-66.25-29.8-66.54m230.3 1.06c-9.7-.1-19.5 4.95-16.3 15.6c6 20.14 23.7 16.73 31-.34c4.2-9.92-5.1-15.16-14.8-15.25zm-112.3 5.65c-12.4-.14-24.2 11.9-12.9 35.55c-34.2-.71-21.3 46.81 4.4 33.51c-13.4 41.4 40.7 47.9 33.5 4.92c32.3 20.28 46.9-12.15 14.7-27.33c42.2-9.17 7.4-59.04-19.8-23.92c-.1-15.13-10.2-22.61-19.9-22.72zm10.3 39.21c6.3 0 11.4 5.08 11.4 11.34c0 6.27-5.1 11.34-11.4 11.34s-11.3-5.07-11.3-11.34c0-6.26 5-11.34 11.3-11.34m138.1 1.31c-17.4-.11-28.3 22.49 6.1 35.84c-18.3 24.8 32.7 47.4 24.4 5.4c42.7-1.3 17.2-56.74-8-26.56c-6.7-10.55-15.2-14.64-22.5-14.68M119.4 87.38C104.1 91.46 95.36 106.9 99.36 122c4.04 15.3 19.44 24.2 34.64 20.1c15.2-4 24.1-19.5 20-34.7c-3.4-12.9-15-21.25-27.7-21.01c-2.3.1-4.9.46-6.9.99m91.3 14.72l-37 13.5c-.3 11.7-4.8 22.6-12.4 31l28.3 28.8c43.7 3.5 62.4-49.3 21.1-73.3m-178.64 1.4c-36.199 29.3 5.9 104.9 44.2 92l23.5-42.2c-13.88-10.5-19.37-21.5-19.9-36.2zm367.24 20.8c-15 .2-31.8 9.8-46.5 32l11.4 49.3c1.5-.1 3 0 4.5.1c12.5.9 24.5 6.3 33.4 15.6l39.4-27.7c5.4-39.9-14.8-68.7-40.8-69.3zm79.1 28.1c-21 .6-22.3 18.6-7.7 30.1c17 13.2 29.9-30.7 7.7-30.1m-165.3 3.5c-40.1.4-74.3 32.3-43.4 88.4l46.1.1c3.3-18.7 15.2-28.7 30.1-35.1l-11.8-50.7c-6.9-1.9-14.1-2.8-21-2.7m-167 1.8c-9.1 4.1-20.5 4.9-29.2 3.1l-22.14 39.9c35.34 42.4 66.94 18.7 77.84-16zm298 57L412.3 237c4.8 11.9 4.9 24.8.8 36.3l36 21.3c51.6-7.4 55.5-71.5-5-79.9m-78.9 9.5c-5.5 0-11 1.4-16.1 4.3c-15.5 9-20.7 28.5-11.8 44c9 15.5 28.5 20.8 44 11.8c15.5-8.9 20.8-28.5 11.8-44c-5.6-9.7-15.3-15.4-25.6-16.1zM79.66 235.6c-34.7.5-57.8 31.9-33.3 81.6l53.2 16.7c7.64-14 21.24-24.2 37.44-27.3l-3-48.8c-18.1-15.5-37.54-22.5-54.34-22.2m113.94 2.8c-13.1.2-27.7 6.9-40.7 22.4l2.8 45.4c13.3 2.1 25.1 9.1 33.4 19.1l39.2-22.2c15.1-35.7-6.5-65.2-34.7-64.7m73 24.5c-30.8 56.4 24.9 96.3 68.2 80.7l11.3-40.1c-10.1-4.1-19.1-11.5-24.9-21.6c-3.5-6-5.5-12.3-6.4-18.8zm137.2 26.6c-3.6 4.3-8 8-13.1 11c-8.3 4.7-17.3 6.9-26.2 6.8l-12 42.6c33.6 38 90.6 1.2 86.5-39.6zM233 322l-34.6 19.5c5.7 15.8 2.9 34.4-5.1 47.4l30.2 31.7c67.6-28.1 48.5-74.9 9.5-98.6m-85.7 2.2c-19.9 0-35.8 16-35.8 35.8c0 19.9 15.9 35.8 35.8 35.8c19.8 0 35.7-15.9 35.7-35.8c0-19.8-15.9-35.8-35.7-35.8M40.46 334.9c-36.699 38.3-23 115.2 44 109.5l25.84-44.5c-14.61-13.3-19.79-30.8-16.74-48.3zm425.94 22c-15.5.1-41.5 23.1-13.8 29c-3.3 38 49.1 5.5 23-14c2-11.1-2.7-15.1-9.2-15m-119.2 24.4c-8 0-16.3 7.1-19.4 25.4c-23.9-30.7-58.2 4.6-20.5 26.8c-47.6 24.4 2.6 57 21.9 27.5c4.3 49.5 60.8 18.2 29.1-10.8c40.2 6.6 40.1-32.2 1-31c13.6-18.7 1.2-38-12.1-37.9m-166.4 21.5c-18.1 11.8-36 15.2-54.8 7.3l-28.94 49.8C118.7 511.3 218.5 487 217.4 439.3l-.9.9zm156.4 20.8c6.3 0 11.3 5.1 11.3 11.3c0 6.3-5 11.4-11.3 11.4s-11.3-5.1-11.3-11.4c0-6.2 5-11.3 11.3-11.3m108.1 7c-12.2-.4-16.2 20.1 6.4 32.9c-21.5 28.8 29.4 50.7 23.8 6.8c36.7 7 9.6-36.1-8.5-20.7c-7.8-13.5-15.7-18.8-21.7-19" />
                        </svg>
                    </div>
                    <p style="margin-top: 10px; color: #333;"><strong>Zajuna</strong></p>
                </div>
            </a>

            <a href="http://senasofiaplus.edu.co/sofia-public/" target="_blank" style="text-decoration: none;">
                <div style="text-align: center;">
                    <div style="width: 100px; height: 100px; border-radius: 50%; background: linear-gradient(135deg, #28a745 40%, #4db111 60%); display: flex; align-items: center; justify-content: center; color: white;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" viewBox="0 0 24 24">
                            <path fill="white" d="m13.666 1.429l6.75 3.98l.096.063l.093.078l.106.074a3.22 3.22 0 0 1 1.284 2.39l.005.204v7.284c0 1.175-.643 2.256-1.623 2.793l-6.804 4.302c-.98.538-2.166.538-3.2-.032l-6.695-4.237A3.23 3.23 0 0 1 2 15.502V8.217c0-1.106.57-2.128 1.476-2.705l6.95-4.098c1-.552 2.214-.552 3.24.015M13 7h-2a2 2 0 0 0-2 2v2a2 2 0 0 0 2 2h2v2h-2a1 1 0 0 0-2 0a2 2 0 0 0 2 2h2a2 2 0 0 0 2-2v-2a2 2 0 0 0-2-2h-2V9h2l.007.117A1 1 0 0 0 15 9a2 2 0 0 0-2-2" />
                        </svg>
                    </div>
                    <p style="margin-top: 10px; color: #333;"><strong>Sofía Plus</strong></p>
                </div>
            </a>

            <a href="https://www.sena.edu.co/es-co/Paginas/default.aspx" target="_blank" style="text-decoration: none;">
                <div style="text-align: center;">
                    <div style="width: 100px; height: 100px; border-radius: 50%; background: linear-gradient(135deg, #28a745 40%, #4db111 60%); display: flex; align-items: center; justify-content: center; color: white;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" viewBox="0 0 24 24">
                            <path fill="white" d="M7.41 8.49a1.72 1.72 0 0 1 1.425-.777h12.694c.4 0 .548.157.433.486c-.033.095-.085.2-.157.3l-.571.771c-.235.32-.563.56-.939.686c-.19.058-.347.139-.495.139H8.797c-.262 0-.51.09-.72.357a.4.4 0 0 0-.076.143c-.062.166.015.452.224.452H18.8c.595 0 .805.029.643.505c-.062.172-.134.32-.239.448l-2.595 3.5a1.9 1.9 0 0 1-1.425.787H2.466c-.395 0-.543-.157-.428-.486c.033-.095.085-.2.157-.3l1.734-2.334c.347-.462.828-.643 1.429-.69h10.145c.262 0 .51-.22.72-.477a.4.4 0 0 0 .076-.148c.048-.162-.014-.328-.21-.328H6.372c-.61 0-.833-.148-.671-.62c.047-.123.138-.271.257-.452L7.41 8.485z" />
                        </svg>
                    </div>
                    <p style="margin-top: 10px; color: #333;"><strong>PaginaSena</strong></p>
                </div>
            </a>
        </div>
    </div>
    <footer style="background-color: #f9f9f9; padding: 20px; font-size: 0.9em; color: #333;">
        <div class="container" style="display: flex; flex-wrap: wrap; align-items: center; justify-content: space-between; text-align: left;">

            <div style="flex: 1; max-width: 600px;">
                <p>
                    <strong style="font-size: 22px;">SERVICIO NACIONAL DE APRENDIZAJE SENA</strong><br>
                    DIRECCIÓN GENERAL<br>
                    Calle 57 No. 8 - 69 Bogotá D.C. (Cundinamarca), Colombia<br>
                    El SENA brinda a la ciudadanía atención presencial en las 33 Regionales y 117 Centros de Formación.<br>
                    <a href="#" style="color: #007bff; text-decoration: none;">Conozca aquí los puntos de atención</a>
                </p>
                <p>
                    Líneas de atención al aprendiz, instructores y coordinador:<br>
                    Duitama (+57) 323 419 51 09 - otras líneas de atención (+57) 301 170 88 55 - (+57) 310 261 42 79 - (+57) 311 593 68 46
                </p>
            </div>


            <div style="flex: 0 0 auto; text-align: center;">
                <img src="../icons/logoSena.png" alt="Logo SENA" style="width: 150px; margin-left: 20px;" />
            </div>
        </div>
    </footer>
</asp:Content>
