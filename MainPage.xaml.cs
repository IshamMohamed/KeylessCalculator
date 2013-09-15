using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net; //used for WebUtility class

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CalcSample
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void btnCla_pressed(object sender, RoutedEventArgs e)
        {
            string calctext = txtBox.Text;

            try
            {
                HttpClient htc = new HttpClient();

                //string uri = String.Format("http://www.google.com/ig/calculator?q={0}",calctext); 
                //the above will not work for + symbol

                string uri = String.Format("http://www.google.com/ig/calculator?q={0}", WebUtility.UrlEncode(calctext));
                string result = await htc.GetStringAsync(uri);

                //---String parsing algo to get correct rhs val-------------
                string[] resultArray = result.Split(new Char[] { ',' });
                result = resultArray[1];
                result = result.Substring(6);
                result = result.Substring(0, result.Length - 1);
                //---Edn of String parsing algo to get correct rhs val------

                txtResult.Text = result;
            }
            catch(Exception ex)
            {
                //not implenemted and no need for it.. ;)
            }
        }
    }
}
