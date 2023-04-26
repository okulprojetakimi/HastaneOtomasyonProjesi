 <%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="HastaneOtomasyonProjesi._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>  
		<form id="form1" runat="server">
			<img src="assets/img/logo.png">
            <!-- HBYS MOdülleri panel giriş butonları -->
            <table cellpadding="35">
				<tr>
					<td><asp:Button ID="hastaIslemPaneli" CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t1.png"></asp:Button></td>
					<td><asp:Button CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t2.png"></asp:Button></td>
					<td><asp:Button CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t3.png"></asp:Button></td>
					<td><asp:Button CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t4.png"></asp:Button></td>
				</tr>
				<tr class="td_2">
					<td><asp:Button CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t5.png"></asp:Button></td>
					<td><asp:Button CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t6.png"></asp:Button></td>
					<td><asp:Button CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t7.png"></asp:Button></td>
					<td><asp:Button CssClass="fix_Button" runat="server"><img style="width:90px; height: 90px;" src="assets/img/t8.png"></asp:Button></td>
					</tr>
			</table>
		    <a style="position: absolute; left: 90%; top: 90%; right: 0%;" href="cikis.aspx"><img src="assets/img/logout.png"></a>
        </form>
    </main>

</asp:Content>
