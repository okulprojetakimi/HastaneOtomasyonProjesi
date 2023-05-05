<%@ Page Language="C#" Title="Ameliyathane Modülü Anasayfa" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.ameliyathaneModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table cellpadding="15">
            <tr>
                <td><asp:Button CssClass="btn btn-success" ID="yeniKayit_ekle" Text="+ Yeni ameliyat kaydı ekle" runat="server" /></td>
                <td> <button type="button" class="btn btn-success" id="diyalogButon">Ameliyat Arama</button></td>
            </tr>
        </table>
        <br />
        <br />
        <style>
            .ameliyatFiltreleme {
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
        <div>
            <!-- 
                Ameliyat Numarası
                Ameliyat Giriş Tarihi
                Ameliyat Çıkış Tarihi
                Ameliyat Personel Numarası
                Ameliyat Hasta Numarası
                -->
            <h1 style="color: white;"><i class="fa-solid fa-bed-pulse"></i>Bugünkü Ameliyatlar</h1>
            <p style="color: white;">Bu tablo her gün güncellenmektedir. Bu tabloda bugünkü gerçekleşecek veya gerçekleşmiş olan tüm ameliyatlar listelenmektedir..</p>
            <br />

            <!-- Açılır kapanır dialog -->
            <div id="ameliyatFiltreleme" class="ameliyatFiltreleme">
                <table cellpadding="15">
                    <tr>
                        <td><button id="fomrKapat" type="button" class="btn btn-danger">X</button></td>
                        <td><h3>Ameliyat araması</h3></td>
                    </tr>
                </table>
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
                <br />
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
            <!-- Açılır kapanır diyalog js -->
            <script>
                var formKutusu = document.getElementById("ameliyatFiltreleme");
                var formButton = document.getElementById("diyalogButon");

                formButton.onclick = function () {
                    if (formKutusu.style.display === "none") {
                        formKutusu.style.display = "block";
                    } else {
                        formKutusu.style.display = "none";
                    }
                }
                fomrKapat.onclick = function () {
                    if (formKutusu.style.display === "none") {
                        formKutusu.style.display = "block";
                    } else {
                        formKutusu.style.display = "none";
                    }
                }
            </script>
        </div>
        <div class="tablo_div">

            <asp:GridView ID="bugunku_ameliyatlarListesi" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="15" ForeColor="Black" GridLines="Horizontal">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>

        </div>
        <br />
        <h3 style="color: white;">Ameliyat Detay Görüntüleme</h3>
        <table cellpadding="15">
            <tr>
                <td><label style="color: white;">Ameliyat Numarası: </label></td>
                <td>
                    <asp:TextBox CssClass="form-control" ID="ameliyat_Numarasi" runat="server" /></td>
                <td>
                    <asp:Button CssClass="btn btn-success" Text="Ameliyat Detay Görüntüle" ID="detayButon" runat="server" OnClick="detayButon_Click" /></td>
            </tr>
        </table>
    </main>
</asp:Content>
