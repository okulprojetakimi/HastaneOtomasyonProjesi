<%@ Page Language="C#" Title="Hasta İlaç Görüntüle" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaIlacGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaIlacGoruntuleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Kutu -->
        <div class="hasta_IlacGoruntuleme_Kutusu">
            <h2>İlaç kaydı görüntüleme</h2>
            <asp:CheckBox ID="devamDurumu" Text="İlaca devam ediliyormu?" runat="server" />
            <br />
            <asp:Button CssClass="btn btn-info" Text="İlaç Kaydını Düzenle" ID="hasta_IlacDuzenle" runat="server" OnClick="hasta_IlacDuzenle_Click" />
        </div>
    </main>
</asp:Content>