<%@ Page Language="C#" Title="Hasta İlaç Görüntüle" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaIlacGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaIlacGoruntuleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Kutu -->
        <div class="hasta_IlacGoruntuleme_Kutusu">
            <h2>İlaca devam edilecekmi?</h2>
            <asp:DropDownList ID="ilacDurum" runat="server">
                <asp:ListItem Text="İlaca Devam" Value="1"></asp:ListItem>
                <asp:ListItem Text="İlaç Kesildi" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <br />
            <asp:Button CssClass="btn btn-info" Text="İlaç Kaydını Düzenle" ID="hasta_IlacDuzenle" runat="server" OnClick="hasta_IlacDuzenle_Click" />
        </div>
    </main>
</asp:Content>
