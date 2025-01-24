<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listarAprendices.aspx.cs" Inherits="Sena_TimeHub.vista.listarAprendices" MasterPageFile="master.Master" %>

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
            padding: 10px;
            text-align: center;
            border-radius: 8px 8px 0 0;
        }


        .ficha-item {
            display: inline-block;
            width: 30%;
            margin: 10px 1%;
            text-align: center;
        }


        @media (max-width: 768px) {
            .ficha-item {
                width: 45%; /* Dos columnas en pantallas medianas */
            }
        }

        @media (max-width: 480px) {
            .ficha-item {
                width: 100%; /* Una columna en pantallas pequeñas */
            }
        }

        /* Botón */
        .btn {
            padding: 5px 10px;
            border: none;
            border-radius: 4px;
            color: white;
            cursor: pointer;
        }

        .btn-primary {
            background-color: #2e7d32;
        }

            .btn-primary:hover {
                background-color: #1b5e20;
            }


        .table {
            width: 100%;
            border-collapse: collapse;
            table-layout: fixed;
        }

            .table th,
            .table td {
                padding: 10px;
                text-align: left;
                border: 1px solid #4caf50;
                word-wrap: break-word;
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

    <!-- HiddenFields para mantener los estados -->
    <asp:HiddenField ID="hfSelectedFicha" runat="server" />
    <asp:HiddenField ID="hfAprendizId" runat="server" />

    <!-- Título principal -->
    <div class="grid-container">
        <h2 class="grid-title">Listar Aprendices</h2>

        <!-- Repeater para mostrar las fichas -->
        <asp:Repeater ID="repFichas" runat="server" OnItemCommand="repFichas_ItemCommand">
            <ItemTemplate>
                <div class="ficha-item">
                    <asp:LinkButton ID="btnFicha" runat="server" CommandName="Select"
                        CommandArgument='<%# Eval("idFicha") %>' CssClass="btn btn-primary">
                    <%# Eval("numeroFicha") %>
                    </asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Panel ID="pnlAprendices" runat="server" Visible="false" CssClass="grid-container">
            <div class="grid-title">Listado de Aprendices</div>
            <asp:GridView ID="gvAprendices" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" DataKeyNames="idUsuario" OnRowCommand="gvAprendices_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("idUsuario") %>' CssClass="btn btn-sm btn-primary" />

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="CustomDelete" CommandArgument='<%# Eval("idUsuario") %>' CssClass="btn btn-sm btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="nombre" HeaderText="Nombre" ItemStyle-Width="150px" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellido" ItemStyle-Width="150px" />
                    <asp:BoundField DataField="email" HeaderText="Correo Electrónico" ItemStyle-Width="300px" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

                <div class="table-controls">
        <button id="btnExportExcel" class="btn btn-success" onclick="ExportToExcel()">Exportar a Excel</button>
        <button id="btnPrint" class="btn btn-info" onclick="printTable()">Imprimir</button>

    </div>
 </div>
    <script type="text/javascript">

    function printTable() {
        var content = document.getElementById('<%= gvAprendices.ClientID %>').outerHTML;
        var printWindow = window.open('', '', 'height=1400,width=1600');
        printWindow.document.write('<html><head><title>Tabla de Aprendices</title></head><body>');
        printWindow.document.write(content);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    }
</script>

        <!-- Panel para editar un aprendiz -->
        <asp:Panel ID="pnlEditarAprendiz" runat="server" Visible="false" CssClass="grid-container">
            <h3>Editar Aprendiz</h3>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div>
                <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control" /><br />
                <asp:TextBox ID="txtApellido" runat="server" Placeholder="Apellido" CssClass="form-control" /><br />
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control" /><br />
            </div>
        </asp:Panel>
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
