using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WinCanvas {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        

        private void StartupApp(object sender, StartupEventArgs args) {   
            var window = new MainWindow();
            window.Show();
        }
    }
}
