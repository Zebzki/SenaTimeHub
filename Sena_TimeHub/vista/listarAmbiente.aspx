<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="listarAmbiente.aspx.cs" Inherits="Sena_TimeHub.vista.listarAmbiente" %>

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
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="grid-container">
        <div class="grid-title">Listado de Ambientes</div>
        <asp:GridView ID="gvAmbiente" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="gvAmbiente_RowCommand">
            <Columns>


                <asp:BoundField DataField="nombreAmbiente" HeaderText="Nombre del Ambiente" ItemStyle-Width="150px" />
                <asp:BoundField DataField="nombreSede" HeaderText="Nombre de la Sede" ItemStyle-Width="150px" />
                <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-Width="150px" />
                <asp:TemplateField HeaderText="Imagen del Ambiente">
                    <ItemTemplate>
                        <img src='<%# Eval("imagenAmbiente") %>' style="width: 100px; height: 100px;" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
                <div class="table-controls">
        <button id="btnExportExcel" class="btn btn-success" onclick="ExportToExcel()">Exportar a Excel</button>
        <button id="btnPrint" class="btn btn-info" onclick="printTable()">Imprimir</button>

    </div>
    </div>
    <script type="text/javascript">

    function printTable() {
        var content = document.getElementById('<%= gvAmbiente.ClientID %>').outerHTML;
        var printWindow = window.open('', '', 'height=1400,width=1600');
        printWindow.document.write('<html><head><title>Tabla de Ambientes:</title></head><body class="text-center">');
        printWindow.document.write(content);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    }
</script>
    


    <footer>
        &copy; 2024 Sena TimeHub. Todos los derechos reservados.

    </footer>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
