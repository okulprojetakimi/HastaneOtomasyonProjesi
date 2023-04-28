<%@ Page Title="Hasta İşlemleri" Language="C#" AutoEventWireup="true" CodeBehind="hastaIslemleri.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.hastaIslemleri" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <main>

        <!-- Hasta Işlemleri ( Hasta arama filtreleme) -->
        <form action="" method="post">
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
                    <asp:GridView ID="hastaTablosuGrid" runat="server">
                    </asp:GridView>
                </tr>
            </table>
            
        </form>

        <!-- Hasta tablosu -->
       

        <!-- Hasta Listesi -->

    </main>
</asp:Content>
