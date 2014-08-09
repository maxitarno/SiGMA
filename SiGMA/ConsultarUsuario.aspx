<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs" Inherits="SiGMA.ConsultarUsuario" MasterPageFile="Site.Master" %>

<asp:Content ContentPlaceHolderID=HeadContent runat=server>
    
</asp:Content>
<asp:Content ContentPlaceHolderID=MainContent runat=server>
     <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Consultar usuarios</h3>
        </div>
        <div class="panel-body">
            <div class="almedio">
            <table>
                <tr style="display:inline">
                    <td>
                        Por persona&nbsp<asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1" ValidationGroup="1" />&nbsp&nbsp&nbsp
                    </td>
                    <td>
                        Por usuario&nbsp<asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1" ValidationGroup="1" />
                    </td>
                </tr>
                <tr>
                    
                </tr>
                <tr>
                    
                </tr>
                <tr>
                    
                </tr>
                <tr>
                    
                </tr>
                <tr>
                    
                </tr>
                <tr>
                    
                </tr>
                <tr>
                   
                </tr>
                <tr>
                    
                </tr>
            </table>
            </div>
        </div>
    </div>
</asp:Content>