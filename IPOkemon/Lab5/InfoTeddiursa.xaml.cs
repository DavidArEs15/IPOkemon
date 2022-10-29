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
    public sealed partial class InfoTeddiursa : Page
    {
        string idioma = "Español";
        public InfoTeddiursa()
        {
            this.InitializeComponent();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PokedexPage), idioma);
        }

        private void tbGeneracion2_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (idioma.Equals("Español"))
            {
                tbNombreTeddiursa.Text = "Nombre:";
                tbCategoriaTeddiursa.Text = "Categoría:";
                tbCategoriaTeddiursa2.Text = "Osito";
                tbDescripcionTeddiursa.Text = "Descripción:";
                tbDescripcionTeddiursa2.Text = "Si encuentra miel, brillará la marca de su frente. Antes de ";
                tbDescripcionTeddiursa3.Text = "que la comida escasee en invierno, tiene por costumbre ocultar comida en lugares secretos.";
                tbEvolucionTeddiursa.Text = "Evolución:";
                tbGeneracionTeddiursa.Text = "Generación:";
                tbGeneracionTeddiursa2.Text = "Segunda";
                tbHabilidadTeddiursa.Text = "Habilidad:";
                tbEvolucionTeddiursa.Text = "Evolución:";
                tbHabilidadTeddiursa2.Text = "Pies rápidos";
                tbRarezaTeddiursa.Text = "Rareza:";
                tbRarezaTeddiursa2.Text = "Normal";
                tbTipoTeddiursa.Text = "Tipo:";
            }
            else if (idioma.Equals("English"))
            {
                tbNombreTeddiursa.Text = "Name:";
                tbCategoriaTeddiursa.Text = "Category:";
                tbCategoriaTeddiursa2.Text = "Bear";
                tbDescripcionTeddiursa.Text = "Description:";
                tbDescripcionTeddiursa2.Text = "If he finds honey, the mark on his forehead will glow. ";
                tbDescripcionTeddiursa3.Text = "Before food becomes scarce in winter, they have a habit of hiding food in secret places.";
                tbEvolucionTeddiursa.Text = "Evolution:";
                tbGeneracionTeddiursa.Text = "Generation:";
                tbGeneracionTeddiursa2.Text = "Second";
                tbHabilidadTeddiursa.Text = "Skill:";
                tbEvolucionTeddiursa.Text = "Evolution:";
                tbHabilidadTeddiursa2.Text = "Fast feet";
                tbRarezaTeddiursa.Text = "Rarely:";
                tbRarezaTeddiursa2.Text = "Normal";
                tbTipoTeddiursa.Text = "Type:";
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbNombreTeddiursa.FontSize = 30;
            tbNombreTeddiursa2.FontSize = 30;
            tbCategoriaTeddiursa.FontSize = 30;
            tbCategoriaTeddiursa2.FontSize = 30;
            tbDescripcionTeddiursa.FontSize = 30;
            tbDescripcionTeddiursa2.FontSize = 30;
            tbDescripcionTeddiursa3.FontSize = 30;
            tbEvolucionTeddiursa.FontSize = 30;
            tbGeneracionTeddiursa.FontSize = 30;
            tbGeneracionTeddiursa2.FontSize = 30;
            tbHabilidadTeddiursa.FontSize = 30;
            tbEvolucionTeddiursa.FontSize = 30;
            tbHabilidadTeddiursa2.FontSize = 30;
            tbRarezaTeddiursa.FontSize = 30;
            tbRarezaTeddiursa2.FontSize = 30;
            tbTipoTeddiursa.FontSize = 30;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbNombreTeddiursa.FontSize = 25;
            tbNombreTeddiursa2.FontSize = 25;
            tbCategoriaTeddiursa.FontSize = 25;
            tbCategoriaTeddiursa2.FontSize = 25;
            tbDescripcionTeddiursa.FontSize = 25;
            tbDescripcionTeddiursa2.FontSize = 25;
            tbDescripcionTeddiursa3.FontSize = 25;
            tbEvolucionTeddiursa.FontSize = 25;
            tbGeneracionTeddiursa.FontSize = 25;
            tbGeneracionTeddiursa2.FontSize = 25;
            tbHabilidadTeddiursa.FontSize = 25;
            tbEvolucionTeddiursa.FontSize = 25;
            tbHabilidadTeddiursa2.FontSize = 25;
            tbRarezaTeddiursa.FontSize = 25;
            tbRarezaTeddiursa2.FontSize = 25;
            tbTipoTeddiursa.FontSize = 25;
        }
    }
}
