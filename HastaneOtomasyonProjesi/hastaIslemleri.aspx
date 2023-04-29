<%@ Page Title="Hasta İşlemleri" Language="C#" AutoEventWireup="true" CodeBehind="hastaIslemleri.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.hastaIslemleri" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <main>
        <!-- Hasta Işlemleri ( Hasta arama filtreleme) -->
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
                        <button type="submit" name="hasta_Filtrele" class="btn btn-primary">Hasta ara</button>
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
        <form action="" method="post">
            <h2 style="color: white;">Hasta Görüntüleme</h2>
            <br />
            <table cellpading="10">
                <tr>
                    <th>
                        <div class="form-group">
                            <input type="text" class="form-control" id="hastaIsim" name="hastaIsmi" placeholder="Hasta ismi giriniz">
                        </div>
                    </th>
                    <th>
                            <button type="submit" name="hasta_Goruntule" class="btn btn-info">Hasta Görüntüle</button>
                    </th>
                </tr>
            </table>
        </form>

    </main>
</asp:Content>
