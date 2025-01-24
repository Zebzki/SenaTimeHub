<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Sena_TimeHub.vista.index1" %>

<!DOCTYPE html>
<style>
    .btn-login {
    background-color: #28a745; /* Verde */
    color: white; /* Color del texto */
    border: none; /* Elimina el borde */
    padding: 12px 20px;
    border-radius: 6px;
    font-size: 1em;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

    .btn-login:hover {
        background-color: #218838
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SENA TimeHub</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet"/>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"/>
    <link rel="icon" href="../icons/logoSena.png" />
    <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    
    <link href="styleIndex.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background-overlay"></div> 
<div class="container-fluid vh-100 d-flex justify-content-center align-items-center">
    <div class="card  p-4 text-center animate__animated animate__fadeIn" style="max-width: 400px; border-radius: 20px;">
        <div class="card-header bg-transparent border-0">
            <div class="d-flex align-items-center justify-content-center mb-2">
                <img src="../icons/logoSena.png" alt="Logo SENA" class="img-fluid" style="max-height: 50px; margin-right: 10px;"/>
                <h2  style="color:#28a745">SENA TimeHub</h2>
            </div>
            <p class="text-muted">Tu plataforma de gestión de tiempo</p>
        </div>
        <div class="card-body">
            <div class="mb-4">
                <i class="fas fa-user-clock fa-5x " style="color:#00324D"></i>
            </div>
            
                <div class="mb-3">
                    <label for="document" class="form-label">Usuario</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="fas fa-id-card"></i></span>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Email"></asp:TextBox>

                    </div>
                </div>
                <div class="mb-3">
                    <label for="password" class="form-label">Contraseña</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="fas fa-lock"></i></span>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    </div>
                </div>

                <div class="d-grid gap-2">
                   <asp:Button ID="btnLogin" runat="server" CssClass="btn-login btn-block animate__animated animate__pulse animate__infinite infinite"  Text="Iniciar Sesion" OnClick="btnLogin_Click"/>
                </div>
                <div class="text-center mt-3">
                    <a href="vista/recuperarContrasena.aspx" style="color:#00324D" class="fw-bold">¿Olvidaste tu contraseña?</a>
                </div>
           
        </div>
    </div>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
        <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
