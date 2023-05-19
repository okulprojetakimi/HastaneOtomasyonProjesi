<%@ Page Language="C#" MasterPageFile="~/adminModulu/adminTema.Master" Title="Personel Hesap İşlemleri" AutoEventWireup="true" CodeBehind="personelHesapIslemleri.aspx.cs" Inherits="HastaneOtomasyonProjesi.adminModulu.personelHesapIslemleri" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-users"></i> Personel Hesap İşlemleri</h1>
        <p style="color: white;">Bu sayfada personel hesapları ile işlemler gerçekleştirebilirsiniz.</p>
        <br />
        <style>
            label{
                color: white;
            }
        </style>
        <div class="personelArama_Form">
            <table cellpadding="15">
                <tr>
                    <td><label>Personel Ismi: </label><input id="personel_Ismi" class="form-control"></td>
                    <td><label>Personel Soyismi: </label><input id="personel_Soyismi" class="form-control"></td>
                    <td><button type="button" id="personelAra_Buton" class="btn btn-success">Personel Ara</button></td>
                </tr> 
            </table>

            <!-- Personel Tablosu -->
                    <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>Persone Numarası</th>
                        <th>Personel TC</th>
                        <th>Personel Isim</th>
                        <th>Personel Soyisim</th>
                        <th>Personel Türü</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        <br />
        <div class="hasta_Listesi">

        </div>
        <script>
            $(document).ready(function () {
                $("#personelAra_Buton").click(function () {
                    $.ajax({
                        type: "GET",
                        url: "personelApi.aspx",
                        data: {
                            isim: document.getElementById('personel_Ismi').value,
                            soyisim: document.getElementById('personel_Soyismi').value
                        },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.personel_Id + "</td><td>" + value.personel_Tc + "</td><td>" + value.personel_Isim + "</td>" + "<td>" + value.personel_Soyisim + "</td>" + "<td>" + value.personel_Turu + "</td>" + "<td> <a href='hesapIslem.aspx.aspx?personelNumarasi=" + value.personel_Id + "'><button type='button' class='btn btn-success'>Personel İşlem</button></a></td>" + "</tr>";
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