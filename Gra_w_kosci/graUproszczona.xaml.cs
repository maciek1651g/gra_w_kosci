using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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
        int[] wartosciKosci = new int[5];
        int[] kosciDoRzucenia = new[] { 0, 0, 0, 0, 0 };
        int[,] punktyGraczy;
        int aktualnyGracz = 0;
        int kolejka=1;

        public graUproszczona()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                liczbaGraczy = Convert.ToInt32(e.Parameter);
            }
            base.OnNavigatedTo(e);
            Start();
        }

        private void Start()
        {
            switch(liczbaGraczy)
            {
                case 1:
                    gracz1.Visibility = Visibility.Visible;
                    komputer.Visibility = Visibility.Visible;
                    break;
                case 2:
                    gracz1.Visibility = Visibility.Visible;
                    gracz2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    gracz1.Visibility = Visibility.Visible;
                    gracz2.Visibility = Visibility.Visible;
                    gracz3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    gracz1.Visibility = Visibility.Visible;
                    gracz2.Visibility = Visibility.Visible;
                    gracz3.Visibility = Visibility.Visible;
                    gracz4.Visibility = Visibility.Visible;
                    break;
            }
            punktyGraczy = new int[liczbaGraczy, 2];
            aktualnyGracz = 0;
            kolejka = 1;
            gracz1.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void KostkaKliknieta(object sender, RoutedEventArgs e)
        {
            if (rzut >= 1 && rzut <= 2)
            {
                var przycisk = (Button)sender;
                int numerKostki = przycisk.Name[przycisk.Name.Length - 1] - '0';

                if (kosciDoRzucenia[numerKostki - 1] == 0)
                {
                    kosciDoRzucenia[numerKostki - 1] = 1;
                    przycisk.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    kosciDoRzucenia[numerKostki - 1] = 0;
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
                for (int i = 0; i < kosciDoRzucenia.Length; i++)
                {
                    kosciDoRzucenia[i] = 1;
                }

                Losowanko(kosciDoRzucenia, wartosciKosci);

                WyswietlKosci(kosciDoRzucenia, wartosciKosci);

                przycisk.Content = "Przerzuć kości";
            }
            else if(rzut==1)
            {
                Losowanko(kosciDoRzucenia, wartosciKosci);

                WyswietlKosci(kosciDoRzucenia, wartosciKosci);
            }
            else if(rzut==2)
            {
                Losowanko(kosciDoRzucenia, wartosciKosci);

                WyswietlKosci(kosciDoRzucenia, wartosciKosci);

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
            var messageDialog = new MessageDialog("Czy na pewno chcesz przerwać aktualną grę?");
            messageDialog.Commands.Add(new UICommand("Tak", new UICommandInvokedHandler(this.NowaGra2)));
            messageDialog.Commands.Add(new UICommand("Nie"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            messageDialog.ShowAsync();
        }
        private void MenuGlowne(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Czy na pewno chcesz przerwać aktualną grę?");
            messageDialog.Commands.Add(new UICommand("Tak", new UICommandInvokedHandler(this.StronaGlowna)));
            messageDialog.Commands.Add(new UICommand("Nie"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            messageDialog.ShowAsync();
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Czy na pewno chcesz przerwać aktualną grę?");
            messageDialog.Commands.Add(new UICommand("Tak", new UICommandInvokedHandler(this.WyjdzZGry)));
            messageDialog.Commands.Add(new UICommand("Nie"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            messageDialog.ShowAsync();
        }

        private void PodajWynik(object sender, RoutedEventArgs e)
        {
            var przycisk = (Button)sender;
            FrameworkElement siatka = (FrameworkElement)przycisk.Parent;
            int kolumna = Grid.GetColumn(siatka);
            int wiersz = Grid.GetRow(przycisk);

            if (rzut <= 0 || kolumna != aktualnyGracz)
                return;

            int punkty=0;
            bool flaga = false;

            if(punktyGraczy[aktualnyGracz,1]<63)
            {
                flaga = true;
            }

            switch(wiersz)
            {
                case 1:
                    punkty = LiczeniePunktow.PunktyZaKonkretneKostki(wartosciKosci,1);
                    punktyGraczy[aktualnyGracz,1] += punkty;
                    break;
                case 2:
                    punkty = LiczeniePunktow.PunktyZaKonkretneKostki(wartosciKosci, 2);
                    punktyGraczy[aktualnyGracz, 1] += punkty;
                    break;
                case 3:
                    punkty = LiczeniePunktow.PunktyZaKonkretneKostki(wartosciKosci, 3);
                    punktyGraczy[aktualnyGracz, 1] += punkty;
                    break;
                case 4:
                    punkty = LiczeniePunktow.PunktyZaKonkretneKostki(wartosciKosci, 4);
                    punktyGraczy[aktualnyGracz, 1] += punkty;
                    break;
                case 5:
                    punkty = LiczeniePunktow.PunktyZaKonkretneKostki(wartosciKosci, 5);
                    punktyGraczy[aktualnyGracz, 1] += punkty;
                    break;
                case 6:
                    punkty = LiczeniePunktow.PunktyZaKonkretneKostki(wartosciKosci, 6);
                    punktyGraczy[aktualnyGracz, 1] += punkty;
                    break;
                case 8:
                    punkty = LiczeniePunktow.TrojkaKosci(wartosciKosci);
                    break;
                case 9:
                    punkty = LiczeniePunktow.CzworkaKosci(wartosciKosci);
                    break;
                case 10:
                    punkty = LiczeniePunktow.Full(wartosciKosci);
                    break;
                case 11:
                    punkty = LiczeniePunktow.MalyStrit(wartosciKosci);
                    break;
                case 12:
                    punkty = LiczeniePunktow.DuzyStrit(wartosciKosci);
                    break;
                case 13:
                    punkty = LiczeniePunktow.Poker(wartosciKosci);
                    break;
                case 14:
                    punkty = LiczeniePunktow.Szansa(wartosciKosci);
                    break;
            }

            if (punktyGraczy[aktualnyGracz, 1] >= 63 && flaga)
            {
                punktyGraczy[aktualnyGracz, 0] += 35;

                switch (aktualnyGracz+1)
                {
                    case 1:
                        bonusGracz1.Text = "35";
                        break;
                    case 2:
                        bonusGracz2.Text = "35";
                        break;
                    case 3:
                        bonusGracz3.Text = "35";
                        break;
                    case 4:
                        bonusGracz4.Text = "35";
                        break;
                }
            }

            punktyGraczy[aktualnyGracz, 0] += punkty;

            switch (aktualnyGracz+1)
            {
                case 1:
                    wynikGracz1.Text = punktyGraczy[aktualnyGracz, 0].ToString();
                    break;
                case 2:
                    wynikGracz2.Text = punktyGraczy[aktualnyGracz, 0].ToString();
                    break;
                case 3:
                    wynikGracz3.Text = punktyGraczy[aktualnyGracz, 0].ToString();
                    break;
                case 4:
                    wynikGracz4.Text = punktyGraczy[aktualnyGracz, 0].ToString();
                    break;
            }
            
            przycisk.Content = punkty;
            przycisk.IsEnabled = false;
            NastepnyGracz();
        }

        private void NastepnyGracz()
        {
            if(liczbaGraczy==1)
            {
                //ruch komputera
            }
            else
            {
                switch(aktualnyGracz)
                {
                    case 0:
                        gracz1.BorderBrush = new SolidColorBrush(Colors.Black);
                        break;
                    case 1:
                        gracz2.BorderBrush = new SolidColorBrush(Colors.Black);
                        break;
                    case 2:
                        gracz3.BorderBrush = new SolidColorBrush(Colors.Black);
                        break;
                    case 3:
                        gracz4.BorderBrush = new SolidColorBrush(Colors.Black);
                        break;
                }

                aktualnyGracz = (aktualnyGracz + 1) % liczbaGraczy;

                if (aktualnyGracz == 0)
                    kolejka++;

                if(kolejka==14)
                {
                    //koniec gry
                    int max = punktyGraczy[0, 0];
                    int[] wygraniGracze = new int[liczbaGraczy];
                    wygraniGracze[0]=1;

                    for (int i = 1; i < liczbaGraczy; i++)
                    {
                        if(max<=punktyGraczy[i,0])
                        {
                            if(max == punktyGraczy[i, 0])
                            {
                                wygraniGracze[i] = 1;
                            }
                            else
                            {
                                wygraniGracze = new int[liczbaGraczy];
                                wygraniGracze[i] = 1;
                                max = punktyGraczy[i, 0];
                            }
                        }
                    }

                    string komunikat = "Wygrał ";
                    bool flaga = false;
                    for (int i = 0; i < wygraniGracze.Length; i++)
                    {
                        if(wygraniGracze[i]==1)
                        {
                            if(flaga)
                            {
                                komunikat = komunikat + (" i Gracz " + (i + 1));
                            }
                            else
                            {
                                komunikat = komunikat + ("Gracz " + (i + 1));
                                flaga = true;
                            }
                        }
                    }
                    komunikat = komunikat + ".";

                    var messageDialog = new MessageDialog(komunikat);
                    messageDialog.Commands.Add(new UICommand("Nowa Gra", new UICommandInvokedHandler(this.NowaGra2)));
                    messageDialog.Commands.Add(new UICommand("Wyjdź z gry", new UICommandInvokedHandler(this.WyjdzZGry)));
                    messageDialog.DefaultCommandIndex = 0;
                    messageDialog.CancelCommandIndex = 1;
                    messageDialog.ShowAsync();
                }
                else
                {
                    switch (aktualnyGracz)
                    {
                        case 0:
                            gracz1.BorderBrush = new SolidColorBrush(Colors.Red);
                            break;
                        case 1:
                            gracz2.BorderBrush = new SolidColorBrush(Colors.Red);
                            break;
                        case 2:
                            gracz3.BorderBrush = new SolidColorBrush(Colors.Red);
                            break;
                        case 3:
                            gracz4.BorderBrush = new SolidColorBrush(Colors.Red);
                            break;
                    }
                }
            }

            wartosciKosci = new int[5];
            kosciDoRzucenia = new[] { 1, 1, 1, 1, 1 };
            WyswietlKosci(kosciDoRzucenia,wartosciKosci);
            rzutKoscmi.IsEnabled = true;
            rzut = 0;
        }

        private void NowaGra2(IUICommand command)
        {
            this.Frame.Navigate(typeof(liczbaGraczy));
        }

        private void WyjdzZGry(IUICommand command)
        {
            App.Current.Exit();
        }

        private void StronaGlowna(IUICommand command)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
