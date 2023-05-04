<%@ Page Language="C#" Title="Hasta Tetkik Detay Görüntüleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaTetkikDetay.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaTetkikDetay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h1 style="color: white;"><i class="fa-solid fa-vials"></i> Laboratuvar Sonuç Detay Görüntüleme</h1>

            <!-- -->
            <asp:GridView ID="tetkikDetaylari" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </main>
</asp:Content>