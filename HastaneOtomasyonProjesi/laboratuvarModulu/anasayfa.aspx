<%@ Page Language="C#" Title="Laboratuvar Modülü" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.laboratuvarModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-flask"></i> Laboratuvar Modülü</h1>

        <!-- Hasta tablosu -->
        <div class="hastaArama_Form">
            <table cellpadding="15">
                <tr>
                    <td>Aranacak Hasta İsmi <input class="form-control" placeholder="Hasta İsmi" id="hasta_Isim" /></td>
                    <td>Aranacak Hasta Soyismi: <input class="form-control" placeholder="Hasta İsmi" id="hasta_Soyisim" /></td>
                    <td><button type="button" class="btn btn-info" id="hasta_Ara">Hasta ara</button></td>
                </tr>
            </table>
        </div>
        <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>Hasta Numarası</th>
                        <th>Hasta TC</th>
                        <th>Hasta Adı</th>
                        <th>Hasta Soyadı</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        <br />
        <div class="hasta_Listesi">

        </div>
        <script>
            $(document).ready(function () {
                $("#hasta_Ara").click(function () {
                    $.ajax({
                        type: "GET",
                        url: "hastaArama.aspx",
                        data: {
                            isim: document.getElementById('hasta_Isim').value,
                            soyisim: document.getElementById('hasta_Soyisim').value
                        },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.hasta_Id + "</td><td>" + value.hasta_Tc + "</td><td>" + value.hasta_Adi + "</td>" + "<td>" + value.hasta_Soyadi + "</td>" + "<td> <a href='laboratuvarModulEkle.aspx?hastaNumara=" + value.hasta_Id + "'><button type='button' class='btn btn-success'>Tetkik İşlemi</button></a></td>" + "</tr>";
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