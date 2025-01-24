<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="insertarSede.aspx.cs" Inherits="Sena_TimeHub.vista.insertarSede" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* Center the form container and make it larger */
        body {
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            margin: 0;
            background-color: #f8f9fa;
        }

        .form-container {
            background-color: #F8F9FA;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            width: 60%;
            max-width: 800px;
            margin: 50px auto 20px auto;
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
            padding: 10px;
            text-align: center;
            border-radius: 8px 8px 0 0;
            margin: -40px -40px 30px -40px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-label {
            display: block;
            margin-bottom: 5px;
            color: #28a745;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            border: 1px solid #28a745;
            border-radius: 4px;
        }

        .btn-submit {
            justify-content: center;
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 4px;
            cursor: pointer;
        }

            .btn-submit:hover {
                background-color: #1b5e20;
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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-container">
        <h3 class="form-title">Registrar Sede</h3>

        <!-- Panel for Success Message -->
        <asp:Panel ID="pnlAlert" runat="server" CssClass="alert alert-success" Visible="false">
            <contenttemplate>
                <div class="text-green-600">
                    <asp:Literal ID="litAlert" runat="server"></asp:Literal>
                </div>
            </contenttemplate>
        </asp:Panel>

        <!-- Form fields -->
        <div class="form-group">
            <asp:Label ID="lblSede" runat="server" Text="Nombre De La Sede" CssClass="form-label" AssociatedControlID="txtSede"></asp:Label>
            <asp:TextBox ID="txtSede" runat="server" CssClass="form-control" placeholder="Nombre De La Sede"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valSede" runat="server" ControlToValidate="txtSede" ErrorMessage="Campo de Sede Obligatorio!" CssClass="text-danger" Display="Dynamic" ValidationGroup="error" />
        </div>

        <asp:Label ID="lblMensage" runat="server" Text="" ForeColor="Red"></asp:Label>


        <div class="form-group">
            <asp:Button ID="btnRegistrarSede" runat="server" Text="Registrar" CssClass="btn-submit" OnClick="btnRegistrarSede_Click" ValidationGroup="error" />
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
</asp:Content>

