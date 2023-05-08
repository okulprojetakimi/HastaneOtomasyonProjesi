<%@ Page Title="Yeni ameliyat ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="yeniAmeliyatKaydiEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.yeniAmeliyatKaydiEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th>Yeni Ameliyat Kaydi Ekle</th>
            <tr>
            <td>
                <div class="form-grop">
                    <label for="ameliyatGirisTarihi">Ameliyat Giris Tarihi:</label>
                    <asp:TextBox CssClass="form-control" TextMode="DateTimeLocal" ID="ameliyatGirisTarihi" runat="server" />
                </div>
            </td>
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="ameliyatAnesteziTuru">Ameliyat Anestezi Turu:</label>
                        <asp:TextBox CssClass="form-control" ID="ameliyatAnesteziTuru" runat="server" />
                    </div>
                    
                </td>
                <td>Ameliyata Girecek Doktor: <asp:DropDownList ID="ameliyatPersonelSecimi" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="ameliyatNotu">Ameliyat Notu:</label>
                        <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="ameliyatNotu" runat="server" />
                    </div>
                </td>
            </tr>
            <asp:Button Text="+ Yeni ameliyat ekle" CssClass="btn btn-success" ID="ameliyatEkle" runat="server" />

        </table>
    </main>
    
    
</asp:Content>
