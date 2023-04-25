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
			<h3>Giriş Yap<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </h3>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </p>
			<form action="" method="POST">
				<asp:TextBox name="TextBox2" ID="TextBox2" runat="server"></asp:TextBox>
				<br><br>
                <asp:TextBox name="TextBox1" ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <br>
			</form>
		    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
		</div>
	</center>
    </main>
</asp:Content>