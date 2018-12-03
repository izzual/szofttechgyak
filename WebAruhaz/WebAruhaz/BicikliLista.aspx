<%@ Page Title="Biciklik" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BicikliLista.aspx.cs" Inherits="WebAruhaz.BicikliLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:ListView runat="server" ID="BicikliList" DataKeyNames="BicikliID" GroupItemCount="4" 
                ItemType="WebAruhaz.Models.Bicikli" SelectMethod="GetBiciklik">
           <EmptyDataTemplate>
             <table>
               <tr>
                 <td>Nincs adat</td>
              </tr>
            </table>
          </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
           <ItemTemplate>
               <td runat="server">
                   <table>
                       <tr>
                           <td>
                               <a href="BicikliReszletek.aspx?bicikliID=<%#:Item.BicikliID %>">
                                   <img src="/Catalog/Thumbs/<%#:Item.Kepfajl %>" width="100" 
                                       height="75" style="border:solid" />
                               </a>
                           </td>
                       </tr>
                       <tr>
                           <td>
                               <a href="BicikliReszletek.aspx?bicikliID=<%#: Item.BicikliID %>">
                                   <span>
                                       <%#: Item.ModelNev %>
                                   </span>
                               </a>
                               <br />
                               <span>
                                   <b >Ár: </b><%#:String.Format("{0:c}",Item.Egysegar) %>
                               </span>
                               <br />
                               <a href="/KosarbaTesz.aspx?bicikliID=<%#:Item.BicikliID %>">
                                   <span class="BicikliListaElem">
                                       <b>Kosárba tesz</b>
                                   </span>
                               </a>
                           </td>
                       </tr>
                       <tr>
                           <td>&nbsp;</td>
                       </tr>
                   </table>
                   <p></p>
               </td>
           </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
