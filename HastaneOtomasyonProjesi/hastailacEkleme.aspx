<%@ Page Title="Hasta ilaç ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastailacEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastailacEkleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- İlaç Listesi -->
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-pills"></i>Hastaya İlaç Ekleme</h1>
        <br />
        <style>
            .labels {
                color: white;
            }
        </style>
        <asp:Label CssClass="labels" Text="İlaç eklenecek hasta: " ID="ilac_Hasta" runat="server" /><br />
        <asp:Label CssClass="labels" Text="İlaç eklenecek hasta tc: " ID="ilac_HastaTc" runat="server" />
        &nbsp;<br />
        <br />
        <br />
        <div class="ilacArama_Kutusu">

            <table>
                <tr>
                    <td>
                        <label>Aranacak İlaç Ismi: </label>
                    </td>
                    <td>
                        <input class="form-control" name="ilac_AramaInput" id="ilac_AramaInput" /><br />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>İlaç Numarası</th>
                        <th>İlaç İsmi</th>
                        <th>İlaç Reçete Türü</th>
                        <th>İlaç Fiyatı</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>

        </div>
        <script>
            $(document).ready(function () {
                // input alanına her veri girildiğinde
                $("#ilac_AramaInput").keyup(function () {
                    // AJAX çağrısı gönderiyoruz
                    $.ajax({
                        type: "GET",
                        url: "ilacArama.aspx",
                        data: { ilacIsmi: $(this).val() },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            // AJAX çağrısı başarılı olduysa, gridview'i güncelliyoruz
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.ilacId + "</td><td>" + value.ilacIsmi + "</td><td>" + value.ilacreceteTuru + "</td>" + "<td>" + value.ilacFiyat + "</td>" + "</tr>";
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

        <table>
            <tr>
                <td>İlaç Numarası: <asp:TextBox CssClass="form-control" ID="ilacIdNum" runat="server" /></td>
                <td><asp:Button CssClass="btn btn-success" Text="+ Ilac ekle" runat="server" ID="hastaIlac_Ekle" OnClick="hastaIlac_Ekle_Click" /></td>
            </tr>

        </table>
    </main>
</asp:Content>
