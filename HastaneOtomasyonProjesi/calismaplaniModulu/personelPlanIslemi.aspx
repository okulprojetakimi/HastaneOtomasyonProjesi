<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Personel Çalışma Plan İşlemleri" CodeBehind="personelPlanIslemi.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.personelPlanIslemi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-days"></i> Personel Çalışma Plan İşlemleri</h1>
        <p style="color: white;">Bu sayfada personel için aylık planlama yapabilir, daha önce yapılmış planlar görüntülenebilir ve düzenlenebilir. Ayrıca pdf şeklinde de dışarı aktarım işlemi gerçekleştirebilirsiniz.</p>
        <br />
        <table cellpadding="12">
            <tr>
                <td><a href="personelPlanEkle.aspx"><button type="button" class="btn btn-success" id="planEkle">+ Plan Ekleme</button></a></td>
                <td><a href="personelPlanGoruntuleme.aspx"><button type="button" class="btn btn-success" id="planGoruntule"><i class="fa-solid fa-list"></i> Plan Görüntüleme / Güncelleme</button></a></td>
            </tr>
        </table>
    </main>
</asp:Content>