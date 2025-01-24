<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="listarSede.aspx.cs" Inherits="Sena_TimeHub.vista.listarSede" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style>
    /* Contenedor del GridView */
    .grid-container {
        background-color: #e6ffee;
        padding: 40px;
        border-radius: 8px;
        box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        max-width: 100%; /* Se adapta al ancho de la pantalla */
        overflow-x: auto; /* Habilita scroll horizontal si el contenido desborda */
        margin: 20px auto; /* Centra el contenedor */
    }

    .grid-title {
        background-color: #2e7d32;
        color: white;
        padding: 10px;
        text-align: center;
        border-radius: 8px 8px 0 0;
    }

    .table {
        width: 100%;
        border-collapse: collapse;
        table-layout: fixed; /* Distribuye el ancho de las columnas de manera uniforme */
    }

    .table th, .table td {
        padding: 10px;
        text-align: left;
        border: 1px solid #4caf50;
        word-wrap: break-word; /* Rompe las palabras largas */
    }

    .table th {
        background-color: #2e7d32;
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
 .table-controls {
    text-align: center;
    margin-bottom: 10px;
}

.table-controls .btn {
    margin: 0 5px;
}

#btnExportExcel, #btnPrint {
    padding: 8px 15px;
    font-size: 14px;
    border-radius: 5px;
}

#btnExportExcel {
    background-color: #28a745;
    color: white;
}

#btnPrint {
    background-color: #17a2b8;
    color: white;
}


</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
        <div class="grid-container">
        <div class="grid-title">Listado de Sedes</div>
        <asp:GridView ID="gvSede" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="gvSede_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div style="text-align: center;">

                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("idSede") %>' CssClass="btn btn-sm btn-primary text-center" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="nombreSede" HeaderText="Nombre" ItemStyle-Width="150px"/>
            </Columns>
        </asp:GridView>
                  <div class="table-controls">
        <button id="btnExportExcel" class="btn btn-success" onclick="ExportToExcel()">Exportar a Excel</button>
        <button id="btnPrint" class="btn btn-info" onclick="printTable()">Imprimir</button>

    </div>
    <script type="text/javascript">

    function printTable() {
        var content = document.getElementById('<%= gvSede.ClientID %>').outerHTML;
        var printWindow = window.open('', '', 'height=1400,width=1600');
        printWindow.document.write('<html><head><title class="grid-title">Tabla de Sedes</title></head><body>');
        printWindow.document.write(content);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    }
</script>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
