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
    public sealed partial class AyudaMain : Page
    {
        string idioma = "Español";
        public AyudaMain()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (idioma.Equals("Español"))
            {
                imgTextoAyuda.Visibility = Visibility.Visible;
                tbMultijugadorAyuda.Visibility = Visibility.Visible;
                tbIndividualAyuda.Visibility = Visibility.Visible;
                imgMultijugador.Visibility = Visibility.Visible;
                imgIndividual.Visibility = Visibility.Visible;
                tbPokedexAyuda.Visibility = Visibility.Visible;

                imgTextHelp.Visibility = Visibility.Collapsed;
                tbMultijugadorAyudaIngles.Visibility = Visibility.Collapsed;
                tbIndividualAyudaIngles.Visibility = Visibility.Collapsed;
                imgMultiplayer.Visibility = Visibility.Collapsed;
                imgOnePlayer.Visibility = Visibility.Collapsed;
                tbPokedexAyudaIngles.Visibility = Visibility.Collapsed;
            }
            else if (idioma.Equals("English"))
            {
                imgTextoAyuda.Visibility = Visibility.Collapsed;
                tbMultijugadorAyuda.Visibility = Visibility.Collapsed;
                tbIndividualAyuda.Visibility = Visibility.Collapsed;
                imgMultijugador.Visibility = Visibility.Collapsed;
                imgIndividual.Visibility = Visibility.Collapsed;
                tbPokedexAyuda.Visibility = Visibility.Collapsed;

                imgTextHelp.Visibility = Visibility.Visible;
                tbMultijugadorAyudaIngles.Visibility = Visibility.Visible;
                tbIndividualAyudaIngles.Visibility = Visibility.Visible;
                imgMultiplayer.Visibility = Visibility.Visible;
                imgOnePlayer.Visibility = Visibility.Visible;
                tbPokedexAyudaIngles.Visibility = Visibility.Visible;
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbMultijugadorAyuda.FontSize = 21;
            tbIndividualAyuda.FontSize = 21;
            tbPokedexAyuda.FontSize = 21;

            tbMultijugadorAyudaIngles.FontSize = 21;
            tbIndividualAyudaIngles.FontSize = 21;
            tbPokedexAyudaIngles.FontSize = 21;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbMultijugadorAyuda.FontSize = 17;
            tbIndividualAyuda.FontSize = 17;
            tbPokedexAyuda.FontSize = 17;

            tbMultijugadorAyudaIngles.FontSize = 17;
            tbIndividualAyudaIngles.FontSize = 17;
            tbPokedexAyudaIngles.FontSize = 17;
        }
    }
}
