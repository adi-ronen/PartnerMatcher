using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using yad2.Control;
using yad2.Model;

namespace yad2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private void StartUp(object sender, StartupEventArgs e)
        //{
        //    Model.Model model = new Model.Model();
        //    MainWindow view = new MainWindow();
        //    Controller c = new Controller(model, view);
        //    model.SetController(c);
        //    view.SetController(c);
        //    view.Show();
        //}
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Model.Model model = new Model.Model();
            MainWindow view = new MainWindow();
            Controller c = new Controller(model, view);
            model.SetController(c);
            view.SetController(c);
            view.Show();
        }
    }
}
