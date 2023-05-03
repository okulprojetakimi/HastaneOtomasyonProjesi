<%@ Page Title="Hasta ilaç ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastailacEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastailacEkleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style>
            .labels {
                color: white;
                font-weight: bolder;
            }
        </style>
        <asp:TextBox ID="txtSearchBox" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" />
        <!-- İlaçlar Tablosu -->
        <asp:Panel ID="Panel1" ScrollBars="Vertical" Height="500px" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" Width="100%"
                BorderColor="#DEDFDE" BorderStyle="Ridge" BorderWidth="1px" CellPadding="4"
                Font-Size="Small" ForeColor="Black" GridLines="Vertical"
                OnRowDataBound="GridView1_RowDataBound" OnDataBound="OnDataBound"
                CssClass="table table-responsive table-striped table-hover" EmptyDataText="No Record Found..." RowStyle-Height="7px">

                <Columns>

                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="40px">

                        <asp:boundfield datafield="OrderID" headertext="OrderID" />

                        <%--<asp:CommandField ShowEditButton="True" ItemStyle-HorizontalAlign="Center"/>
                    <asp:CommandField ShowDeleteButton="True"  ItemStyle-HorizontalAlign="Center" />--%>
                </Columns>

                <EmptyDataRowStyle Width="1195px" HorizontalAlign="Center" BackColor="#C2D69B" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle Height="10px" VerticalAlign="Middle" BackColor="#6B696B" CssClass="tb_font" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </asp:Panel>
        <script type="text/javascript">
            $(document).ready(function () {

                $('#Button1').click(function (event) {
                    event.preventDefault();
                    var searchKey = $('#txtSearchBox').val();
                    $("#GridView1 tr td:nth-child(2)").each(function () {
                        var cellText = $(this).text().toLowerCase();
                        if (cellText.indexOf(searchKey) >= 0) {
                            $(this).parent().show();
                        }
                        else {
                            $(this).parent().hide();
                        }
                    });
                });
            });
        </script>
        <asp:Button CssClass="btn btn-success" Text="+ Ilac ekle" runat="server" ID="hastaIlac_Ekle" OnClick="hastaIlac_Ekle_Click" />
    </main>
</asp:Content>
