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
    public sealed partial class MUCPinguino : UserControl
    {
        DispatcherTimer dtReloj_Vida;
        DispatcherTimer dtReloj_Escudo;
        DispatcherTimer dtReloj_bomba;
        static double vida_actual = 100.0;
        static double pbVida2 = 100.0;
        static double valor = 0.0;
        public Boolean turnoIA = false;
        public Boolean pocionUtilizada = false;
        public double escudo_actual = 100.0;
        DispatcherTimer dtReloj2;

        public double pVida = pbVida2;

        public double vidaPiplup
        {
            get { return this.pbVida.Value; }
            set { this.pbVida.Value = value; }
        }

        public ProgressBar barraVidaPiplup
        {
            get { return pbVida; }
            set { pbVida = value; }
        }

        public MUCPinguino()
        {
            this.InitializeComponent();
            ojosVerdes_Contento();
            abrirBoca();
            movCabeza();
            movimientoPieIzq();
            movimientoPieDer();
            
        }

        private void ojosVerdes_Contento()
        {
            Storyboard sbOjoIzq = (Storyboard)this.ojoIzq.Resources["sbColorOjoIzqKey"];
            Storyboard sbOjoDer = (Storyboard)this.ojoDer.Resources["sbColorOjoDerKey"];
            sbOjoIzq.Begin();
            sbOjoDer.Begin();
        }

        private void ojosMorados_Herido()
        {
            Storyboard sbColorOjoIzqMORADO = (Storyboard)this.ojoIzq.Resources["sbColorOjoIzqMORADOKey"];
            Storyboard sbColorOjoDerMORADO = (Storyboard)this.ojoDer.Resources["sbColorOjoDerMORADOKey"];
            sbColorOjoIzqMORADO.Begin();
            sbColorOjoDerMORADO.Begin();
        }

        private void cambioColorPokemonDerrotado()
        {
            Storyboard sbCabAzulOsc = (Storyboard)this.cabAzulOsc.Resources["sbColorCabAzulOscKey"];
            Storyboard sbCuelloAzulOsc = (Storyboard)this.cuelloAzulOsc.Resources["sbColorCuelloAzulOscKey"];
            Storyboard sbColorCuerpo = (Storyboard)this.cuerpo.Resources["sbColorCuerpoKey"];
            Storyboard sbColorCabAzulClaro = (Storyboard)this.cabAzulClaro.Resources["sbColorCabAzulClaroKey"];
            Storyboard sbColorArribaBoca = (Storyboard)this.arribaBoca.Resources["sbColorArribaBocaKey"];
            Storyboard sbColorAbajoBoca = (Storyboard)this.abajoBoca.Resources["sbColorAbajoBocaKey"];
            Storyboard sbColorPieIzq = (Storyboard)this.pieIzq.Resources["sbColorPieIzqKey"];
            Storyboard sbColorPieDer = (Storyboard)this.pieDer.Resources["sbColorPieDerKey"];
            sbCabAzulOsc.Begin();
            sbCuelloAzulOsc.Begin();
            sbColorCuerpo.Begin();
            sbColorCabAzulClaro.Begin();
            sbColorArribaBoca.Begin();
            sbColorAbajoBoca.Begin();
            sbColorPieIzq.Begin();
            sbColorPieDer.Begin();
        }


        private void pokemonHerido()
        {
            vbTiritas1.Visibility = Visibility.Visible;
            vbTiritas2.Visibility = Visibility.Visible;
            vbTiritas3.Visibility = Visibility.Visible;
            sbTiritas1.Begin();
            sbTiritas2.Begin();
            sbTiritas3.Begin();
        }

        private void quitarTiritas()
        {
            vbTiritas1.Visibility = Visibility.Collapsed;
            vbTiritas2.Visibility = Visibility.Collapsed;
            vbTiritas3.Visibility = Visibility.Collapsed;
        }

        private void quitarBomba(object sender, object e)
        {
            bomba.Visibility = Visibility.Collapsed;
            dtReloj_bomba.Stop();
        }



        private void abrirBoca()
        {
            Storyboard sbAbrirBoca = (Storyboard)this.Resources["boca"];
            sbAbrirBoca.Begin();
        }

        private void movCabeza()
        {
            Storyboard sbMovCabeza = (Storyboard)this.Resources["cabeza"];
            sbMovCabeza.Begin();
        }

        private void movimientoPieIzq()
        {
            Storyboard sbMmovimientoPieIzq = (Storyboard)this.Resources["movPieIzq"];
            sbMmovimientoPieIzq.Begin();
        }

        private void movimientoPieDer()
        {
            Storyboard sbMmovimientoPieDer = (Storyboard)this.Resources["movPieDer"];
            sbMmovimientoPieDer.Begin();
        }

        private void movHerido()
        {
            var transform = this.PokemonPiplup.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.PokemonPiplup.RenderTransform = transform;
            }
            this.PokemonPiplup.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMovimientoHerido = new DoubleAnimation
            {
                To = -10,
                From = 10,
                Duration = new Duration(TimeSpan.FromMilliseconds(40)),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(15)
            };
            Storyboard.SetTarget(dbMovimientoHerido, this.PokemonPiplup);
            var axis = "X";
            Storyboard.SetTargetProperty(dbMovimientoHerido, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMovLateral = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbMovLateral.Children.Add(dbMovimientoHerido);
            sbMovLateral.Begin();

        }

        public void movBombaMortifera()
        {
            var transform = this.bomba.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.bomba.RenderTransform = transform;
            }
            this.bomba.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMovimientoBomba = new DoubleAnimation
            {
                To = 500,
                From = 0,
                Duration = new Duration(TimeSpan.FromSeconds(4)),
                AutoReverse = false,
                RepeatBehavior = new RepeatBehavior(1)
            };
            Storyboard.SetTarget(dbMovimientoBomba, this.bomba);
            var axis = "Y";
            Storyboard.SetTargetProperty(dbMovimientoBomba, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbBombaMortifera = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbBombaMortifera.Children.Add(dbMovimientoBomba);
            sbBombaMortifera.Begin();
        }

        public void piesRapidos()
        {
            var transform = this.PokemonPiplup.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.PokemonPiplup.RenderTransform = transform;
            }
            this.PokemonPiplup.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMovimientoLateral = new DoubleAnimation
            {
                To = -200,
                From = 200,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(5)
            };
            Storyboard.SetTarget(dbMovimientoLateral, this.PokemonPiplup);
            var axis = "X";
            Storyboard.SetTargetProperty(dbMovimientoLateral, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMovLateral = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbMovLateral.Children.Add(dbMovimientoLateral);
            sbMovLateral.Begin();
        }
        public event EventHandler StatusUpdated2;
        private void btnEsquivarAtaque_Click(object sender, RoutedEventArgs e)
        {
            piesRapidos();
            turnoIA = true;

            if (this.StatusUpdated2 != null)
                this.StatusUpdated2(this, new EventArgs());
        }

        public void miradaPetrificadora()
        {
            Storyboard sbColorOjoIzqROJO = (Storyboard)this.ojoIzq.Resources["sbColorOjoIzqROJOKey"];
            Storyboard sbColorOjoDerROJO = (Storyboard)this.ojoDer.Resources["sbColorOjoDerROJOKey"];
            sbColorOjoIzqROJO.Begin();
            sbColorOjoDerROJO.Begin();
            pbEscudo.Value = escudo_actual - 50;
            escudo_actual -= 50;
            if (pbEscudo.Value <= 0.0)
            {
                dtReloj2 = new DispatcherTimer();
                dtReloj2.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj2.Tick += incrementarBarraEscudo;
                dtReloj2.Start();
            }
        }

        public event EventHandler StatusUpdated;
        public void btnMiradaPetrificadora_Click(object sender, RoutedEventArgs e)
        {
            miradaPetrificadora();
            turnoIA = true;

            if (this.StatusUpdated != null)
                this.StatusUpdated(this, new EventArgs());
        }

        public event EventHandler StatusUpdated3;
        public void ataqueBomba()
        {
            bomba.Visibility = Visibility.Visible;
            sbBombaOp.Begin();
            movBombaMortifera();
            dtReloj_bomba = new DispatcherTimer();
            dtReloj_bomba.Interval = TimeSpan.FromSeconds(2);
            dtReloj_bomba.Tick += quitarBomba;
            dtReloj_bomba.Start();
        }
        private void btnBombaMortifera_Click(object sender, RoutedEventArgs e)
        {
            ataqueBomba();
            turnoIA = true;

            if (this.StatusUpdated3 != null)
                this.StatusUpdated3(this, new EventArgs());
        }

        private void btnEmoticonoHerido_Click(object sender, RoutedEventArgs e)
        {
            dtReloj_Escudo = new DispatcherTimer();
            dtReloj_Escudo.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj_Escudo.Tick += decrementarBarraEscudo;
            dtReloj_Escudo.Start();
            btnEmoticonoHerido.Visibility = Visibility.Collapsed;
        }

        public void btnDerrotado_Click(object sender, RoutedEventArgs e)
        {
            cambioColorPokemonDerrotado();
        }

        public void Herido(double valorpasado)
        {
            valor = valorpasado;
            vida_actual = this.pbVida.Value;
            if (vida_actual - valor <= 0.0)
            {
                pokemonHerido();
                abrirBoca();
                ojosMorados_Herido();
                movHerido();

                dtReloj_Vida = new DispatcherTimer();
                dtReloj_Vida.Interval = TimeSpan.FromMilliseconds(80);
                dtReloj_Vida.Tick += decrementarBarraVida;
                dtReloj_Vida.Start();
            }
            else
            {
                pokemonHerido();
                abrirBoca();
                ojosMorados_Herido();
                movHerido();

                dtReloj_Vida = new DispatcherTimer();
                dtReloj_Vida.Interval = TimeSpan.FromMilliseconds(80);
                dtReloj_Vida.Tick += decrementarBarraVida;
                dtReloj_Vida.Start();
            }
        }

        public void curar()
        {
            if (pbVida.Value > 0.0)
            {
                dtReloj_Vida = new DispatcherTimer();
                dtReloj_Vida.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj_Vida.Tick += incrementarBarraVida;
                dtReloj_Vida.Start();
                imPocima.Visibility = Visibility.Collapsed;
                pocionUtilizada = true;
                vida_actual = pbVida.Value;
            }
        }

        private void incrementarBarraVida(object sender, object e)
        {
            if (vida_actual + 40.0 >= 100)
            {
                this.pbVida.Value = 100.0;
            }
            else
            {
                this.pbVida.Value = vida_actual + 40.0;
            }
            ojosVerdes_Contento();
            abrirBoca();
            dtReloj_Vida.Stop();
        }

        public void decrementarBarraVida(object sender, object e)
        {
            this.pbVida.Value -= 1.0;
            if (pbVida.Value == vida_actual - valor)
            {
                quitarTiritas();
                dtReloj_Vida.Stop();
            }

            if (pbVida.Value <= 0.0)
            {
                quitarTiritas();
                cambioColorPokemonDerrotado();
                dtReloj_Vida.Stop();
                desactivarBotones();
            }
            pbVida2 = pbVida.Value;
            
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

        private void decrementarBarraEscudo(object sender, object e)
        {
            this.pbEscudo.Value -= 0.5;
            if (pbEscudo.Value <= 0.0)
            {
                dtReloj_Escudo.Stop();
            }
        }

        public void activarBotones()
        {
            btnBombaMortifera.IsEnabled = true;
            btnEsquivarAtaque.IsEnabled = true;
            btnEmoticonoHerido.IsEnabled = true;
            if (escudo_actual > 0.0 && escudo_actual <= 100.0)
            {
                btnMiradaPetrificadora.IsEnabled = true;
            }
            if (pocionUtilizada == false)
            {
                imPocima.Visibility = Visibility.Visible;
            }
            tbTurno.Visibility = Visibility.Visible;
        }

        public void desactivarBotones()
        {
            btnBombaMortifera.IsEnabled = false;
            btnMiradaPetrificadora.IsEnabled = false;
            btnEsquivarAtaque.IsEnabled = false;
            btnEmoticonoHerido.IsEnabled = false;
            imPocima.Visibility = Visibility.Collapsed;
            tbTurno.Visibility = Visibility.Collapsed;
        }

        public void ocultarElementos()
        {
            pbVida.Visibility = Visibility.Collapsed;
            pbEscudo.Visibility = Visibility.Collapsed;
            imgCorazon.Visibility = Visibility.Collapsed;
            imgEscudo.Visibility = Visibility.Collapsed;
            imPocima.Visibility = Visibility.Collapsed;
            btnBombaMortifera.Visibility = Visibility.Collapsed;
            btnEsquivarAtaque.Visibility = Visibility.Collapsed;
            btnMiradaPetrificadora.Visibility = Visibility.Collapsed;
            btnEmoticonoHerido.Visibility = Visibility.Collapsed;
        }

        public void ocultarBotones()
        {
            imPocima.Visibility = Visibility.Collapsed;
            btnBombaMortifera.Visibility = Visibility.Collapsed;
            btnEsquivarAtaque.Visibility = Visibility.Collapsed;
            btnMiradaPetrificadora.Visibility = Visibility.Collapsed;
            btnEmoticonoHerido.Visibility = Visibility.Collapsed;
        }

        private async void pinPinguino(object sender, PointerRoutedEventArgs e)
        {
            SecondaryTile myTile = new SecondaryTile("Favorito", "Dos", "Tres",
            new Uri("ms-appx:///imagenesPinguino/piplupNoF.png"),
            Windows.UI.StartScreen.TileSize.Square150x150);
            myTile.DisplayName = "Piplup";
            myTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await myTile.RequestCreateAsync();
        }

        private void NotificacionSubida(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
                .AddArgument("action", "Favoritos")
                .AddArgument("conversationId", 9813)
                .AddText("Piplup ha evolucionado")
                .AddText("Puedes ver más información en IPOkemon")
                .AddInlineImage(new Uri("ms-appx:///imagenesPinguino/piplupEvolucionNoF.png"))
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
        public void ocultarImgAbajo()
        {
            imgChinchetaPunguino.Visibility = Visibility.Collapsed;
            imgPiedraPinguino.Visibility = Visibility.Collapsed;
        }

        public event EventHandler StatusUpdated4;
        private void subirVida(object sender, PointerRoutedEventArgs e)
        {
            curar();
            if (this.StatusUpdated4 != null)
                this.StatusUpdated4(this, new EventArgs());
            turnoIA = true;
        }
    }
}

