<%@ Page Language="C#" Title="Randevu Oluştur" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaRandevuEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.randevuModulu.hastaRandevuEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
            
               
                    <div>
                        <label for="kRandevu_Tc">Hasta TCKN: </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="kRandevu_Tc" />
                    </div>
                
                    <div>
                        <label for="kRandevu_Isim">Hasta İsmi: </label>
                        <asp:TextBox runat="server" ID="kRandevu_Isim" CssClass="form-control" />
                    </div>
                
                    <div>
                        <label for="kRandevu_Soyisim">Hasta Soyismi</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="kRandevu_Soyisim" />
                    </div>
                
                    <div>
                        <label for="kRandevu_Tarih">Hasta Randevu Tarihi: </label>
                        <asp:TextBox runat="server" ID="kRandevu_Tarih" TextMode="Date" />
                    </div>
                     <div>
                        <label for="Randevu_randevuNot">Hasta Randevu Not: </label>
                        <asp:TextBox runat="server" ID="Randevu_randevuNot" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                                       
</main>
</asp:Content>
