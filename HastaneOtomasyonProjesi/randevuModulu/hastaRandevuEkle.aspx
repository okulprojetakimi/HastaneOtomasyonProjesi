<%@ Page Language="C#" Title="Randevu Oluştur" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaRandevuEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.randevuModulu.hastaRandevuEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-plus"></i> Hasta Randevu Oluşturma</h1>
        <table>
            <tr>
                <div>
                    
                </div>

                <asp:DropDownList runat="server" ID="randevuDoktor"></asp:DropDownList>
            </tr>
        </table>
    </main>
</asp:Content>
