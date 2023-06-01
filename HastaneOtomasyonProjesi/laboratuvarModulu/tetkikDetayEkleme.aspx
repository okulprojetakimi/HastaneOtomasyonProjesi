<%@ Page Language="C#" Title="Tetkik Detay Ekleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tetkikDetayEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.tetkikDetayEkleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th>
                <h1 style="color: white;">Laboratuvar Tetkik Detay Ekle</h1>
            </th>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="tetkik_Sonuc">Tetkik Sonuc:</label>
                        <asp:TextBox ID="tetkik_Sonuc" CssClass="form-control" runat="server" />
                    </div>
                </td>
               
                    
            </tr>
            <tr>
                <td>Doktor: <asp:DropDownList DataValueField="personel_Id" DataTextField="Personel Isim Soyisim" DataSourceID="doktor_Cek" CssClass="btn btn-primary dropdown-toggle" ID="PersonelSecimi" runat="server">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="doktor_Cek" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT personel_Id, personel_Isim + ' ' +  personel_Soyisim AS [Personel Isim Soyisim] FROM personel_Tablo WHERE personel_Turu = 'Doktor'"></asp:SqlDataSource>
                </td>  
                 <td>
                    </br>
                    <div class="form-grop">
                        <label for="tetkikdetay_Durum">Tetkik Durumu:</label>
                        <asp:DropDownList CssClass="btn btn-primary dropdown-toggle" ID="tetkikdetay_Durum" runat="server">
                            <asp:ListItem Value="1" Text="Tamamlandı" />
                            <asp:ListItem Value="0" Text="Tamamlanmadı" />
                        </asp:DropDownList>
                    </div>
                    </td>
            </tr>
            <tr>
                <td>Tetkik Tanımı: <asp:DropDownList DataValueField="tanim_Id" DataTextField="Tetkik Tanımı" DataSourceID="tahlilTanim" CssClass="btn btn-primary dropdown-toggle" ID="labTetkikAdı" runat="server">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="tahlilTanim" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT tanim_Id, tanim_tahlilIsmi AS [Tetkik Tanımı] FROM tetkik_Tanimlari"></asp:SqlDataSource>
                </td>  

            </tr>
        </table>
        <asp:Button CssClass="btn btn-success" Text="+ Laboratuvar Tetkik Ekle" ID="Button_Click109" runat="server" OnClick="labDetayEkleButon_click" />
        <br />
        <br />
        <div class="eklenen_Div">
            <h2 style="color: white;">Daha önce eklenen değerler</h2>
            <asp:GridView ID="tetkikDetaylari" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <br />

        </div>
    </main>
      
     
</asp:Content>
