﻿<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="insertarFicha.aspx.cs" Inherits="Sena_TimeHub.vista.insertarFicha" %>

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

        .form-container {
            background-color: #F8F9FA;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            width: 60%;
            max-width: 800px;
            margin: 50px auto 20px auto;
            overflow: hidden;
            box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1), 0 6px 6px rgba(0, 0, 0, 0.1);
        }

        @media (max-width: 992px) {
            .form-container {
                width: 80%;
            }
        }

        @media (max-width: 768px) {
            .form-container {
                width: 95%;
            }
        }

        @media (max-width: 480px) {
            .form-container {
                width: 100%;
                padding: 20px;
            }
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

        .form-group i {
            position: absolute;
            top: 65%;
            left: 12px;
            transform: translateY(-50%);
            color: #28a745;
            font-size: 1.2em;
            pointer-events: none;
        }

        .btn-submit {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 6px;
            font-size: 1em;
            cursor: pointer;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            transition: all 0.3s ease;
        }

            .btn-submit:active {
                transform: scale(0.98);
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            }

            .btn-submit:hover {
                background-color: #218838;
                box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
            }

        .alert {
            display: none;
            padding: 15px;
            border-radius: 6px;
            margin-bottom: 20px;
            color: #155724;
            background-color: #d4edda;
            border: 1px solid #c3e6cb;
        }

        .text-center {
            text-align: center;
        }

        .text-danger {
            color: #dc3545;
            font-size: 0.9em;
        }

        .background-decorations {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            overflow: hidden;
            z-index: -1;
        }

        .floating-dots {
            position: absolute;
            width: 10px;
            height: 10px;
            background-color: #28a745;
            border-radius: 50%;
            animation: float 60s ease-in-out infinite;
        }

        .circle {
            position: absolute;
            top: 20%;
            left: 10%;
            width: 150px;
            height: 150px;
        }

        .square {
            position: absolute;
            bottom: 10%;
            right: 15%;
            width: 100px;
            height: 100px;
        }

        @keyframes float {
            0%, 100% {
                transform: translateY(0);
            }

            50% {
                transform: translateY(-20px);
            }

            100% {
                transform: translate(0);
            }
        }



        .circle {
            animation: float 3s ease-in-out infinite;
        }

        .square {
            animation: float 3s ease-in-out infinite;
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
            box-shadow: 0px -4px 10px rgba(0,0,0,0.1);
        }

        .footer a {
            color: white;
            text-decoration: none;
        }

            .footer a:hover {
                text-decoration: underline;
            }

        .file-upload-container {
            display: flex;
            flex-direction: column;
            align-items: start;
            gap: 8px;
            max-width: 300px;
        }

            .file-upload-container label {
                font-weight: bold;
            }

            .file-upload-container input[type="file"] {
                padding: 6px;
                border: 1px solid #ccc;
                border-radius: 5px;
                background-color: #f8f9fa;
                cursor: pointer;
                transition: all 0.3s ease-in-out;
            }

                .file-upload-container input[type="file"]:hover {
                    background-color: #e9ecef;
                    transform: scale(1.05);
                    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
                }

        .form-group-jor {
            display: flex;
            flex-direction: column;
            align-items: start;
            gap: 8px;
        }

            .form-group-jor label {
                font-weight: bold;
            }

            .form-group-jor select {
                padding: 8px;
                border: 1px solid #ccc;
                border-radius: 5px;
                background-color: #f8f9fa;
                cursor: pointer;
                transition: all 0.3s ease-in-out;
                width: 100%;
            }

                .form-group-jor select:hover {
                    background-color: #e9ecef;
                    transform: scale(1.05);
                    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
                }

        .form-group-pro {
            display: flex;
            flex-direction: column;
            align-items: start;
            gap: 8px;
        }

            .form-group-pro select {
                padding: 6px;
                border: 1px solid #ccc;
                border-radius: 5px;
                background-color: #f8f9fa;
                cursor: pointer;
                transition: all 0.3s ease-in-out;
                width: 100%;
            }

                .form-group-pro select:hover {
                    transform: scale(1.05);
                    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
                }

      
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-container">
        <h2 class="form-title">Registro de Ficha</h2>



        <asp:Label runat="server" ID="lblM" CssClass="form-label"></asp:Label>
        <asp:Label ID="lblMensaje" runat="server" CssClass="form-label"></asp:Label>

        <!-- Form fields -->
        <div class="form-group">
            <asp:Label ID="lblNumeroFicha" runat="server" Text="Número de Ficha" CssClass="form-label" AssociatedControlID="txtNumeroFicha"></asp:Label>
            <asp:TextBox ID="txtNumeroFicha" runat="server" CssClass="form-control" placeholder="Ingrese el número de ficha" required="required"></asp:TextBox>
        </div>

        <div class="form-group-text">
            <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha de Inicio" CssClass="form-label" AssociatedControlID="txtFechaInicio"></asp:Label>
            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date" required="required" />
        </div>

        <div class="form-group-text">
            <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final" CssClass="form-label" AssociatedControlID="txtFechaFinal"></asp:Label>
            <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="form-control" TextMode="Date" required="required" />
        </div>
        <div class="form-group-pro">
            <asp:Label ID="lblPrograma" runat="server" Text="Programa" CssClass="form-label" AssociatedControlID="ddlPrograma"></asp:Label>
            <asp:DropDownList ID="ddlPrograma" runat="server" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="false">
                <asp:ListItem Text="Seleccione un programa" Value="0" />
            </asp:DropDownList>
        </div>
        <div class="form-group-jor">
            <asp:Label ID="lblJornadaFicha" runat="server" Text="Jornada" CssClass="form-label" AssociatedControlID="ddlJornadaFicha"></asp:Label>
            <asp:DropDownList ID="ddlJornadaFicha" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione..." Value="0"></asp:ListItem>
                <asp:ListItem Text="Mañana" Value="Mañana"></asp:ListItem>
                <asp:ListItem Text="Tarde" Value="Tarde"></asp:ListItem>
                <asp:ListItem Text="Noche" Value="Noche"></asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="form-group-jor">
            <asp:Label ID="lblSede" runat="server" Text="Sede" CssClass="form-label" AssociatedControlID="ddlSede"></asp:Label>

            <asp:DropDownList ID="ddlSede" runat="server" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="false">
                <asp:ListItem Text="Seleccione una sede" Value="0"></asp:ListItem>

            </asp:DropDownList>

        </div>
        <div class="form-group-jor">
       <asp:Label ID="lblSede" runat="server" Text="Sede" CssClass="form-label" AssociatedControlID="ddlSede"></asp:Label>

       <asp:DropDownList ID="ddlSede" runat="server" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="false">
           <asp:ListItem Text="Seleccione una sede" Value="0"></asp:ListItem>

       </asp:DropDownList>

   </div>
        <div class="file-upload-container">
            <label for="fuUsuarios" class="form-label">Subir Excel de Aprendices:</label>
            <asp:FileUpload ID="fuUsuarios" runat="server" CssClass="form-control" />
        </div>
        <br />
        <div class="form-group">
            <asp:Button ID="btnGuardarFicha" runat="server" Text="Guardar" CssClass="btn-submit" OnClick="btnGuardarFicha_Click" />
        </div>
    </div>
    <div class="background-decorations">
        <svg class="circle" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100">
            <circle cx="50" cy="50" r="50" fill="#28a745" opacity="0.1" />
        </svg>
        <svg class="square" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100">
            <rect width="100" height="100" fill="#28a745" opacity="0.1" />
        </svg>
    </div>


    <footer>
        &copy; 2024 Sena TimeHub. Todos los derechos reservados.
   
    </footer>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
