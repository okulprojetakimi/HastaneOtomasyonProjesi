<%@ Page Language="C#" Title="Yeni Hasta Ekleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="yeniHastaKaydi.aspx.cs" Inherits="HastaneOtomasyonProjesi.yeniHastaKaydı" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>


        <h1 style="color: white;"><i class="fa-solid fa-user-plus"></i>Yeni Hasta Ekleme</h1>
        <hr style="width: 256px;" />
        <!-- Hasta ekleme formu -->
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
                            <input type="number" class="form-control" id="hasta_Tc" name="hasta_Tc" aria-describedby="hasta_Tc" placeholder="Hasta TC Numarası">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Adres">Hasta Adres</label>
                            <textarea id="hasta_Adres" name="hasta_Adres" class="form-control" aria-describedby="hasta_Adres" placeholder="Hasta Adres"></textarea>
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
                            <input type="text" class="form-control" id="hasta_Adi" name="hasta_Adi" aria-describedby="hasta_Adi" placeholder="Hastanin adi">
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
                            <input type="text" class="form-control" id="hasta_Soyadi" name="hasta_Soyadi" aria-describedby="hasta_Soyadi" placeholder="Hastanin Soyadi">
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
            
             <!-- <input type="reset" onclick="Button31_Click31" id="btnT" name="btnT" value="Temizle"> -->
            <style>
                table {
                    width: 100%;
                    border-collapse: collapse;
                }

                    table th {
                        text-align: center;
                        background-color: #2196F3;
                        color: white;
                    }

                    table th, td {
                        border: 1px solid blue;
                        padding: 6px;
                    }



                    table tr:hover {
                        background-color: #ddd;
                    }
            </style>
            </table>
            <!-- hasta_Id, hasta_Tc, hasta_Adi, hasta_Soyadi, hasta_kanGrubu, hasta_BabaAdi, hasta_AnneAdi, hasta_DogumYeri, hasta_DogumTarihi, hasta_Cinsiyet, 
            hasta_Adres, hasta_Eposta, hasta_faxNo, hasta_evTelefonu, hasta_cepTelefonu, hasta_sigortaTuru, hasta_karneNo, hasta_sicilNo, hasta_YakinAdi, hasat_yakinlikDerecesi, hasta_tedaviDurumu,
            hasta_tedaviTuru, 
            hasta_OdemeDUrumu-->

        </form>
    </main>
    <asp:button CssClass="btn btn-success" text="+ Hasta Ekle" id="Button31_Click31" runat="server" OnClick="hastaEkleButon_click" />
</asp:Content>
