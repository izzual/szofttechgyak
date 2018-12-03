<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VasarloiKosar.aspx.cs" Inherits="WebAruhaz.VasarloiKosar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="VasarloiKosarCim" runat="server" class="Contenthead">
        <h1>Vásárlói kosár</h1>
        <asp:GridView ID="KosarLista" runat="server" AutoGenerateColumns="false" ShowFooter="true" 
            GridLines="Vertical" CellPadding="4" ItemType="WebAruhaz.Models.KosarElem" SelectMethod="GetVasarloiKosarElemek" 
            CssClass="table table-striped table-bordered">
            <Columns>
            <asp:BoundField DataField="BicikliID" HeaderText="ID" SortExpression="BicikliID" />
            <asp:BoundField DataField="Bicikli.ModelNev" HeaderText="Modell név" />

            <asp:BoundField DataField="Bicikli.Egysegar" DataFormatString="{0:c}" HeaderText="Egységár " />
            <asp:TemplateField HeaderText="Mennyiség">
                <ItemTemplate>
                    <asp:TextBox ID="VasaroltMennyiseg" Width="40" runat="server" Text="<%# Item.Mennyiseg %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tételek összesen">
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Mennyiseg))*Convert.ToDouble(Item.Bicikli.Egysegar))) %>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Tétel törlése">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        </asp:GridView>
        <div>
            <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Rendelés mindösszesen:"></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong>
        </div>
    </div>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button id="btnUpdate" runat="server" Text="Módosít" OnClick="btnUpdate_Click" />
            </td>
            <td>
                <!--visszaigazolas, ellenorzes -->
            </td>
        </tr>
    </table>
</asp:Content>
