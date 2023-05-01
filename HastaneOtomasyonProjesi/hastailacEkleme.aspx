<%@ Page Title="Hasta ilaç ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastailacEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastailacEkleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style>
            .labels {
                color: white;
                font-weight: bolder;
            }
        </style>
        <!-- İlaçlar Tablosu -->
        <style>
            .table {
                font-family: Arial, sans-serif;
                border-collapse: collapse;
                width: 100%;
            }

                .table th {
                    background-color: #0099cc;
                    color: #fff;
                    font-weight: bold;
                    padding: 8px;
                    text-align: left;
                }

                .table td {
                    border: 1px solid #ddd;
                    padding: 8px;
                }

                .table tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                .table tr {
                    background-color: #fff;
                }

                    .table tr:nth-child(even) {
                        background-color: #f2f2f2;
                    }
        </style>
        <div class="ilac_aramaFormu">
            <table cellpadding="15">
                <tr>
                    <td><label style="color: white; font-weight: bolder;">Aranacak ilacın ismi: </label></td>
                    <td><asp:TextBox CssClass="form-control" ID="ilacIsmi" runat="server" /></td>
                    <td><asp:Button ID="ilacIsmiAraButonu" CssClass="btn btn-info" Text="İlaç ara" runat="server" OnClick="ilacIsmiAraButonu_Click" /></td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="ilacListesiTablo" runat="server" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="ilacId" HeaderText="İlaç Id" />
                    <asp:BoundField DataField="ilacIsmi" HeaderText="İlaç ismi" />
                    <asp:BoundField DataField="ilacreceteTuru" HeaderText="İlaç reçete türü" />
                    <asp:BoundField DataField="ilacFiyat" HeaderText="İlaç türü" />
                </Columns>
            </asp:GridView>
        </div>
        
    </main>
    <asp:Button CssClass="btn btn-success" Text="+ Ilac ekle" runat="server" ID="hastaIlac_Ekle" OnClick="hastaIlac_Ekle_Click" />
</asp:Content>
