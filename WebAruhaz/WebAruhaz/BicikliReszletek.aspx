<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BicikliReszletek.aspx.cs" Inherits="WebAruhaz.BicikliReszletek" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="Reszletek" ItemType="WebAruhaz.Models.Bicikli" DataKeyNames="BicikliID" RenderOuterTable="False" SelectMethod="Egybicikli">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ModelNev %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/<%#:Item.Kepfajl %>"
                            style="border: solid; height: 300px" alt="<%#:Item.ModelNev %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Gyártó:</b><br />
                        <%#:Item.Gyarto %><br />
                        <span><b>Ár:</b>&nbsp;<%#:String.Format("{0:c}",Item.Egysegar) %></span>
                        <br />
                        <span>
                            <b>Típus:</b>&nbsp;<%#:Item.Tipus %></span>
                        <br />
                        <span><b>Bicikli kód:</b>&nbsp;<%#:Item.BicikliID %></span><br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
