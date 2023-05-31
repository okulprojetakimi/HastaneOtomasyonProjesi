<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Personel Çalışma Plan İşlemleri" CodeBehind="personelPlanIslemi.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.personelPlanIslemi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:HiddenField ID="personel_Id" runat="server" />
        <style>
            label {
                color: white;
            }
        </style>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-days"></i>Personel Çalışma Plan İşlemleri</h1>
        <p style="color: white;">Bu sayfada personel için aylık planlama yapabilir, daha önce yapılmış planlar görüntülenebilir ve düzenlenebilir. Ayrıca pdf şeklinde de dışarı aktarım işlemi gerçekleştirebilirsiniz.</p>
        <br />
        <a href="personelPlanEkle.aspx">
            <a id="ekleme_Yonlendir" href="personelPlanEkle.aspx?personelNumara="><button type="button" class="btn btn-success" id="planEkle">+ Plan Ekleme</button></a></a>
        <button type="button" class="btn btn-success" id="plan_Aktarma" onclick="popupAc()"><i class="fa-solid fa-list"></i> Personel Plan Dışa Aktarma</button>
        <script>
            function popupAc() {
                var personelId = document.getElementById('<%= personel_Id.ClientID %>').value;
                var popupWindow = window.open("personelListeAl.aspx?personelNumarasi=" + personelId, "_blank", "width=1200,height=512");
            }
        </script>
        <!-- -->
        <br />
        <table cellpadding="15">
            <tr>
                <th>
                    <label>Aranacak Tarih Aralığı: </label>
                </th>
                <th>
                    <input type="month" class="form-control" name="aranacak_Tarih" id="aranacak_Tarih" />
                </th>
                <th>
                    <input type="month" class="form-control" name="aranacak_Tarih" id="sonT" /></th>
                </th>
                    <th>
                        <button type="button" class="btn btn-success" id="ara_Buton" name="ara_Buton">Plan Ara</button
                    </th>
            </tr>
        </table>

        <!-- -->
        <table id="myGrid" class="table table-striped" border="1">
            <thead>
                <tr>
                    <td>Plan Numarası</td>
                    <td>Plan Personel Numarası</td>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
        <script>
            $(document).ready(function () {
                var ss = new URLSearchParams(window.location.search);
                $("#ekleme_Yonlendir").attr("href", "personelPlanEkle.aspx?personelNumara=" + ss.get("pId"));
                $("#ara_Buton").click(function () {
                    var planTarih = $("#aranacak_Tarih").val();
                    var sonTarih = $("#sonT").val();
                    var params = new URLSearchParams(window.location.search);
                    var personelNumara = params.get("pId");

                    // AJAX çağrısı gönderiyoruz
                    $.ajax({
                        type: "GET",
                        url: "planArama.aspx",
                        data: {
                            personel_Numara: personelNumara,
                            plan_Tarih: planTarih,
                            plan_SonTarih: sonTarih
                        },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            // AJAX çağrısı başarılı olduysa, gridview'i güncelliyoruz
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.calismaPlaniListeId + "</td>" + "<td>" + value.calismaPlaniPersonelId + "</td><td><a href='personelPlanGoruntule.aspx?listeId=" + value.calismaPlaniListeId + "'><button type='button' class='btn btn-success'>Personel Plan işlem</button></a></td>" + "</tr>";
                            });
                            $("#myGrid tbody").html(html);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log(textStatus, errorThrown);
                        }
                    });
                });
            });
        </script>

    </main>
</asp:Content>
