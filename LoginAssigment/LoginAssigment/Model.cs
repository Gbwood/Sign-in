using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoginAssigment
{
    class Model
    {
        public static int Open(int cont,string user, string pass)
        {
            int c = 0;
            SqlConnection cn = new SqlConnection("Data Source=10.135.85.168;Initial Catalog=GROUP6;Persist Security Info=True;User ID=group6;Password=Grp6313s");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Table_Login where User_Name = '" + user + "' and Password = '" + pass + "'", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c += 1;
            }
            return c;
        }
    }
}