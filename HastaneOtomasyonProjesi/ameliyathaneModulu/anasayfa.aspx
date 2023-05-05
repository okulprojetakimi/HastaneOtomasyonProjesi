<%@ Page Language="C#" Title="Ameliyathane Modülü Anasayfa" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Button CssClass="btn btn-success" ID="yeniKayit_ekle" Text="+ Yeni ameliyat kaydı ekle" runat="server" />
        <br />
        <br />
        
        <div>
            <!-- 
                Ameliyat Numarası
                Ameliyat Giriş Tarihi
                Ameliyat Çıkış Tarihi
                Ameliyat Personel Numarası
                Ameliyat Hasta Numarası
                -->
            <h1 style="color: white;"><i class="fa-solid fa-bed-pulse"></i> Bugünkü Ameliyatlar</h1>
            <br />
            <div class="ameliyatFiltreleme">

            <table cellpadding="15">
                <tr>
                    <td>
                        <label>Hasta TC Kimlik Numarası: </label>
                    </td>
                    <td>
                        <input class="form-control" name="ameliyat_Arama" id="ameliyat_Arama" /><br />
                    </td>
                </tr>
            </table>
        </div>
            <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>Ameliyat Numarası</th>
                        <th>Ameliyat Giriş Tarihi</th>
                        <th>Ameliyat Çıkış Tarihi</th>
                        <th>Ameliyat Personel İsmi</th>
                        <th>Ameliyat Personel Soyismi</th>
                        <th>Ameliyat Hasta İsim Soyisim</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>

        </div>
         <script>
            $(document).ready(function () {
                // input alanına her veri girildiğinde
                $("#ameliyat_Arama").keyup(function () {
                    // AJAX çağrısı gönderiyoruz
                    $.ajax({
                        type: "GET",
                        url: "ameliyatAra.aspx",
                        data: { hastaTcKn: $(this).val() },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            // AJAX çağrısı başarılı olduysa, gridview'i güncelliyoruz
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.ameliyatId + "</td><td>" + value.ameliyatGirisTarihi + "</td><td>" + value.ameliyatCikisTarihi + "</td>" + "<td>" + value.personel_Isim + "</td>" + "<td>" + value.personel_Soyisim + "</td>" + "<td>" + value.hasta_Adi + " " + value.hasta_Soyadi + "</td>" + "</tr>";
                            });
                            $("#myGrid tbody").html(html);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log(textStatus, errorThrown);
                        }
                    });
                });
            });

         </script>
    </main>
</asp:Content>