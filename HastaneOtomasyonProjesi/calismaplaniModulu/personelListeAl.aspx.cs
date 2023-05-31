using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Web.DynamicData;

namespace HastaneOtomasyonProjesi.calismaplaniModulu
{
    public partial class personelListeAl : System.Web.UI.Page
    {
        public string IDDegeri = HttpContext.Current.Request.QueryString["personelNumarasi"];
        public DataTable aktarmaVerisi;
        public string personelIsim, personelSoyisim;
        private SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            // personelId
            if (IDDegeri == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                using (SqlCommand personelVerisi = new SqlCommand("SELECT personel_Isim, personel_Soyisim FROM personel_Tablo WHERE personel_Id = @pId", sqlcon))
                {
                    sqlcon.Open();
                    personelVerisi.Parameters.AddWithValue("@pId", IDDegeri);
                    SqlDataReader dread = personelVerisi.ExecuteReader();
                    if (dread.Read())
                    {
                        personelIsim = dread.GetString(0);
                        personelSoyisim = dread.GetString(1);
                    }
                    else
                    {
                        Response.Redirect("/panel.aspx");
                    }
                    Label1.Text = personelIsim + " ";
                    Label2.Text = personelSoyisim;
                    sqlcon.Close();
                }
            }
        }

        private void excelAktar()
        {

            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlcon.Open();
                using (SqlCommand sqlcom = new SqlCommand("SELECT CONCAT(DATEPART(MONTH, personelCalismaTarih), '-', DATEPART(YEAR, personelCalismaTarih)) AS [Tarih] ,g1 AS [Gün 1],g2 AS [Gün 2],g3 AS [Gün 3],g4 AS [Gün 4],g5 AS [Gün 5],g6 AS [Gün 6],g7 AS [Gün 7],g8 AS [Gün 8],g9 AS [Gün 9],g10 AS [Gün 10] ,g11 AS [Gün 11],g12 AS [Gün 12],g13 AS [Gün 13],g14 AS [Gün 14],g15 AS [Gün 15],g16 AS [Gün 16],g17 AS [Gün 17],g18 AS [Gün 18],g19 AS [Gün 19],g20 AS [Gün 20],g21 AS [Gün 21],g22 AS [Gün 22],g23 AS [Gün 23],g24 AS [Gün 24],g25 AS [Gün 25],g26 AS [Gün 26],g27 AS [Gün 27],g28 AS [Gün 28],g29 AS [Gün 29],g30 AS [Gün 30],g31 AS [Gün 31] FROM calisanPersonelTablosu WHERE personelId = @personelId AND personelCalismaTarih >= @baslangicTarihi AND personelCalismaTarih <= @bitisTarihi", sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@personelId", IDDegeri);
                    sqlcom.Parameters.AddWithValue("@baslangicTarihi", DateTime.Parse(baslangic_Tarih.Text).Date);
                    sqlcom.Parameters.AddWithValue("@bitisTarihi", DateTime.Parse(bitis_Tarihi.Text).Date);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcom);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // EPPlus kullanarak Excel dosyası oluşturma
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Çalışma Planı");
                        worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                        // Excel dosyasını kaydet
                        byte[] fileBytes = package.GetAsByteArray();

                        // Dosyayı indirme işlemi
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment; filename="+personelIsim.Trim()+ "_" + personelSoyisim.Trim() + "_Plan" + ".xlsx");
                        Response.BinaryWrite(fileBytes);
                        Response.End();
                    }
                }
            }

        }


        protected void excel_Aktar_Click(object sender, EventArgs e)
        {
            excelAktar();
        }

        protected void plan_Cek_Click(object sender, EventArgs e)
        {

                sqlcon.Open();
                using (SqlCommand sqlcom = new SqlCommand("SELECT personelCalismaTarih AS [Plan Tarihi],g1 AS [Gün 1],g2 AS [Gün 2],g3 AS [Gün 3],g4 AS [Gün 4],g5 AS [Gün 5],g6 AS [Gün 6],g7 AS [Gün 7],g8 AS [Gün 8],g9 AS [Gün 9],g10 AS [Gün 10] ,g11 AS [Gün 11],g12 AS [Gün 12],g13 AS [Gün 13],g14 AS [Gün 14],g15 AS [Gün 15],g16 AS [Gün 16],g17 AS [Gün 17],g18 AS [Gün 18],g19 AS [Gün 19],g20 AS [Gün 20],g21 AS [Gün 21],g22 AS [Gün 22],g23 AS [Gün 23],g24 AS [Gün 24],g25 AS [Gün 25],g26 AS [Gün 26],g27 AS [Gün 27],g28 AS [Gün 28],g29 AS [Gün 29],g30 AS [Gün 30],g31 AS [Gün 31] FROM calisanPersonelTablosu WHERE personelId = @personelId AND personelCalismaTarih >= @baslangicTarihi AND personelCalismaTarih <= @bitisTarihi", sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@personelId", IDDegeri);
                    sqlcom.Parameters.AddWithValue("@baslangicTarihi", DateTime.Parse(baslangic_Tarih.Text).Date);
                    sqlcom.Parameters.AddWithValue("@bitisTarihi", DateTime.Parse(bitis_Tarihi.Text).Date);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcom);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    aktarmaVerisi = dataTable;  
                    listeGridView.DataSource = dataTable;
                    listeGridView.DataBind();
                    
                    sqlcon.Close();
                }

        }
    }
}