<%@ Page Language="C#" Title="Hasta Görüntüle" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-user"></i>Hasta Görüntüleme</h1>
        <table cellpadding="15">
            <tr>
                <td>
                    <asp:Button runat="server" ID="hastaNotEkleme" CssClass="btn btn-success" Text="+ Hastaya Not Ekle" OnClick="hastaNotEkleme_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="hastaIlacEkleme" CssClass="btn btn-info" Text="+ Hastaya İlaç Ekle" OnClick="hastaIlacEkleme_Click" /></td>
            </tr>
        </table>

        <!-- Hasta Bilgileri  -->
        



    </main>
</asp:Content>
