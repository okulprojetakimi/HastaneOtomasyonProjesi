<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hastaRandevuAra.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaRandevuAra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <label for="Ad">Ad:</label>
            <asp:TextBox ID="Ad" runat="server"></asp:TextBox>

            <label for="Soyad">Soyad:</label>
            <asp:TextBox ID="Soyad" runat="server"></asp:TextBox>

            <asp:Button ID="btnAra" runat="server" Text="Ara" OnClick="btnSearch_Click" />
        </div>
    </form>
</body>
</html>
