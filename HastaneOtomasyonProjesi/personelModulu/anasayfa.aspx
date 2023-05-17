<%@ Page Title="Personel İşlemleri" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1 style="color: white;">Personel Modülü</h1>
        <p style="color:white;">Bu modül ile personel ekleme, arama, görüntüleme işlemlerini gerçekleştirebilirsiniz.</p>
        <a href="personelEkleme.aspx"><button type="button" class="btn btn-success">+ Personel Ekleme</button></a>

        <!-- Persnel tablo -->
        <div class="personel_Tablosu">
            <table style="color: white;" cellpadding="15">
                <tr>
                    <td>
                        <label>Personel İsim: </label>
                        <input type="text" id="personel_Isim" class="form-control" name="personel_Isim" />
                    </td>
                    <td>
                        <label>Personel Soyisim: </label>
                        <input type="text" id="personel_Soyisim" class="form-control" name="personel_Soyisim" />
                    </td>
                    <td>
                        <input type="button" value="Personel Ara" class="btn btn-success" name="personel_Arama" id="personel_Arama"/>
                    </td>
                </tr>
            </table>
            
        </div>
    </main>

</asp:Content>