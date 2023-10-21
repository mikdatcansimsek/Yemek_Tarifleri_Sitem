using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Yemek_Tarifleri_Sitem
{
    public partial class HakkimizdaAdmin : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;

            if (Page.IsPostBack == false)
            {
                SqlCommand cmd = new SqlCommand("Select * from tbl_hakkimizda", bgl.Baglanti());
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TextBox1.Text = rdr[0].ToString();
                }
                bgl.Baglanti().Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel2.Visible=true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible=false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Update tbl_Hakkimizda set Metin=@p1", bgl.Baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", TextBox1.Text);
            sqlCommand.ExecuteNonQuery();
            bgl.Baglanti().Close();
        }
    }
}