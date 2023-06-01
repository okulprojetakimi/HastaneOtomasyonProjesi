<%@ Page Language="C#" Async="True" Title="Hasta Görüntüle" EnableViewState="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaGoruntule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-user"></i>Hasta Bilgi Görüntüleme</h1>
        <table cellpadding="15">
            <tr>
                <td>
                    <asp:Button runat="server" ID="hastaNotEkleme" CssClass="btn btn-success" Text="+ Hastaya Not Ekle" OnClick="hastaNotEkleme_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="hastaIlacEkleme" CssClass="btn btn-info" Text="+ Hastaya İlaç Ekle" OnClick="hastaIlacEkleme_Click" /></td>
                <td> <button type="button" class="btn btn-info" id="hastaNotFormAc"><i class="fa-sharp fa-solid fa-notes-medical"></i> Hasta Not İşlemleri</button></td>
                <td> <button type="button" class="btn btn-info" id="ilacFormDialogButton"><i class="fa-solid fa-pills"></i> Hasta İlaç Verileri</button></td>
                <td> <button type="button" class="btn btn-info" id="laboratuvarTetkikListesiAc"><i class="fa-solid fa-vials"></i> Hasta Laboratuvar Verileri</button></td>

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
            #tetkikDialog{
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
                    <asp:BoundField DataField="hastailac_Id" HeaderText="Hasta İlaç Kayıt Numarası" />
                    <asp:BoundField DataField="hastailac_ilacId" HeaderText="İlaç Numarası" />
                    <asp:BoundField DataField="hastailac_verilmeTarih" HeaderText="İlaç Verilme Tarihi" />
                    <asp:BoundField DataField="hasta_IlacDevamDurumu" HeaderText="İlaç Devam Durumu" />
                    <asp:BoundField DataField="ilacId" HeaderText="İlaç Numarası" />
                    <asp:BoundField DataField="ilacIsmi" HeaderText="İlaç İsmi" />
                </Columns>
            </asp:GridView>
            <br />
            Hasta İlaç Id: <input class="form-control" id="hastaIlac_ID" />
            <br />
            <button type="button" class="btn btn-success" id="goruntuleButton" name="goruntuleButton" onclick="popupAc()">Görüntüle</button></td>
             <script>
                 function popupAc() {
                     var ilacId = document.getElementById("hastaIlac_ID").value;
                     var popupWindow = window.open("hastaIlacGoruntule.aspx?vIlacId=" + ilacId, "_blank", "width=375,height=675");
                }
             </script>
        </div>

        <div id="tetkikDialog">
            <table>
                <tr>
                    <td><button type="button" id="tetkikDialogFormKapatma" class="btn btn-danger">X</button></td>
                    <td><h2>    Hasta Laboratuvar Sonuçları</h2></td>
                </tr>
            </table>
            <br />
            <!-- Hasta laboratuvar verileri -->
            <asp:GridView ID="hasta_laboratuvarSonuclari" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="tetkik_Id" HeaderText="Tetkik Numarası" />
                    <asp:BoundField DataField="tetkik_istekTarih" HeaderText="Tetkik İstek Tarihi" />
                    <asp:BoundField DataField="personel_Isim" HeaderText="Tetkik İsteyen Doktor" />
                    <asp:BoundField DataField="tetkik_sonucTarih" HeaderText="Tetkik Sonuç Tarihi" />
                    <asp:BoundField DataField="tetkik_durum" HeaderText="Tetkik Durumu" />
                </Columns>
            </asp:GridView>
            <br />
            Hasta Tetkik Numarası: <asp:TextBox ID="hasta_TetkikDetayID" CssClass="form-control" runat="server" />
            <br />
            <asp:Button runat="server" ID="tetkikDetayButonu" CssClass="btn btn-info" Text="Hasta Tetkik Detay Aç" OnClick="tetkikDetayButonu_Click" /></td>
            
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

            var tetkikDetayDialog = document.getElementById("tetkikDialog");
            var tetkikDetayDialogButonu = document.getElementById("tetkikDialogFormKapatma");

            laboratuvarTetkikListesiAc.onclick = function () {
                if (tetkikDetayDialog.style.display === "none") {
                    tetkikDetayDialog.style.display = "block";
                } else {
                    tetkikDetayDialog.style.display = "none";
                }
            }
            tetkikDialogFormKapatma.onclick = function () {
                if (tetkikDetayDialog.style.display === "none") {
                    tetkikDetayDialog.style.display = "block";
                } else {
                    tetkikDetayDialog.style.display = "none";
                }
            }
        </script>

        <!-- Buradan itibaren yazmaya başla -->
        <h1 style="color: white;"><i class="fa-solid fa-user-plus"></i>Yeni Hasta Kaydetme</h1>
        <hr style="width: 256px;" />
        <!-- Hasta kaydetme formu -->
        <form action="" method="post">
            <style>
                .labels {
                    color: white;
                }
            </style>
            <table cellpadding="15">
                 <tr>
                    <th>Hasta Genel Bilgileri</th>
                    <th>Hasta İletişim Bilgileri</th>
                    <th>Hasta Yakin Bilgileri</th>
                </tr>

              <tr>
                  <%--  <%
                        Random idGenerator = new Random();
                        int randId = idGenerator.Next(111111,999999);
                    %>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Tc">Hasta ID</label>
                            <asp:TextBox CssClass="form-control" ID="hasta_Id" runat="server" />
                           <!--  <input type="number" value="<% = randId %>" class="form-control" id="hasta_Id" name="hasta_Id" aria-describedby="hasta_Id" placeholder="Hasta ID"> -->
                            <span><label>ID Numarası sistem tarafından otomatik oluşturulmaktadır.</label></span>
                        </div>
                    </td>--%>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Tc">Hasta TC</label>
                            <asp:TextBox TextMode="SingleLine" placeholder="" runat="server" CssClass="form-control" ID="hasta_Tc" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Adres">Hasta Adres</label>
                            <asp:textbox TextMode="SingleLine" placeholder=""  runat="server" ID="hasta_Adres" CssClass="form-control" Text="hasta_Adres"></asp:textbox>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_YakinAdi">Hasta Yakin Adi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_YakinAdi" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Adi">Hasta Adi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_Adi" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Eposta">Hasta Eposta </label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_Eposta"  />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_yakinlikDerecesi">Hasta Yakınlık Derecesi</label>
                         <asp:TextBox runat="server" CssClass="form-control" ID="hasta_yakinlikDerecesi"  />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Soyadi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_Soyadi" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_faxNo">Hasta Fax No</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_faxNo" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_tedaviDurumu">Tedavi Durumu</label>
                             <asp:TextBox runat="server" CssClass="form-control" ID="hasta_tedaviDurumu" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_kanGrubu">Kan Grubu</label>
                            <asp:DropDownList ID="hasta_kanGrubu" CssClass="form-control" runat="server">
                                <asp:ListItem Value="1" Text="A RH+" />
                                <asp:ListItem Value="2" Text="A RH-" />
                                <asp:ListItem Value="3" Text="0 RH+" />
                                <asp:ListItem Value="4" Text="0 RH-" />
                                <asp:ListItem Value="5" Text="B+" />
                                <asp:ListItem Value="6" Text="B-" />
                                <asp:ListItem Value="7" Text="AB-" />
                                <asp:ListItem Value="8" Text="AB+" />
                                
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_evTelefonu">Hasta Ev Telefonu</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_evTelefonu" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_tedaviTuru">Hasta Tedavi Türü</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_tedaviTuru" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_BabaAdi">Hasta Baba Adi</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_babaAd" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_cepTelefonu">Hasta Cep Telefonu</label>
                             <asp:TextBox runat="server" CssClass="form-control" ID="hasta_cepTelefonu" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_AnneAdi">Hasta Anne Adi</label>
                             <asp:TextBox runat="server" CssClass="form-control" ID="hasta_AnneAd" />
                        </div>
                    </td>

                    <th>Hasta Acente</th>
                    
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Doğum Yeri</label>
                             <asp:TextBox runat="server" CssClass="form-control" ID="hasta_DogumYer" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_sigortaTuru">Hasta Sigorta Türü</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_sigortaTuru" />
                        </div>
                    </td>

                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_DogumTarihi">Hasta Doğum Tarihi</label>
                             <asp:TextBox TextMode="DateTime"  runat="server" CssClass="form-control" ID="hasta_DogumTarihi" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_karneNo">Hasta Karne No</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_karneNo" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Cinsiyet">Hasta Cinsiyet</label>
                            <asp:DropDownList ID="hasta_Cinsiyet" CssClass="form-control" runat="server">
                                  <asp:ListItem Value="1" Text="ERKEK" />
                                  <asp:ListItem Value="2" Text="KADIN" />
                         </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_sicilNo">Hasta Sicil No</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="hasta_sicilNo" />
                        </div>
                    </td>
                </tr>

            </table>
            <br />
            <asp:Button Text="Kaydet" ID="kaydet_Button" OnClick="kaydet_Button_Click" CssClass="btn btn-success" runat="server" />
            </main>
</form>
</asp:Content>