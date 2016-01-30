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
using Hackathon.Core.Domin;
using Hackathon.Core.Servives;
using Hackathon.Core.Services;

namespace _13a_Hackathon1._0
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            string City = txb1.Text;
            string State = txb2.Text;
        
            var location = LocationService.showLocation(City,State);

            List<CriminalInfo> crminalstable = CriminalDataDisplay.showData(location.Latitude, location.Longitude);




            DataDisply displydata = new DataDisply(crminalstable);
            displydata.ShowDialog();
        }
    }
}
