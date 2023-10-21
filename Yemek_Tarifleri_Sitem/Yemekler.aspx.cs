using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yemek_Tarifleri_Sitem
{
    public partial class Yemekler : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string islem = "";
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            Panel5.Visible = false;

            if (Page.IsPostBack == false)
            {

                id = Request.QueryString["Yemekid"];
                islem = Request.QueryString["islem"];

                //Kategori Listesi
                SqlCommand komut2 = new SqlCommand("Select * from tbl_Kategoriler", bgl.Baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();

                DropDownList1.DataTextField = "KategoriAd";
                DropDownList1.DataValueField = "KAtegoriid";

                DropDownList1.DataSource = dr2;
                DropDownList1.DataBind();
            }


            //Yemek Listesi
            SqlCommand cmd = new SqlCommand("Select * from tbl_Yemekler",bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();
            DataList1.DataSource = reader;
            DataList1.DataBind();

            if (islem == "sil")
            {
                SqlCommand sqlCommand = new SqlCommand("delete from tbl_yemekler where Yemekid=@p1", bgl.Baglanti());
                sqlCommand.Parameters.AddWithValue("@p1", id);
                sqlCommand.ExecuteNonQuery();
                bgl.Baglanti().Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel5.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;
        }

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            //Yemek Ekleme
            SqlCommand komut = new SqlCommand("Insert into tbl_Yemekler (yemekad,yemekmalzeme,yemektarif,kategoriid) values (@p1,@p2,@p3,@p4)",bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TextBox1.Text);
            komut.Parameters.AddWithValue("@p2", TextBox2.Text);
            komut.Parameters.AddWithValue("@p3", TextBox3.Text);
            komut.Parameters.AddWithValue("@p4", DropDownList1.SelectedValue);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();

            //Kategori Sayısını Arttırma
            SqlCommand sqlCommand = new SqlCommand("update tbl_kategoriler set kategoriadet=kategoriadet+1 where kategoriid=@p1",bgl.Baglanti());
            sqlCommand.Parameters.AddWithValue("@p1",DropDownList1.SelectedValue);
            sqlCommand.ExecuteNonQuery();
            bgl.Baglanti().Close();
        }
    }
}