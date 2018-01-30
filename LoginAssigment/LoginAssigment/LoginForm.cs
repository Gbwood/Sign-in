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
        public static int cont = 0;
        public static string user = ""; 
        public static string pass = "";
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Control.count == 1)
            {
                UserText.Enabled = false;
                PassText.Enabled = false;
                LoginBtn.Enabled = false;
                Timer1.Enabled = true;
            }
            Control.Click();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UserText_TextChanged(object sender, EventArgs e)
        {
            user = UserText.Text;
        }

        public void PassText_TextChanged(object sender, EventArgs e)
        {
            pass = PassText.Text;
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            count++;
            label3.Text = "Your account has been locked, it will be available in " + (7200 - count) + " seconds";
            if (count >= 7200)
            {
                Timer1.Enabled = false;
                UserText.Enabled = true;
                PassText.Enabled = true;
                LoginBtn.Enabled = true;
            }
        }
    }
}
