 <%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="HastaneOtomasyonProjesi._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>  
            <!-- HBYS MOdülleri panel giriş butonları -->
           <center>
				<table cellpadding="35">
					<tr>
						<td><a href="hastaIslemleri.aspx"><button type="button" class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t1.png"></button></a></td>
						<td><a href="ameliyathaneModulu/anasayfa.aspx"><button type="button" class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t2.png"></button></a></td>
						<td><a href="laboratuvarModulu/anasayfa.aspx"><button type="button" class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t3.png"></button></a></td>
						<td><a href="randevuModulu/anasayfa.aspx"><button type="button" class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t4.png"></button></a></td>
					</tr>
				    <tr class="td_2">
						<td><a href="personelModulu/anasayfa.aspx"><button type="button" class="fix_Button"><img style="width:90px; height: 90px;" src="assets/img/t5.png"></button></a></td>
						<td><a href="calismaplaniModulu/anasayfa.aspx"><button type="button" class="fix_Button"><img	style="width:90px; height: 90px;" src="assets/img/t7.png"></button></a></td>
						<td><a href="adminModulu/anasayfa.aspx"><button type="button" class="fix_Button"><img	style="width:90px; height: 90px;" src="assets/img/t8.png"></button></a></td>
					</tr>
				</table>
				
			</center>
		<a style="position: absolute; left: 90%; top: 90%; right: 0%;" href="cikis.aspx"><img src="assets/img/logout.png"></a>
    </main>

</asp:Content>
