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
    public sealed partial class InfoCastform : Page
    {
        string idioma = "Español";
        public InfoCastform()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PokedexPage), idioma);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (idioma.Equals("Español"))
            {
                tbNombreCastform.Text = "Nombre:";
                tbCategoriaCastform.Text = "Categoría:";
                tbCategoriaCastform2.Text = "Clima";
                tbDescripcionCastform.Text = "Descripción:";
                tbDescripcionCastform2.Text = "El tiempo atmosférico cambia tanto su aspecto como su";
                tbDescripcionCastform3.Text = "estado de ánimo. Cuanto más arrecia, más agresivo se vuelve.";
                tbEvolucionCastform.Text = "Evolución:";
                tbGeneracionCastform.Text = "Generación:";
                tbGeneracionCastform2.Text = "Tercera";
                tbHabilidadCastform.Text = "Habilidad:";
                tbEvolucionCastform.Text = "Evolución:";
                tbHabilidadCastform2.Text = "Predicción";
                tbRarezaCastform.Text = "Rareza:";
                tbRarezaCastform2.Text = "Legendario";
                tbTipoCastform.Text = "Tipo:";
            }
            else if (idioma.Equals("English"))
            {
                tbNombreCastform.Text = "Name:";
                tbCategoriaCastform.Text = "Category:";
                tbCategoriaCastform2.Text = "Weather";
                tbDescripcionCastform.Text = "Description:";
                tbDescripcionCastform2.Text = "The weather changes both its appearance and its";
                tbDescripcionCastform3.Text = "state of mind. The harder it gets, the more aggressive it becomes.";
                tbEvolucionCastform.Text = "Evolution:";
                tbGeneracionCastform.Text = "Generation:";
                tbGeneracionCastform2.Text = "Third";
                tbHabilidadCastform.Text = "Skill:";
                tbEvolucionCastform.Text = "Evolution:";
                tbHabilidadCastform2.Text = "Prediction";
                tbRarezaCastform.Text = "Rarely:";
                tbRarezaCastform2.Text = "Legendary";
                tbTipoCastform.Text = "Type:";
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbNombreCastform.FontSize = 30;
            tbNombreCastform2.FontSize = 30;
            tbCategoriaCastform.FontSize = 30;
            tbCategoriaCastform2.FontSize = 30;
            tbDescripcionCastform.FontSize = 30;
            tbDescripcionCastform2.FontSize = 30;
            tbDescripcionCastform3.FontSize = 30;
            tbEvolucionCastform.FontSize = 30;
            tbGeneracionCastform.FontSize = 30;
            tbGeneracionCastform2.FontSize = 30;
            tbHabilidadCastform.FontSize = 30;
            tbEvolucionCastform.FontSize = 30;
            tbHabilidadCastform2.FontSize = 30;
            tbRarezaCastform.FontSize = 30;
            tbRarezaCastform2.FontSize = 30;
            tbTipoCastform.FontSize = 30;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbNombreCastform.FontSize = 25;
            tbNombreCastform2.FontSize = 25;
            tbCategoriaCastform.FontSize = 25;
            tbCategoriaCastform2.FontSize = 25;
            tbDescripcionCastform.FontSize = 25;
            tbDescripcionCastform2.FontSize = 25;
            tbDescripcionCastform3.FontSize = 25;
            tbEvolucionCastform.FontSize = 25;
            tbGeneracionCastform.FontSize = 25;
            tbGeneracionCastform2.FontSize = 25;
            tbHabilidadCastform.FontSize = 25;
            tbEvolucionCastform.FontSize = 25;
            tbHabilidadCastform2.FontSize = 25;
            tbRarezaCastform.FontSize = 25;
            tbRarezaCastform2.FontSize = 25;
            tbTipoCastform.FontSize = 25;
        }
    }
}
