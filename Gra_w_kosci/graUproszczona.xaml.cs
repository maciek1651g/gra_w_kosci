using System;
using System.Collections.Generic;
using System.Drawing;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gra_w_kosci
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class graUproszczona : Page
    {
        int rzut = 0;
        int liczbaGraczy = 1;

        public graUproszczona()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                //liczbaGraczy = Convert.ToInt32(e.Parameter);
            }

            base.OnNavigatedTo(e);
        }

        private void KostkaKliknieta(object sender, RoutedEventArgs e)
        {
            var przycisk = (Button)sender;

        }

        private void PrzelaczKosci()
        {
            kostka1.IsEnabled = !kostka1.IsEnabled;
            kostka2.IsEnabled = !kostka2.IsEnabled;
            kostka3.IsEnabled = !kostka3.IsEnabled;
            kostka4.IsEnabled = !kostka4.IsEnabled;
            kostka5.IsEnabled = !kostka5.IsEnabled;
        }

        private void RzutKoscmi(object sender, RoutedEventArgs e)
        {
            var przycisk = (Button)sender;
            

            if (rzut==0)
            {
                int[] wartosci = Losowanko();

                WyswietlKosci(new[] { 1, 2, 3, 4, 5 }, wartosci);

                przycisk.Content = "Przerzuć kości";
            }
            else if(rzut==1)
            {

            }
            else if(rzut==2)
            {
                przycisk.IsEnabled = false;
            }

            rzut++;
        }

        private void WyswietlKosci(int[] kostki, int[] wartosci)
        {
            for (int i = 0; i < kostki.Length; i++)
            {
                BitmapImage Obraz = new BitmapImage(new Uri("ms-appx:///Assets/kostki/" + wartosci[i] + ".png"));
                Image content = null;

                switch (kostki[i])
                {
                    case 1:
                        content = (Image)kostka1.Content;
                        break;
                    case 2:
                        content = (Image)kostka2.Content;
                        break;
                    case 3:
                        content = (Image)kostka3.Content;
                        break;
                    case 4:
                        content = (Image)kostka4.Content;
                        break;
                    case 5:
                        content = (Image)kostka5.Content;
                        break;
                }

                content.Source = Obraz;
            }
        }

        private int[] Losowanko()
        {
            int[] tab = new int[5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                tab[i] = random.Next(1,6);
            }

            return tab;
        }

        private void NowaGra(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(graUproszczona));
        }
        private void MenuGlowne(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }
    }
}
