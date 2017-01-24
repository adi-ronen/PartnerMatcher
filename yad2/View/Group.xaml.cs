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

namespace yad2.View
{
    /// <summary>
    /// Interaction logic for Group.xaml
    /// </summary>
    public partial class Group : Window
    {
        
        Control.Controller m_c;
        string m_userMail;
        string m_groupID;
        public Group (Control.Controller c , string groupID, string userMail)
        {
            InitializeComponent();
            m_c = c;
            m_groupID = groupID;
            m_userMail = userMail;
            GroupName.Text = groupID;
            Category.Text = m_c.GroupCategory(groupID);
            Manager.Text = "Manager: " + m_c.GroupManager(groupID);
            Members.ItemsSource = m_c.GroupMembers(groupID);
            if (m_c.isPublished(Convert.ToInt32(groupID)))
                Publish_Add.IsEnabled = false;
            else
            {
                UnPublish_Add.IsEnabled = false;
                GoToAdd.IsEnabled = false;
            }
        }

        private void Publish_Add_Click(object sender, RoutedEventArgs e)
        {
            addAd newAdd = new addAd(m_userMail, m_groupID,m_c,this);
            newAdd.Show();

        }

        private void UnPublish_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_c.RemoveAd(Convert.ToInt32 (m_groupID));
                MessageBox.Show("Ad was removed");
                Publish_Add.IsEnabled = true;
                UnPublish_Add.IsEnabled = false;
                GoToAdd.IsEnabled = false;
            }
            catch
            {
                if (!m_c.isPublished(Convert.ToInt32(m_groupID)))
                {
                    MessageBox.Show("Ad was removed");
                    Publish_Add.IsEnabled = true;
                    UnPublish_Add.IsEnabled = false;
                    GoToAdd.IsEnabled = false;
                }
                 MessageBox.Show("Couldn't remove add, try again");
            }
           
        }

        private void OpenChat(object sender, RoutedEventArgs e)
        {
            Chat c = new Chat(m_c, m_groupID, m_userMail);
            c.Show();
        }

        private void GoToAdd_Click(object sender, RoutedEventArgs e)
        {
            Ad ad = new Ad(m_c, m_groupID);
            ad.Show();

        }
    }
}
