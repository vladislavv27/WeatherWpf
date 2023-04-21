using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WeatherWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string apiKey = "113d894b21400eacbab0da34887b802d";
        public MainWindow()
        {
            InitializeComponent();

        }



        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            getweather();
        }

        private void getweather()
        {
           using(WebClient web=new WebClient())
           {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", textboxCity.Text, apiKey);
           }
        }
    }
}
