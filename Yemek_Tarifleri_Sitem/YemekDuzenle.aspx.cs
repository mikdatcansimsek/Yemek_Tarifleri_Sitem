using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yemek_Tarifleri_Sitem
{
    public partial class YemekDuzenle : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["Yemekid"];

            if (Page.IsPostBack == false)
            {

                //Kategori Listesi
                SqlCommand komut2 = new SqlCommand("Select * from tbl_Kategoriler", bgl.Baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();

                DropDownList1.DataTextField = "KategoriAd";
                DropDownList1.DataValueField = "Kategoriid";

                DropDownList1.DataSource = dr2;
                DropDownList1.DataBind();
            }

            if (Page.IsPostBack == false)
            {
                SqlCommand cmd = new SqlCommand("Select * from tbl_yemekler where Yemekid=@p1", bgl.Baglanti());
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TextBox1.Text = dr[1].ToString();
                    TextBox2.Text = dr[2].ToString();
                    TextBox3.Text = dr[3].ToString();
                }
                bgl.Baglanti().Close();
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FileUpload1.SaveAs(Server.MapPath("/resimler/" + FileUpload1.FileName));


            SqlCommand komut = new SqlCommand("update tbl_yemekler set yemekad=@p1, yemekmalzeme=@p2, yemektarif=@p3, kategoriid=@p4, YemekResim=@p6 where yemekid=@p5", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TextBox1.Text);
            komut.Parameters.AddWithValue("@p2", TextBox2.Text);
            komut.Parameters.AddWithValue("@p3", TextBox3.Text);
            komut.Parameters.AddWithValue("@p4", DropDownList1.SelectedValue);
            komut.Parameters.AddWithValue("@p5", id);
            komut.Parameters.AddWithValue("@p6", "~/resimler/" + FileUpload1.FileName);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Tüm yemeklerin durumunu false yaptık
            SqlCommand sqlCommand = new SqlCommand("Update tbl_yemekler set durum=0", bgl.Baglanti());
            sqlCommand.ExecuteNonQuery();
            bgl.Baglanti().Close();

            //Gunun yemegi için id ye göre durumu true yapalım

            SqlCommand sqlCommand1 = new SqlCommand("Update tbl_Yemekler set durum=1 where yemekid=@p1",bgl.Baglanti());
            sqlCommand1.Parameters.AddWithValue("@p1", id);
            sqlCommand1.ExecuteNonQuery();
            bgl.Baglanti().Close();    
        }
    }
}