<%@ Page Language="C#" MasterPageFile="~/adminModulu/adminTema.Master" Title="Personel Hesap İşlem" AutoEventWireup="true" CodeBehind="hesapIslem.aspx.cs" Inherits="HastaneOtomasyonProjesi.adminModulu.hesapIslem" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-users"></i> Personel Detay İşlemi</h1>
        <p style="color: white;">Bu sayfada seçilen personelin hesap işlemlerini gerçekleştirebilirsiniz.</p>
        <br />
        <style>
            label{
                color: white;
            }
        </style>
        <div class="hesap_Detay">
            <table cellpadding="15">
                <tr>
                    <th>
                        <label>Personel Kullanıcı Adı: </label>
                        <asp:TextBox ID="personelKullaniciAdi" CssClass="form-control" runat="server" />
                    </th>
                    <th>
                        <label>Personel Kullanıcı Şifresi: </label>
                        <asp:TextBox ID="personelKullaniciSifre" CssClass="form-control" runat="server" />
                    </th>
                    <th>
                        <label>Personel Hesap Oluşturma Tarihi: </label>
                        <asp:TextBox TextMode="DateTime" ID="personelHOlusturmaTarihi" CssClass="form-control" runat="server" />
                    </th>
                </tr>
                <tr>
                    <th>
                        <label>Personel Hesap Son Erişim Tarihi: </label>
                        <asp:TextBox runat="server" TextMode="DateTime" ID="personelSonErisim" CssClass="form-control"/>
                    </th>
                    <th>
                        <label>Personel Özel Oturum Kodu: </label>
                        <asp:TextBox ID="personel_ErisimKodu" CssClass="form-control" runat="server" />
                    </th>
                </tr>
                <tr>
                     <th>
                        <label>Personel Erişim Düzeyi: </label>
                        <asp:DropDownList ID="personel_ErisimDuzey" CssClass="btn btn-primary dropdown-toggle" runat="server">
                            <asp:ListItem Value="0" Text="Admin Değil" />
                            <asp:ListItem Value="1" Text="Admin" />
                        </asp:DropDownList>
                    </th>
                    <th>
                        <label>Personel Hesap Aktiflik: </label>
                        <asp:DropDownList CssClass="btn btn-primary dropdown-toggle" ID="personel_HesapAktiflik" runat="server">
                            <asp:ListItem Value="0" Text="Aktif değil" />
                            <asp:ListItem Value="1" Text="Aktif" />
                        </asp:DropDownList>
                    </th>
                </tr>
            </table>

            <asp:Button CssClass="btn btn-warning" ID="kaydet_Buton" Text="Kaydet" runat="server" />
        </div>
    </main>
</asp:Content>