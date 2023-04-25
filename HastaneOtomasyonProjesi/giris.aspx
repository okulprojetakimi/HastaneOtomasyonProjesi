<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="giris.aspx.cs" Inherits="HastaneOtomasyonProjesi.giris" %>

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
		<a href="giris.html"><img src="assets/img/logo.png"></a>
		<div class="div_giris_Kutusu">
			<br>
			<h3>Giriş Yap</h3>
			<form action="" method="POST">
				<bl-input style="width: 250px;" label="Kullanıcı Adı" placeholder="Kullanıcı adınızı giriniz." name="kullaniciAdi_Input" label-fixed></bl-input>
				<br><br>
				<bl-input style="width: 250px;" label="Kullanıcı Şifre" type="password" placeholder="Kullanıcı şifrenizi giriniz." name="kullaniciSifre_Input" label-fixed></bl-input>
				<br><br>
				<bl-button>Giriş Yap</bl-button>
			</form>
		</div>
	</center>
    </main>
</asp:Content>