using Newtonsoft.Json;
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
                if (textboxCity.Text!=null)
                {
                    try
                    {
                        string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", textboxCity.Text, apiKey);
                        var json = web.DownloadString(url);
                        WeatherInfo.root info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                        weatherimg.Source = new BitmapImage(new Uri("https://openweathermap.org/img/w/" + info.weather[0].icon + ".png"));
                        labelCondition.Content = info.weather[0].main;
                        labelDetail.Content = info.weather[0].description;
                        LabelSunset.Content = convertToDate(info.sys.sunset);
                        Labelsunrise.Content = convertToDate(info.sys.sunrise);
                        Labelwindspeed.Content = info.wind.speed.ToString() +" m/s";
                        Labelpreassure.Content = info.main.pressure.ToString() + " pa";
                        LabelTemp.Content=(info.main.temp - 273.15).ToString("0.0")+ "°C";
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Wrong name! Please enter a valid name.", "Error", MessageBoxButton.OK);

                    }

                }
               
            }
        }
        DateTime convertToDate(long millisec)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddSeconds(millisec);

            return dateTime;
        }
    }
}
