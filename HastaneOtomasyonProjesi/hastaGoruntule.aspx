<%@ Page Language="C#" Title="Hasta Görüntüle" EnableViewState="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastaGoruntule.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastaGoruntule" %>

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
            Hasta İlaç Id: <asp:TextBox ID="hastaIlac_ID" CssClass="form-control" runat="server" />
            <br />
            <asp:Button runat="server" ID="hastaIlacForm_yonlendir" CssClass="btn btn-info" Text="Hasta İlaç Görüntüle" OnClick="hastaIlacForm_yonlendir_Click" /></td>
            
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
                            <asp:textbox runat="server" ID="hasta_Adres" CssClass="form-control" Text="hasta_Adres"></asp:textbox>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_YakinAdi">Hasta Yakin Adi</label>
                            <input type="text" class="form-control" id="hasta_YakinAdi" name="hasta_YakinAdi" aria-describedby="hasta_YakinAdi" placeholder="Hasta Yakin Adi">
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
                            <input type="email" class="form-control" id="hasta_Eposta" name="hasta_Eposta" aria-describedby="hasta_Eposta" placeholder="Hasta Eposta">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_yakinlikDerecesi">Hasta Yakınlık Derecesi</label>
                            <input type="text" class="form-control" id="hasta_yakinlikDerecesi" name="hasta_yakinlikDerecesi" aria-describedby="hasta_yakinlikDerecesi" placeholder="Hasta Yakinlik Derecesi">
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
                            <input type="number" class="form-control" id="hasta_faxNo" name="hasta_faxNo" aria-describedby="hasta_faxNo" placeholder="Hasta Fax No">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_tedaviDurumu">Tedavi Durumu</label>
                            <input type="text" class="form-control" id="hasta_tedaviDurumu" name="hasta_tedaviDurumu" aria-describedby="hasta_tedaviDurumu" placeholder="Hasta Tedavi Durumu">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_kanGrubu">Kan Grubu</label>
                            <select class="form-control" id="hasta_kanGrubu" name="hasta_kanGrubu">
                                <option value="1">A RH+</option>
                                <option value="2">A RH-</option>
                                <option value="3">0 RH+</option>
                                <option value="4">0 RH-</option>
                                <option value="5">B+</option>
                                <option value="6">B-</option>
                                <option value="7">AB-</option>
                                <option value="8">AB+</option>
                            </select>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_evTelefonu">Hasta Ev Telefonu</label>
                            <input type="number" class="form-control" id="hasta_evTelefonu" name="hasta_evTelefonu" aria-describedby="hasta_evTelefonu" placeholder="Hasta Ev Telefonu">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_tedaviTuru">Hasta Tedavi Türü</label>
                            <input type="text" class="form-control" id="hasta_tedaviTuru" name="hasta_tedaviTuru" aria-describedby="hasta_tedaviTuru" placeholder="Hasta Tedavi Türü">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Baba Adi</label>
                            <input type="text" class="form-control" id="hasta_BabaAdi" name="hasta_BabaAdi" aria-describedby="hasta_BabaAdi" placeholder="Hastanın Baba Adı">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_cepTelefonu">Hasta Cep Telefonu</label>
                            <input type="number" class="form-control" id="hasta_cepTelefonu" name="hasta_cepTelefonu" aria-describedby="hasta_cepTelefonu" placeholder="Hasta Cep Telefonu">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_OdemeDurumu">Hasta Ödeme Durumu</label>
                            <input type="text" class="form-control" id="hasta_OdemeDurumu" name="hasta_OdemeDurumu"  aria-describedby="hasta_OdemeDurumu" placeholder="Hasta Ödeme Durumu">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_AnneAdi">Hasta Anne Adi</label>
                            <input type="text" class="form-control" id="hasta_AnneAdi" name="hasta_AnneAdi" aria-describedby="hasta_AnneAdi" placeholder="Hastanın Anne Adi">
                        </div>
                    </td>

                    <th>Hasta Acente</th>
                    
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Doğum Yeri</label>
                            <input type="text" class="form-control" id="hasta_DogumYeri" name="hasta_DogumYeri" aria-describedby="hasta_DogumYeri" placeholder="Hastanın Doğum Yeri">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_sigortaTuru">Hasta Sigorta Türü</label>
                            <input type="text" id="hasta_sigortaTuru" name="hasta_sigortaTuru" class="form-control" aria-describedby="hasta_sigortaTuru" placeholder="Hasta Sigorta">
                        </div>
                    </td>

                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_DogumTarihi">Hasta Doğum Tarihi</label>
                            <input type="date" id="hasta_DogumTarihi" name="hasta_DogumTarihi">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_karneNo">Hasta Karne No</label>
                            <input type="number" class="form-control" id="hasta_karneNo" name="hasta_karneNo" aria-describedby="hasta_karneNo" placeholder="Hasta Karne No">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Cinsiyet">Hasta Cinsiyet</label>
                            <select class="form-control" id="hasta_Cinsiyet" name="hasta_Cinsiyet">
                                <option value="e">Erkek</option>
                                <option value="k">Kadın</option>
                            </select>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_sicilNo">Hasta Sicil No</label>
                            <input type="number" class="form-control" id="hasta_sicilNo" name="hasta_sicilNo" aria-describedby="hasta_sicilNo" placeholder="Hasta Sicil No">
                        </div>
                    </td>
                </tr>

            </table>
            <br />
            <asp:Button Text="Kaydet" ID="kaydet_Button" OnClick="kaydet_Button_Click" CssClass="btn btn-success" runat="server" />
            </main>
</form>
</asp:Content>