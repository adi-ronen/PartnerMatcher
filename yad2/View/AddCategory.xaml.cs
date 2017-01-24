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
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        Control.Controller m_c;
        newGroup m_group;
        public AddCategory(Control.Controller c,newGroup g)
        {
            InitializeComponent();
            m_c = c;
            m_group = g;
        }

        private void addCat(object sender, RoutedEventArgs e)
        {
            if (newCat.Text == null)
            {
                MessageBox.Show("Please select new Category first");
            }
            else
            {
                if (m_c.IscategoryExsist(newCat.Text))
                    MessageBox.Show("Category allready exsist!");
                else
                {
                    m_c.AddNewCategory(newCat.Text);
                    m_group.category.ItemsSource = m_c.getALLCategories();
                    MessageBox.Show("New Category completed!");
                    Close();
                }

            }
        }
    }
}
