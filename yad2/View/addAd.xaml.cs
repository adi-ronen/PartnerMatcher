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
    /// Interaction logic for addAd.xaml
    /// </summary>
    public partial class addAd : Window
    {
        string m_userEmail;
        string m_groupid;
        Control.Controller m_c;
        View.Group m_group;
        public addAd(string email,string grupId, Control.Controller c,View.Group g)
        {
            InitializeComponent();
            m_c = c;

            City.ItemsSource = m_c.getALLLocations();
            m_userEmail = email;
            m_groupid = grupId;
            m_group = g;
        }
        

        private void Add(object sender, RoutedEventArgs e)
        {
            string temp = Date.Text;
            DateTime eventDate;
             if(City.SelectedItem==null)
            {
                MessageBox.Show("Please select City first");
            }
            else if(Date.Text==null)
            {
                MessageBox.Show("Please select Date first");
            }
            else if (!DateTime.TryParse(temp, out eventDate))
            {
                MessageBox.Show("Unrecognaized date format (try-'mm.dd.yy')");
            }
            else
            {      
                    string loc = City.SelectedItem.ToString();
                    string cat = m_group.Category.Text;
                    m_c.AddNewAd(eventDate, about.Text, DateTime.Now, loc, cat, m_userEmail, Convert.ToInt32( m_groupid));   
                    MessageBox.Show("New ad completed!");
                    m_group.Publish_Add.IsEnabled = false;
                    m_group.UnPublish_Add.IsEnabled = true;
                    m_group.GoToAdd.IsEnabled = true;
                    Close();
            }
        }

    }
}
