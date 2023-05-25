<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Çalışma Planı Modülü" CodeBehind="personelPlanEkle.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.anasayfa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-calendar-days"></i>Personel Çalışma Planı Modülü</h1>
        <p style="color: white;">Bu modül ile personellerin nöbet planlarını ekleyebilir, düzenleyebilir ve silebilirsiniz.</p>
        <br />
        <style>
            label {
                color: white;
            }
        </style>

        <asp:HiddenField ID="personelid" runat="server" />
        <div>

            <table cellpadding="15">
                <tr>
                    <td>
                        <label for="<%= plan_Tarih.ClientID %>">Çalışma Planı Yapılacak Ay ve Yıl: </label>
                    </td>
                    <td>
                        <asp:TextBox ID="plan_Tarih" ClientIDMode="Static" CssClass="form-control" runat="server" TextMode="Date" />
                    </td>
                    <td>
                        <asp:Button Text="Personel Çalışma Planı Araması" CssClass="btn btn-warning" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div>
            <asp:PlaceHolder ID="gunInputKutusu" runat="server">
                <%
                    for (int i = 1; i <= 31; i++)
                    {
                        Response.Write("<div style='display: inline-block; margin-right: 100px;'>");
                        Response.Write("<label>Gün " + i + ":</label><br />");
                        Response.Write("<div style='display: flex; flex-direction: column;'>");
                        Response.Write("<input type='time' id='gunBaslangicInput_" + i.ToString() + "' class='form-control'>");
                        Response.Write("<br />");
                        Response.Write("<input type='time' id='gunBitisInput_" + i.ToString() + "' class='form-control'>");
                        Response.Write("</div>");
                        Response.Write("</div>");

                        if (i % 5 == 0)
                        {
                            Response.Write("<br />");
                        }
                    }
                %>            
            </asp:PlaceHolder>
        </div>
        <br />
        <button type="button" class="btn btn-warning" id="kaydet_Buton" name="kaydet_Buton">Planı Kaydet</button>

        <script>
            $(document).ready(function () {
                $("#kaydet_Buton").click(function () {
                    var calismaPlanlari = [];
                    for (var i = 1; i <= 31; i++) {
                        var baslangicSaat = $("#gunBaslangicInput_" + i).val();
                        var bitisSaat = $("#gunBitisInput_" + i).val();
                        calismaPlanlari.push([baslangicSaat, bitisSaat]);
                    }

                    var calismaPlanlariString = JSON.stringify(calismaPlanlari);
                    console.log(calismaPlanlariString);

                    var random = Math.floor(Math.random() * (9999 - 1111 + 1)) + 1111;
                    console.log(random);

                    var personelId = $("#<%= personelid.ClientID %>").val();
                    console.log(personelId);

                    var personelCalismaTarih = $("#plan_Tarih").val();
                    console.log(personelCalismaTarih);

                    var data = {
                        calismaListeId: random,
                        personelCalismaTarih: personelCalismaTarih,
                        personelid: personelId,
                        calismaPlanlari: calismaPlanlariString
                    };

                    $.ajax({
                        type: "GET",
                        url: "kaydetapi.aspx",
                        data: data,
                        success: function (response) {
                            console.log(response);
                            alert("Plan başarıyla kaydedildi.");
                        },
                        error: function (response) {
                            console.log(response);
                            alert("Plan kaydedilirken bir hata oluştu.");
                        }
                    });
                });
            });
        </script>


    </main>
</asp:Content>
