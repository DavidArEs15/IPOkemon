using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Lab5
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string idioma = "Español";
        String selectedLanguage = "Español";
        public MainPage()
        {
            this.InitializeComponent();
            cbIdioma.SelectedIndex = 0;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                    new AdaptiveText()
                                    {
                                        Text = "Un proyecto de IPO2",
                                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                                    }
                             }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "Version 1.0",
                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un Proyecto de IPO2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                    HintWrap = true,
                                }
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un Proyecto de IPO2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },
                }
            };
            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);
        }

        private void btnPokedex_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(PokedexPage), idioma);
        }

        public void btnCombate_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(CombatePokemon), idioma);
        }

       private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), idioma);
        }

        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (fmMain.BackStack.Any())
            {
                fmMain.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(PokemonCombateIndividual), idioma);
        }

        private void btnAyudaClick(object sender, PointerRoutedEventArgs e)
        {
            fmMain.Navigate(typeof(AyudaMain), idioma);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;
            if (idioma.Equals("Español"))
            {
                cbIdioma.SelectedIndex = 0;
            }
            else if (idioma.Equals("English"))
            {
                cbIdioma.SelectedIndex = 1;
            }
        }

        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int cbi = cbIdioma.SelectedIndex;
            switch (cbi)
            {
                case 0:
                    idioma = "Español";
                    tbIdiomaInicio.Text = "Español";
                    break;
                case 1:
                    idioma = "English";
                    tbIdiomaInicio.Text = "English";
                    break;
            }

            selectedLanguage = (string)cbIdioma.SelectedItem;
            tbIdiomaInicio.Text = selectedLanguage;
            if (tbIdiomaInicio.Text == "Español")
            {
                btnCombate.Content = "Combate Multijugador";
                btnInicio.Content = "Inicio";
                btnCombateIndividual.Content = "Combate Individual";
                tbCreadores.Text = "Creadores";
                tbSeleccionarIdioma.Visibility = Visibility.Visible;
                tbSeleccionarIdiomaIngles.Visibility = Visibility.Collapsed;
                imgSpanish.Visibility = Visibility.Visible;
                imgEnglish.Visibility = Visibility.Collapsed;

            }
            else if (tbIdiomaInicio.Text == "English")
            {
                btnCombate.Content = "Multiplayer Combat";
                btnInicio.Content = "Home";
                btnCombateIndividual.Content = "One Player";
                tbCreadores.Text = "Creators";
                tbSeleccionarIdioma.Visibility = Visibility.Collapsed;
                tbSeleccionarIdiomaIngles.Visibility = Visibility.Visible;
                imgSpanish.Visibility = Visibility.Collapsed;
                imgEnglish.Visibility = Visibility.Visible;

            }
        }

        private void cbIdioma_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void cbIdioma_Loaded(object sender, RoutedEventArgs e)
        {
            cbIdioma.Items.Add("Español");
            cbIdioma.Items.Add("English");
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbSeleccionarIdioma.FontSize = 20;
            tbSeleccionarIdiomaIngles.FontSize = 20;
            cbIdioma.FontSize = 19;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbSeleccionarIdioma.FontSize = 15;
            tbSeleccionarIdiomaIngles.FontSize = 15;
            cbIdioma.FontSize = 14;
        }

        private void cbIdioma_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            
        }

        private void btnManualClick(object sender, PointerRoutedEventArgs e)
        {
            fmMain.Navigate(typeof(ManualJuego), idioma);
        }
    }
}
