<%@ Page Title="Hasta İşlemleri" Language="C#" AutoEventWireup="true" CodeBehind="hastaIslemleri.aspx.cs" MasterPageFile="~/Site.Master" Inherits="HastaneOtomasyonProjesi.hastaIslemleri" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="maincontent" runat="server">
    <main>

        <!-- Hasta Işlemleri ( Hasta arama filtreleme) -->
        <form>
            <table cellpadding="15">
                <tr>
                    <td>
                        <div class="form-group">
                            <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Hasta ismi giriniz">
                        </div>
                    </td>

                    <!-- -->
                    <td>
                        <div class="form-group">
                            <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Hasta ismi giriniz">
                        </div>
                    </td>
                    <!-- -->
                    <td>
                        <button type="submit" class="btn btn-primary">Hasta ara</button></td>
                </tr>
            </table>
        </form>

        <!-- Hasta tablosu -->
        <table class="table table-striped table-dark">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col">Handle</th>
                    <th scope="col">Hasta İşlem</th>
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
