<%@ Page Language="C#" Title="Personel Detay" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personelDetay.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.personelDetay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-person"></i> Personel Detay Görüntüleme</h1>
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
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_Bolum" />
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
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_kanGrubu" />
                    </td>
                    <td>
                        <label for="personel_ikametAdres">İkamet Adres: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_ikametAdres" />
                    </td>
                    <td>
                        <label>Personel Türü</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_Turu" />
                    </td>
                    <td>
                        <label for="personel_izinDurum">Personel İzin Durumu: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="personel_izinDurum" />
                    </td>
                </tr>
            </table>

            <asp:Button ID="personel_Guncelle" Text="Kaydet" CssClass="btn btn-warning" runat="server" OnClick="personel_Guncelle_Click" />
        </div>
    </main>
</asp:Content>
