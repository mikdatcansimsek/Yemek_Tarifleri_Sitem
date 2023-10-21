using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Yemek_Tarifleri_Sitem
{
    public partial class YorumDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["Yorumid"];

            if (Page.IsPostBack == false)
            {



                SqlCommand cmd = new SqlCommand("Select YorumAdSoyad,YorumMail,Yorumicerik,YemekAd from tbl_yorumlar inner join tbl_yemekler on tbl_yorumlar.yemekid=tbl_yemekler.yemekid where yorumid=@p1", bgl.Baglanti());
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TxtAd.Text = dr[0].ToString();
                    TxtMail.Text = dr[1].ToString();
                    TxtIcerik.Text = dr[2].ToString();
                    TxtYemek.Text = dr[3].ToString();
                }
                bgl.Baglanti().Close();
            }
        }

        protected void BtnOnayla_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Update tbl_yorumlar set yorumicerik=@p1, yorumonay=@p2 where yorumid=@p3",bgl.Baglanti());
            sqlCommand.Parameters.AddWithValue("@p1",TxtIcerik.Text);
            sqlCommand.Parameters.AddWithValue("@p2", "True");
            sqlCommand.Parameters.AddWithValue("@p3", id);
            sqlCommand.ExecuteNonQuery();
            bgl.Baglanti().Close();
        }
    }
}