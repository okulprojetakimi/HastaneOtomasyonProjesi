<%@ Page Title="Personel Giriş" Language="C#" AutoEventWireup="true" MasterPageFile="~/giris.Master" CodeBehind="giris.aspx.cs" Inherits="HastaneOtomasyonProjesi.giris" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style type="text/css">
            .div_giris_Kutusu {
                width: 541px;
                height: 300px;
                background-color: #2E2E2E;
                color: White;
                border-radius: 5px;
            }

            body {
                font-family: sans-serif;
            }
        </style>
        <center>
            <div class="div_giris_Kutusu">
                <br>
                <h3>Giriş Yap<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </h3>
                <p>
                    <asp:TextBox ID="kullaniciAdi" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:TextBox ID="kullaniciSifre" runat="server" TextMode="Password"></asp:TextBox>
                </p>
                <p>
                    <!-- reCAPTCHA kontrolünü ekleyin -->
                    <div class="g-recaptcha" data-sitekey="6LcDfxwmAAAAAC27pIlTaFHNB5nj4XrhBSu-WYfc"></div>
                </p>
                <p>
                    <asp:Button CssClass="btn btn-success" ID="Button1" runat="server" OnClick="Button1_Click1" Text="Giriş yap" />
                </p>
                <p>
                    <div>
                    </div>
                </p>
                <p>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </p>


            </div>
        </center>
    </main>
</asp:Content>
