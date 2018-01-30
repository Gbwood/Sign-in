using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginAssigment
{
    public partial class LoginForm : Form
    {
        public int count = 3;
        public string user = "";
        public string pass = "";
        public bool LogSuccess = false;
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=10.135.85.168;Initial Catalog=GROUP6;Persist Security Info=True;User ID=group6;Password=Grp6313s");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Table_Login where User_Name = '" + UserText.Text + "' and Password = '" + PassText.Text + "'",cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int cont = 0;
            while (dr.Read())
            {
                cont += 1;
            }
            if(cont == 1)
            {
                this.Hide();
                MessageBox.Show("You have been authorized to proceed.");
                MainForm mf = new MainForm();
                mf.Show();
            }
            else if(count > 1)
            {
                count--;
                MessageBox.Show("You have " + count + " more tries before your account is locked for 2 hours.");
            }
            else
            {
                MessageBox.Show("Your account has been locked for 2 hours.");
                UserText.Enabled = false;
                PassText.Enabled = false;
                label1.Text = "Your account has been locked, it will be available in 7200 seconds";
                label1.Visible = true;
                LoginBtn.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginUx_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            count++;
            label1.Text = "Your account has been locked, it will be available in " + (7200 - count) + " seconds";
            if (count >= 7200)
            {
                timer1.Enabled = false;
                UserText.Enabled = true;
                PassText.Enabled = true;
                LoginBtn.Enabled = true;
            }

        }
    }
}
