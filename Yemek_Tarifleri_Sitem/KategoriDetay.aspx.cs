using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Yemek_Tarifleri_Sitem
{
    public partial class KategoriDetay : System.Web.UI.Page
    {
        sqlsinif snf = new sqlsinif();
        string kategoriid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            kategoriid = Request.QueryString["Kategoriid"];
            SqlCommand komut = new SqlCommand("Select * From tbl_yemekler where kategoriid=@p1",snf.Baglanti());
            komut.Parameters.AddWithValue("@p1", kategoriid);
            SqlDataReader reader = komut.ExecuteReader();
            DataList2.DataSource = reader;
            DataList2.DataBind();
        }
    }
}