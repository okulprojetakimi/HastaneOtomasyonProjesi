<%@ Page Language="C#" Title="Hasta İlaç Görüntüle" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaIlacGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaIlacGoruntuleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Kutu -->
        <div class="hasta_IlacGoruntuleme_Kutusu">
            <h2 style="color: white;">İlaca devam edilecekmi?</h2>
            <br />
            <asp:DropDownList CssClass="btn btn-info dropdown-toggle dropdown-toggle-split" ID="ilacDurum" runat="server">
                <asp:ListItem Text="İlaca Devam" Value="1"></asp:ListItem>
                <asp:ListItem Text="İlaç Kesildi" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button CssClass="btn btn-success" Text="Kaydet" ID="hasta_IlacDuzenle" runat="server" OnClick="hasta_IlacDuzenle_Click" />
        </div>
    </main>
</asp:Content>
