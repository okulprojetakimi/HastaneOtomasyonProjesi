<%@ Page Title="Hasta İşlemleri" Language="C#" AutoEventWireup="true" CodeBehind="hastaIslemleri.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.hastaIslemleri" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <main>
        <!-- Hasta Işlemleri ( Hasta arama filtreleme) -->
        <asp:Button CssClass="btn btn-info" Text="+ Yeni Hasta Ekle" runat="server" ID="yeniHastaEkle" OnClick="yeniHastaEkle_Click" />
        <br />
        <br />
        <form action="hastaIslemleri.aspx" method="post">
            <h2 style="color: white;">Hasta Filtreleme</h2>
            <table cellpadding="15">
                <tr>
                    <td>
                        <div class="form-group">
                            <input type="text" class="form-control" id="hastaIsim" name="hastaIsmi" placeholder="Hasta ismi giriniz">
                        </div>
                    </td>

                    <!-- -->
                    <td>
                        <div class="form-group">
                            <input type="text" class="form-control" id="hastaSoyisim" name="hastaSoyismi" placeholder="Hasta soyismi giriniz">
                        </div>
                    </td>
                    <!-- -->
                    <td>
                        <asp:Button ID="hasta_Ara" Text="Hasta Ara" name="hasta_Ara" CssClass="btn btn-primary" runat="server" OnClick="hasta_Ara_Click" />
                        <!-- <button type="submit" name="hasta_Filtrele" class="btn btn-primary">Hasta ara</button> -->
                    </td>
                </tr>
            </table>

        </form>

        <!-- Hasta tablosu -->
        <style>
            .table {
                font-family: Arial, sans-serif;
                border-collapse: collapse;
                width: 100%;
            }

                .table th {
                    background-color: #0099cc;
                    color: #fff;
                    font-weight: bold;
                    padding: 8px;
                    text-align: left;
                }

                .table td {
                    border: 1px solid #ddd;
                    padding: 8px;
                }

                .table tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                .table tr {
                    background-color: #fff;
                }

                    .table tr:nth-child(even) {
                        background-color: #f2f2f2;
                    }
        </style>
        <div>
            <asp:GridView ID="enYeniOnHasta" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="hasta_Tc" HeaderText="Hasta TC" />
                    <asp:BoundField DataField="hasta_Adi" HeaderText="Hasta İsmi" />
                    <asp:BoundField DataField="hasta_Soyadi" HeaderText="Hasta Soyismi" />
                    <asp:BoundField DataField="hasta_yakinAdi" HeaderText="Hasta Yakın Adı" />
                    <asp:BoundField DataField="hasta_tedaviDurumu" HeaderText="Hasta Tedavi Durumu" />
                </Columns>
            </asp:GridView>
        </div>

        <!-- Hasta Listesi Bitişi -->
        <br />
        <!-- Hasta Görüntüleme Formu -->
        <h2 style="color: white;">Hasta İşlem</h2>
        <br />
        <div class="form-group">
            <asp:TextBox CssClass="form-control" ID="hasta_Tc_Numara" runat="server" />
            <!-- <input maxlength="11" type="text" class="form-control" id="hasta_Goruntuleme_Tc" name="hasta_Goruntuleme_Tc" placeholder="Hasta TCKN"> -->

            <label style="color: white;"><span>Görüntülemek istediğiniz hastanın tc sini giriniz.</span></label>
            <br />
        </div>
        <asp:Button Text="Hasta Görüntüle" ID="hastaGoruntule_Buton" CssClass="btn btn-info" runat="server" OnClick="hastaGoruntule_Buton_Click" />
        <asp:Button Text="Hasta Bilgileri Görüntüle" ID="hastaBilgileriGoruntule" CssClass="btn btn-info" runat="server" OnClick="hastaBilgileriGoruntule_Click" />
    </main>
</asp:Content>
