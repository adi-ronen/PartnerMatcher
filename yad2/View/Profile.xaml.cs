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

namespace yad2
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        Control.Controller m_c;
        string m_userMail;
        public Profile(Control.Controller c, string email)
        {
            InitializeComponent();
            m_c = c;
            string[] details = m_c.GetDetails(email);
            userName.Text = details[0];
            Email.Text = details[1];
            Gender.Text =details[2];
            Age.Text = details[3];
            List<string> l_groups =m_c.getGroupList(email);
            this.Groups.ItemsSource = l_groups;
            m_userMail = email;
        }

        private void Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if( Groups.SelectedIndex != -1)
            {
            View.Group g = new View.Group(m_c, Groups.SelectedItem.ToString().Substring(0, (Groups.SelectedItem.ToString()).IndexOf(',')).Trim(),m_userMail);
            g.Show();
            Groups.SelectedIndex = -1;
            }
        }

        private void NewGroup_Click(object sender, RoutedEventArgs e)
        {
            newGroup newg = new newGroup(m_c, m_userMail,this);
            newg.Show();
            List<string> l_groups = m_c.getGroupList(m_userMail);
            this.Groups.ItemsSource = l_groups;
        }
    }
}
