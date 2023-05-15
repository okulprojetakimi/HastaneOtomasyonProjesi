<%@ Page Language="C#" Title="Personel Detay" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personelDetay.aspx.cs" Inherits="HastaneOtomasyonProjesi.personelModulu.personelDetay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1><i class="fa-solid fa-person"></i> Personel Detay Görüntüleme</h1>
        <p>Bu sayfada personel verilerini görüntüleyebilir, düzenlemeler yapabilirsin.</p>
        <br />
        <div class="personel_Info">
            <asp:SqlDataSource ID="personelData_Source" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" runat="server" SelectCommand="SELECT * FROM personel_tablo WHERE personel_Tc = @pTc" />
            <asp:SqlDataSource runat="server" > 

            </asp:SqlDataSource>
            <SelecParameters>
                <asp:Parameter Name="pTc" Type="String" DefaultValue="<% HttpContext.Current.Request.QueryString["personelTc"].ToString(); %>" />
            </SelecParameters>

            <asp:TextBox runat="server" ID="personel_Tc" />
            <asp:TextBox runat="server" ID="personel_Isim" />
            <asp:TextBox runat="server" ID="personel_Soyisim" />
            <asp:TextBox runat="server" ID="personel_Telefon" />
            <asp:TextBox runat="server" ID="personel_Eposta" />
            <asp:TextBox runat="server" ID="personel_SicilNo" />
            <asp:TextBox runat="server" ID="personel_Bolum" />
            <asp:TextBox runat="server" ID="personel_SozlesmeTipi" />
            <asp:TextBox runat="server" ID="personel_kanGrubu" />
            <asp:TextBox runat="server" ID="personel_ikametAdres" />
            <asp:TextBox runat="server" ID="personel_Turu" />
            <asp:TextBox runat="server" ID="personel_izinDurum" />

        </div>
    </main>
</asp:Content>