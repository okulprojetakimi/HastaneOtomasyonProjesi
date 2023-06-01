<%@ Page Title="Tetkik Ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="laboratuvarModulEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.laboratuvarModulu.laboratuvarModulEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="tetkik_Ekleme_Div">
            <table>
                <th>
                    <h1 style="color: white;">Laboratuvar Tetkik Ekle</h1>
                </th>
                <tr>
                    <td>
                        <div class="form-grop">
                            <label for="tetkik_istekTarih">Tetkik Giris Tarihi:</label>
                            <asp:TextBox TextMode="DateTimeLocal" ID="tetkik_istekTarih" CssClass="form-control" runat="server" />
                        </div>
                    </td>
                    <td>
                        <div class="form-grop">
                            <label for="tetkik_durum">Tetkik Durumu:</label>
                            <asp:DropDownList CssClass="btn btn-primary dropdown-toggle" ID="tetkik_durum" runat="server">
                                <asp:ListItem Value="1" Text="Tamamlandı" />
                                <asp:ListItem Value="0" Text="Tamamlanmadı" />
                            </asp:DropDownList>
                        </div>

                    </td>
                    <td>Doktor:
                        <asp:DropDownList DataValueField="personel_Id" DataTextField="Personel Isim Soyisim" DataSourceID="doktor_Cek" CssClass="btn btn-primary dropdown-toggle" ID="labPersonelSecimi" runat="server">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="doktor_Cek" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT personel_Id, personel_Isim + ' ' +  personel_Soyisim AS [Personel Isim Soyisim] FROM personel_Tablo WHERE personel_Turu = 'Doktor'"></asp:SqlDataSource>
                    </td>

                </tr>
            </table>
            <br />
            <asp:Button CssClass="btn btn-success" Text="+ Laboratuvar Tetkik Ekle" ID="Button_Click09" runat="server" OnClick="labEkleButon_click" />
        </div>
        <br />
        <!-- Tetkik Arama İşlemi -->
        <div class="tetkik_Arama_Div">
            <h1 style="color: white;">Tetkik Arama</h1>
            <p style="color: white;">Buradan düzenlemek istediğiniz tetkikleri arayabilir ve düzenleyebilirsiniz.</p>
            <br />
            <table>
                <tr>
                    <td>Tetkik İstek Tarihi: </td>
                    <td>
                        <asp:TextBox CssClass="form-control" TextMode="Date" ID="tetkik_Tarihi" runat="server" /></td>
                    <td>
                        <asp:Button Text="Ara" runat="server" ID="tetkik_AraButon" CssClass="btn btn-success" OnClick="tetkik_AraButon_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="tablo_Div">
                <asp:GridView ID="tetkikListe" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <table>
                <tr>
                    <td>Düzenlenecek tetkik numarası: </td>
                    <td>
                        <asp:TextBox CssClass="form-control" TextMode="Number" ID="id_Degeri" runat="server" /></td>
                    <td>
                        <asp:Button Text="Ara" runat="server" ID="ara_Buton" CssClass="btn btn-success" OnClick="ara_Buton_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </main>
</asp:Content>
