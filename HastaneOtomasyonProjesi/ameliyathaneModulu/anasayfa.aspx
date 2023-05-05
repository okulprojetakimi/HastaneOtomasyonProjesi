<%@ Page Language="C#" Title="Ameliyathane Modülü Anasayfa" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-stretcher"></i> Bugünkü Ameliyatlar</h1>
        <asp:Button CssClass="btn btn-success" ID="yeniKayit_ekle" Text="+ Yeni ameliyat kaydı ekle" runat="server" />
    </main>
</asp:Content>