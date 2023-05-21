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
        <div>

            <table cellpadding="15">
                <tr>
                    <td>
                        <label for="<%= plan_Tarih.ClientID %>">Çalışma Planı Yapılacak Ay ve Yıl: </label>
                    </td>
                    <td>
                        <asp:TextBox ID="plan_Tarih" CssClass="form-control" runat="server" TextMode="Date" />
                    </td>
                    <td>
                        <asp:Button Text="Personel Çalışma Planı Araması" CssClass="btn btn-warning" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <hr />
        <asp:PlaceHolder ID="gunInputKutusu" runat="server">
            <%
                for (int i = 1; i <= 31; i++)
                {
                    Response.Write("<label>Gün " + i + ": </label>");
                    Response.Write("<input type='time' id='gunInput_"+i.ToString()+"' class='form-control'>");
                    if (i % 7 == 0)
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
            // Butona tıklandığında tüm inputları tek tek alacak.

            $(document).ready(function () {
                $("#kaydet_Buton").click(function () {
                    var tArray = "[";
                    for (var ix = 1; ix <= 5; ix++) {
                        tArray += document.getElementById('gunInput_' + ix).value + ", ";
                    }
                    tArray += "]";
                    alert(tArray);
                });
            });
        </script>
    </main>
</asp:Content>
