<%@ Page Language="C#" Title="Ameliyat Detay Görüntüleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ameliyatDetayGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.ameliyatDetayGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style>
            .labels {
                color: white;
            }
            #acilirKutu_IlacArama {
                display: none;
                position: absolute;
                top: 30%;
                left: 50%;
                transform: translate(-50%, -50%);
                background-color: #fff;
                padding: 20px;
                border: 1px solid #ccc;
                z-index: 9999;
                width: 1024px;
            }
        </style>


        <!-- -->
        <button type="button" class="btn btn-info" id="FormAc"><i class="fa-sharp fa-solid fa-notes-medical"></i>Ameliyata ilaç ekle</button>
        <div class="acilirKutu_IlacArama" id="acilirKutu_IlacArama">
            <div class="ilacArama_Kutusu">
                <table>
                    <tr>
                        <td><button type="button" class="btn btn-danger" id="formKapat">X</button></td>
                        <td><h2>Ameliyat ilaç ekleme formu</h2></td>
                    </tr>
                </table>
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
                            url: "/ilacArama.aspx",
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
            <br />
            <div>
                <h3>İlaç ekle</h3>
                İlaç Numarası: <asp:TextBox CssClass="form-control" ID="ilacIdNum" runat="server" />
                <br />
                <asp:Button CssClass="btn btn-success" Text="+ İlaç Ekle" runat="server" ID="hastaIlac_Ekle" OnClick="hastaIlac_Ekle_Click" />
            </div>
            
        </div>
        <script>
            var formKutusu = document.getElementById("acilirKutu_IlacArama");
            var formButton = document.getElementById("FormAc");

            formButton.onclick = function () {
                if (formKutusu.style.display === "none") {
                    formKutusu.style.display = "block";
                } else {
                    formKutusu.style.display = "none";
                }
            }
            formKapat.onclick = function () {
                if (formKutusu.style.display === "none") {
                    formKutusu.style.display = "block";
                } else {
                    formKutusu.style.display = "none";
                }
            }
        </script>
        <!-- -->


        <h1 style="color: white;">Ameliyat Detayları</h1>
        <table cellpadding="15">

            <tr>
                <td>
                    <label class="labels">Ameliyat Giriş Tarihi: </label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" runat="server" ID="ameliyat_GirisT" Text="" ReadOnly="True" /></td>
                <td>
                    <label class="labels">Ameliyat Çıkış Tarihi: </label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" ID="ameliyat_CikisT" runat="server" Text="" ReadOnly="True" /></td>
            </tr>
            <tr>
                <td>
                    <label class="labels">Anestezi Türü: </label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" ID="ameliyatAnesteziTuru" runat="server" ReadOnly="True" /></td>
                <td>
                    <label class="labels">Ameliyata giren doktor: </label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" runat="server" ID="ameliyat_Doktor" ReadOnly="True" />
                </td>
            </tr>
            <tr>
                <td>
                    <label class="labels">Ameliyata giren hasta: </label>
                </td>
                <td>
                    <asp:TextBox TextMode="MultiLine" CssClass="form-control" runat="server" ID="ameliyat_Not" ReadOnly="True" /></td>
            </tr>
        </table>
        <br />
        <br />
        <h1 style="color: white;"><i class="fa-solid fa-list-ol"></i>Kullanılan İlaçlar</h1>
        <div>

            <asp:GridView ID="ameliyatKullanilan_Tablo" runat="server" CellPadding="15" ForeColor="#333333" GridLines="None" EmptyDataText="Eklenmiş bir ilaç bulunamadı!">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

        </div>

    </main>
</asp:Content>
