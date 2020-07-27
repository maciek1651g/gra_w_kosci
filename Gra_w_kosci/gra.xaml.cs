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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gra_w_kosci
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class gra : Page
    {
        int liczbaGraczy = 1;
        int typGry = 0;

        public gra()
        {
            this.InitializeComponent();

            if(typGry==0)
            {
                Uproszczony();
            }
            else
            {
                Pelny();
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int typGry = 10;

            if(e.Parameter!=null)
            {
                typGry = Convert.ToInt32(e.Parameter);
                liczbaGraczy = typGry / 10;
                this.typGry = typGry % 10;
            }

            base.OnNavigatedTo(e);
        }

        private void Uproszczony()
        {
            var grid = new Grid();

            Grid.SetColumn(grid, 0);
            Grid.SetColumn(grid, 0);


            for (int i = 0; i < 16; i++)
            {
                Grid.SetRow(grid, i);
            }

            this.UpdateLayout();
        }

        private void Pelny()
        {

        }
    }
}
