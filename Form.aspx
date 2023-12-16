<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="EncuestasUTC.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container text-center">
        <h1>FOMULARIO DE ENCUESTA</h1>
      </div>
  
    <div class="container text-center">
        Nombre: <asp:TextBox ID="tNom" class="form-control" runat="server"></asp:TextBox>
        Edad: <asp:TextBox ID="tEdad" class="form-control" runat="server"></asp:TextBox>
        CorreoElec: <asp:TextBox runat="server" ID="tCore" CssClass="form-control" type="email" required="true"/>
      <label for="Partidos" class="form-label">Partidos:</label>
      <asp:DropDownList ID="DropList"  class="form-control" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
    </div>
    <div class="container text-center">

        <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Añadir" OnClick="Button1_Click"  /> 
  

    </div>
</asp:Content>
