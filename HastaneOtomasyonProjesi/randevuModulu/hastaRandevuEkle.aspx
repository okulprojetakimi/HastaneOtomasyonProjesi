<%@ Page Language="C#" Title="Randevu Oluştur" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaRandevuEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.randevuModulu.hastaRandevuEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:HiddenField ID="saatVerisi" runat="server" />
        <asp:HiddenField ID="secilenDoktor" runat="server" />
        <asp:HiddenField ID="secilenPoliklinik" runat="server" />
        <h1 style="color: white;"><i class="fa-solid fa-calendar-plus"></i>Hasta Randevu Oluşturma</h1>
        <table>
            <tr>
                <td>
                    <div>
                        <label for="tcNo">Hasta TCNO: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="tcNumara" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="randevuTarih">Hasta Randevu Tarihi: </label>
                        <asp:TextBox runat="server" ID="randevuTarih" TextMode="Date" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="randevuPoliklinik">Randevu Polikliniği: </label>
                        <select id="randevuPoliklinik" class="btn btn-info dropdown-toggle">
                            <option>Poliklinik seçiniz.</option>
                            <%
                                using (System.Data.SqlClient.SqlConnection pol = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                                {
                                    pol.Open();
                                    using (System.Data.SqlClient.SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand("SELECT pId, pIsim FROM poliklinik_Tablo", pol))
                                    {
                                        System.Data.SqlClient.SqlDataReader reader = sqlCom.ExecuteReader();
                                        while (reader.Read())
                                        { %>
                            <option value="<% Response.Write(reader.GetInt32(0)); %>"><% Response.Write(reader.GetString(1)); %></option>
                            <% }
                            %>

                            <%
                                        pol.Close();
                                        reader.Close();
                                    }
                                }
                            %>
                        </select>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <table class="table table-striped" id="Grid" border="1">
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
                        <table style="position: absolute; top: 175px; left: 75%; width: 275px;" class="table table-striped" id="saatTablo" border="1">
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
                        $("#randevuPoliklinik").change(function () {
                            document.getElementById('<%= secilenPoliklinik.ClientID %>').value = document.getElementById("randevuPoliklinik").value;
                            $.ajax({
                                type: "GET",
                                url: "veriIslem.aspx",
                                data: { bolumId: $(randevuPoliklinik).val() },
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    var html = "";
                                    $.each(data, function (key, value) {
                                        html += "<tr><td>" + value.personel_Id + "</td><td>" + value.personel_Isim + "</td><td>" + value.personel_Soyisim + "</td>" + "<td><button id='kontrolButon' class='btn btn-info' onclick='doktorSaatGetir(" + value.personel_Id + ")' type='button'>Doktoru Seç</button></td>" + "</tr>";
                                    });
                                    $("#Grid tbody").html(html);
                                },
                                error: function (jqXHR, textStatus, errorThrown) {
                                    console.log(textStatus, errorThrown);
                                }
                            });
                        });
                    });

                    function doktorSaatGetir(doktorId) {
                        document.getElementById('<%= secilenDoktor.ClientID %>').value = doktorId;
                        var randevuTarihi = document.getElementById("<%= randevuTarih.ClientID %>").value;
                        $.ajax({
                            type: "GET",
                            url: "randevuKontrol.aspx",
                            data: { personelNumarasi: doktorId, randevuTarihi: randevuTarihi },
                            dataType: "json",
                            success: function (veri) {
                                $("#ddlSaatler").empty();
                                var listem = "";
                                for (var i = 0; i < veri.length; i++) {
                                    listem += "<tr><td>" + veri[i] + "</td><td><button type='button' class='btn btn-success' id='saatSecme' onclick='saatSecimiGerceklestir(" + '"' + veri[i] + '"' + ")'>Saat Seç</button></td></tr>";
                                }
                                $("#saatTablo tbody").html(listem);
                            },
                            error: function (xhr, status, error) {
                                console.log(status, error);
                            }
                        });
                    }
                    function saatSecimiGerceklestir(veriAl) {
                        document.getElementById('<%= saatVerisi.ClientID %>').value = veriAl;
                    }
                </script>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="randevuNot">Hasta Randevu Not: </label>
                        <asp:TextBox runat="server" ID="randevuNot" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </td>
            </tr>
        
        </table>
    </main>
 
    <asp:Button Text="+ Randevu Ekle" ID="randevuEkle_Buton" CssClass="btn btn-success" runat="server" OnClick="randevuEklemeButon_Click" />
</asp:Content>


