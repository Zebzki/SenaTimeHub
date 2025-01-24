<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="listarInstructor.aspx.cs" Inherits="Sena_TimeHub.vista.listarInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .grid-container {
            background-color: #F8F9FA;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            max-width: 100%;
            overflow-x: auto;
            margin: 80px auto 20px auto;
        }

        .grid-title {
            background-color: #28a745;
            color: white;
            padding: 20px; /* Ajusta el padding según necesites */
            text-align: center;
            border-radius: 12px 12px 0 0;
            font-size: 1.5em;
            font-weight: bold;
            width: 100%; /* Asegura que el fondo verde abarque todo el ancho */
            margin: 0; /* Elimina cualquier margen adicional */
            box-sizing: border-box; /* Incluye el padding dentro del tamaño total */
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            table-layout: fixed;
        }

            .table th, .table td {
                padding: 10px;
                text-align: left;
                border: 1px solid #4caf50;
                word-wrap: break-word; /* Rompe las palabras largas */
            }

            .table th {
                background-color: #28a745;
                color: white;
            }

        .btn {
            padding: 5px 10px;
            border: none;
            border-radius: 4px;
            color: white;
            cursor: pointer;
        }

        .btn-sm {
            font-size: 12px;
        }

        .btn-primary {
            background-color: #2e7d32;
        }

            .btn-primary:hover {
                background-color: #1b5e20;
            }

        .btn-danger {
            background-color: #d32f2f;
        }

            .btn-danger:hover {
                background-color: #b71c1c;
            }
        /* Tabla principal */
        .tabla-usuarios {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            font-size: 16px;
            text-align: left;
        }

            /* Encabezados */
            .tabla-usuarios th {
                background-color: #4CAF50;
                color: white;
                padding: 10px;
                text-align: center;
            }

            /* Filas */
            .tabla-usuarios td {
                word-wrap: break-word;
                max-width: 300px; /* Ajusta el máximo ancho permitido */
                overflow: hidden;
                text-overflow: ellipsis; /* Muestra '...' si el texto es muy largo */
                white-space: nowrap; /* Evita que el texto ocupe varias líneas */
            }

            /* Alternar colores en las filas */
            .tabla-usuarios tr:nth-child(even) {
                background-color: #f2f2f2;
            }

        /* Botón Editar */
        .btn-editar {
            background-color: #4CAF50;
            color: white;
            padding: 5px 10px;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }

        /* Botón Eliminar */
        .btn-eliminar {
            background-color: #f44336;
            color: white;
            padding: 5px 10px;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }

            /* Hover para botones */
            .btn-editar:hover,
            .btn-eliminar:hover {
                opacity: 0.8;
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
        <div class="grid-title">Listado de Instructores</div>
        <asp:GridView ID="gvInstructor" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="gvInstructor_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("idUsuario") %>' CssClass="btn btn-sm btn-primary" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idUsuario") %>' CssClass="btn btn-sm btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="nombre" HeaderText="Nombre" ItemStyle-Width="150px" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" ItemStyle-Width="150px" />
                <asp:BoundField DataField="tipoDocumento" HeaderText="Tipo de Documento" ItemStyle-Width="50px" />
                <asp:BoundField DataField="documento" HeaderText="Documento" ItemStyle-Width="200px" />
                <asp:BoundField DataField="email" HeaderText="Correo Electrónico" ItemStyle-Width="300px" />
            </Columns>
        </asp:GridView>



                  <div class="table-controls">
        <button id="btnExportExcel" class="btn btn-success" onclick="ExportToExcel()">Exportar a Excel</button>
        <button id="btnPrint" class="btn btn-info" onclick="printTable()">Imprimir</button>

    </div>
    <script type="text/javascript">

    function printTable() {
        var content = document.getElementById('<%= gvInstructor.ClientID %>').outerHTML;
        var printWindow = window.open('', '', 'height=1400,width=1600');
        printWindow.document.write('<html><head><title>Tabla de Instructores:</title></head><body>');
        printWindow.document.write(content);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    }
</script>

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
