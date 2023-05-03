<%@ Page Language="C#" Title="Hasta İlaç Görüntüle" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaIlacGoruntuleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaIlacGoruntuleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Kutu -->
        <div class="hasta_IlacGoruntuleme_Kutusu">
            
            <asp:Button CssClass="btn btn-info" Text="İlaç Düzenle" ID="hasta_IlacDuzenle" runat="server" />
        </div>
    </main>
</asp:Content>