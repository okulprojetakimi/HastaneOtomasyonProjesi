<%@ Page Language="C#" Title="Hasta Görüntüle" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-user"></i>Hasta Görüntüleme</h1>
        <table cellpadding="15">
            <tr>
                <td>
                    <asp:Button runat="server" ID="hastaNotEkleme" CssClass="btn btn-success" Text="+ Hastaya Not Ekle" OnClick="hastaNotEkleme_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="hastaIlacEkleme" CssClass="btn btn-info" Text="+ Hastaya İlaç Ekle" OnClick="hastaIlacEkleme_Click" /></td>
                <td> <button type="button" class="btn btn-info" id="hastaNotFormAc"><i class="fa-sharp fa-solid fa-notes-medical"></i> Hasta Not İşlemleri</button></td>
                <td> <button type="button" class="btn btn-info" id="ilacFormDialogButton"><i class="fa-solid fa-pills"></i> Hasta İlaç İşlemleri</button></td>
            </tr>
        </table>

        <!-- Hasta notları   -->
        <style>
            #hasta_NotlariKutusu {
                display: none;
                position: absolute;
                top: 30%;
                left: 50%;
                transform: translate(-50%, -50%);
                background-color: #fff;
                padding: 20px;
                border: 1px solid #ccc;
                z-index: 9999;
                width: 1024px;
            }
            #ilacFormDialog {
                display: none;
                position: absolute;
                top: 30%;
                left: 50%;
                transform: translate(-50%, -50%);
                background-color: #fff;
                padding: 20px;
                border: 1px solid #ccc;
                z-index: 9999;
                width: 1024px;
            }
        </style>
        <div id="hasta_NotlariKutusu">
            <table>
                <tr>
                    <td><button type="button" id="hastaNotFormKapat" class="btn btn-danger">X</button></td>
                    <td><h2>Hasta Not İşlemleri</h2></td>
                </tr>
            </table>
            <br />
            <!-- Hasta notları listesi -->
            <asp:GridView ID="hastaNotListesi" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="hasta_NotId" HeaderText="Hasta Not Numarası" />
                    <asp:BoundField DataField="hasta_Not" HeaderText="Hasta Notu" />
                    <asp:BoundField DataField="hasta_notTarihi" HeaderText="Hasta Not Tarihi" />
                </Columns>
            </asp:GridView>
            <br />
            Not Numarası: <asp:TextBox ID="not_Id" CssClass="form-control" runat="server" />
            <br />
            <asp:Button runat="server" ID="notGoruntuleButonu" CssClass="btn btn-info" Text="Hasta Not Görüntüle" OnClick="notGoruntuleButonu_Click" /></td>
            
        </div>

        <div id="ilacFormDialog">
            <table>
                <tr>
                    <td><button type="button" id="ilacFormDialogButtonKapatma" class="btn btn-danger">X</button></td>
                    <td><h2>Hasta İlaç İşlemleri</h2></td>
                </tr>
            </table>
            <br />
            <!-- Hasta notları listesi -->
            <asp:GridView ID="hasta_IlacListesi" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="hasta_NotId" HeaderText="Hasta Not Numarası" />
                    <asp:BoundField DataField="hasta_Not" HeaderText="Hasta Notu" />
                    <asp:BoundField DataField="hasta_notTarihi" HeaderText="Hasta Not Tarihi" />
                </Columns>
            </asp:GridView>
            <br />
            Hasta İlaç Id: <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" />
            <br />
            <asp:Button runat="server" ID="Button1" CssClass="btn btn-info" Text="Hasta Not Görüntüle" OnClick="notGoruntuleButonu_Click" /></td>
            
        </div>


        <script>
            <!-- Hasta Not İşlem Formu eventleri -->
            var formKutusu = document.getElementById("hasta_NotlariKutusu");
            var formButton = document.getElementById("hastaNotFormAc");

            formButton.onclick = function () {
                if (formKutusu.style.display === "none") {
                    formKutusu.style.display = "block";
                } else {
                    formKutusu.style.display = "none";
                }
            }
            hastaNotFormKapat.onclick = function () {
                if (formKutusu.style.display === "none") {
                    formKutusu.style.display = "block";
                } else {
                    formKutusu.style.display = "none";
                }
            }

            var ilacFormDialog = document.getElementById("ilacFormDialog");
            var ilacFormDialogButton = document.getElementById("ilacFormDialogButton");

            ilacFormDialogButton.onclick = function () {
                if (ilacFormDialog.style.display === "none") {
                    ilacFormDialog.style.display = "block";
                } else {
                    ilacFormDialog.style.display = "none";
                }
            }
            ilacFormDialogButtonKapatma.onclick = function () {
                if (ilacFormDialog.style.display === "none") {
                    ilacFormDialog.style.display = "block";
                } else {
                    ilacFormDialog.style.display = "none";
                }
            }
        </script>



    </main>
</asp:Content>
