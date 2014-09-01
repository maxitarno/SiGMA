<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imagenes.aspx.cs" Inherits="SiGMA.Imagenes" MasterPageFile="Site.Master" %>
<asp:Content ContentPlaceHolderID=HeadContent runat=server>

</asp:Content>
<asp:Content ContentPlaceHolderID=MainContent runat=server>
    <div class="almedio">
        <table>
            <tr>
                <td>
                    <asp:Image ID="imgImage1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAceptar" runat="server" Text="Button" OnClick="BtnOrigenClick"/>
                </td>
            </tr>
        </table>
     </div>
</asp:Content>
