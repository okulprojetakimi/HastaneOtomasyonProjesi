<%@ Page Language="C#" Title="Ameliyat Detay Görüntüleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ameliyatDetayGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.ameliyatDetayGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style>
            .labels{
                color: white;
            }
        </style>

        <h1 style="color: white;">Ameliyat Detayları</h1>
        <label class="labels">Ameliyat Giriş Tarihi: </label>
        <input type="date" id="ameliyatGirisTarihi" />
        <br />
        <br />
        <asp:Label Text="Ameliyat Çıkış Tarihi: " runat="server" />
        <input type="date" id="ameliyatCikisTarihi" />
        <br />
        <br />
        <label class="labels">Anestezi Türü: </label>
        <asp:TextBox CssClass="form-control" ID="ameliyatAnesteziTuru" runat="server" />

    </main>
</asp:Content>