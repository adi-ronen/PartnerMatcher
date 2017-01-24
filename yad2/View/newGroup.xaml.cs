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
    /// Interaction logic for newGroup.xaml
    /// </summary>
    public partial class newGroup : Window
    {
        Control.Controller m_c;
        string m_userMail;
        List<string> m_partners;
        Profile m_profile;
        public newGroup(Control.Controller c, string userMail,Profile p)
        {
            InitializeComponent();
            m_c = c;
            category.ItemsSource = m_c.getALLCategories();
            m_userMail = userMail;
            m_profile = p;
            m_partners = new List<string>();
        }

        private void AddCategory(object sender, RoutedEventArgs e)
        {
            AddCategory a = new AddCategory(m_c,this);
            a.Show();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            if (category.SelectedItem == null)
            {
                MessageBox.Show("Please select Category first");
            }
      
            else
            {
                string cat = category.SelectedItem.ToString();
                m_c.AddNewGroup(cat,m_userMail,m_partners);
                m_profile.Groups.ItemsSource= m_c.getGroupList(m_userMail);
                MessageBox.Show("New Group completed!");

                Close();

            }
        }

        private void addPartner__Click(object sender, RoutedEventArgs e)
        {
            if(partner_.Text!="")
            {
                if (partner_.Text == m_userMail)
                {
                    MessageBox.Show("You can't add yourself!");
                }
                else if (m_partners.Contains(partner_.Text))
                {
                    MessageBox.Show(partner_.Text+ " was already added");
                }
                else
                {
                    if (m_c.UserExist(partner_.Text))
                    {
                        m_partners.Add(partner_.Text);
                        partner_.Text = "";
                        MessageBox.Show("Partner added!");

                    }
                    else
                    {
                        MessageBox.Show("user doesn't exsist!");
                    }
                }
            }
        }
    }
}
