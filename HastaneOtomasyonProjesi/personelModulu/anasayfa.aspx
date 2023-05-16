<%@ Page Title="Personel İşlemleri" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1 style="color: white;">Personel Modülü</h1>
        <p style="color:white;">Bu modül ile personel ekleme, arama, görüntüleme işlemlerini gerçekleştirebilirsiniz.</p>
        <a href="personelEkleme.aspx"><button class="btn btn-success">+ Personel Ekleme</button></a>

        <!-- Persnel tablo -->
        <div class="personel_Tablosu">
            
            <table cellpadding="15">
                <tr>
                    <td><label for="personel_Isim">Personel Isim: </label></td>
                    <td><asp:TextBox ID="personel_Isim" CssClass="form-control" runat="server" /></td>
                    <td><label for="personel_Soyisim">Personel Soyisim: </label></td>
                    <td><asp:TextBox ID="personel_Soyisim" CssClass="form-control" runat="server" /></td>
                    <td><asp:Button Text="Arama Yap" ID="arama_Yap" CssClass="btn btn-success" runat="server" /></td>
                </tr>
            </table>
        </div>
    </main>

</asp:Content>