<%@ Page Language="C#" AutoEventWireup="true" Title="Perosnel Çalışma Planı Dışa Aktar" MasterPageFile="~/Site.Master" CodeBehind="personelListeAl.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.personelListeAl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;">Çalışma Planı Dışa Aktarma -
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </h1>
        <p style="color: white;">Bu sayfada seçilen personelin belirtilen tarih aralığındaki çalışma planlarını excel verisi olarak aktarabilirsiniz.</p>
        <br />
        <!-- 
        
        -->
        <div class="tarihSecim_Div">
            <table cellpadding="15">
                <tr>
                    <td><label>Başlangıç Tarihi: </label><asp:TextBox TextMode="Month" CssClass="form-control" ID="baslangic_Tarih" runat="server" /></td>
                    <td><label>Bitiş Tarihi: </label><asp:TextBox TextMode="Month" ID="bitis_Tarihi" CssClass="form-control" runat="server" /></td>
                    <td>
                        <asp:Button Text="Plan Listesi Çek" CssClass="btn btn-success" ID="plan_Cek" runat="server" OnClick="plan_Cek_Click" /></td>
                </tr>
            </table>
        </div>
        <!-- Plan Tablosu -->
        <div class="tablo_Div">

            <asp:GridView AutoGenerateColumns="True" ID="listeGridView" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
            <br />
            <asp:Button Text="Listeyi Dışarı Aktar" ID="excel_Aktar" CssClass="btn btn-success" runat="server" OnClick="excel_Aktar_Click" />
        </div>
    </main>
</asp:Content>