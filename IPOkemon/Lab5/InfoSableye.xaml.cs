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
    public sealed partial class InfoSableye : Page
    {
        string idioma = "Español";
        public InfoSableye()
        {
            this.InitializeComponent();
        }

        private void tbSleccionar_SelectionChanged(object sender, RoutedEventArgs e)
        {

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
                tbNombreSableye.Text = "Nombre:";
                tbCategoriaSableye.Text = "Categoría:";
                tbCategoriaSableye2.Text = "Oscuridad";
                tbDescripcionSableye.Text = "Descripción:";
                tbDescripcionSableye2.Text = "Cuando las gemas de los ojos de estos Pokémon tan";
                tbDescripcionSableye3.Text = "temidos brillan de manera siniestra, están robándole el alma a alguien.";
                tbEvolucionSableye.Text = "Evolución:";
                tbGeneracionSableye.Text = "Generación:";
                tbGeneracionSableye2.Text = "Tercera";
                tbHabilidadSableye.Text = "Habilidad:";
                tbEvolucionSableye.Text = "Evolución:";
                tbHabilidadSableye2.Text = "Vista lince";
                tbRarezaSableye.Text = "Rareza:";
                tbRarezaSableye2.Text = "Épico";
                tbTipoSableye.Text = "Tipo:";
            }
            else if (idioma.Equals("English"))
            {
                tbNombreSableye.Text = "Name:";
                tbCategoriaSableye.Text = "Category:";
                tbCategoriaSableye2.Text = "Darkness";
                tbDescripcionSableye.Text = "Description:";
                tbDescripcionSableye2.Text = "When the gems in the eyes of these Pokémon so";
                tbDescripcionSableye3.Text = "feared shine sinisterly, they are stealing someone's soul.";
                tbEvolucionSableye.Text = "Evolution:";
                tbGeneracionSableye.Text = "Generation:";
                tbGeneracionSableye2.Text = "Third";
                tbHabilidadSableye.Text = "Skill:";
                tbEvolucionSableye.Text = "Evolution:";
                tbHabilidadSableye2.Text = "Lynx view";
                tbRarezaSableye.Text = "Rarely:";
                tbRarezaSableye2.Text = "Epic";
                tbTipoSableye.Text = "Type:";
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbNombreSableye.FontSize = 30;
            tbNombreSableye2.FontSize = 30;
            tbCategoriaSableye.FontSize = 30;
            tbCategoriaSableye2.FontSize = 30;
            tbDescripcionSableye.FontSize = 30;
            tbDescripcionSableye2.FontSize = 30;
            tbDescripcionSableye3.FontSize = 30;
            tbEvolucionSableye.FontSize = 30;
            tbGeneracionSableye.FontSize = 30;
            tbGeneracionSableye2.FontSize = 30;
            tbHabilidadSableye.FontSize = 30;
            tbEvolucionSableye.FontSize = 30;
            tbHabilidadSableye2.FontSize = 30;
            tbRarezaSableye.FontSize = 30;
            tbRarezaSableye2.FontSize = 30;
            tbTipoSableye.FontSize = 30;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbNombreSableye.FontSize = 25;
            tbNombreSableye2.FontSize = 25;
            tbCategoriaSableye.FontSize = 25;
            tbCategoriaSableye2.FontSize = 25;
            tbDescripcionSableye.FontSize = 25;
            tbDescripcionSableye2.FontSize = 25;
            tbDescripcionSableye3.FontSize = 25;
            tbEvolucionSableye.FontSize = 25;
            tbGeneracionSableye.FontSize = 25;
            tbGeneracionSableye2.FontSize = 25;
            tbHabilidadSableye.FontSize = 25;
            tbEvolucionSableye.FontSize = 25;
            tbHabilidadSableye2.FontSize = 25;
            tbRarezaSableye.FontSize = 25;
            tbRarezaSableye2.FontSize = 25;
            tbTipoSableye.FontSize = 25;
        }
    }
}
