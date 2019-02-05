using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;
using System.Net.Http;
using Newtonsoft.Json;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace cop4777c_dawn_summerall
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ViewallButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Collection), null);
        }

        private void AddcdButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Addcd), null);
        }

        private void ArtistButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Artist), null);
        }
    }
}
