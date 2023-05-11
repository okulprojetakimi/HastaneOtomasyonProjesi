<%@ Page Language="C#" Title="Tetkik Detay Ekleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tetkikDetayEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.tetkikDetayEkleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th>
                <h1>Laboratuvar Tetkik Detay Ekle</h1>
            </th>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="tetkik_Sonuc">Tetkik Sonuc:</label>
                        <asp:TextBox ID="tetkik_Sonuc" CssClass="form-control" TextMode="Number" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
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
                <td> Doktor: <asp:DropDownList AutoPostBack="false" CssClass="btn btn-primary dropdown-toggle" ID="secim" runat="server">
                    </asp:DropDownList></td> 
                
            </tr>
            <tr>
                <td> Tetkik Adı: <asp:DropDownList CssClass="btn btn-primary dropdown-toggle" AutoPostBack="false" ID="labTetkikAdi"  runat="server">
                    </asp:DropDownList>
                </td> 
            </tr>
        </table>
    </main>
      <asp:Button CssClass="btn btn-success" Text="+ Laboratuvar Tetkik Ekle" ID="Button_Click109" runat="server" OnClick="labDetayEkleButon_click" />
     
</asp:Content>
