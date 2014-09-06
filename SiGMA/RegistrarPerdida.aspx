<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPerdida.aspx.cs" Inherits="SiGMA.RegistrarPerdida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!-- encabezado -->
<!-- fin encabezado -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h1 class="panel-title">
                    Mascota Perdida
                </h1>
            </div>
            <div class="panel-body">
               <div class="almedio">
                     <asp:Panel runat="server" ID="pnlCorrecto" class="alert alert-dismissable alert-success"
                        Visible="false">
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                        Visible="false">
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlAtento" class="alert alert-dismissable alert-danger"
                        Visible="false">
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </asp:Panel>

               </div>
            </div>
        </div>
    </div>
</asp:Content>
