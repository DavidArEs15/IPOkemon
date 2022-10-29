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
    public sealed partial class InfoPiplup : Page
    {
        string idioma = "Español";
        public InfoPiplup()
        {
            this.InitializeComponent();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PokedexPage), idioma);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (idioma.Equals("Español"))
            {
                tbNombrePiplup.Text = "Nombre:";
                tbCategoriaPiplup.Text = "Categoría:";
                tbCategoriaPiplup2.Text = "Pingüino";
                tbDescripcionPiplup.Text = "Descripción:";
                tbDescripcionPiplup2.Text = "Vive en las costas de los países nórdicos. Es un gran nadador";
                tbDescripcionPiplup3.Text = "y puede bucear más de 10 minutos.";
                tbEvolucionPiplup.Text = "Evolución:";
                tbGeneracionPiplup.Text = "Generación:";
                tbGeneracionPiplup2.Text = "Cuarta";
                tbHabilidadPiplup.Text = "Habilidad:";
                tbEvolucionPiplup.Text = "Evolución:";
                tbHabilidadPiplup2.Text = "Torrente";
                tbRarezaPiplup.Text = "Rareza:";
                tbRarezaPiplup2.Text = "Normal";
                tbTipoPiplup.Text = "Tipo:";
            }
            else if (idioma.Equals("English"))
            {
                tbNombrePiplup.Text = "Name:";
                tbCategoriaPiplup.Text = "Category:";
                tbCategoriaPiplup2.Text = "Penguin";
                tbDescripcionPiplup.Text = "Description:";
                tbDescripcionPiplup2.Text = "It lives on the coasts of the Nordic countries. He is a great ";
                tbDescripcionPiplup3.Text = "swimmer and can dive more than 10 minutes.";
                tbEvolucionPiplup.Text = "Evolution:";
                tbGeneracionPiplup.Text = "Generation:";
                tbGeneracionPiplup2.Text = "Fourth";
                tbHabilidadPiplup.Text = "Skill:";
                tbEvolucionPiplup.Text = "Evolution:";
                tbHabilidadPiplup2.Text = "Torrent";
                tbRarezaPiplup.Text = "Rarely:";
                tbRarezaPiplup2.Text = "Normal";
                tbTipoPiplup.Text = "Type:";
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbNombrePiplup.FontSize = 30;
            tbNombrePiplup2.FontSize = 30;
            tbCategoriaPiplup.FontSize = 30;
            tbCategoriaPiplup2.FontSize = 30;
            tbDescripcionPiplup.FontSize = 30;
            tbDescripcionPiplup2.FontSize = 30;
            tbDescripcionPiplup3.FontSize = 30;
            tbEvolucionPiplup.FontSize = 30;
            tbGeneracionPiplup.FontSize = 30;
            tbGeneracionPiplup2.FontSize = 30;
            tbHabilidadPiplup.FontSize = 30;
            tbEvolucionPiplup.FontSize = 30;
            tbHabilidadPiplup2.FontSize = 30;
            tbRarezaPiplup.FontSize = 30;
            tbRarezaPiplup2.FontSize = 30;
            tbTipoPiplup.FontSize = 30;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbNombrePiplup.FontSize = 25;
            tbNombrePiplup2.FontSize = 25;
            tbCategoriaPiplup.FontSize = 25;
            tbCategoriaPiplup2.FontSize = 25;
            tbDescripcionPiplup.FontSize = 25;
            tbDescripcionPiplup2.FontSize = 25;
            tbDescripcionPiplup3.FontSize = 25;
            tbEvolucionPiplup.FontSize = 25;
            tbGeneracionPiplup.FontSize = 25;
            tbGeneracionPiplup2.FontSize = 25;
            tbHabilidadPiplup.FontSize = 25;
            tbEvolucionPiplup.FontSize = 25;
            tbHabilidadPiplup2.FontSize = 25;
            tbRarezaPiplup.FontSize = 25;
            tbRarezaPiplup2.FontSize = 25;
            tbTipoPiplup.FontSize = 25;
        }
    }
}
