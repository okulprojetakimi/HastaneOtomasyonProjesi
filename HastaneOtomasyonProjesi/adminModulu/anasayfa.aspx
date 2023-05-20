<%@ Page Language="C#" Title="Admin Modülü" MasterPageFile="~/adminModulu/adminTema.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.adminModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-gear"></i> ADMİN MODÜLÜ</h1>
        <p><font style="font-size: 35px; color: red;">Uyarı!</font> <font style="color: white;">Sistem yöneticisi dışında bir personelin erişmesi yasaktır!</font></p>
        <br />
        <table cellpadding="15">
            <tr>
                <td><a href="bakimModuAyar.aspx"><button type="button" class="btn btn-warning"><i class="fa-solid fa-wrench"></i> Bakım Modu Ayarları</button></a></td>
                <td><a href="personelHesapIslemleri.aspx"><button type="button" class="btn btn-info"><i class="fa-solid fa-id-card"></i> Personel Hesap İşlemleri</button></a></td>
                <td><a href="istatistikSayfasi.aspx"><button type="button" class="btn btn-primary"><i class="fa-solid fa-chart-simple"></i> İstatistikler</button></a></td>
            </tr>
        </table>
    </main>
</asp:Content>