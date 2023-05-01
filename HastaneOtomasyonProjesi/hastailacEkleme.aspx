<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastailacEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastailacEkleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table cellpadding="50">
            <tr>
                <td>
                    <h1 style="color: white;"><i class="fa-solid fa-user-plus"></i> Hasta Ilac Ekleme</h1>
                    <table>
                        <style>
                            .labels {
                                color: white;
                                font-weight: bolder;
                            }
                        </style>
                  
                    </table>
                </td>
            </tr>
        </table>
    </main>
    <asp:Button CssClass="btn btn-success" Text="+ Ilac ekle" runat="server" ID="hastaIlac_Ekle" OnClick="hastaIlac_Ekle_Click" />
</asp:Content>
