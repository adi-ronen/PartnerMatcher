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
using System.Windows.Navigation;
using System.Windows.Shapes;
using yad2.Control;
using yad2.View;

namespace yad2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller m_controller;
        public string m_userMail;
        public MainWindow()
        {
            InitializeComponent();
            My_Profile.IsEnabled = false;
        }

        private void existingUser(object sender, RoutedEventArgs e)
        {
            existingUser ExistingUser = new existingUser(this, m_controller);
            ExistingUser.Show();
        }

        public void SetController(Controller c)
        {
            m_controller = c;
            Categories.ItemsSource = m_controller.getALLCategories();
            Locations.ItemsSource = m_controller.getALLLocations();
        }
        private void newUser(object sender, RoutedEventArgs e)
        {
            newUser NewUser = new newUser(this,m_controller);
            NewUser.Show();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
             
            if (HelloUser.Text == "Hello Guest") //אם לא מחובר יעני
                MessageBox.Show("Please Login or Register first");
            else
            { 
                if(Locations.SelectedItem!=null && Categories.SelectedItem!=null)
                {

                    string loc = Locations.SelectedItem.ToString();
                    string cat = Categories.SelectedItem.ToString();
                    List<Add> adds = m_controller.getSearchAds(cat,loc);
                    if (adds.Count() > 0)
                    {
                        Window win = new Window();
                        win.Background = Brushes.SandyBrown;
                        //win.Height = 250.00;
                        win.Width = 350.00;
                        SearchResults results = new SearchResults(m_controller, adds);
                        results.Show();
                       
                    }
                    else
                    {
                        MessageBox.Show("Sorry!!! but there is no adds matching your search :(");
                    }
                }
                else
                {
                    MessageBox.Show("Please select Location And Category first");
                }
            }
        }

        private void open_profile(object sender, RoutedEventArgs e)
        {
            Profile p = new Profile(m_controller,m_userMail);
            p.Show();
        }

        private void Categories_DropDownOpened(object sender, EventArgs e)
        {
            Categories.ItemsSource = m_controller.getALLCategories();

        }
    }
}
