<%@ Page Language="C#" Title="Hasta Randevu Görüntüleme" AutoEventWireup="true" CodeBehind="hastaRandevuGoruntule.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.randevuModulu.hastaRandevuGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:HiddenField ID="secilenPoliklinik" runat="server" />
        <asp:HiddenField ID="secilenDoktor" runat="server" />
        <table cellpadding="15">
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label6" runat="server" Text="Randevu Poliklinik: "></asp:Label>
                </td>
                <td>
                    <%--  <asp:DropDownList DataSourceID="poliklinik_Cek" DataValueField="pId" DataTextField="Poliklinik İsim" CssClass="form-control" runat="server" ID="randevuPoliklinik" />
                    <asp:SqlDataSource ID="poliklinik_Cek" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT  pId , pIsim  AS [Poliklinik İsim] FROM poliklinik_Tablo "></asp:SqlDataSource>--%>
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
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label2" runat="server" Text="Randevu Tarih: "></asp:Label>
                </td>
                <td>
                    <input type="date" class="form-control" runat="server" id="randevuTarih" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label3" runat="server" Text="Randevu Saat: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" runat="server" ID="randevuSaat" TextMode="Time" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label4" runat="server" Text="Randevu Not: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" runat="server" ID="randevuNot" TextMode="MultiLine" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label5" runat="server" Text="Randevu Doktor: "></asp:Label>
                </td>
                <td>
                    <%-- <asp:DropDownList DataSourceID="doktor_Cek" DataValueField="personel_Id" DataTextField="Personel Isim Soyisim" CssClass="form-control" runat="server" ID="randevuDoktor" />
                    <asp:SqlDataSource ID="doktor_Cek" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT personel_Id, personel_Isim + ' ' +  personel_Soyisim AS [Personel Isim Soyisim] FROM personel_Tablo WHERE personel_Turu = 'Doktor'"></asp:SqlDataSource>--%>
                    <select id="randevuDoktor" class="btn btn-info dropdown-toggle">
                        <option>Doktor seçiniz.</option>
                    </select>
                </td>
            </tr>
        </table>

        <script>
            $(document).ready(function () {
                $("#randevuPoliklinik").change(function () {
                    document.getElementById('<%= secilenPoliklinik.ClientID %>').value = document.getElementById("randevuPoliklinik").value;
                    $.ajax({
                        type: "GET",
                        url: "doktorListe.aspx",
                        data: { poliklinikId: $(randevuPoliklinik).val() },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var html = "<option>Doktor seçiniz.</option>";
                            $.each(data, function (key, value) {
                                html += "<option value='" + value.personel_Id + "'>" + value.personel_Isim + " " + value.personel_Soyisim + "</option>";
                            });
                            $("#randevuDoktor").html(html);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log(textStatus, errorThrown);
                        }
                    });
                });
            });
            $(document).ready(function () {
                $("#randevuDoktor").change(function () {
                    document.getElementById('<%= secilenDoktor.ClientID %>').value = document.getElementById("randevuDoktor").value;
                });
             });
        </script>

        <style>
            table {
                width: 100%;
                border-collapse: collapse;
            }

                table th {
                    text-align: center;
                    background-color: #2196F3;
                    color: white;
                }

                table th, td {
                    border: 1px solid blue;
                    padding: 6px;
                }



                table tr:hover {
                    background-color: #ddd;
                }
        </style>
    </main>
    <asp:Button Text="Hasta Detay Güncelleme" ID="Button1" CssClass="btn btn-success" runat="server" OnClick="randevu_Guncelle_Click" />
</asp:Content>


