<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="insertarPrograma.aspx.cs" Inherits="Sena_TimeHub.vista.insertarPrograma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Importación de Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />

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
            box-shadow:0 4px 6px rgba(0, 0, 0, 0.1); 
            transition: all 0.3s ease;
        }
        .btn-submit:active{
            transform:scale(0.98);
            box-shadow:0 4px 8px rgba(0, 0, 0, 0.2);
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
            position:relative;
            bottom:0;
            width:100%;
            color: #6c757d;
            font-size: 0.9em;
            box-shadow: 0px -4px 10px rgba(0,0,0,0.1);
        }
        .footer a{
            color:white;
            text-decoration:none;
        }
        .footer a:hover{
            text-decoration:underline;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-container">
        <h2 class="form-title">Registrar Programa</h2>

        <!-- Panel for Success Message -->
        <asp:Panel ID="pnlAlert" runat="server" CssClass="alert" Visible="false">
            <asp:Literal ID="litAlert" runat="server"></asp:Literal>
        </asp:Panel>

        <!-- Form fields -->
        <div class="form-group">
            <i class="fas fa-book"></i>
            <asp:Label ID="lblPrograma" runat="server" Text="Nombre del Programa" CssClass="form-label" AssociatedControlID="txtPrograma"></asp:Label>

            <asp:TextBox ID="txtPrograma" runat="server" CssClass="form-control" placeholder="Programa de Formación"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valPrograma" runat="server" ControlToValidate="txtPrograma" ErrorMessage="¡Este campo es obligatorio!" CssClass="text-danger" Display="Dynamic" ValidationGroup="error" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblVersion" runat="server" Text="Versión" CssClass="form-label" AssociatedControlID="txtVersion"></asp:Label>
            <i class="fas fa-code-branch"></i>
            <asp:TextBox ID="txtVersion" runat="server" CssClass="form-control" placeholder="Versión del Programa"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valVersion" runat="server" ControlToValidate="txtVersion" ErrorMessage="¡Este campo es obligatorio!" CssClass="text-danger" Display="Dynamic" ValidationGroup="error" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblCodigo" runat="server" Text="Código" CssClass="form-label" AssociatedControlID="txtCodigo"></asp:Label>
            <i class="fas fa-barcode"></i>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Código del Programa"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="¡Este campo es obligatorio!" CssClass="text-danger" Display="Dynamic" ValidationGroup="error" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblTipo" runat="server" Text="Tipo" CssClass="form-label" AssociatedControlID="txtTipo"></asp:Label>
            <i class="fas fa-tags"></i>
            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" placeholder="Tipo del Programa"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valTipo" runat="server" ControlToValidate="txtTipo" ErrorMessage="¡Este campo es obligatorio!" CssClass="text-danger" Display="Dynamic" ValidationGroup="error" />
        </div>

        <div class="form-group text-center">
            <asp:Button ID="btnRegistrarProducto" runat="server" Text="Registrar" CssClass="btn-submit" OnClick="btnRegistrarProducto_Click" ValidationGroup="error" />
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
