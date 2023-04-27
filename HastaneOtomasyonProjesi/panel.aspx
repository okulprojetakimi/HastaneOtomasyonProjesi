 <%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="HastaneOtomasyonProjesi._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>  
		<form id="form1" runat="server">
			<img src="assets/img/logo.png">
            <!-- HBYS MOdülleri panel giriş butonları -->
            <table cellpadding="35">
                <tr>
                    <td><asp:ImageButton ID="hastaIslemPaneli" CssClass="fix_Button" runat="server" ImageUrl="assets/img/t1.png" /></td>
                    <td><asp:ImageButton CssClass="fix_Button" runat="server" ImageUrl="assets/img/t2.png" /></td>
                    <td><asp:ImageButton CssClass="fix_Button" runat="server" ImageUrl="assets/img/t3.png" /></td>
                    <td><asp:ImageButton CssClass="fix_Button" runat="server" ImageUrl="assets/img/t4.png" /></td>
                </tr>
                <tr class="td_2">
                    <td><asp:ImageButton CssClass="fix_Button" runat="server" ImageUrl="assets/img/t5.png" /></td>
                    <td><asp:ImageButton CssClass="fix_Button" runat="server" ImageUrl="assets/img/t6.png" /></td>
                    <td><asp:ImageButton CssClass="fix_Button" runat="server" ImageUrl="assets/img/t7.png" /></td>
                    <td><asp:ImageButton CssClass="fix_Button" runat="server" ImageUrl="assets/img/t8.png" /></td>
                </tr>
            </table>

		    <a style="position: absolute; left: 90%; top: 90%; right: 0%;" href="cikis.aspx"><img src="assets/img/logout.png"></a>
        </form>
    </main>

</asp:Content>
