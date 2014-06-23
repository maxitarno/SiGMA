<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SiGMA.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Login ID="login" runat="server" onauthenticate="login_Authenticate">
    </asp:Login>
</asp:Content>
