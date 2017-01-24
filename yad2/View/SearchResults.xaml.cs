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
    /// Interaction logic for SearchResults.xaml
    /// </summary>
    public partial class SearchResults : Window
    {
        Control.Controller m_c;
        List<Add> m_ads;
        Dictionary<string, Add> m_adsdic;
        
        public SearchResults (Control.Controller c,List<Add> ads)
        {
            InitializeComponent();
            Results.Background = Brushes.Lavender;
            Results.Foreground = Brushes.DimGray;
            m_c = c;
            m_ads = ads;
            m_adsdic = new Dictionary<string, Add>();
            foreach (var item in ads)
            {
                string s=string.Format("Category:{0} \nLocation:{1} \nDate Published:{2} \nEvent Date:{3} \nAbout:{4}", item.Category.Type, item.Location.Area, item.DatePublished, item.EventDate, item.About);
                m_adsdic.Add(s,item);
            }
            Results.ItemsSource = m_adsdic.Keys;
        }
        

        private void gotoad_Click(object sender, RoutedEventArgs e)
        {
            if (Results.SelectedItem != null)
            {
                string selected = Results.SelectedItem.ToString();
                Add selectedAd = m_adsdic[selected];
                Ad ad = new Ad(m_c, selectedAd.id.ToString());
                ad.Show();
            }

        }
    }
}
