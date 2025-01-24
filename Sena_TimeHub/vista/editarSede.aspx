<%@ Page Title="" Language="C#" MasterPageFile="~/vista/master.Master" AutoEventWireup="true" CodeBehind="editarSede.aspx.cs" Inherits="Sena_TimeHub.vista.editarSede" %>
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
      <h2 class="form-title">Edicion De Sedes</h2>
      <div class="form-group">
          <label class="form-label">Nombre de Sede</label>
          <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
      </div>
      <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
      
      <div class="form-group">
          <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn-submit btn-outline-primary" />

      </div>
  </div>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
