<%@ Page Title="Hasta İşlemleri" Language="C#" AutoEventWireup="true" CodeBehind="hastaIslemleri.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.hastaIslemleri" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <main>

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <!-- Hasta Işlemleri ( Hasta arama filtreleme) -->
        <form action="hastaIslemleri.aspx" method="post">
            <h2 style="color : white;">Hasta Filtreleme</h2>
            <table cellpadding="15">
                <tr>
                    <td>
                        <div class="form-group">
                            <input type="text" class="form-control" id="hastaIsim" name="hastaIsmi" placeholder="Hasta ismi giriniz">
                        </div>
                    </td>

                    <!-- --> 
                    <td>
                        <div class="form-group">
                            <input type="text" class="form-control" id="hastaSoyisim" name="hastaSoyismi" placeholder="Hasta soyismi giriniz">
                        </div>
                    </td>
                    <!-- -->
                    <td>
                        <button type="submit" name="hasta_Ara" class="btn btn-primary">Hasta ara</button>
                    </td>
                </tr>
            </table>
            
        </form>

        <!-- Hasta tablosu -->
       <asp:GridView ID="ornGridView" runat="server" CellPadding="4"                ForeColor="#333333" GridLines="Horizontal" AutoGenerateColumns="False"                Width="530px">                <footerstyle backcolor="#990000" font-bold="True" forecolor="White" />                <rowstyle backcolor="#FFFBD6" forecolor="#333333" />                <columns>                    <asp:BoundField HeaderText="İsim" DataField="AD" />                    <asp:BoundField HeaderText="Soyisim" DataField="SOYAD" />                    <asp:BoundField HeaderText="Adres" DataField="ADRES" />                    <asp:BoundField HeaderText="Bölüm" DataField="BOLUM" />                </columns>                <pagerstyle backcolor="#FFCC66" forecolor="#333333"                    horizontalalign="Center" />                <selectedrowstyle backcolor="#FFCC66" font-bold="True" forecolor="Navy" />                <headerstyle backcolor="#990000" font-bold="True" forecolor="White" />                <alternatingrowstyle backcolor="White" />            </asp:GridView>

        <!-- Hasta Listesi -->

    </main>
</asp:Content>
