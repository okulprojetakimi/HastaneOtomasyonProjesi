﻿<%@ Page Title="Hasta İşlemleri" Language="C#" AutoEventWireup="true" CodeBehind="hastaIslemleri.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.hastaIslemleri" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <main>

        <!-- Hasta Işlemleri ( Hasta arama filtreleme) -->
        <form action="" method="post">
            <h2 style="color : white;">Hasta Filtreleme</h2>
            <table cellpadding="15">
                <tr>
                    <td>
                        <div class="form-group">
                            <input type="email" class="form-control" id="hastaIsim" placeholder="Hasta ismi giriniz">
                        </div>
                    </td>

                    <!-- --> 
                    <td>
                        <div class="form-group">
                            <input type="email" class="form-control" id="hastaSoyisim" placeholder="Hasta soyismi giriniz">
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
        <h1 style="color: white;">Hasta Listesi</h1>
        <table class="table table-striped table-dark">
            <thead>
                <tr>
                    <th scope="col"><i class="fa-sharp fa-solid fa-passport"></i> Hasta TC</th>
                    <th scope="col"><i class="fa-solid fa-id-card-clip"></i> Hasta İsim</th>
                    <th scope="col"><i class="fa-solid fa-id-card-clip"></i> Hasta Soyisim</th>
                    <th scope="col"><i class="fa-regular fa-calendar-days"></i> Hasta Kayıt Tarihi</th>
                    <th scope="col"><i class="fa-solid fa-user-gear"></i> Hasta İşlem</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">1</th>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>@mdo</td>
                    <td><a href="secilenHasta.aspx"><button type="button" class="btn btn-info">Hasta İşlem</button></a></td>
                </tr>
                <tr>
                    <th scope="row">2</th>
                    <td>Jacob</td>
                    <td>Thornton</td>
                    <td>@fat</td>
                     <td><a href="secilenHasta.aspx"><button type="button" class="btn btn-info">Hasta İşlem</button></a></td>
                </tr>
                <tr>
                    <th scope="row">3</th>
                    <td>Larry</td>
                    <td>the Bird</td>
                    <td>@twitter</td>
                     <td><a href="secilenHasta.aspx"><button type="button" class="btn btn-info">Hasta İşlem</button></a></td>
                </tr>
            </tbody>
        </table>

        <!-- Hasta Listesi -->

    </main>
</asp:Content>
