using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gra_w_kosci
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class liczbaGraczy : Page
    {
        int typGry=0;

        public liczbaGraczy()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter!=null)
            {
                typGry = Convert.ToInt32(e.Parameter);
            }

            /*
            var messageDialog = new MessageDialog("Witaj świecie! "+typGry);
            messageDialog.Commands.Add(new UICommand("Cancel"));
            messageDialog.ShowAsync();
            */

            base.OnNavigatedTo(e);
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartGry(10 + typGry);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StartGry(20 + typGry);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StartGry(30 + typGry);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StartGry(40 + typGry);
        }


        /// <summary>
        /// Przechodzi do strony gdzie rozpoczyna się gra
        /// </summary>
        /// <param name="typGry">pierwsza cyfra to liczba graczy, druga cyfra to typ gry 0-uproszczony, 1-pełny</param>
        private void StartGry(int typGry)
        {
            this.Frame.Navigate(typeof(gra), typGry);
        }
    }
}
