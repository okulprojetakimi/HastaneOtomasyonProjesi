<%@ Page Language="C#" Title="Hasta Randevu Ekleme" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="kayitliOlmayanHastaRandevu.aspx.cs" Inherits="HastaneOtomasyonProjesi.randevuModulu.kayitliOlmayanHastaRandevu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <h1 style="color: white;"><i class="fa-solid fa-calendar-plus"></i> Yeni Hasta Randevusu</h1>
    <p style="color: white;">Bu sayfada daha önce hasta kaydı olmayan yeni hastalar için randevu oluşturukabilir.</p>

    <main>
        <asp:TextBox ID="randevu_Saati" runat="server" />
        <table cellpadding="5">
            <tr>
                <td>
                    <div>
                        <label for="kRandevu_Tc">Hasta TCKN: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="kRandevu_Tc" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="kRandevu_Isim">Hasta İsmi: </label>
                        <asp:TextBox runat="server" ID="kRandevu_Isim" CssClass="form-control" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="kRandevu_Soyisim">Hasta Soyismi</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="kRandevu_Soyisim" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="kRandevu_Tarih">Hasta Randevu Tarihi: </label>
                        <asp:TextBox runat="server" ID="kRandevu_Tarih" TextMode="Date" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>

                        <label for="kRandevu_poliklinik">Randevu Polikliniği: </label>

                        <select id="kRandevu_poliklinik"  class="btn btn-info dropdown-toggle">
                            <option>Bir poliklinik seçiniz.</option>
                            <%
                                using (System.Data.SqlClient.SqlConnection sa = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                                {
                                    sa.Open();
                                    using (System.Data.SqlClient.SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand("SELECT pId, pIsim FROM poliklinik_Tablo", sa))
                                    {
                                        System.Data.SqlClient.SqlDataReader reader = sqlCom.ExecuteReader();
                                        while (reader.Read())
                                        { %>
                            <option value="<% Response.Write(reader.GetInt32(0)); %>"><% Response.Write(reader.GetString(1)); %></option>
                            <% }
                            %>

                            <%
                                        sa.Close();
                                        reader.Close();
                                    }
                                }
                            %>
                        </select>

                        <%-- <asp:DropDownList DataValueField="pId" DataTextField="pIsim" DataSourceID="kRandevu_poliklinikSource" CssClass="btn btn-info dropdown-toggle" ID="kRandevu_poliklinik" runat="server"></asp:DropDownList>
                        <asp:SqlDataSource ID="kRandevu_poliklinikSource" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT pId, pIsim FROM poliklinik_Tablo"></asp:SqlDataSource>--%>
                    </div>

                </td>

                <%--<td>
                    <div>
                        <label for="kRandevu_Doktor">Randevu Doktoru Seç: </label>
                        <asp:DropDownList CssClass="btn btn-info dropdown-toggle" ID="kRandevu_Doktor" runat="server"></asp:DropDownList>
                    </div>
                </td>--%>
            </tr>
            <tr>
                <td>
                    <div>
                        <table class="table table-striped" id="myGrid" border="1">
                            <thead>
                                <tr>
                                    <th>Doktor Numarası</th>
                                    <th>Doktor İsmi</th>
                                    <th>Doktor Soyismi</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                    </div>
                   
                </td>
                <td>
                    <div>
                        <table style="position: absolute; top: 175px; left: 75%; width:275px;" class="table table-striped" id="saatTablo" border="1">
                            <thead>
                                <tr>
                                    <th>Saat Aralıkları</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                    </div>
                </td>
                <script>
                    $(document).ready(function () {
                        // input alanına her veri girildiğinde
                        $("#kRandevu_poliklinik").change(function () {
                            // AJAX çağrısı gönderiyoruz
                            $.ajax({
                                type: "GET",
                                url: "veriIslem.aspx",
                                data: { bolumId: $(kRandevu_poliklinik).val() },
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    // AJAX çağrısı başarılı olduysa, gridview'i güncelliyoruz
                                    var html = "";
                                    $.each(data, function (key, value) {
                                        html += "<tr><td>" + value.personel_Id + "</td><td>" + value.personel_Isim + "</td><td>" + value.personel_Soyisim + "</td>" + "<td><button id='kontrolButon' class='btn btn-info' onclick='doktorSaatGetir(" + value.personel_Id + ")' type='button'>Doktoru Seç</button></td>" + "</tr>";
                                    });
                                    $("#myGrid tbody").html(html);
                                },
                                error: function (jqXHR, textStatus, errorThrown) {
                                    console.log(textStatus, errorThrown);
                                }
                            });
                        });
                    });

                    function doktorSaatGetir(doktorId) {
                        var randevuTarihi = document.getElementById("<%= kRandevu_Tarih.ClientID %>").value;
                        $.ajax({
                            type: "GET",
                            url: "randevuKontrol.aspx",
                            data: { personelNumarasi: doktorId, randevuTarihi: randevuTarihi },
                            dataType: "json",
                            success: function (veri) {
                                // DropdownList'i temizleyelim
                                $("#ddlSaatler").empty();
                                var listem = "";
                                // `veri` dizisindeki her bir öğeyi `option` olarak seçim kutusuna ekleyelim
                                for (var i = 0; i < veri.length; i++) {
                                    listem += "<tr><td>" + veri[i] + "</td><td><button type='button' class='btn btn-success' id='saatSecme' onclick='saatSecimiGerceklestir(" + '"' +  veri[i] + '"' +  ")'>Saat Seç</button></td></tr>";
                                }
                                $("#saatTablo tbody").html(listem);
                            },
                            error: function (xhr, status, error) {
                                console.log(status, error);
                            }
                        });
                    }
                    function saatSecimiGerceklestir(veriAl) {
                        var doc = document.getElementById("veriAl").value = veriAl;
                    }

                </script>
            </tr>
            
            <tr>
                <td>
                    <div>
                        <label for="kRandevu_randevuNot">Hasta Randevu Not: </label>
                        <asp:TextBox runat="server" ID="kRandevu_randevuNot" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </td>
            </tr>

        </table>
        <asp:Button Text="+ Randevu Ekle" ID="randevuEkle_Buton" CssClass="btn btn-success" runat="server" OnClick="randevuEkle_Buton_Click" />

    </main>

</asp:Content>
