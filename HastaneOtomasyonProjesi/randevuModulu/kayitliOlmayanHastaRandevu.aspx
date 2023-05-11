<%@ Page Language="C#" Title="Hasta Randevu Ekleme" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="kayitliOlmayanHastaRandevu.aspx.cs" Inherits="HastaneOtomasyonProjesi.randevuModulu.kayitliOlmayanHastaRandevu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <h1 style="color: white;"><i class="fa-solid fa-calendar-plus"></i> Yeni Hasta Randevusu</h1>
    <p style="color: white;">Bu sayfada daha önce hasta kaydı olmayan yeni hastalar için randevu oluşturukabilir.</p>

    <main>
        <table cellpadding="10">
            <tr>
                <td>
                    <div>
                        <label for="kRandevu_Tc">Hasta TCKN: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="kRandevu_Tc" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="kRandevu_Isim">Hasta İsmi: </label>
                        <asp:TextBox runat="server" ID="kRandevu_Isim" CssClass="form-control" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="kRandevu_">Hasta Soyismi</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="kRandevu_Soyisim" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>

                        <label for="kRandevu_poliklinik">Randevu Polikliniği: </label>
                        <asp:DropDownList  DataValueField="pId" DataTextField="pIsim" DataSourceID="kRandevu_poliklinikSource"  CssClass="btn btn-info dropdown-toggle" ID="kRandevu_poliklinik" runat="server"></asp:DropDownList>
                        <asp:SqlDataSource ID="kRandevu_poliklinikSource" runat="server" ConnectionString="<%$ConnectionStrings:veritabaniBilgi %>" SelectCommand="SELECT pId, pIsim FROM poliklinik_Tablo"></asp:SqlDataSource>


                    </div>
                </td>
                <td>
                    <div>
                        <label for="kRandevu_Doktor">Randevu Doktoru Seç: </label>
                        <asp:DropDownList CssClass="btn btn-info dropdown-toggle" ID="kRandevu_Doktor" runat="server"></asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="kRandevu_Tarih">Hasta Randevu Tarihi: </label>
                        <asp:TextBox runat="server" ID="kRandevu_Tarih" TextMode="Date" />
                    </div>
                </td>
                <td>
                    <div>
                        <label for="kRandevu_Saat">Hasta Randevu Saat: </label>
                        <asp:TextBox runat="server" ID="kRandevu_Saat" TextMode="Time" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <label for="kRandevu_randevuNot">Hasta Randevu Not: </label>
                        <asp:TextBox runat="server" ID="kRandevu_randevuNot" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </td>
            </tr>
            
        </table>
        <asp:Button Text="+ Randevu Ekle" ID="randevuEkle_Buton" CssClass="btn btn-success" runat="server" OnClick="randevuEkle_Buton_Click" />

    </main>

</asp:Content>
