<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="laboratuvarModulEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.laboratuvarModulu.laboratuvarModulEkle" %>

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
                        <input type="date" class="form-control" id="tetkik_istekTarih" name="tetkik_istekTarih" aria-describedby="tetkik_istekTarih" placeholder="Tetkik İstek Tarih ">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-grop">
                        <label for="tetkik_durum">Tetkik Durumu:</label>
                        <input type="number" class="form-control" id="tetkik_durum" name="tetkik_durum" aria-describedby="tetkik_durum" placeholder="Tetkik Durum ">
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
