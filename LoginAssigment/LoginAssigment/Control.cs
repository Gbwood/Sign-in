using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAssigment
{
    public class Control
    {
        public static int count = 3;

        public static int Count
        {
            get
            {
                return count;
            }
        }
        public static void Click()
        {
            int cont = LoginForm.cont;
            string user = LoginForm.user;
            string pass = LoginForm.pass;
            if (Model.Open(cont, user, pass) == 1)
            {
                //Form.Hide();
                MessageBox.Show("You have been authorized to proceed.");
                MainForm mf = new MainForm();
                mf.Show();
            }
            else if (count > 1)
            {
                count--;
                MessageBox.Show("You have " + count + " more tries before your account is locked for 2 hours.");
            }
            else
            {
                MessageBox.Show("Your account has been locked for 2 hours.");
            }
        }
    }
}
