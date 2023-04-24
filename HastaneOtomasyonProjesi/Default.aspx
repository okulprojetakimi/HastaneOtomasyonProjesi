<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HastaneOtomasyonProjesi._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
		<center>
		<img src="assets/img/logo.png">
		<table cellpadding="35">
		<tr>
			<td><button onclick="alert('selam!')" class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t1.png"></button></td>
			<td><button class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t2.png"></button></td>
			<td><button class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t3.png"></button></td>
			<td><button class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t4.png"></button></td>
		</tr>
		<tr class="td_2">
			<td><button class="fix_Button"><img	style="width:90px; height: 90px;" src="assets/img/t5.png"></button></td>
			<td><button class="fix_Button"><img	style="width:90px; height: 90px;" src="assets/img/t6.png"></button></td>
			<td><button class="fix_Button"><img	style="width:90px; height: 90px;" src="assets/img/t7.png"></button></td>
			<td><button class="fix_Button"><img	style="width:90px; height: 90px;" src="assets/img/t8.png"></button></td>
		</tr>
	</table>
	<a style="position: absolute; left: 90%; top: 90%; right: 0%;" href="cikis.aspx"><img src="assets/img/logout.png"></a>
	</center>

    </main>

</asp:Content>
