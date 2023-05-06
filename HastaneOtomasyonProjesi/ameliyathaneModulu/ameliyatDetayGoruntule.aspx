<%@ Page Language="C#" Title="Ameliyat Detay Görüntüleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ameliyatDetayGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.ameliyatDetayGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style>
            .labels{
                color: white;
            }
        </style>

        <h1 style="color: white;">Ameliyat Detayları</h1>
        <table cellpadding="15">

            <tr>
                <td><label class="labels">Ameliyat Giriş Tarihi: </label></td>
                <td>
                    <asp:TextBox CssClass="form-control" runat="server" ID="ameliyat_GirisT" Text="" ReadOnly="True" /></td>
                <td><label class="labels">Ameliyat Çıkış Tarihi: </label></td>
                <td>
                    <asp:TextBox CssClass="form-control" ID="ameliyat_CikisT" runat="server" Text="" ReadOnly="True" /></td>
            </tr>
            <tr>
                <td><label class="labels">Anestezi Türü: </label></td>
                <td><asp:TextBox CssClass="form-control" ID="ameliyatAnesteziTuru" runat="server" ReadOnly="True" /></td>
                <td><label class="labels">Ameliyata giren doktor: </label></td>
                <td>
                    <asp:TextBox CssClass="form-control" runat="server" ID="ameliyat_Doktor" ReadOnly="True"/>
                </td>
            </tr>
            <tr>
                <td><label class="labels">Ameliyata giren hasta: </label></td>
                <td>
                    <asp:TextBox TextMode="MultiLine" CssClass="form-control" runat="server" ID="ameliyat_Not" ReadOnly="True"/></td>
            </tr>
        </table>
        <br />
        <br />
        <h1 style="color: white;"><i class="fa-solid fa-list-ol"></i> Kullanılan İlaçlar</h1>
        <div>

            <asp:GridView ID="ameliyatKullanilan_Tablo" runat="server" CellPadding="15" ForeColor="#333333" GridLines="None" EmptyDataText="Eklenmiş bir ilaç bulunamadı!">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

        </div>
        
    </main>
</asp:Content>