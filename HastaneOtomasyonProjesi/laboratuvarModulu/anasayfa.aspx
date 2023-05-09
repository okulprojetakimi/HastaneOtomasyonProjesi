<%@ Page Language="C#" Title="Laboratuvar Modülü" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.laboratuvarModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-flask"></i> Laboratuvar Modülü</h1>

        <!-- Hasta tablosu -->
        <div class="hastaArama_Form">
            <table cellpadding="15">
                <tr>
                    <td>Aranacak Hasta İsmi <asp:TextBox CssClass="form-control" ID="hasta_Isim" runat="server" /></td>
                    <td>Aranacak Hasta Soyismi: <asp:TextBox CssClass="form-control" ID="hasta_Soyisim" runat="server" /></td>
                </tr>
            </table>
            <asp:Button CssClass="btn btn-success" Text="Hasta Ara" runat="server" />
        </div>
        <asp:GridView ID="hastaTablo" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="Listelenecek Hasta Yok!">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        <br />
        <div class="hasta_Listesi">

        </div>
    </main>
</asp:Content>