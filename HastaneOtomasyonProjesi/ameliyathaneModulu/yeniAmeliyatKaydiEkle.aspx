<%@ Page Title="Yeni Ameliyat Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="yeniAmeliyatKaydiEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.yeniAmeliyatKaydiEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th><h1 style="color: white;">Yeni Ameliyat Kaydi Ekle</h1></th>
            <tr>
                <td>
                <div class="form-grop">
                    <label for="ameliyatTckn">Hasta TCKN: </label>
                    <asp:TextBox CssClass="form-control" ID="ameliyatTckn" runat="server" />
                </div>
            </td>
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
                        <asp:TextBox ID="ameliyatAnesteziTuru" CssClass="form-control" runat="server" />
                    </div>
                    
                </td>
                <td>Ameliyata Girecek Doktor: <asp:DropDownList CssClass="btn btn-primary dropdown-toggle" ID="ameliyatPersonelSecimi" runat="server">
                    </asp:DropDownList></td>             
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="ameliyatNotu">Ameliyat Notu:</label>
                        <asp:TextBox CssClass="form-control" ID="ameliyatNotu" TextMode="MultiLine" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        <br />
         <asp:Button CssClass="btn btn-success" Text="Yeni Ameliyat Ekle" ID="ameliyatEkle_Buton" runat="server" OnClick="ameliyatEkle_Buton_Click"/>
    </main>
   
</asp:Content>
