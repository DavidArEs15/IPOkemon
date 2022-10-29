using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Lab5
{
    public sealed partial class MUCPokemonSableye : UserControl
    {
        DispatcherTimer dtReloj, ojosReloj;
        DispatcherTimer dtReloj2;
        static double vida_actual = 100.0;
        public double escudo_actual = 100.0;
        static double valor = 0.0;
        public Boolean turnoIA = false;
        public Boolean ataqueTerminado = false;
        public Boolean pocionUtilizada = false;
        public double vidaSableye
        {
            get { return vida_actual; }
            set { vida_actual = value; }
        }

        public ProgressBar barraVidaSableye
        {
            get { return BarraVida; }
            set { BarraVida = value; }
        }

        public MUCPokemonSableye()
        {
            this.InitializeComponent();
        }

        public void derrota()
        {
            desactivarBotones();
            ojosApagados();
            poner_boca_derrotado();
            var transform = this.pokemon.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.pokemon.RenderTransform = transform;
            }
            this.pokemon.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbQuieto = new DoubleAnimation
            {
                To = 0,
                From = 0,
                Duration = TimeSpan.FromMilliseconds(1),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            Storyboard.SetTarget(dbQuieto, this.pokemon);
            var axis = "X";
            Storyboard.SetTargetProperty(dbQuieto, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbQuieto = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbQuieto.Children.Add(dbQuieto);
            sbQuieto.Begin();
        }

        public void enfado()
        {
            desactivarBotones();
            ojosRojos();
            poner_boca_triste();
            salto_subida();

            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += decrementarBarraEscudo;
            dtReloj.Start();
            btnEnfado.Visibility = Visibility.Collapsed;
        }

        public void herido()
        {
            desactivarBotones();
            gdTiritas1.Visibility = Visibility.Visible;
            gdTiritas2.Visibility = Visibility.Visible;
            sbTiritas1.Begin();
            sbTiritas2.Begin();
            poner_boca_triste();
            Storyboard sbojoi_Rojo = (Storyboard)this.path_ojoizq.Resources["pupilaRojaIKey"];
            Storyboard sbojod_Rojo = (Storyboard)this.path_ojoder.Resources["pupilaRojaDKey"];
            Storyboard sbAroI_Rojo = (Storyboard)this.path_AroOjoI.Resources["aroOjoRojoIKey"];
            Storyboard sbAroD_Rojo = (Storyboard)this.path_AroOjoD.Resources["aroOjoRojoDKey"];
            Storyboard sbGemaPmedio_Rojo = (Storyboard)this.gemaPmedio.Resources["gemaPmedioRojaIKey"];
            Storyboard sbGemaParo_Rojo = (Storyboard)this.gemaParo.Resources["gemaParoRojaIKey"];
            sbojod_Rojo.Begin();
            sbojoi_Rojo.Begin();
            sbAroD_Rojo.Begin();
            sbAroI_Rojo.Begin();
            sbGemaPmedio_Rojo.Begin();
            sbGemaParo_Rojo.Begin();
            ojosReloj = new DispatcherTimer();
            ojosReloj.Interval = TimeSpan.FromMilliseconds(4000);
            ojosReloj.Tick += ojosNormales;
            ojosReloj.Start();
        }

        public void destello_espejismo()
        {
            desactivarBotones();
            gdEspejo.Visibility = Visibility.Visible;
            sbEspejo.Begin();
            ojosDorados();
            salto_subida();
            sacar_lengua();
        }

        public void aranazo_maligno()
        {
            pbEscudo.Value = escudo_actual - 50;
            escudo_actual -= 50;
            desactivarBotones();
            
            mov_aranazo();
            sbAranazoOp.Begin();
            poner_boca_triste();
            gdAranazo1.Visibility = Visibility.Visible;
            gdAranazo2.Visibility = Visibility.Visible;
            Storyboard sbojoi_Oscuro = (Storyboard)this.path_ojoizq.Resources["pupilaOscuraIKey"];
            Storyboard sbojod_Oscuro = (Storyboard)this.path_ojoder.Resources["pupilaOscuraDKey"];
            Storyboard sbAroI_Oscuro = (Storyboard)this.path_AroOjoI.Resources["aroOjoOscuroIKey"];
            Storyboard sbAroD_Oscuro = (Storyboard)this.path_AroOjoD.Resources["aroOjoOscuroDKey"];
            Storyboard sbGemaPmedio_Oscuro = (Storyboard)this.gemaPmedio.Resources["gemaPmedioOscuraIKey"];
            Storyboard sbGemaParo_Oscuro = (Storyboard)this.gemaParo.Resources["gemaParoOscuraIKey"];
            sbojod_Oscuro.Begin();
            sbojoi_Oscuro.Begin();
            sbAroD_Oscuro.Begin();
            sbAroI_Oscuro.Begin();
            sbGemaPmedio_Oscuro.Begin();
            sbGemaParo_Oscuro.Begin();
            ojosReloj = new DispatcherTimer();
            ojosReloj.Interval = TimeSpan.FromMilliseconds(2000);
            ojosReloj.Tick += ojosNormales;
            ojosReloj.Start();
            
            if (pbEscudo.Value <= 0.0)
            {
                dtReloj2 = new DispatcherTimer();
                dtReloj2.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj2.Tick += incrementarBarraEscudo;
                dtReloj2.Start();
            }
        }


        public void ojosDorados()
        {
            Storyboard sbojoi_Dorado = (Storyboard)this.path_ojoizq.Resources["pupilaDoradaIKey"];
            Storyboard sbojod_Dorado = (Storyboard)this.path_ojoder.Resources["pupilaDoradaDKey"];
            Storyboard sbAroI_Dorado = (Storyboard)this.path_AroOjoI.Resources["aroOjoDoradoIKey"];
            Storyboard sbAroD_Dorado = (Storyboard)this.path_AroOjoD.Resources["aroOjoDoradoDKey"];
            Storyboard sbGemaPmedio_Dorado = (Storyboard)this.gemaPmedio.Resources["gemaPmedioDoradaIKey"];
            Storyboard sbGemaParo_Dorado = (Storyboard)this.gemaParo.Resources["gemaParoDoradaIKey"];
            sbojod_Dorado.Begin();
            sbojoi_Dorado.Begin();
            sbAroD_Dorado.Begin();
            sbAroI_Dorado.Begin();
            sbGemaPmedio_Dorado.Begin();
            sbGemaParo_Dorado.Begin();
            ojosReloj = new DispatcherTimer();
            ojosReloj.Interval = TimeSpan.FromMilliseconds(4000);
            ojosReloj.Tick += ojosNormales;
            ojosReloj.Start();
        }

        public void ojosRojos()
        {
            Storyboard sbojoi_Rojo = (Storyboard)this.path_ojoizq.Resources["pupilaRojaIKey"];
            Storyboard sbojod_Rojo = (Storyboard)this.path_ojoder.Resources["pupilaRojaDKey"];
            Storyboard sbAroI_Rojo = (Storyboard)this.path_AroOjoI.Resources["aroOjoRojoIKey"];
            Storyboard sbAroD_Rojo = (Storyboard)this.path_AroOjoD.Resources["aroOjoRojoDKey"];
            Storyboard sbGemaPmedio_Rojo = (Storyboard)this.gemaPmedio.Resources["gemaPmedioRojaIKey"];
            Storyboard sbGemaParo_Rojo = (Storyboard)this.gemaParo.Resources["gemaParoRojaIKey"];
            sbojod_Rojo.Begin();
            sbojoi_Rojo.Begin();
            sbAroD_Rojo.Begin();
            sbAroI_Rojo.Begin();
            sbGemaPmedio_Rojo.Begin();
            sbGemaParo_Rojo.Begin();
            ojosReloj = new DispatcherTimer();
            ojosReloj.Interval = TimeSpan.FromMilliseconds(13000);
            ojosReloj.Tick += ojosNormales;
            ojosReloj.Start();
        }

        public void ojosApagados()
        {
            Storyboard sbojoi_Apagado = (Storyboard)this.path_ojoizq.Resources["pupilaApagadaIKey"];
            Storyboard sbojod_Apagado = (Storyboard)this.path_ojoder.Resources["pupilaApagadaDKey"];
            Storyboard sbAroI_Apagado = (Storyboard)this.path_AroOjoI.Resources["aroOjoApagadoIKey"];
            Storyboard sbAroD_Apagado = (Storyboard)this.path_AroOjoD.Resources["aroOjoApagadoDKey"];
            Storyboard sbGemaPmedio_Apagado = (Storyboard)this.gemaPmedio.Resources["gemaPmedioApagadaIKey"];
            Storyboard sbGemaParo_Apagado = (Storyboard)this.gemaParo.Resources["gemaParoApagadaIKey"];
            sbojod_Apagado.Begin();
            sbojoi_Apagado.Begin();
            sbAroD_Apagado.Begin();
            sbAroI_Apagado.Begin();
            sbGemaPmedio_Apagado.Begin();
            sbGemaParo_Apagado.Begin();
        }

        public void ojosNormales(object sender, object e)
        {
            Storyboard sbojoi_Normal = (Storyboard)this.path_ojoizq.Resources["pupilaNormalIKey"];
            Storyboard sbojod_Normal = (Storyboard)this.path_ojoder.Resources["pupilaNormalDKey"];
            Storyboard sbAroI_Normal = (Storyboard)this.path_AroOjoI.Resources["aroOjoNormalIKey"];
            Storyboard sbAroD_Normal = (Storyboard)this.path_AroOjoD.Resources["aroOjoNormalDKey"];
            Storyboard sbGemaPmedio_Normal = (Storyboard)this.gemaPmedio.Resources["gemaPmedioNormalIKey"];
            Storyboard sbGemaParo_Normal = (Storyboard)this.gemaParo.Resources["gemaParoNormalIKey"];
            sbojod_Normal.Begin();
            sbojoi_Normal.Begin();
            sbAroD_Normal.Begin();
            sbAroI_Normal.Begin();
            sbGemaPmedio_Normal.Begin();
            sbGemaParo_Normal.Begin();
            boca_normal();
            ojosReloj.Stop();
            pokemon.Margin = new Thickness(28, 0, 32, 0);
            bolaSombra.Visibility = Visibility.Collapsed;
            gdEspejo.Visibility = Visibility.Collapsed;
            gdTiritas1.Visibility = Visibility.Collapsed;
            gdTiritas2.Visibility = Visibility.Collapsed;
            gdAranazo1.Visibility = Visibility.Collapsed;
            gdAranazo2.Visibility = Visibility.Collapsed;
            ataqueTerminado = true;
        }

        public void ojosOscuros()
        {
            Storyboard sbojoi_Oscuro = (Storyboard)this.path_ojoizq.Resources["pupilaOscuraIKey"];
            Storyboard sbojod_Oscuro = (Storyboard)this.path_ojoder.Resources["pupilaOscuraDKey"];
            Storyboard sbAroI_Oscuro = (Storyboard)this.path_AroOjoI.Resources["aroOjoOscuroIKey"];
            Storyboard sbAroD_Oscuro = (Storyboard)this.path_AroOjoD.Resources["aroOjoOscuroDKey"];
            Storyboard sbGemaPmedio_Oscuro = (Storyboard)this.gemaPmedio.Resources["gemaPmedioOscuraIKey"];
            Storyboard sbGemaParo_Oscuro = (Storyboard)this.gemaParo.Resources["gemaParoOscuraIKey"];
            sbojod_Oscuro.Begin();
            sbojoi_Oscuro.Begin();
            sbAroD_Oscuro.Begin();
            sbAroI_Oscuro.Begin();
            sbGemaPmedio_Oscuro.Begin();
            sbGemaParo_Oscuro.Begin();
            ojosReloj = new DispatcherTimer();
            ojosReloj.Interval = TimeSpan.FromMilliseconds(3000);
            ojosReloj.Tick += ojosNormales;
            ojosReloj.Start();
        }

        public void sacar_lengua()
        {
            this.path_boca.Visibility = Visibility.Collapsed;
            this.grid_lengua.Visibility = Visibility.Visible;
            this.bocaDerrotado.Visibility = Visibility.Collapsed;
            this.boca_triste.Visibility = Visibility.Collapsed;
        }

        public void boca_normal()
        {
            this.path_boca.Visibility = Visibility.Visible;
            this.grid_lengua.Visibility = Visibility.Collapsed;
            this.bocaDerrotado.Visibility = Visibility.Collapsed;
            this.boca_triste.Visibility = Visibility.Collapsed;
        }


        public void poner_boca_triste()
        {
            this.boca_triste.Visibility = Visibility.Visible;
            this.grid_lengua.Visibility = Visibility.Collapsed;
            this.path_boca.Visibility = Visibility.Collapsed;
            this.bocaDerrotado.Visibility = Visibility.Collapsed;
        }

        public void poner_boca_derrotado()
        {
            this.boca_triste.Visibility = Visibility.Collapsed;
            this.grid_lengua.Visibility = Visibility.Collapsed;
            this.path_boca.Visibility = Visibility.Collapsed;
            this.bocaDerrotado.Visibility = Visibility.Visible;
        }

        public void salto_subida()
        {
            var transform = this.pokemon.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.pokemon.RenderTransform = transform;
            }
            this.pokemon.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbSalto = new DoubleAnimation
            {
                To = -100,
                From = 0,
                Duration = TimeSpan.FromMilliseconds(700),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbSalto, this.pokemon);
            var axis = "Y";
            Storyboard.SetTargetProperty(dbSalto, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbSalto = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbSalto.Children.Add(dbSalto);
            sbSalto.Begin();

        }



        public void mov_aranazo()
        {
            var transform = this.pokemon.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.pokemon.RenderTransform = transform;
            }
            this.pokemon.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbAranazo = new DoubleAnimation
            {
                To = 200,
                From = 0,
                Duration = TimeSpan.FromMilliseconds(700),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(1)
            };
            Storyboard.SetTarget(dbAranazo, this.pokemon);
            var axis = "X";
            Storyboard.SetTargetProperty(dbAranazo, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbAranazo = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbAranazo.Children.Add(dbAranazo);
            sbAranazo.Begin();
        }


        public void movimiento_lateral()
        {

            var transform = this.pokemon.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.pokemon.RenderTransform = transform;
            }
            this.pokemon.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbLateral = new DoubleAnimation
            {
                To = 0,
                From = 100,
                Duration = TimeSpan.FromMilliseconds(1500),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            Storyboard.SetTarget(dbLateral, this.pokemon);
            var axis = "X";
            Storyboard.SetTargetProperty(dbLateral, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbLateral = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbLateral.Children.Add(dbLateral);
            sbLateral.Begin();

        }

        public void ataqueBolaSombra()
        {
            desactivarBotones();
            bolaSombra.Visibility = Visibility.Visible;
            sbBolaSombraOp.Begin();
            sacar_lengua();
            ojosOscuros();
            var transform = this.bolaSombra.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.bolaSombra.RenderTransform = transform;
            }
            this.bolaSombra.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbBolaSombra = new DoubleAnimation
            {
                To = 800,
                From = 0,
                Duration = TimeSpan.FromMilliseconds(4000),
                AutoReverse = false,
                RepeatBehavior = new RepeatBehavior(1)
            };
            Storyboard.SetTarget(dbBolaSombra, this.bolaSombra);
            var axis = "Y";
            Storyboard.SetTargetProperty(dbBolaSombra, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbBolaSombra = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbBolaSombra.Children.Add(dbBolaSombra);
            sbBolaSombra.Begin();

            ojosReloj = new DispatcherTimer();
            ojosReloj.Interval = TimeSpan.FromMilliseconds(8000);
            ojosReloj.Tick += ojosNormales;
            ojosReloj.Start();
        }

        public void curar()
        {
            if (BarraVida.Value > 0.0)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += incrementarBarra;
                dtReloj.Start();
                btnPocion.Visibility = Visibility.Collapsed;
                pocionUtilizada = true;
                vida_actual = BarraVida.Value;
            }
        }

        public event EventHandler StatusUpdated4;
        public void btnPocion_Click(object sender, RoutedEventArgs e)
        {
            curar();
            if (this.StatusUpdated4 != null)
                this.StatusUpdated4(this, new EventArgs());
            
            turnoIA = true;
        }

        public void btnEnfado_Click(object sender, RoutedEventArgs e)
        {
            enfado();
            turnoIA = true;
            ataqueTerminado = true;
        }

        public event EventHandler StatusUpdated3;
        public void btnAtaqueDestello_Click(object sender, RoutedEventArgs e)
        {
            destello_espejismo();
            turnoIA = true;

            if (this.StatusUpdated3 != null)
                this.StatusUpdated3(this, new EventArgs());
            ataqueTerminado = true;
        }

        public event EventHandler StatusUpdated;
        public void btnBolaSombra_Click(object sender, RoutedEventArgs e)
        {
            ataqueBolaSombra();
            turnoIA = true;

            if (this.StatusUpdated != null)
                this.StatusUpdated(this, new EventArgs());

            ataqueTerminado = true;
        }

        public event EventHandler StatusUpdated2;
        public void btnArañazoMaligno_Click(object sender, RoutedEventArgs e)
        {
            aranazo_maligno();
            turnoIA = true;

            if (this.StatusUpdated2 != null)
                this.StatusUpdated2(this, new EventArgs());

            ataqueTerminado = true;
        }

        public void Herido(double valorpasado)
        {
            valor = valorpasado;
            vida_actual = this.BarraVida.Value;
            if (vida_actual - valor <= 0.0)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(80);
                dtReloj.Tick += decrementarBarraVida;
                dtReloj.Start();
                derrota();
                desactivarBotones();
            }
            else
            {
                herido();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(80);
                dtReloj.Tick += decrementarBarraVida;
                dtReloj.Start();
            }
        }

        public void btnDerrotado_Click(object sender, RoutedEventArgs e)
        {
            derrota();
        }

        public void incrementarBarra(object sender, object e)
        {
            
            if (vida_actual + 40.0 >= 100)
            {
                this.BarraVida.Value = 100.0;
            }
            else
            {
                this.BarraVida.Value = vida_actual + 40.0;
            }
            dtReloj.Stop();
        }

        public void decrementarBarraEscudo(object sender, object e)
        {
            this.pbEscudo.Value -= 1.3;
            if (pbEscudo.Value <= 0.0)
            {
                dtReloj.Stop();
            }
        }

        public void activarBotones()
        {
            btnAtaqueDestello.IsEnabled = true;
            btnBolaSombra.IsEnabled = true;
            if (escudo_actual > 0.0 && escudo_actual <= 100.0)
            {
                btnArañazoMaligno.IsEnabled = true;
            }
            if (pocionUtilizada == false)
            {
                btnPocion.IsEnabled = true;
            }
            tbTurno.Visibility = Visibility.Visible;
        }

        public void desactivarBotones()
        {
            btnAtaqueDestello.IsEnabled = false;
            btnBolaSombra.IsEnabled = false;
            btnArañazoMaligno.IsEnabled = false;
            btnEnfado.IsEnabled = false;
            btnPocion.IsEnabled = false;
            tbTurno.Visibility = Visibility.Collapsed;
        }

        public void ocultarElementos()
        {
            BarraVida.Visibility = Visibility.Collapsed;
            pbEscudo.Visibility = Visibility.Collapsed;
            imgVida.Visibility = Visibility.Collapsed;
            imgEscudo.Visibility = Visibility.Collapsed;
            btnPocion.Visibility = Visibility.Collapsed;
            btnArañazoMaligno.Visibility = Visibility.Collapsed;
            btnAtaqueDestello.Visibility = Visibility.Collapsed;
            btnBolaSombra.Visibility = Visibility.Collapsed;
            btnEnfado.Visibility = Visibility.Collapsed;
        }

        public void ocultarBotones()
        {
            btnPocion.Visibility = Visibility.Collapsed;
            btnArañazoMaligno.Visibility = Visibility.Collapsed;
            btnAtaqueDestello.Visibility = Visibility.Collapsed;
            btnBolaSombra.Visibility = Visibility.Collapsed;
            btnEnfado.Visibility = Visibility.Collapsed;
        }

        public async void pinSableye(object sender, PointerRoutedEventArgs e)
        {
            SecondaryTile myTile = new SecondaryTile("Favorito", "Dos", "Tres",
            new Uri("ms-appx:///imagenesSableye/sableyeNoF.png"),
            Windows.UI.StartScreen.TileSize.Square150x150);
            myTile.DisplayName = "Sableye";
            myTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await myTile.RequestCreateAsync();
        }

        public void NotificacionSubida(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
                .AddArgument("action", "Favoritos")
                .AddArgument("conversationId", 9813)
                .AddText("Sableye ha evolucionado")
                .AddText("Puedes ver más información en IPOkemon")
                .AddInlineImage(new Uri("ms-appx:///imagenesSableye/sableyeEvolucionNoF.png"))
                .AddAppLogoOverride(new Uri("ms-appx:///img/iconoAp.png"),
                        ToastGenericAppLogoCrop.Circle)
                .AddInputTextBox("tbName", "Ponle un nombre")
                .AddButton(new ToastButton()
                    .SetContent("Name")
                    .SetTextBoxId("tbName")
                    .SetImageUri(new Uri("Assets/outbutton.webp", UriKind.Relative))
                    .AddArgument("action", "reply")
                    .SetBackgroundActivation())
                .Show();
        }

        public void decrementarBarraVida(object sender, object e)
        {
            this.BarraVida.Value -= 1.0;
            if (BarraVida.Value == vida_actual - valor)
            {
                dtReloj.Stop();
            }
        }

        private void incrementarBarraEscudo(object sender, object e)
        {
            this.pbEscudo.Value += 0.4;
            if (pbEscudo.Value >= 100.0)
            {
                escudo_actual = 100.0;
                dtReloj2.Stop();
            }
        }

        public void ocultarImgAbajo()
        {
            imgChinchetaSableye.Visibility = Visibility.Collapsed;
            imgPiedraSableye.Visibility = Visibility.Collapsed;
        }
    }
}