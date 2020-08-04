using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        int[] wartosci = new int[5];
        int[] kosciDorzucenia = new[] { 0, 0, 0, 0, 0 };

        public graUproszczona()
        {
            this.InitializeComponent();
            Start();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                //liczbaGraczy = Convert.ToInt32(e.Parameter);
            }

            base.OnNavigatedTo(e);
        }

        private void Start()
        {
            switch(liczbaGraczy)
            {
                case 1:
                    gracz1.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void KostkaKliknieta(object sender, RoutedEventArgs e)
        {
            if (rzut >= 1 && rzut <= 2)
            {
                var przycisk = (Button)sender;
                int numerKostki = przycisk.Name[przycisk.Name.Length - 1] - '0';

                if (kosciDorzucenia[numerKostki - 1] == 0)
                {
                    kosciDorzucenia[numerKostki - 1] = 1;
                    przycisk.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    kosciDorzucenia[numerKostki - 1] = 0;
                    przycisk.Background = new SolidColorBrush(Colors.White);
                }
            }
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
                for (int i = 0; i < kosciDorzucenia.Length; i++)
                {
                    kosciDorzucenia[i] = 1;
                }

                Losowanko(kosciDorzucenia, wartosci);

                WyswietlKosci(kosciDorzucenia, wartosci);

                przycisk.Content = "Przerzuć kości";
            }
            else if(rzut==1)
            {
                Losowanko(kosciDorzucenia, wartosci);

                WyswietlKosci(kosciDorzucenia, wartosci);
            }
            else if(rzut==2)
            {
                Losowanko(kosciDorzucenia, wartosci);

                WyswietlKosci(kosciDorzucenia, wartosci);

                przycisk.IsEnabled = false;
            }

            rzut++;
        }

        private void WyswietlKosci(int[] kosciDorzucenia, int[] wartosci)
        {
            for (int i = 0; i < kosciDorzucenia.Length; i++)
            {
                if (kosciDorzucenia[i] != 0)
                {
                    BitmapImage Obraz = new BitmapImage(new Uri("ms-appx:///Assets/kostki/" + wartosci[i] + ".png"));
                    Image content = null;

                    switch (i+1)
                    {
                        case 1:
                            content = (Image)kostka1.Content;
                            kostka1.Background = new SolidColorBrush(Colors.White);
                            break;
                        case 2:
                            content = (Image)kostka2.Content;
                            kostka2.Background = new SolidColorBrush(Colors.White);
                            break;
                        case 3:
                            content = (Image)kostka3.Content;
                            kostka3.Background = new SolidColorBrush(Colors.White);
                            break;
                        case 4:
                            content = (Image)kostka4.Content;
                            kostka4.Background = new SolidColorBrush(Colors.White);
                            break;
                        case 5:
                            content = (Image)kostka5.Content;
                            kostka5.Background = new SolidColorBrush(Colors.White);
                            break;
                    }

                    kosciDorzucenia[i] = 0;
                    content.Source = Obraz;
                }
            }
        }

        private void Losowanko(int[] kosciDorzucenia, int[] wartosci)
        {
            Random random = new Random();

            for (int i = 0; i < kosciDorzucenia.Length; i++)
            {
                if(kosciDorzucenia[i]!=0)
                {
                    wartosci[i] = random.Next(1, 6);
                }
            }
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

        private void PodajWynik(object sender, RoutedEventArgs e)
        {
            var przycisk = (Button)sender;

            int kolumna = Grid.GetColumn(przycisk);
            int wiersz = Grid.GetRow(przycisk);
        }
    }
}
