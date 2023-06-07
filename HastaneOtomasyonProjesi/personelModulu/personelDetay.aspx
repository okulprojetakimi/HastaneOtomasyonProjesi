<%@ Page Language="C#" Title="Personel Detay" EnableViewState="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personelDetay.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.personelDetay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-person"></i>Personel Detay Görüntüleme</h1>
        <p style="color: white;">Bu sayfada personel verilerini görüntüleyebilir, düzenlemeler yapabilirsin.</p>
        <br />
        <div class="personel_Info">
            <style>
                label {
                    color: white;
                }
            </style>
            <table cellpadding="12">
                <tr>
                    <td>
                        <label for="personel_Tc">Personel TC: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_Tc" />
                    </td>
                    <td>
                        <label for="personel_Isim">Personel Isim: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_Isim" />
                    </td>
                    <td>
                        <label for="personel_Soyisim">Personel Soyisim: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_Soyisim" />
                    </td>
                    <td>
                        <label for="personel_Telefon">Personel Telefon No: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_Telefon" />
                    </td>
                </tr>
                <!-- -->
                <tr>
                    <td>
                        <label for="personel_Eposta">Personel Eposta: </label>
                        <asp:TextBox CssClass="form-control" TextMode="Email" runat="server" ID="personel_Eposta" />
                    </td>
                    <td>
                        <label for="personel_SicilNo">Sicil No: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_SicilNo" />
                    </td>
                    <td>
                        <label for="personel_Bolum">Personel Bölüm</label>
                        <asp:DropDownList DataValueField="pBolumID" DataTextField="pBolumIsmi" DataSourceID="bolum_Cek" ID="personel_Bolum" runat="server" CssClass="btn btn-primary dropdown-toggle">
                            <asp:ListItem Text="Seçim Yap" Value="0" />
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="bolum_Cek" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT pBolumID, pBolumIsmi FROM personelBolum_tablo"></asp:SqlDataSource>

                    </td>
                    <td>
                        <label for="personel_SozlesmeTipi">Personel Sözleşme Tipi</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_SozlesmeTipi" />
                    </td>
                </tr>
                <!-- -->
                <tr>
                    <td>
                        <label for="personel_kanGrubu">Personel Kan Grubu: </label>
                        <asp:DropDownList ID="personel_kanGrubu" runat="server" CssClass="btn btn-primary dropdown-toggle">
                            <asp:ListItem Text="Seçim yap" Value="0" />
                            <asp:ListItem Text="A RH+" Value="1"></asp:ListItem>
                            <asp:ListItem Text="A RH-" Value="2"></asp:ListItem>
                            <asp:ListItem Text="0 RH+" Value="3"></asp:ListItem>
                            <asp:ListItem Text="0 RH-" Value="4"></asp:ListItem>
                            <asp:ListItem Text="B+" Value="5"></asp:ListItem>
                            <asp:ListItem Text="B-" Value="6"></asp:ListItem>
                            <asp:ListItem Text="AB-" Value="7"></asp:ListItem>
                            <asp:ListItem Text="AB+" Value="8"></asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>
                        <label for="personel_ikametAdres">İkamet Adres: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_ikametAdres" />
                    </td>
                    <td>
                        <label>Personel Türü</label>
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
                    </td>
                    <td>
                        <label for="personel_izinDurum">Personel İzin Durumu: </label>
                        <asp:DropDownList ID="personel_izinDurum" runat="server" CssClass="btn btn-primary dropdown-toggle">
                            <asp:ListItem Text="Personel İzinde" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Personel İzinde Değil" Value="0" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

            <asp:Button ID="personel_Guncelle" Text="Kaydet" CssClass="btn btn-warning" runat="server" OnClick="personel_Guncelle_Click" />
        </div>
    </main>
</asp:Content>
