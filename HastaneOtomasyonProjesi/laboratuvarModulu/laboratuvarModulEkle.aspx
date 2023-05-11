<%@ Page Title="Tetkik Ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="laboratuvarModulEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.laboratuvarModulu.laboratuvarModulEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th>
                <h1 style="color:white;">Laboratuvar Tetkik Ekle</h1>
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
                <td> Doktor: <asp:DropDownList DataValueField="personel_Id" DataTextField="Personel Isim Soyisim" DataSourceID="doktor_Cek" CssClass="btn btn-primary dropdown-toggle" ID="labPersonelSecimi" runat="server">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="doktor_Cek" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT personel_Id, personel_Isim + ' ' +  personel_Soyisim AS [Personel Isim Soyisim] FROM personel_Tablo WHERE personel_Turu = 'Doktor'"></asp:SqlDataSource>
                </td> 

            </tr>
        </table>
        <br />
    <asp:Button CssClass="btn btn-success" Text="+ Laboratuvar Tetkik Ekle" ID="Button_Click09" runat="server" OnClick="labEkleButon_click" />
     
    </main>
</asp:Content>
