﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yemek_Tarifleri_Sitem
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From tbl_Yemekler", bgl.Baglanti());
            SqlDataReader rdr = komut.ExecuteReader();
            DataList2.DataSource = rdr;
            DataList2.DataBind();
        }
    }
}