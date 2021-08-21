using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TWX3
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();

            WelcomeGrid.Visibility = Visibility.Visible;
            ServerGrid.Visibility = Visibility.Hidden;
            LoginGrid.Visibility = Visibility.Hidden;

            Address.Items.Add("cruncherstw.no-ip.biz (Cruncher's)");
            Address.Items.Add("microblaster.net (MBN)");
            Address.Items.Add("sk-twgs.com (Ice 9)");
            Address.Items.Add("v1.sk-twgs.com (Ice 9 v1)");
            Address.Items.Add("games.TradeWars-League.com (Sultan Bey)");
            Address.Items.Add("202.151.82.243 (Vid's World on Guam)");

            Port.Text = "2002";
            Protocal.SelectedIndex = 0;
            ClentPort.Text = "2300";
            ClientProtocal.SelectedIndex = 0;

            Game.Items.Add("A - Game A");
            Game.SelectedIndex = 0;
        }

        private void WikiLinkClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo {FileName = "https://github.com/MicroBlaster/TWX3/wiki", UseShellExecute = true});
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            WelcomeGrid.Visibility = Visibility.Hidden;
            ServerGrid.Visibility = Visibility.Visible;
        }

        private void NextButton2Click(object sender, RoutedEventArgs e)
        {
            ServerGrid.Visibility = Visibility.Hidden;
            LoginGrid.Visibility = Visibility.Visible;
        }

        private void BrowseButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void Port_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TraIconListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
