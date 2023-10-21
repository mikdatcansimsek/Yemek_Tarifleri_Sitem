using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Yemek_Tarifleri_Sitem
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel4.Visible = false;
            //Onaylı Yorumlar Listesi
            SqlCommand cmd = new SqlCommand("Select * from tbl_yorumlar where yorumonay=1", bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();
            DataList1.DataSource = reader;
            DataList1.DataBind();

            //Onaysız Yorumlar Listesi
            SqlCommand cmd2 = new SqlCommand("Select * from tbl_yorumlar where yorumonay=0",bgl.Baglanti());
            SqlDataReader reader2 = cmd2.ExecuteReader();   
            DataList2.DataSource = reader2;
            DataList2.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            panel2.Visible=true;
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