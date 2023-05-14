<%@ Page Title="Personel İşlemleri" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1 style="color: white;"><i class="fa-solid fa-person-simple"></i> Personel Modülü</h1>
        <p style="color:white;">Bu modül ile personel ekleme, arama, görüntüleme işlemlerini gerçekleştirebilirsiniz.</p>
        <a href="personelEkleme.aspx"><button class="btn btn-success">+ Personel Ekleme</button></a>
        <br />
        <br />
        <!-- Persnel tablo -->
        <div class="personel_Tablosu">
            <table cellpadding="15">
                <tr>
                    <th><label style="color: white;">Personel TCKN: </label></th>
                    <th><input type="text" class="form-control" id="personel_tckn" name="personel_tckn"</th>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>Personel TC</th>
                        <th>Personel Adı</th>
                        <th>Personel Soyadı</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>

        </div>
        <script>
            $(document).ready(function () {
                $("#personel_tckn").keyup(function () {
                    $.ajax({
                        type: "GET",
                        url: "personelData.aspx",
                        data: { personelTc: $(this).val() },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.personel_Isim + "</td><td>" + value.personel_Soyisim + "</td>" + "<td><a href='personelDetay.aspx?personelTc=" + value.personel_Tc + "'><button class='btn btn-success'>Personel Detay</button></a></td>" + "</tr>";
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