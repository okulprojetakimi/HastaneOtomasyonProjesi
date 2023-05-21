<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Hasta Randevu Arama" AutoEventWireup="true" CodeBehind="hastaRandevuAra.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaRandevuAra" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-days"></i> Hasta Randevu Arama</h1>
        <p style="color: white;">Bu sayfada hastalara ait randevuları listeleyebilirsiniz.</p>
        <br />
        <table cellpadding="15">
            <tr>
                <td>
                    <label>Hasta TCKN: </label>
                    <input type="text" id="hasta_Tc" class="form-control" name="hasta_Tc" />
                </td>
                <td>
                    <label>Randevu Tarih: </label>
                    <input type="date" id="randevu_Tarih" class="form-control" />
                </td>
                <td>
                    <input type="button" value="Ara" class="btn btn-success" name="randevu_Arama" id="randevu_Arama" />
                </td>
            </tr>
        </table>

        <!-- Hasta Randevu Tablo -->
        <div class="tablo_Div">
            <!-- Hasta tablosu olacak -->
            <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>Randevu Numarası</th>
                        <th>Randevu Tarihi</th>
                        <th>Randevu Saati</th>
                        <th>Hasta Adı</th>
                        <th>Hasta Soyadı</th>
                        <th>Randevu Doktor İsim</th>
                        <th>Randevu Doktor Soyisim</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        <br />
        
        </div>
        <script>
            $(document).ready(function () {
                $("#randevu_Arama").click(function () {
                    $.ajax({
                        type: "GET",
                        url: "randevuAraApi.aspx",
                        data: {
                            tckn: document.getElementById('hasta_Tc').value,
                            rTarih: document.getElementById('randevu_Tarih').value
                        },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.randevuId + "</td><td>" + value.randevuTarih + "</td><td>" + value.randevuSaat + "</td>" + "<td>" + value.hasta_Adi + "</td>" + "<td>" + value.hasta_Soyadi + "</td>" + "<td>" + value.personel_Isim + "</td>" + "<td>" + value.personel_Soyisim + "</td>" + "<td><a href='hastaRandevuGoruntule.aspx?randevuNumara="+value.randevuId+"'><button type='button' id='randevu_Ac' class='btn btn-success'>Randevu Görüntüle</button></a></td>" + "</tr>";
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


