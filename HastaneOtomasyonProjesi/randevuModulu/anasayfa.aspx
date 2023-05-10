<%@ Page Language="C#" Title="Randevu Sistemi" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.randevuModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-days"></i> Randevu Sistemi</h1>
        <br />
        <table>
            <tr>
                <td><button type="button" id="randevu_EkleButon" class="btn btn-success">+ Yeni Randevu Ekle</button></td>
                <td><button type="button" id="randevu_Ara" class="btn btn-success"><i class="fa-solid fa-magnifying-glass"></i> Randevu Ara</button></td>
            </tr>
        </table>
    </main>
</asp:Content>