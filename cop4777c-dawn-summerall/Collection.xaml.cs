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
    public sealed partial class Collection : Page
    {
        public Collection()
        {
            this.InitializeComponent();
        }

        IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        MobileServiceCollection<TodoItem, TodoItem> items;

        public class TodoItem
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Year { get; set; }
            public string Mood { get; set; }
            public string Genre { get; set; }
        }


        private async Task RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                items = await todoTable
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
            }
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshTodoItems();
        }
    }
}
