<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="insertarArea.aspx.cs" Inherits="Sena_TimeHub.vista.insertarArea" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
            body {
        justify-content: center;
        align-items: center;
        min-height: 100vh;
        margin: 0;
        background-color: #f8f9fa;
        
    }

    .form-container {
        background-color:#F8F9FA;
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
        color:  #28a745;
    }

    .form-control {
        width: 100%;
        padding: 8px;
        border: 1px solid  #28a745;
        border-radius: 4px;
    }

    .btn-submit {
        justify-content:center;
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
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-container">
        <h3 class="form-title">Agregar Área</h3>

        
        <asp:Panel ID="pnlAlert" runat="server" CssClass="alert" Visible="false">
            <asp:Literal ID="litAlert" runat="server"></asp:Literal>
        </asp:Panel>

        
        <div class="form-group">
            <asp:Label ID="lblNombreArea" runat="server" Text="Nombre del Área" CssClass="form-label" AssociatedControlID="txtNombreArea"></asp:Label>
            <asp:TextBox ID="txtNombreArea" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del área"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valNombreArea" runat="server" ControlToValidate="txtNombreArea" ErrorMessage="El nombre del área es obligatorio" CssClass="text-danger" Display="Dynamic" ValidationGroup="error" />
        </div>

        <div class="form-group">
    <asp:Label ID="lblTipo" runat="server" Text="Tipo del Área" CssClass="form-label" AssociatedControlID="txtTipoArea"></asp:Label>
    <asp:TextBox ID="txtTipoArea" runat="server" CssClass="form-control" placeholder="Ingrese el Tipo del área"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTipoArea" ErrorMessage="El Tipo del área es obligatorio" CssClass="text-danger" Display="Dynamic" ValidationGroup="error" />
</div>

        <div class="form-group">
            <asp:Button ID="btnRegistrarArea" runat="server" Text="Registrar" CssClass="btn-submit" OnClick="btnRegistrarArea_Click" ValidationGroup="error" />
        </div>
    </div>
</asp:Content>
