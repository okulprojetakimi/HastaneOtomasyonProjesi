<%@ Page Language="C#" MasterPageFile="~/adminModulu/adminTema.Master" Title="Sistem İstatistik Sayfası" AutoEventWireup="true" CodeBehind="istatistikSayfasi.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.istatistikSayfasi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:HiddenField ID="IIScpuKullanimi" runat="server" />
        <asp:HiddenField ID="MssqlDBCount" runat="server" />

        <h1 style="color: white;"><i class="fa-solid fa-chart-simple"></i> İstatistikler Sayfası</h1>
        <p style="color: white;">Bu sayfada sistem ve kayıtlar hakkında bilgi sahibi olabilirsiniz.</p>
        <br />
        <h3>Sistem İstatistikleri</h3>
        <table>
            <tr>
                <td>
                    <label><i class="fa-solid fa-hard-drive"></i> Veritabanı Boyutu: </label>
                </td>
                <td>
                    <asp:Label ID="db_Boyut" Text="......" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <label><i class="fa-solid fa-microchip"></i> Web Server CPU Kullanımı: </label>
                </td>
                <td>
                    % <asp:Label ID="web_Cpu" Text="...." runat="server" />
                    <progress value="<%= IIScpuKullanimi.Value %>" max="100"></progress>
                </td>
            </tr>
        </table>
        <hr />
        <h3>Hastane Kayıt İstatistikleri</h3>
        <table>
            <tr>
                <td>
                    <asp:Label Text="Hasta Sayısı: " runat="server" />
                </td>
                <td>
                    <asp:Label ID="hasta_Sayisi" Text="......" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Toplam Ameliyat Sayısı: " runat="server" />
                </td>
                <td>
                    <asp:Label ID="ameliyat_Sayisi" Text="......" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Personel Sayısı: " runat="server" />
                </td>
                <td>
                    <asp:Label ID="personel_Sayi" Text="......" runat="server" />
                </td>
            </tr>
        </table>
        <br />

    </main>
</asp:Content>
