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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab5
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PokedexPage : Page
    {
        string idioma = "Español";
        public PokedexPage()
        {
            this.InitializeComponent();
            mucCastform.ocultarElementos();
            mucPiplup.ocultarElementos();
            mucSableye.ocultarElementos();
            mucTeddiursa.ocultarElementos();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;

        }

        private void btnInfoOso_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoTeddiursa), idioma);
        }

        private void btnInfoCastform_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoCastform), idioma);
        }

        private void btnInfoPiplup_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoPiplup), idioma);
        }

        private void btnInfoSableye_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoSableye), idioma);
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

           tbSableye.FontSize = 30;
           tbCastform.FontSize = 30;
           tbPiplup.FontSize = 30;
           tbTeddiursa.FontSize = 30;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbSableye.FontSize = 22;
            tbCastform.FontSize = 22;
            tbPiplup.FontSize = 22;
            tbTeddiursa.FontSize = 22;
        }
    }
}
