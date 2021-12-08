<%@ Page Title="" Language="C#" MasterPageFile="~/view/EnSesion.Master" AutoEventWireup="true" CodeBehind="EnSesion.aspx.cs" Inherits="WebApplication3.view.EnSesion1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/StyleIS.css" rel="stylesheet" />
    <div>

        <hr />

        <h2>Datos Academicos</h2>
        <hr />
        <h3>Matricula</h3>
        <asp:Label ID="LBMatricula" runat="server"></asp:Label>
    </div>
</asp:Content>