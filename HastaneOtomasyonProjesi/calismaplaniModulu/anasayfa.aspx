<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Çalışma Planı Modülü" CodeBehind="anasayfa.aspx.cs" Inherits="HastaneOtomasyonProjesi.calismaplaniModulu.anasayfa" %>

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
        <asp:Panel ID="inputContainer" runat="server">
            <%
                for (int x = 1; x <= 31; x++)
                {
                    Response.Write("&nbsp;");
                    Response.Write("<label>Gün " + x.ToString() + " </label>");
                    Response.Write("&nbsp;<input type='time' id='gunDyn_" + x.ToString() + "' >");
                    if (x % 7 == 0)
                    {
                        Response.Write("<br/><br/>");
                    }
                }
            %>
        </asp:Panel>
        <br />
        <asp:Button Text="Çalışma Planını Kaydet" CssClass="btn btn-success" ID="plan_Kaydet" runat="server" />
    </main>
</asp:Content>
