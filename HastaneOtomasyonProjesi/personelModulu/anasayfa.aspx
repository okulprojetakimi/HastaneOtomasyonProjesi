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
            <!-- -->
            <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>Personel TC</th>
                        <th>Personel Isim</th>
                        <th>Personel Soyisim</th
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        <br />
        <script>
            $(document).ready(function () {
                $("#personel_Arama").click(function () {
                    $.ajax({
                        type: "GET",
                        url: "personelApi.aspx",
                        data: {
                            isim: document.getElementById('personel_Isim').value,
                            soyisim: document.getElementById('personel_Soyisim').value
                        },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.personel_Tc + "</td><td>" + value.personel_Isim+ "</td><td>" + value.personel_Soyisim+ "</td>" + "<td> <a href='personelDetay.aspx?personelTc=" + value.personel_Tc + "'><button type='button' class='btn btn-success'>Personel Detay</button></a></td>" + "</tr>";
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
            
        </div>
    </main>

</asp:Content>