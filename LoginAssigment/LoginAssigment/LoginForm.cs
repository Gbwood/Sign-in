using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAssigment
{
    public partial class LoginForm : Form
    {
        public int count = 3;
        public string pass = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UserText.Text == "user" && PassText.Text == "pass")
            {
                this.Hide();
                MessageBox.Show("You have been authorized to proceed.");
                MainForm mf = new MainForm();
                mf.Show();
            }
            else if(count != 1)
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
