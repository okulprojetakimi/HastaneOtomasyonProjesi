<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Çalışma Planı Modülü" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.anasayfa1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-days"></i> Personel Çalışma Planı Modülü</h1>
        <p style="color: white;">Bu modül ile personellerin nöbet planlarını ekleyebilir, düzenleyebilir ve silebilirsiniz. Sayfada bulunan formu kullanarak planlamasını yapmak istediğiniz personeli bulabilirsiniz.</p>
        <br />
        <div class="arama_Form">
            <table cellpadding="12">
                <tr>
                    <td>
                        <label>Personel İsim: </label>
                        <input type="text" id="personel_Isim" class="form-control" />
                    </td>
                    <td>
                        <label>Personel Soyisim: </label>
                        <input type="text" id="personel_Soyisim" class="form-control" />
                    </td>
                    <td><button id="p_Ara" type="button" class="btn btn-success">Personel Ara</button>
                    </td>
                </tr>
            </table>
        </div>
        <!-- Personel Tablosu -->
       <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>Personel TC</th>
                        <th>Personel Isim</th>
                        <th>Personel Soyisim</th>
                        <th>Personel Türü</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        <br />
        <script>
            $(document).ready(function () {
                $("#p_Ara").click(function () {
                    $.ajax({
                        type: "GET",
                        url: "api.aspx",
                        data: {
                            personel_Isim: document.getElementById('personel_Isim').value,
                            personel_Soyisim: document.getElementById('personel_Soyisim').value
                        },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.personel_Tc + "</td><td>" + value.personel_Isim+ "</td><td>" + value.personel_Soyisim+ "</td>" + "<td> <a href='personelPlanIslemi.aspx?pId=" + value.personel_Id + "'><button type='button' class='btn btn-success'>Çalışma Planı İşlemi</button></a></td>" + "</tr>";
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
