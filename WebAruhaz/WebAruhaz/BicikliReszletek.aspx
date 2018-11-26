<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BicikliReszletek.aspx.cs" Inherits="WebAruhaz.BicikliReszletek" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%#: Page.Title %></h2>
            </hgroup>
            <asp:ListView runat="server" ID="BicikliList" DataKeyNames="BicikliID" ItemType="WebAruhaz.Models.Bicikli" GroupItemCount="4"></asp:ListView>
        </div>
    </section>
</asp:Content>
