<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Personel Plan Görüntüleme" CodeBehind="personelPlanGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.personelPlanGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<main>
    <h1 style="color: white;">Personel Çalışma Planı</h1>
    <p style="color: white;">Bu sayfada seçilen personelin belirtilen tarihteki çalışma planını görüntüleyebilir ve silebilirsiniz.</p>
    <br />
    <button>Listeyi Dışa Aktar</button>
    <div class="planListe_Div">

    </div>
</main>
</asp:Content>