<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Personel Plan Görüntüleme" CodeBehind="personelPlanGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.personelPlanGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;">Personel Çalışma Planı</h1>
        <p style="color: white;">Bu sayfada seçilen personelin belirtilen tarihteki çalışma planını görüntüleyebilir ve silebilirsiniz.</p>
        <br />
        <%-- <button type="button" class="btn btn-success">Listeyi Dışa Aktar</button>--%>
        <asp:Button Text="Listeyi Dışarı Aktar" CssClass="btn btn-success" ID="excel_Aktar" runat="server" OnClick="excel_Aktar_Click" />
        <asp:Button ID="btnSil" runat="server" Text="Listeyi Sil" CssClass="btn btn-success" OnClick="btnSil_Click" />

        <style>
            .gridview-container {
                max-height: 500px;
                overflow: auto;
                margin-bottom: 20px;
            }

            .gridview {
                border-collapse: collapse;
                width: 100%;
            }

                .gridview th,
                .gridview td {
                    padding: 10px;
                    text-align: left;
                }

                .gridview th {
                    background-color: #f2f2f2;
                    font-weight: bold;
                }

                .gridview tr {
                    background-color: #ffffff;
                }

                    .gridview tr:hover {
                        background-color: #e9e9e9;
                    }
        </style>

        <div class="planListe_Div gridview-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="gridview">
            </asp:GridView>
        </div>


    </main>
</asp:Content>
