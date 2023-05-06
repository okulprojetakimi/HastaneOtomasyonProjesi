<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="yeniAmeliyatKaydiEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.yeniAmeliyatKaydiEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th>Yeni Ameliyat Kaydi Ekle</th>
            <tr>
            <td>
                <div class="form-grop">
                    <label for="ameliyatGirisTarihi">Ameliyat Giris Tarihi:</label>
                    <input type="datetime" class="form-control" id="ameliyatGirisTarihi" name="ameliyatGirisTarihi" aria-describedby="ameliyatGirisTarihi" placeholder="Ameliyat Giris Tarihi">
                </div>
            </td>
            <td>
                <div class="form-grop">
                    <label for="ameliyatCikisTarihi">Ameliyat Cikis Tarihi:</label>
                    <input type="datetime" class="form-control" id="ameliyatCikisTarihi" name="ameliyatCikisTarihi" aria-describedby="ameliyatCikisTarihi" placeholder="Ameliyat Cikis Tarihi">
                </div>
            </td>
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="ameliyatAnesteziTuru">Ameliyat Anestezi Turu:</label>
                        <input type="text" class="form-control" id="ameliyatAnesteziTuru" name="ameliyatAnesteziTuru" aria-describedby="ameliyatAnesteziTuru" placeholder="Ameliyat Anestezi Turu" />
                    </div>
                    
                </td>
                <td>Ameliyata Girecek Doktor: <asp:DropDownList ID="ameliyatPersonelSecimi" runat="server">
                    </asp:DropDownList></td>

                
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="ameliyatNotu">Ameliyat Notu:</label>
                        <textarea class="form-control" id="ameliyatNotu" name="ameliyatNotu" aria-describedby="ameliyatNotu" placeholder="Ameliyat Notu"></textarea>
                    </div>
                </td>
            </tr>
             

        </table>
    </main>
    <asp:Button CssClass="btn btn-success" Text="Yeni Ameliyat Ekle" ID="ameliyatEkle_Buton" runat="server" OnClick="kayitEkleme_Butonu"/>
</asp:Content>
