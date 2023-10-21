using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Yemek_Tarifleri_Sitem
{
    public partial class TarifOnerDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id= Request.QueryString["Tarifid"];
            if (Page.IsPostBack==false)
            {
                SqlCommand cmd = new SqlCommand("Select * from tbl_tarifler where Tarifid=@p1", bgl.Baglanti());
                cmd.Parameters.AddWithValue("@p1", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TextBox1.Text = reader[1].ToString();
                    TextBox2.Text = reader[2].ToString();
                    TextBox3.Text = reader[3].ToString();
                    TextBox4.Text = reader[5].ToString();
                    TextBox5.Text = reader[6].ToString();
                }
                bgl.Baglanti().Close();

                //Kategori Listesi
                SqlCommand komut2 = new SqlCommand("Select * from tbl_Kategoriler", bgl.Baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();

                DropDownList1.DataTextField = "KategoriAd";
                DropDownList1.DataValueField = "Kategoriid";

                DropDownList1.DataSource = dr2;
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Durum Güncelleme
            SqlCommand sqlCommand = new SqlCommand("update tbl_tarifler set tarifdurum=1 where tarifid=@p1", bgl.Baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", id);
            sqlCommand.ExecuteNonQuery();
            bgl.Baglanti().Close();

            //Yemeği Ana Sayfa Ekleme
            SqlCommand sqlCommand2 = new SqlCommand("Insert into tbl_yemekler (YemekAd, YemekMalzeme, YemekTarif,Kategoriid) values (@p1,@p2,@p3,@p4)", bgl.Baglanti());
            sqlCommand2.Parameters.AddWithValue("@p1", TextBox1.Text);
            sqlCommand2.Parameters.AddWithValue("@p2", TextBox2.Text);
            sqlCommand2.Parameters.AddWithValue("@p3", TextBox3.Text);
            sqlCommand2.Parameters.AddWithValue("@p4", DropDownList1.SelectedValue);
            sqlCommand2.ExecuteNonQuery();
            bgl.Baglanti() .Close();
        }
    }
}