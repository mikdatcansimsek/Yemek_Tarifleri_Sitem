using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Yemek_Tarifleri_Sitem
{
    public partial class Tarifler : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel4.Visible = false;
            SqlCommand sqlCommand = new SqlCommand("Select * from tbl_tarifler where tarifdurum=0", bgl.Baglanti());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            DataList1.DataSource = reader;
            DataList1.DataBind();

            SqlCommand sqlCommand1 = new SqlCommand("Select * from tbl_tarifler where tarifdurum=1", bgl.Baglanti());
            SqlDataReader reader1 = sqlCommand1.ExecuteReader();
            DataList2.DataSource = reader1;
            DataList2.DataBind();

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
            panel4.Visible=true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }
    }
}