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
using LiveCharts;
using LiveCharts.Wpf;
using System.Net;
using System.IO;
using System.Windows.Threading;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using MongoDB.Driver;

namespace Arduino_testi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// MOI testi
    /// uhkjjk
    /// uuuusi
    public partial class MainWindow : Window
    {
        public string strData;
        public string Segments;
        public string Segments2;



        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();


        }

        class MongoHelper
        {
            public static IMongoClient client { get; set; }
            public static IMongoDatabase database { get; set; }
            public static string MongoConnection = "mongodb://Tietotekniikkaprojekti:projekti2020@cluster0-shard-00-00-bg3jl.azure.mongodb.net:27017,cluster0-shard-00-01-bg3jl.azure.mongodb.net:27017,cluster0-shard-00-02-bg3jl.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
            public static string MongoDatabase = "Tietotekniikka";

            internal static void ConnectToMongoService()
            {
                try
                {
                    client = new MongoClient(MongoConnection);
                    database = client.GetDatabase(MongoDatabase);
                    Console.WriteLine("Yhteys muodostettu");

                }
                catch (Exception)
                {
                    Console.WriteLine("Yhteys muodostettu2");
                    throw;
                }
            }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                String Str = "https://api.thingspeak.com/channels/1009658/feeds.json?api_key=52YD0GLZ5GHX3O6S&results=1";
                String End = "/feeds.json?api_key=52YD0GLZ5GHX3O6S&results=1";
                //String Mid = "1009658";

               //String All1 = String.Join(Str,End);

                WebRequest request = WebRequest.Create(Str);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream datastream = response.GetResponseStream();
                StreamReader reader = new StreamReader(datastream);
                strData = reader.ReadToEnd();
                
            }
            catch(Exception)
            {
               
           }
            try
           {
                int start = strData.LastIndexOf("field1");
                Segments = strData.Substring(start + 9, 2);
            }
          catch (Exception)
            {

            }
            try
            {
                int start = strData.LastIndexOf("field2");
                Segments2 = strData.Substring(start + 9, 2);
            }
            catch (Exception)
            {

            }
            try
            {
                var convertDouble = Convert.ToDouble(Segments);
                temp.Value = convertDouble;
            }
            catch (Exception)
            {

            }
            try
            {
                var convertDouble = Convert.ToDouble(Segments2);
                humidity.Value = convertDouble;
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hides Current Button
            temp.Visibility = Visibility.Visible;
            On.Visibility = Visibility.Hidden;
            Off.Visibility = Visibility.Visible;
            
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            temp.Visibility = Visibility.Hidden;
            On.Visibility = Visibility.Visible;
            Off.Visibility = Visibility.Hidden;
        }
    }

    //sadsadsadasdsadas
}
