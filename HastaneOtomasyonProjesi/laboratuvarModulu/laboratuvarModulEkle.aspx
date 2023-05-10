<%@ Page Title="Tetkik Ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="laboratuvarModulEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.laboratuvarModulu.laboratuvarModulEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
            <th>
                <h1>Laboratuvar Tetkik Ekle</h1>
            </th>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="tetkik_istekTarih">Tetkik Giris Tarihi:</label>
                        <asp:TextBox TextMode="DateTimeLocal" ID="tetkik_istekTarih" CssClass="form-control" runat="server" />
                        <input type="date" class="form-control" id="" name="tetkik_istekTarih" aria-describedby="tetkik_istekTarih" placeholder="Tetkik İstek Tarih ">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="tetkik_durum">Tetkik Durumu:</label>
                        <asp:DropDownList CssClass="btn btn-primary dropdown-toggle" ID="tetkik_durum" runat="server">
                            <asp:ListItem Value="1" Text="Tamamlandı" />
                            <asp:ListItem Value="0" Text="Tamamlanmadı" />
                        </asp:DropDownList>
                    </div>

                </td>
            </tr>
            <tr>
                <br />
                <br />
                <td> Doktor: <asp:DropDownList CssClass="btn btn-primary dropdown-toggle" ID="labPersonelSecimi" runat="server">
                    </asp:DropDownList></td> 
                 <br />
            </tr>
        </table>
    </main>
    <asp:Button CssClass="btn btn-success" Text="+ Laboratuvar Tetkik Ekle" ID="Button_Click09" runat="server" OnClick="labEkleButon_click" />
     
</asp:Content>
