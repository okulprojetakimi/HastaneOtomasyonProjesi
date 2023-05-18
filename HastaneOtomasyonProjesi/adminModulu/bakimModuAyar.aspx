<%@ Page Language="C#" Title="Bakım Modu Ayarı" MasterPageFile="~/adminModulu/adminTema.Master" AutoEventWireup="true" CodeBehind="bakimModuAyar.aspx.cs" Inherits="HastaneOtomasyonProjesi.adminModulu.bakimModuAyar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: White;">Bakım Ayarları</h1>
        <p style="color: white;">Bu sayfada bakım modunu değiştireiblir ayarları konfigure edebilirsiniz.</p>
        <br />
        <div class="div_Form">
            <table cellpadding="15">
                <tr>
                    <td>
                        <div>
                            <label>Bakım Durumu</label>
                            <asp:DropDownList ID="bakimDurum" CssClass="btn btn-primary dropdown-toggle" runat="server">
                                <asp:ListItem Text="Bakım Devre Dışı" Value="0" />
                                <asp:ListItem Text="Bakım Aktif" Value="1" />
                            </asp:DropDownList>
                        </div>
                    </td>

                    <td>
                        <div>
                            <label>Bakım Sayfası Başlığı</label>
                            <asp:TextBox CssClass="form-control" ID="ayar_Title" TextMode="SingleLine" runat="server" />
                        </div>
                    </td>
                </tr>
            </table>
            <br>
            <div>
                <label>Bakım Sayfası Mesajı</label>
                <asp:TextBox ID="ayar_BakimMesaji" CssClass="form-control" TextMode="MultiLine" runat="server" />
            </div>
            <br />
            <asp:Button Text="Bakım ayarlarını kaydet" ID="bakim_Kaydet" CssClass="btn btn-success" runat="server" OnClick="bakim_Kaydet_Click" />
        </div>
    </main>
</asp:Content>
