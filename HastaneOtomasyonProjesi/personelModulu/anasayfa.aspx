<%@ Page Title="Personel İşlemleri" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1 style="color: white;">Personel Modülü</h1>
        <p style="color:white;">Bu modül ile personel ekleme, arama, görüntüleme işlemlerini gerçekleştirebilirsiniz.</p>
        <a href="personelEkleme.aspx"><button type="button" class="btn btn-success">+ Personel Ekleme</button></a>

        <!-- Persnel tablo -->
        <div class="personel_Tablosu">
            <asp:TextBox ID="hasta_Tc" CssClass="form-control" runat="server" />
            <asp:Button Text="Arama Yap" ID="arama_Yap" CssClass="btn btn-success" runat="server" />
        </div>
    </main>

</asp:Content>