<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Hasta Bilgileri" AutoEventWireup="true" CodeBehind="hastaBilgiGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaBilgiGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-user-plus"></i>Hasta Bilgileri</h1>
        <hr style="width: 256px;" />
        <!-- Hasta kaydetme formu -->
        <form action="" method="post">
            <style>
                .labels {
                    color: white;
                }
            </style>
            <table cellpadding="15">
                <tr>
                    <th>Hasta Genel Bilgileri</th>
                    <th>Hasta İletişim Bilgileri</th>
                    <th>Hasta Yakin Bilgileri</th>
                </tr>

                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Tc">Hasta TC</label>
                            <asp:TextBox TextMode="SingleLine" placeholder="" runat="server" CssClass="form-control" ID="hasta_Tc" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Adres">Hasta Adres</label>
                            <asp:TextBox TextMode="SingleLine" placeholder="" runat="server" ID="hasta_Adres" CssClass="form-control" Text="hasta_Adres"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_YakinAdi">Hasta Yakin Adi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_YakinAdi" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Adi">Hasta Adi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_Adi" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Eposta">Hasta Eposta </label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_Eposta" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_yakinlikDerecesi">Hasta Yakınlık Derecesi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_yakinlikDerecesi" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Soyadi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_Soyadi" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_faxNo">Hasta Fax No</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_faxNo" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_tedaviDurumu">Tedavi Durumu</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_tedaviDurumu" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_kanGrubu">Kan Grubu</label>
                            <asp:DropDownList ID="hasta_kanGrubu" CssClass="form-control" runat="server">
                                <asp:ListItem Value="1" Text="A RH+" />
                                <asp:ListItem Value="2" Text="A RH-" />
                                <asp:ListItem Value="3" Text="0 RH+" />
                                <asp:ListItem Value="4" Text="0 RH-" />
                                <asp:ListItem Value="5" Text="B+" />
                                <asp:ListItem Value="6" Text="B-" />
                                <asp:ListItem Value="7" Text="AB-" />
                                <asp:ListItem Value="8" Text="AB+" />
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_evTelefonu">Hasta Ev Telefonu</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_evTelefonu" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_tedaviTuru">Hasta Tedavi Türü</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_tedaviTuru" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_BabaAdi">Hasta Baba Adi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_babaAd" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_cepTelefonu">Hasta Cep Telefonu</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_cepTelefonu" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_AnneAdi">Hasta Anne Adi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_AnneAd" />
                        </div>
                    </td>

                    

                </tr>
                <tr>
                    <th>Hasta Acente</th>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Doğum Yeri</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_DogumYer" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_sigortaTuru">Hasta Sigorta Türü</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_sigortaTuru" />
                        </div>
                    </td>

                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_DogumTarihi">Hasta Doğum Tarihi</label>
                            <asp:TextBox TextMode="DateTime" runat="server" CssClass="form-control" ID="hasta_DogumTarihi" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_karneNo">Hasta Karne No</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_karneNo" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Cinsiyet">Hasta Cinsiyet</label>
                            <asp:DropDownList ID="hasta_Cinsiyet" CssClass="form-control" runat="server">
                                <asp:ListItem Value="1" Text="ERKEK" />
                                <asp:ListItem Value="2" Text="KADIN" />
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_sicilNo">Hasta Sicil No</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_sicilNo" />
                        </div>
                    </td>
                </tr>

            </table>
            <br />
            <asp:Button Text="Kaydet" ID="kaydet_Button" OnClick="kaydet_Button_Click" CssClass="btn btn-success" runat="server" />
        </form>
    </main>

</asp:Content>
