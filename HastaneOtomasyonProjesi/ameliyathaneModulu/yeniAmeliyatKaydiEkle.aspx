<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="yeniAmeliyatKaydiEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.yeniAmeliyatKaydiEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th>Yeni Ameliyat Kaydi Ekle</th>
            <tr>
<<<<<<< HEAD
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
=======
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
>>>>>>> 13b87a07e176f99892cdcf99b750531096c13293
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="ameliyatNotu">Ameliyat Notu:</label>
                        <textarea class="form-control" id="ameliyatNotu" name="ameliyatNotu" aria-describedby="ameliyatNotu" placeholder="Ameliyat Notu"></textarea>
                    </div>
                </td>
            </tr>
<<<<<<< HEAD
            <tr>
=======
           <%-- <tr>
>>>>>>> 13b87a07e176f99892cdcf99b750531096c13293
                <td>
                    <div class="form-grop">
                        <label for="ameliyatNotu">Ameliyat Ilac Id:</label>
                        <input type="number" class="form-control" id="ameliyatIlacId" name="ameliyatIlacId" aria-describedby="ameliyatIlacId" placeholder="Ameliyat Ilac Id" />
                    </div>
                </td>
<<<<<<< HEAD
            </tr>
=======
            </tr>--%>
>>>>>>> 13b87a07e176f99892cdcf99b750531096c13293
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="ameliyatAnesteziTuru">Ameliyat Anestezi Turu:</label>
                        <input type="text" class="form-control" id="ameliyatAnesteziTuru" name="ameliyatAnesteziTuru" aria-describedby="ameliyatAnesteziTuru" placeholder="Ameliyat Anestezi Turu" />
                    </div>
                </td>
            </tr>
<<<<<<< HEAD

=======
           
>>>>>>> 13b87a07e176f99892cdcf99b750531096c13293

        </table>
    </main>
    <asp:Button CssClass="btn btn-success" Text="+ Hasta Ekle" ID="Button61_Click61" runat="server" OnClick="AmeliyatKaydıButon_click" />
</asp:Content>
