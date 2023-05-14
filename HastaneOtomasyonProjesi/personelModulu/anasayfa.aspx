<%@ Page Title="Personel İşlemleri" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1 style="color: white;">Personel Modülü</h1>
        <p style="color:white;">Bu modül ile personel ekleme, arama, görüntüleme işlemlerini gerçekleştirebilirsiniz.</p>
        <a href="personelEkleme.aspx"><button class="btn btn-success">+ Personel Ekleme</button></a>

        <!-- Persnel tablo -->
        <div class="personel_Tablosu">

        </div>
    </main>

</asp:Content>