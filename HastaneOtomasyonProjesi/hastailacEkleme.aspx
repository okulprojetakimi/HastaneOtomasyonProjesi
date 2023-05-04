<%@ Page Title="Hasta ilaç ekleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hastailacEkleme.aspx.cs" Inherits="HastaneOtomasyonProjesi.hastailacEkleme" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- <asp:GridView ID="ilacListesi" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ilacId" HeaderText="İlaç Numarası" />
            <asp:BoundField DataField="ilacIsmi" HeaderText="İlaç İsmi" />
            <asp:BoundField DataField="ilacreceteTuru" HeaderText="İlaç Reçete Türü" />
            <asp:BoundField DataField="ilacFiyat" HeaderText="İlaç Fiyatı" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView> -->
    <!-- İlaç Listesi -->
    <main>
        <h1 style="color: white;"><i class="fa-solid fa-pills"></i> Hastaya İlaç Ekleme</h1>
        <br />
        <style>
            .labels{
                color: white;
            }
        </style>
        <asp:Label CssClass="labels" Text="İlaç eklenecek hasta: " ID="ilac_Hasta" runat="server" /><br />
        <asp:Label CssClass="labels" Text="İlaç eklenecek hasta tc: " ID="ilac_HastaTc" runat="server" />
        <br />
        <br />
        <br />
        <div class="ilacArama_Kutusu">
            <!-- <asp:TextBox CssClass="form-control" ID="aranacak_Ilac" runat="server" />
            <asp:Button CssClass="btn btn-info" ID="ilac_AramaButonu" Text="İlaç Ara" runat="server" OnClick="ilac_AramaButonu_Click" /> -->
            <table>
                <tr>
                    <td><label>Aranacak İlaç Ismi: </label></td>
                    <td><input class="form-control" name="ilac_AramaInput" id="ilac_AramaInput" /><br /></td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-striped" id="myGrid" border="1">
                <thead>
                    <tr>
                        <th>İlaç Numarası</th>
                        <th>İlaç İsmi</th>
                        <th>İlaç Reçete Türü</th>
                        <th>İlaç Fiyatı</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>

        </div>
        <script>
            $(document).ready(function () {
                // input alanına her veri girildiğinde
                $("#ilac_AramaInput").keyup(function () {
                    // AJAX çağrısı gönderiyoruz
                    $.ajax({
                        type: "GET",
                        url: "ilacArama.aspx",
                        data: { ilacIsmi: $(this).val() },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            // AJAX çağrısı başarılı olduysa, gridview'i güncelliyoruz
                            var html = "";
                            $.each(data, function (key, value) {
                                html += "<tr><td>" + value.ilacId + "</td><td>" + value.ilacIsmi + "</td><td>" + value.ilacreceteTuru+ "</td>" + "<td>" + value.ilacFiyat + "</td>" + "</tr>";
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

        

        <asp:Button CssClass="btn btn-success" Text="+ Ilac ekle" runat="server" ID="hastaIlac_Ekle" OnClick="hastaIlac_Ekle_Click" />
    </main>
</asp:Content>
