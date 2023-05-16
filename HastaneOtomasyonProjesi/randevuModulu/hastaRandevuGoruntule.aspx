<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hastaRandevuGoruntule.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.randevuModulu.hastaRandevuGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="randevuId" HeaderText="Randevu ID" />
                <asp:BoundField DataField="hastaId" HeaderText="Hasta ID" />
                <asp:BoundField DataField="randevuPoliklinik" HeaderText="Randevu Poliklinik" />
                <asp:BoundField DataField="randevuTarih" HeaderText="Randevu Tarih" />
                <asp:BoundField DataField="randevuSaat" HeaderText="Randevu Saat" />
                <asp:BoundField DataField="randevuNot" HeaderText="Randevu Not" />
                <asp:BoundField DataField="randevuDurumu" HeaderText="Randevu Durumu" />
                <asp:BoundField DataField="randevuDoktor" HeaderText="Randevu Doktor" />
            </Columns>
        </asp:GridView>
        
        &nbsp&nbsp
        <table cellpadding="15">
            <tr>
                <td>
                    <div>
                        <label for="tcNo">Hasta TCNO: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="hastaTcInput" />
                    </div>
                </td>
                <td>
                    <div>

                        <asp:Button Text="+ Hasta Detay Görüntüleme" ID="Button1" CssClass="btn btn-success" runat="server" OnClick="detayGor_Buton_Click" />
                    </div>
                </td>
            </tr>

           
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label1" runat="server" Text="Randevu Poliklinik: "></asp:Label></td>
                <td>
                    <asp:Label CssClass="labels" ID="randevuPoliklinik" runat="server" Text="........"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label2" runat="server" Text="Randevu Tarih: "></asp:Label></td>
                <td>
                    <asp:Label CssClass="labels" ID="randevuTarih" runat="server" Text="........"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label6" runat="server" Text="Randevu Saat: "></asp:Label></td>
                <td>
                    <asp:Label CssClass="labels" ID="randevuSaat" runat="server" Text="........"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label3" runat="server" Text="Randevu Not: "></asp:Label></td>
                <td>
                    <asp:Label CssClass="labels" ID="randevuNot" runat="server" Text="........"></asp:Label></td>
            </tr>
           <%-- <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label4" runat="server" Text="Randevu Durumu: "></asp:Label></td>
                <td>
                    <asp:Label CssClass="labels" ID="randevuDurumu" runat="server" Text="........"></asp:Label></td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label CssClass="labels" ID="Label5" runat="server" Text="Randevu Doktor: "></asp:Label></td>
                <td>
                    <asp:Label CssClass="labels" ID="randevuDoktor" runat="server" Text="........"></asp:Label></td>
            </tr>
        </table>
        <style>
            table {
                width: 100%;
                border-collapse: collapse;
            }

                table th {
                    text-align: center;
                    background-color: #2196F3;
                    color: white;
                }

                table th, td {
                    border: 1px solid blue;
                    padding: 6px;
                }



                table tr:hover {
                    background-color: #ddd;
                }
        </style>
    </main>
</asp:Content>
