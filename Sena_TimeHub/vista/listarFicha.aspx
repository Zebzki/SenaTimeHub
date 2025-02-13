<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="listarFicha.aspx.cs" Inherits="Sena_TimeHub.vista.listarFicha_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet">
    <style>
        /* Estilos del contenedor */
        .grid-container {
            background-color:#F8F9FA;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            max-width: 100%;
            overflow-x: auto;
            margin: 80px auto 20px auto;
        }

        /* Título del grid */
        .grid-title {
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

        /* Estilos para el GridView */
        .table {
            width: 100%;
            border-collapse: collapse;
            table-layout: fixed;
        }

        .table th, .table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #4caf50;
            word-wrap: break-word;
        }

        .table th {
            background-color: #28a745;
            color: white;
        }

        /* Estilos del botón de acción */
        .btn-action {
            background-color: #28a745;
            color: white;
            padding: 8px 16px;
            border-radius: 4px;
            transition: background-color 0.3s ease;
        }

        .btn-action:hover {
            background-color: #1b5e20;
        }

        /* Fondo decorativo */
        .background-decorations {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            overflow: hidden;
            z-index: -1;
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

        footer {
            text-align: center;
            padding: 10px;
            margin-top: 30px;
            color: #6c757d;
            font-size: 0.9em;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="grid-container">
        <div class="grid-title">Listado de Fichas</div>

        <asp:GridView ID="gvFichas" runat="server" CssClass="table" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvFichas_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="numeroFicha" HeaderText="Número de Ficha" />
                <asp:BoundField DataField="nombrePrograma" HeaderText="Programa" />
                <asp:BoundField DataField="fechaInicio" HeaderText="Fecha de Inicio" />
                <asp:BoundField DataField="fechaFinal" HeaderText="Fecha Final" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:BoundField DataField="jornada" HeaderText="Jornada" />
            </Columns>
        </asp:GridView>

        <div class="mt-6 text-center">
            Página: <asp:Label ID="lblPaginaActual" runat="server" Text="1"></asp:Label>
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