<%@ Page Language="C#" Title="Hasta Not Görüntüleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaNotGoruntuleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaNotGoruntuleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- -->
        <table cellpadding="50">
            <tr>
                <td>
                    <h1 style="color: white;"><i class="fa-solid fa-pen"></i>Hasta Not Görüntüleme</h1>
                    <table>
                        <style>
                            .labels {
                                color: white;
                                font-weight: bolder;
                            }
                        </style>
                        <tr>
                            <td><i style="color: white;" class="fa-solid fa-passport"></i>
                                <asp:Label CssClass="labels" ID="on_label_2" runat="server" Text="Hasta TC: "></asp:Label></td>
                            <td>
                                <asp:Label CssClass="labels" ID="hasta_TcLabel" runat="server" Text="........"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><i style="color: white;" class="fa-solid fa-user"></i>
                                <asp:Label CssClass="labels" ID="on_label" runat="server" Text="Not eklenen hasta adı: "></asp:Label></td>
                            <td>
                                <asp:Label CssClass="labels" ID="hasta_IsimSoyisim" runat="server" Text="........"></asp:Label></td>
                        </tr>
                        
                    </table>
                </td>
                <td>
                    <h1 style="color: white;"><i class="fa-light fa-square-pen"></i>Not Formu</h1>
                    <div class="not_EklemeDiv">
                        <div class="form-group">
                            <label style="color: white;" for="exampleFormControlTextarea1">Not</label>
                            <asp:TextBox ReadOnly="true" style="width: 241px;" TextMode="MultiLine" ID="eski_Veri" CssClass="form-control" runat="server" />
                            <br />
                            <asp:TextBox Text="Yeni notu giriniz....." style="width: 241px;" TextMode="MultiLine" ID="hastaNotu" CssClass="form-control" runat="server" />
                        </div>
                        <asp:Button CssClass="btn btn-info" Text="Not Düzenle" runat="server" ID="hastaNot_Duzenle" OnClick="hastaNot_Duzenle_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </main>
</asp:Content>
