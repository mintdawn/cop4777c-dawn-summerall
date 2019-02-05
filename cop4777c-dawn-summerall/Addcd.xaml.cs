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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace cop4777c_dawn_summerall
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Addcd : Page
    {
        public Addcd()
        {
            this.InitializeComponent();
        }

        IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        MobileServiceCollection<TodoItem, TodoItem> items;

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        public class TodoItem
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Year { get; set; }
            public string Mood { get; set; }
            public string Genre { get; set; }
        }

        async private void AddSubmitButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TodoItem item = new TodoItem
                {
                    Title = titleText.Text,
                    Artist = artistText.Text,
                    Genre = genreText.Text,
                    Year = yearText.Text
                };

                await App.MobileService.GetTable<TodoItem>().InsertAsync(item);
                var dialog = new MessageDialog("Successful!");
                ClearBoxes();
                await dialog.ShowAsync();
            }
            catch (Exception em)
            {
                var dialog = new MessageDialog("An Error Occured: " + em.Message);
                await dialog.ShowAsync();
            }
        }
        
        public void ClearBoxes ()
        {
            titleText.Text = string.Empty;
            artistText.Text = string.Empty;
            genreText.Text = string.Empty;
            yearText.Text = string.Empty;
        }
    }
}
