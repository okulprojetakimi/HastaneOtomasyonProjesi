<%@ Page Language="C#" Title="Yeni Hasta Ekleme" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="yeniHastaKaydı.aspx.cs" Inherits="HastaneOtomasyonProjesi.yeniHastaKaydı" %>

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
                    <td>
                        <div class="form-group">
                            <%
                                Random rastgeleSayi = new Random();
                                int hastaNumarasi = rastgeleSayi.Next(1111111, 9999999);
                            %>
                            <label for="hasta_Id">Hasta Numarası</label>
                            <input type="number" value="<% =hastaNumarasi %>" disabled class="form-control" id="hasta_Tc" aria-describedby="hasta_Tc" placeholder="HASTA NUMARASI">
                            <small id="emailHelp" class="form-text text-muted">Bu sistem tarafından otomatik olarak üretilmektedir.</small>
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Tc">Hasta TC</label>
                            <input type="number" class="form-control" id="hasta_Tc" aria-describedby="hasta_Tc" placeholder="Hasta TC Numarası">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Adi">Hasta Adı</label>
                            <input type="text" class="form-control" id="hasta_Adi" aria-describedby="hasta_Adi" placeholder="Hastanın adı">
                        </div>
                    </td>
                    <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Soyadı</label>
                            <input type="text" class="form-control" id="hasta_Soyadi" aria-describedby="hasta_Soyadi" placeholder="Hastanın Soyadı">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <label for="kanGrubuSecimi">Kan Grubu</label>
                            <select class="form-control" id="kanGrubuSecimi">
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
                            <label for="hasta_Soyadi">Hasta Baba Adı</label>
                            <input type="text" class="form-control" id="hasta_BabaAdi" aria-describedby="hasta_BabaAdi" placeholder="Hastanın Baba Adı">
                        </div>
                    </td>
                     <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Anne Adı</label>
                            <input type="text" class="form-control" id="hasta_AnneAdi" aria-describedby="hasta_AnneAdi" placeholder="Hastanın Anne Adı">
                        </div>
                    </td>
                     <td>
                        <div class="form-group">
                            <label for="hasta_Soyadi">Hasta Doğum Yeri</label>
                            <input type="text" class="form-control" id="hasta_DogumYeri" aria-describedby="hasta_DogumYeri" placeholder="Hastanın Doğum Yeri">
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
                            <label for="kanGrubuSecimi">Kan Grubu</label>
                            <select class="form-control" id="kanGrubuSecimi">
                                <option value="e">Erkek</option>
                                <option value="k">Kadın</option>
                            </select>
                        </div>
                    </td>
                    <td>

                    </td>
                </tr>
            </table>
            <!-- hasta_Id, hasta_Tc, hasta_Adi, hasta_Soyadi, hasta_kanGrubu, hasta_BabaAdi, hasta_AnneAdi, hasta_DogumYeri, hasta_DogumTarihi, hasta_Cinsiyet, 
            hasta_Adres, hasta_Eposta, hasta_faxNo, hasta_evTelefonu, hasta_cepTelefonu, hasta_sigortaTuru, hasta_karneNo, hasta_sicilNo, hasta_YakinAdi, hasat_yakinlikDerecesi, hasta_tedaviDurumu,
            hasta_tedaviTuru, 
            hasta_OdemeDUrumu-->

        </form>
    </main>

</asp:Content>
