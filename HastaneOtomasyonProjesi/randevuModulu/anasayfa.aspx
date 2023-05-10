<%@ Page Language="C#" Title="Randevu Sistemi" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.randevuModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-days"></i> Randevu Sistemi</h1>
        <p style="color: white;">Bu sayfada randevu işlemlerini gerçekleştirebilirsiniz.</p>
        <br />
        <table cellpadding="12">
            <tr>
                <td><a href="hastaRandevuEkle.aspx"><button type="button" id="randevu_EkleButon" class="btn btn-success">+ Yeni Randevu Ekle</button></a></td>
                <td><button type="button" id="randevu_Ara" class="btn btn-success"><i class="fa-solid fa-magnifying-glass"></i> Randevu Ara</button></td>

            </tr>
        </table>
    </main>
</asp:Content>