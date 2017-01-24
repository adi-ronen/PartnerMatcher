using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using yad2.Control;

namespace yad2
{
    /// <summary>
    /// Interaction logic for existingUser.xaml
    /// </summary>
    public partial class existingUser : Window
    {
        MainWindow window;
        Controller m_c;
        public existingUser(MainWindow win, Controller c)
        {
            InitializeComponent();
            window = win;
            m_c = c;
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (!m_c.UserExist(mail.Text))
                MessageBox.Show("E-Mail does not exist in the system");
            else
            {
                User user = m_c.getUsers(mail.Text);
                if (user.Password.Trim() == password.Password)
                {
                    MessageBox.Show("Welcome " + user.FirstName.Trim() + " " + user.LastName.Trim());
                    window.HelloUser.Text = "Hello " + user.FirstName.Trim() + " " + user.LastName.Trim();
                    window.My_Profile.IsEnabled = true;
                    window.m_userMail = mail.Text;
                    Profile p = new Profile(m_c, mail.Text);
                    p.Show();
                    Close();
                }
                else
                    MessageBox.Show("Wrong password");
            }
            
        }
    }
}
