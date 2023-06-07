<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personelEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.personelEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:HiddenField ID="secilenPoliklinik" runat="server" />
        <table callpaddin="15">
            <tr>
                <th>Personel Bilgileri</th>
                <th>Personel İlteşim Bilgileri</th>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_Tc">Personel TCNO:</label>
                        <asp:TextBox ID="personel_Tc" CssClass="form-control" runat="server" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="personel_Telefon">Personel Telefon No:</label>
                        <asp:TextBox ID="personel_Telefon" CssClass="form-control" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_Isim">Personel İsim:</label>
                        <asp:TextBox ID="personel_Isim" CssClass="form-control" runat="server" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="personel_Eposta">Personel E-posta:</label>
                        <asp:TextBox TextMode="Email" ID="personel_Eposta" CssClass="form-control" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_Soyisim">Personel Soyisim:</label>
                        <asp:TextBox ID="personel_Soyisim" CssClass="form-control" runat="server" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="personel_ikametAdres">Personel İkamet Adresi:</label>
                        <asp:TextBox ID="personel_ikametAdres" CssClass="form-control" TextMode="MultiLine" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_SicilNo">Personel Sicil No:</label>
                        <asp:TextBox ID="personel_SicilNo" CssClass="form-control" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_SozlesmeTipi">Personel Sözleşme Tipi:</label>
                        <asp:TextBox ID="personel_SozlesmeTipi" CssClass="form-control" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_kanGrubu">Kan Grubu</label>
                        <select class="form-control" id="personel_kanGrubu" name="personel_kanGrubu">
                            <option>Kan Grubu Seçiniz</option>
                            <option value="1">A RH+</option>
                            <option value="2">A RH-</option>
                            <option value="3">0 RH+</option>
                            <option value="4">0 RH-</option>
                            <option value="5">B+</option>
                            <option value="6">B-</option>
                            <option value="7">AB-</option>
                            <option value="8">AB+</option>
                        </select>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_Turu">Personel Türü:</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="personel_Turu">
                            <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Doktor" Value="Doktor"></asp:ListItem>
                            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                            <asp:ListItem Text="Şöfor" Value="Şoför"></asp:ListItem>
                            <asp:ListItem Text="Temizlik Görevlisi" Value="Temizlik Görevlisi"></asp:ListItem>
                            <asp:ListItem Text="Anestezi Teknikeri" Value="Anestezi Teknikeri"></asp:ListItem>
                            <asp:ListItem Text="Laboratuvar Teknikeri" Value="Laboratuvar Teknikeri"></asp:ListItem>
                            <asp:ListItem Text="Danışman" Value="Hasta Danışmanı"></asp:ListItem>
                            <asp:ListItem Text="Hemşire" Value="Hemşire"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="personel_Bolum">Personel Bölüm: </label>
                        <select id="personel_Bolum" class="btn btn-info dropdown-toggle">
                            <option>Bölüm seçiniz.</option>
                            <%
                                using (System.Data.SqlClient.SqlConnection pol = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                                {
                                    pol.Open();
                                    using (System.Data.SqlClient.SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand("SELECT pBolumID, pBolumIsmi FROM personelBolum_tablo", pol))
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
                <script>
                    $(document).ready(function () {
                        $("#personel_Bolum").change(function () {
                            document.getElementById('<%= secilenPoliklinik.ClientID %>').value = document.getElementById("personel_Bolum").value;
                            $.ajax({
                                type: "GET",
                                url: "veriIslem.aspx",
                                data: { bolumId: $(personel_Bolum).val() },
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

                </script>
            </tr>
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
        </table>
    </main>
    <asp:Button CssClass="btn btn-success" Text="+ Hasta Ekle" ID="Button31_Click31" runat="server" OnClick="personelEkleButon_click" />
</asp:Content>
