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
    public sealed partial class MUCPokemonOso : UserControl
    {
        static double vida_actual = 100.0;
        public double escudo_actual = 100.0;
        DispatcherTimer dtReloj;
        DispatcherTimer dtReloj2;
        DispatcherTimer dtRelojEsc;
        DispatcherTimer dtRelojTriste;
        DispatcherTimer dtRelojOjos;
        DispatcherTimer dtRelojLuna;
        DispatcherTimer dtRelojVida;
        DispatcherTimer dtRelojNaranja;
        DispatcherTimer dtRelojLaser;
        DispatcherTimer dtRelojGarras;
        DispatcherTimer dtRelojDerrota;
        public Boolean pocionUtilizada = false;
        static double valor = 0.0;
        public Boolean turnoIA = false;
        public Boolean ataqueTerminado = false;

        public double vidaTeddiursa
        {
            get { return vida_actual; }
            set { vida_actual = value; }
        }

        public ProgressBar barraVidaTeddiursa
        {
            get { return pbVida; }
            set { pbVida = value; }
        }

        public MUCPokemonOso()
        {
            this.InitializeComponent();
        }

        public void curar()
        {
            if (pbVida.Value > 0.0)
            {
                pocionUtilizada = true;
                imgCorazon2.Visibility = Visibility.Visible;
                vbTirita.Visibility = Visibility.Collapsed;
                vbTirita2.Visibility = Visibility.Collapsed;

                dtRelojVida = new DispatcherTimer();
                dtRelojVida.Interval = TimeSpan.FromSeconds(0.6);
                dtRelojVida.Tick += pararCorVida;
                dtRelojVida.Start();

                DoubleAnimation agrandarCorazon1 = new DoubleAnimation();
                agrandarCorazon1.From = 115.14859437751;
                agrandarCorazon1.To = 354.0;
                agrandarCorazon1.Duration = new Duration(TimeSpan.FromSeconds(0.6));
                agrandarCorazon1.RepeatBehavior = new RepeatBehavior(1);

                Storyboard sbCor = new Storyboard();
                Storyboard.SetTargetProperty(agrandarCorazon1,
                "Height");
                Storyboard.SetTarget(agrandarCorazon1, this.imgCorazon2);
                sbCor.Begin();

                DoubleAnimation agrandarCorazon2 = new DoubleAnimation();
                agrandarCorazon2.From = 126.0;
                agrandarCorazon2.To = 387.3603515625;
                agrandarCorazon2.Duration = new Duration(TimeSpan.FromSeconds(0.6));
                agrandarCorazon2.RepeatBehavior = new RepeatBehavior(1);

                Storyboard sbCor2 = new Storyboard();
                Storyboard.SetTargetProperty(agrandarCorazon1,
                "Width");
                Storyboard.SetTarget(agrandarCorazon2, this.imgCorazon2);
                sbCor2.Begin();

                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += incrementarBarra;
                dtReloj.Start();
                imgPocima.Visibility = Visibility.Collapsed;

                caraFeliz();
                vida_actual = pbVida.Value;
            }
        }
        public event EventHandler StatusUpdated6;
        private void subirVida(object sender, PointerRoutedEventArgs e)
        {
            curar();
            if (this.StatusUpdated6 != null)
                this.StatusUpdated6(this, new EventArgs());
            turnoIA = true;
        }

        private void pararCorVida(object sender, object e)
        {
            imgCorazon2.Visibility = Visibility.Collapsed;
            dtRelojVida.Stop();
        }

        private void caraFeliz()
        {
            DoubleAnimation movBoca2 = new DoubleAnimation();
            movBoca2.From = 42.426;
            movBoca2.To = 32.426;
            movBoca2.AutoReverse = true;
            movBoca2.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            movBoca2.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbMovBoca2 = new Storyboard();
            Storyboard.SetTargetProperty(movBoca2,
            "Height");
            Storyboard.SetTarget(movBoca2, this.vbBoca);
            sbMovBoca2.Begin();

            DoubleAnimation ojoPequeño1 = new DoubleAnimation();
            ojoPequeño1.From = vbOjoIzq.Height;
            ojoPequeño1.To = 16.0;
            ojoPequeño1.AutoReverse = true;
            ojoPequeño1.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            ojoPequeño1.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbOjoPeq1 = new Storyboard();
            Storyboard.SetTargetProperty(ojoPequeño1,
            "Height");
            Storyboard.SetTarget(ojoPequeño1, this.vbOjoIzq);
            sbOjoPeq1.Begin();

            DoubleAnimation ojoPequeño2 = new DoubleAnimation();
            ojoPequeño2.From = vbOjoDer.Height;
            ojoPequeño2.To = 16.0;
            ojoPequeño2.AutoReverse = true;
            ojoPequeño2.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            ojoPequeño2.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbOjoPeq2 = new Storyboard();
            Storyboard.SetTargetProperty(ojoPequeño2,
            "Height");
            Storyboard.SetTarget(ojoPequeño2, this.vbOjoDer);
            sbOjoPeq2.Begin();
        }

        private void incrementarBarra(object sender, object e)
        {
            if (vida_actual + 40.0 >= 100)
            {
                this.pbVida.Value = 100.0;
            }
            else
            {
                this.pbVida.Value = vida_actual + 40.0;
            }
            dtReloj.Stop();
        }

        public void Herido(double valorpasado)
        {
            valor = valorpasado;
            vida_actual = this.pbVida.Value;
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(80);
            dtReloj.Tick += decrementarBarraVida;
            dtReloj.Start();
            

            ptBocaTriste.Visibility = Visibility.Visible;
            vbBoca.Visibility = Visibility.Collapsed;
            vbDañar1.Visibility = Visibility.Visible;
            vbDañar2.Visibility = Visibility.Visible;
            dtRelojTriste = new DispatcherTimer();
            dtRelojTriste.Interval = TimeSpan.FromMilliseconds(300);
            dtRelojTriste.Tick += pararCaraTriste;
            dtRelojTriste.Start();

        }

        private void decrementarBarraVida(object sender, object e)
        {
            this.pbVida.Value -= 1.0;
            if (pbVida.Value == vida_actual - valor)
            {
                dtReloj.Stop();
            }
        }

        private void pararCaraTriste(object sender, object e)
        {
            ptBocaTriste.Visibility = Visibility.Collapsed;
            vbDañar1.Visibility = Visibility.Collapsed;
            vbDañar2.Visibility = Visibility.Collapsed;
            vbBoca.Visibility = Visibility.Visible;

            if (vida_actual - valor < 50 && vida_actual - valor > 0)
            {
                vbBoca.Visibility = Visibility.Visible;
                vbTirita.Visibility = Visibility.Visible;
                vbTirita2.Visibility = Visibility.Visible;
            }
            else if (vida_actual - valor <= 0.0)
            {
                imgXroja1.Visibility = Visibility.Visible;
                imgXroja2.Visibility = Visibility.Visible;
                ptBocaDerrota.Visibility = Visibility.Visible;
                vbOjoIzq.Visibility = Visibility.Collapsed;
                vbOjoDer.Visibility = Visibility.Collapsed;
                vbBoca.Visibility = Visibility.Collapsed;


                desactivarBotones();
                btnEscudo.IsEnabled = false;
                imgPocima.Visibility = Visibility.Collapsed;
                imgAtacar.Visibility = Visibility.Collapsed;
            }
            dtRelojTriste.Stop();
        }

        private void finDelJuego(object sender, object e)
        {
            
        }

        private void bajarEscudo(object sender, RoutedEventArgs e)
        {
            dtReloj2 = new DispatcherTimer();
            dtReloj2.Interval = TimeSpan.FromSeconds(0.4);
            dtReloj2.Tick += decrementarBarraEscudo;
            dtReloj2.Start();

            btnEscudo.Visibility = Visibility.Collapsed;
            imgAtacar.Visibility = Visibility.Collapsed;
            imgEscudo2.Visibility = Visibility.Visible;

            DoubleAnimation agrandarEscudo1 = new DoubleAnimation();
            agrandarEscudo1.From = 115.14859437751;
            agrandarEscudo1.To = 354.0;
            agrandarEscudo1.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            agrandarEscudo1.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbAgrandarEsc1 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEscudo1,
            "Height");
            Storyboard.SetTarget(agrandarEscudo1, this.imgEscudo2);
            sbAgrandarEsc1.Begin();

            DoubleAnimation agrandarEscudo2 = new DoubleAnimation();
            agrandarEscudo2.From = 126.0;
            agrandarEscudo2.To = 387.3603515625;
            agrandarEscudo2.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            agrandarEscudo2.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbAgrandarEsc2 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEscudo2,
            "Width");
            Storyboard.SetTarget(agrandarEscudo2, this.imgEscudo2);
            sbAgrandarEsc2.Begin();

            dtRelojEsc = new DispatcherTimer();
            dtRelojEsc.Interval = TimeSpan.FromMilliseconds(800);
            dtRelojEsc.Tick += esconderEscudo;
            dtRelojEsc.Start();
        }

        private void esconderEscudo(object sender, object e)
        {
            imgEscudo2.Visibility = Visibility.Collapsed;
            dtRelojEsc.Stop();
        }

        private void ojosAzules()
        {
            Storyboard sbojod = (Storyboard)this.ptOjoDer.Resources["ojoDerAKey"];
            Storyboard sbojoi = (Storyboard)this.ptOjoIzq.Resources["ojoIzqAKey"];
            sbojoi.Begin();
            sbojod.Begin();
        }

        private void decrementarBarraEscudo(object sender, object e)
        {
            this.pbEscudo.Value -= 15;
            if (pbEscudo.Value <= 0.0)
            {
                imgAtacar.Visibility = Visibility.Collapsed;
                dtReloj2.Stop();
                dtReloj2 = new DispatcherTimer();
                dtReloj2.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj2.Tick += incrementarBarraEscudo;
                dtReloj2.Start();
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
        public void ojos()
        {
            ojosAzules();
            desactivarBotones();

            ptBocaAtaqueOjos.Visibility = Visibility.Visible;
            imgEspiral.Visibility = Visibility.Visible;
            vbBoca.Visibility = Visibility.Collapsed;
            imgAtacar.Visibility = Visibility.Collapsed;

            DoubleAnimation agrandarEspiral1 = new DoubleAnimation();
            agrandarEspiral1.From = 115.14859437751;
            agrandarEspiral1.To = 354.0;
            agrandarEspiral1.Duration = new Duration(TimeSpan.FromSeconds(4));
            agrandarEspiral1.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbAgrandarEsp1 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEspiral1,
            "Height");
            Storyboard.SetTarget(agrandarEspiral1, this.imgEspiral);
            sbAgrandarEsp1.Begin();

            DoubleAnimation agrandarEspiral2 = new DoubleAnimation();
            agrandarEspiral2.From = 126.0;
            agrandarEspiral2.To = 387.3603515625;
            agrandarEspiral2.Duration = new Duration(TimeSpan.FromSeconds(4));
            agrandarEspiral2.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbAgrandarEsp2 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEspiral2,
            "Width");
            Storyboard.SetTarget(agrandarEspiral2, this.imgEspiral);
            sbAgrandarEsp2.Begin();

            dtRelojOjos = new DispatcherTimer();
            dtRelojOjos.Interval = TimeSpan.FromSeconds(4);
            dtRelojOjos.Tick += pararAtaqueOjos;
            dtRelojOjos.Start();
            movimientoAtaqueOjos();
        }
        public event EventHandler StatusUpdated5;
        private void ataqueOjos(object sender, RoutedEventArgs e)
        {
            ojos();
            turnoIA = true;

            if (this.StatusUpdated5 != null)
                this.StatusUpdated5(this, new EventArgs());
        }

        private void movimientoAtaqueOjos()
        {

            var transform = this.pokemon.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.pokemon.RenderTransform = transform;
            }
            this.pokemon.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMvAtaqueOjos = new DoubleAnimation
            {
                To = 100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMvAtaqueOjos, this.pokemon);
            var axis = "X";
            Storyboard.SetTargetProperty(dbMvAtaqueOjos, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMvAtaqueOjos = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbMvAtaqueOjos.Children.Add(dbMvAtaqueOjos);
            sbMvAtaqueOjos.Begin();

        }

        private void pararAtaqueOjos(object sender, object e)
        {
            ptBocaAtaqueOjos.Visibility = Visibility.Collapsed;
            imgEspiral.Visibility = Visibility.Collapsed;
            vbBoca.Visibility = Visibility.Visible;
            imgAtacar.Visibility = Visibility.Collapsed;
            dtRelojOjos.Stop();
            ataqueTerminado = true;
        }

        private void LunaAmarilla()
        {
            Storyboard sLuna = (Storyboard)this.ptLuna.Resources["lunaAmKey"];
            Storyboard sBordeLuna = (Storyboard)this.ptLuna.Resources["bordeLunaAmKey"];
            sLuna.Begin();
            sBordeLuna.Begin();
        }

        public void luna()
        {
            LunaAmarilla();
            vbBocaAtaqueLuna.Visibility = Visibility.Visible;
            vbBoca.Visibility = Visibility.Collapsed;
            ptEstrella.Visibility = Visibility.Visible;
            ptEstrella2.Visibility = Visibility.Visible;
            imgAtacar.Visibility = Visibility.Collapsed;
            desactivarBotones();

            DoubleAnimation agrandarEstrella1 = new DoubleAnimation();
            agrandarEstrella1.From = 55.12;
            agrandarEstrella1.To = 102.326;
            agrandarEstrella1.Duration = new Duration(TimeSpan.FromSeconds(1));
            agrandarEstrella1.RepeatBehavior = new RepeatBehavior(4);
            Storyboard sbAgrandarEst1 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEstrella1,
            "Height");
            Storyboard.SetTarget(agrandarEstrella1, this.ptEstrella);
            sbAgrandarEst1.Begin();

            DoubleAnimation agrandarEstrella2 = new DoubleAnimation();
            agrandarEstrella2.From = 51.061;
            agrandarEstrella2.To = 103.311;
            agrandarEstrella2.Duration = new Duration(TimeSpan.FromSeconds(1));
            agrandarEstrella2.RepeatBehavior = new RepeatBehavior(4);
            Storyboard sbAgrandarEst2 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEstrella2,
            "Width");
            Storyboard.SetTarget(agrandarEstrella2, this.ptEstrella);
            sbAgrandarEst2.Begin();

            DoubleAnimation agrandarEstrella3 = new DoubleAnimation();
            agrandarEstrella3.From = 28.027;
            agrandarEstrella3.To = 55.128;
            agrandarEstrella3.Duration = new Duration(TimeSpan.FromSeconds(1));
            agrandarEstrella3.RepeatBehavior = new RepeatBehavior(4);
            Storyboard sbAgrandarEst3 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEstrella3,
            "Height");
            Storyboard.SetTarget(agrandarEstrella3, this.ptEstrella2);
            sbAgrandarEst3.Begin();

            DoubleAnimation agrandarEstrella4 = new DoubleAnimation();
            agrandarEstrella4.From = 28.027;
            agrandarEstrella4.To = 53.061;
            agrandarEstrella4.Duration = new Duration(TimeSpan.FromSeconds(1));
            agrandarEstrella4.RepeatBehavior = new RepeatBehavior(4);
            Storyboard sbAgrandarEst4 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarEstrella4,
            "Width");
            Storyboard.SetTarget(agrandarEstrella4, this.ptEstrella2);
            sbAgrandarEst4.Begin();

            dtRelojLuna = new DispatcherTimer();
            dtRelojLuna.Interval = TimeSpan.FromSeconds(4);
            dtRelojLuna.Tick += pararAtaqueLuna;
            dtRelojLuna.Start();

            movimientoEstrellas();
        }

        public event EventHandler StatusUpdated4;
        private void ataqueLuna(object sender, RoutedEventArgs e)
        {
            luna();
            turnoIA = true;

            if (this.StatusUpdated4 != null)
                this.StatusUpdated4(this, new EventArgs());

        }

        private void movimientoEstrellas()
        {

            var transform = this.ptEstrella.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.ptEstrella.RenderTransform = transform;
            }
            this.ptEstrella.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov1 = new DoubleAnimation
            {
                To = -100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov1, this.ptEstrella);
            var axis = "X";
            Storyboard.SetTargetProperty(dbMov1, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMov1 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            var transform2 = this.ptEstrella.RenderTransform as CompositeTransform;

            if (transform2 == null)
            {
                transform2 = new CompositeTransform();
                this.ptEstrella.RenderTransform = transform2;
            }
            this.ptEstrella.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov2 = new DoubleAnimation
            {
                To = 100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov2, this.ptEstrella);
            var axis2 = "Y";
            Storyboard.SetTargetProperty(dbMov2, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis2})");

            var sbMov2 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            var transform3 = this.ptEstrella2.RenderTransform as CompositeTransform;

            if (transform3 == null)
            {
                transform3 = new CompositeTransform();
                this.ptEstrella2.RenderTransform = transform3;
            }
            this.ptEstrella2.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov3 = new DoubleAnimation
            {
                To = -100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov3, this.ptEstrella2);
            var axis3 = "X";
            Storyboard.SetTargetProperty(dbMov3, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis3})");

            var sbMov3 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            var transform4 = this.ptEstrella.RenderTransform as CompositeTransform;

            if (transform4 == null)
            {
                transform4 = new CompositeTransform();
                this.ptEstrella2.RenderTransform = transform4;
            }
            this.ptEstrella2.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov4 = new DoubleAnimation
            {
                To = 100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov4, this.ptEstrella2);
            var axis4 = "Y";
            Storyboard.SetTargetProperty(dbMov4, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis4})");

            var sbMov4 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };


            sbMov1.Children.Add(dbMov1);
            sbMov1.Begin();

            sbMov2.Children.Add(dbMov2);
            sbMov2.Begin();

            sbMov3.Children.Add(dbMov3);
            sbMov3.Begin();

            sbMov4.Children.Add(dbMov4);
            sbMov4.Begin();

        }

        private void pararAtaqueLuna(object sender, object e)
        {
            vbBocaAtaqueLuna.Visibility = Visibility.Collapsed;
            vbBoca.Visibility = Visibility.Visible;
            ptEstrella.Visibility = Visibility.Collapsed;
            ptEstrella2.Visibility = Visibility.Collapsed;
            imgAtacar.Visibility = Visibility.Collapsed;
            dtRelojLuna.Stop();
            ataqueTerminado = true;
        }

        public void desactivarBotones()
        {
            btnAtaqueGarras.IsEnabled = false;
            btnAtaqueLuna.IsEnabled = false;
            btnAtaqueNaranja.IsEnabled = false;
            btnAtaqueOjos.IsEnabled = false;
            btnAtaqueOjosLaser.IsEnabled = false;
            btnEscudo.IsEnabled = false;
            imgPocima.Visibility = Visibility.Collapsed;
            tbTurno.Visibility = Visibility.Collapsed;
        }

        public void activarBotones()
        {
            if (escudo_actual > 50.0 && escudo_actual<= 100.0)
            {
                btnAtaqueGarras.IsEnabled = true;
            }
            if (escudo_actual > 0.0 && escudo_actual <= 100.0)
            {
                btnAtaqueNaranja.IsEnabled = true;
            }
            btnAtaqueLuna.IsEnabled = true;
            btnAtaqueOjos.IsEnabled = true;
            btnAtaqueOjosLaser.IsEnabled = true;
            btnEscudo.IsEnabled = true;
            if (pocionUtilizada == false)
            {
                imgPocima.Visibility = Visibility.Visible;
            }
            
            tbTurno.Visibility = Visibility.Visible;
        }

        public void fuego()
        {
            pbEscudo.Value = escudo_actual - 15;
            escudo_actual -= 15;
            cambioColorNaranja();
            movimientoAtaqueFuego();
            movimientoAtaqueNaranja();
            desactivarBotones();

            ptOjoIzqAtaqueNaranja.Visibility = Visibility.Visible;
            ptOjoDerAtaqueNaranja.Visibility = Visibility.Visible;
            imgFuego.Visibility = Visibility.Visible;
            vbBoca.Visibility = Visibility.Collapsed;
            ptBocaAtaqueNaranja.Visibility = Visibility.Visible;
            imgAtacar.Visibility = Visibility.Collapsed;

            DoubleAnimation agrandarFuego1 = new DoubleAnimation();
            agrandarFuego1.From = 55.12;
            agrandarFuego1.To = 102.326;
            agrandarFuego1.Duration = new Duration(TimeSpan.FromSeconds(1));
            agrandarFuego1.RepeatBehavior = new RepeatBehavior(4);
            Storyboard sbagrandarFuego1 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarFuego1,
            "Height");
            Storyboard.SetTarget(agrandarFuego1, this.imgFuego);
            sbagrandarFuego1.Begin();

            DoubleAnimation agrandarFuego2 = new DoubleAnimation();
            agrandarFuego2.From = 51.061;
            agrandarFuego2.To = 103.311;
            agrandarFuego2.Duration = new Duration(TimeSpan.FromSeconds(1));
            agrandarFuego2.RepeatBehavior = new RepeatBehavior(4);
            Storyboard sbagrandarFuego2 = new Storyboard();
            Storyboard.SetTargetProperty(agrandarFuego2,
            "Width");
            Storyboard.SetTarget(agrandarFuego2, this.imgFuego);
            sbagrandarFuego2.Begin();

            dtRelojNaranja = new DispatcherTimer();
            dtRelojNaranja.Interval = TimeSpan.FromSeconds(4);
            dtRelojNaranja.Tick += pararAtaqueNaranja;
            dtRelojNaranja.Start();

            if (pbEscudo.Value <= 0.0)
            {
                dtReloj2 = new DispatcherTimer();
                dtReloj2.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj2.Tick += incrementarBarraEscudo;
                dtReloj2.Start();
            }
        }

        public event EventHandler StatusUpdated3;

        private void ataqueNaranja(object sender, RoutedEventArgs e)
        {
            fuego();
            turnoIA = true;

            if (this.StatusUpdated3 != null)
                this.StatusUpdated3(this, new EventArgs());
        }

        private void pararAtaqueNaranja(object sender, object e)
        {
            ptBocaAtaqueNaranja.Visibility = Visibility.Collapsed;
            vbBoca.Visibility = Visibility.Visible;
            ptOjoIzqAtaqueNaranja.Visibility = Visibility.Collapsed;
            ptOjoDerAtaqueNaranja.Visibility = Visibility.Collapsed;
            imgFuego.Visibility = Visibility.Collapsed;
            imgAtacar.Visibility = Visibility.Collapsed;

            dtRelojNaranja.Stop();
            ataqueTerminado = true;
        }

        private void movimientoAtaqueNaranja()
        {

            var transform = this.pokemon.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.pokemon.RenderTransform = transform;
            }
            this.pokemon.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMvAtaqueNaranja = new DoubleAnimation
            {
                To = 100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMvAtaqueNaranja, this.pokemon);
            var axis = "Y";
            Storyboard.SetTargetProperty(dbMvAtaqueNaranja, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMvAtaqueNaranja = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbMvAtaqueNaranja.Children.Add(dbMvAtaqueNaranja);
            sbMvAtaqueNaranja.Begin();

        }

        private void movimientoAtaqueFuego()
        {

            var transform = this.imgFuego.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.imgFuego.RenderTransform = transform;
            }
            this.imgFuego.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMvAtaqueNaranja = new DoubleAnimation
            {
                To = -8,
                From = 0,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(4)
            };
            Storyboard.SetTarget(dbMvAtaqueNaranja, this.imgFuego);
            var axis = "Y";
            Storyboard.SetTargetProperty(dbMvAtaqueNaranja, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMvAtaqueNaranja = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbMvAtaqueNaranja.Children.Add(dbMvAtaqueNaranja);
            sbMvAtaqueNaranja.Begin();

        }

        private void cambioColorNaranja()
        {
            Storyboard sCabezaNar = (Storyboard)this.ptCabeza.Resources["cabezaNaranjaKey"];
            Storyboard sCuerpoNar = (Storyboard)this.ptCuerpo.Resources["cuerpoNaranjaKey"];
            Storyboard sPataIzqNar = (Storyboard)this.ptPataIzq.Resources["pataIzqNaranjaKey"];
            Storyboard sPataDerNar = (Storyboard)this.ptPataDer.Resources["pataDerNaranjaKey"];
            Storyboard sPieIzqNar = (Storyboard)this.ptPieIzq.Resources["pieIzqNaranjaKey"];
            Storyboard sPieDerNar = (Storyboard)this.ptPieDer.Resources["pieDerNaranjaKey"];

            Storyboard sOrejaIzq = (Storyboard)this.ptOrejaIzq.Resources["orejaIzqNaranjaKey"];
            Storyboard sOrejaDer = (Storyboard)this.ptOrejaDer.Resources["orejaDerNaranjaKey"];
            Storyboard sSombra1Cab = (Storyboard)this.ptsombra1Cab.Resources["sombra1CabNaranjaKey"];
            Storyboard sSombra2Cab = (Storyboard)this.ptsombra2Cab.Resources["sombra2CabNaranjaKey"];
            Storyboard sSombra3Cab = (Storyboard)this.ptsombra3Cab.Resources["sombra3CabNaranjaKey"];
            Storyboard sSombra4Cab = (Storyboard)this.ptsombra4Cab.Resources["sombra4CabNaranjaKey"];
            Storyboard sSombraPieIzq = (Storyboard)this.ptsombraPieIzq.Resources["sombraPieIzqNaranjaKey"];
            Storyboard sSombraPieDer = (Storyboard)this.ptsombraPieDer.Resources["sombraPieDerNaranjaKey"];
            Storyboard sSombraCuerpo = (Storyboard)this.ptsombraCuerpo.Resources["sombraCuerpoNaranjaKey"];
            Storyboard sSombraOrejaIzq = (Storyboard)this.ptsombraOrejaIzq.Resources["sombraOrejaIzqNaranjaKey"];
            Storyboard sSombraOrejaDer = (Storyboard)this.ptsombraOrejaDer.Resources["sombraOrejaDerNaranjaKey"];

            sCabezaNar.Begin();
            sCuerpoNar.Begin();
            sPataIzqNar.Begin();
            sPataDerNar.Begin();
            sPieIzqNar.Begin();
            sPieDerNar.Begin();

            sOrejaIzq.Begin();
            sOrejaDer.Begin();
            sSombra1Cab.Begin();
            sSombra2Cab.Begin();
            sSombra3Cab.Begin();
            sSombra4Cab.Begin();
            sSombraPieIzq.Begin();
            sSombraPieDer.Begin();
            sSombraCuerpo.Begin();
            sSombraOrejaIzq.Begin();
            sSombraOrejaDer.Begin();
        }

        public void laser()
        {

            imgAtacar.Visibility = Visibility.Collapsed;
            ptLaserIzq.Visibility = Visibility.Visible;
            ptLaserDer.Visibility = Visibility.Visible;
            ptOjoIzq.Visibility = Visibility.Collapsed;
            ptOjoDer.Visibility = Visibility.Collapsed;
            ptOjoIzqB.Visibility = Visibility.Collapsed;
            ptOjoDerB.Visibility = Visibility.Collapsed;
            ptOjoIzqG.Visibility = Visibility.Collapsed;
            ptOjoDerG.Visibility = Visibility.Collapsed;
            ptOjoIzqLaser.Visibility = Visibility.Visible;
            ptOjoDerLaser.Visibility = Visibility.Visible;
            vbBocaAtaqueLaser.Visibility = Visibility.Visible;
            vbBoca.Visibility = Visibility.Collapsed;

            desactivarBotones();

            movimientoAtaqueLaser();

            dtRelojLaser = new DispatcherTimer();
            dtRelojLaser.Interval = TimeSpan.FromSeconds(4);
            dtRelojLaser.Tick += pararAtaqueLaser;
            dtRelojLaser.Start();
        }

        public event EventHandler StatusUpdated2;
        private void ataqueOjosLaser(object sender, RoutedEventArgs e)
        {
            laser();
            turnoIA = true;

            if (this.StatusUpdated2 != null)
                this.StatusUpdated2(this, new EventArgs());
        }

        private void pararAtaqueLaser(object sender, object e)
        {
            vbBocaAtaqueLaser.Visibility = Visibility.Collapsed;
            vbBoca.Visibility = Visibility.Visible;
            ptOjoIzq.Visibility = Visibility.Visible;
            ptOjoDer.Visibility = Visibility.Visible;
            ptOjoIzqB.Visibility = Visibility.Visible;
            ptOjoDerB.Visibility = Visibility.Visible;
            ptOjoIzqG.Visibility = Visibility.Visible;
            ptOjoDerG.Visibility = Visibility.Visible;
            ptOjoIzqLaser.Visibility = Visibility.Collapsed;
            ptOjoDerLaser.Visibility = Visibility.Collapsed;
            ptLaserIzq.Visibility = Visibility.Collapsed;
            ptLaserDer.Visibility = Visibility.Collapsed;
            imgAtacar.Visibility = Visibility.Collapsed;

            dtRelojLaser.Stop();
            ataqueTerminado = true;
        }

        private void movimientoAtaqueLaser()
        {

            var transform = this.ptLaserIzq.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.ptLaserIzq.RenderTransform = transform;
            }
            this.ptLaserIzq.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov1 = new DoubleAnimation
            {
                To = -100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov1, this.ptLaserIzq);
            var axis = "X";
            Storyboard.SetTargetProperty(dbMov1, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMov1 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            var transform2 = this.ptLaserIzq.RenderTransform as CompositeTransform;

            if (transform2 == null)
            {
                transform2 = new CompositeTransform();
                this.ptLaserIzq.RenderTransform = transform2;
            }
            this.ptLaserIzq.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov2 = new DoubleAnimation
            {
                To = 100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov2, this.ptLaserIzq);
            var axis2 = "Y";
            Storyboard.SetTargetProperty(dbMov2, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis2})");

            var sbMov2 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            var transform3 = this.vbLaserDer.RenderTransform as CompositeTransform;

            if (transform3 == null)
            {
                transform3 = new CompositeTransform();
                this.vbLaserDer.RenderTransform = transform3;
            }
            this.vbLaserDer.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov3 = new DoubleAnimation
            {
                To = 100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov3, this.vbLaserDer);
            var axis3 = "X";
            Storyboard.SetTargetProperty(dbMov3, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis3})");

            var sbMov3 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            var transform4 = this.vbLaserDer.RenderTransform as CompositeTransform;

            if (transform4 == null)
            {
                transform4 = new CompositeTransform();
                this.vbLaserDer.RenderTransform = transform4;
            }
            this.vbLaserDer.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMov4 = new DoubleAnimation
            {
                To = 100,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMov4, this.vbLaserDer);
            var axis4 = "Y";
            Storyboard.SetTargetProperty(dbMov4, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis4})");

            var sbMov4 = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };


            sbMov1.Children.Add(dbMov1);
            sbMov1.Begin();

            sbMov2.Children.Add(dbMov2);
            sbMov2.Begin();

            sbMov3.Children.Add(dbMov3);
            sbMov3.Begin();

            sbMov4.Children.Add(dbMov4);
            sbMov4.Begin();

        }

        public void garras(){

            aumentarGarras();
            movimientoAtaqueGarras();

            desactivarBotones();

            pbEscudo.Value = escudo_actual - 35;
            escudo_actual -= 35;

            imgAtacar.Visibility = Visibility.Collapsed;
            imgGarras.Visibility = Visibility.Visible;
            vbBocaAtaqueGarras.Visibility = Visibility.Visible;
            vbBoca.Visibility = Visibility.Collapsed;
            ptOjoIzq.Visibility = Visibility.Collapsed;
            ptOjoDer.Visibility = Visibility.Collapsed;
            ptOjoIzqB.Visibility = Visibility.Collapsed;
            ptOjoDerB.Visibility = Visibility.Collapsed;
            ptOjoIzqG.Visibility = Visibility.Collapsed;
            ptOjoDerG.Visibility = Visibility.Collapsed;
            ptOjoIzqLaser.Visibility = Visibility.Visible;
            ptOjoDerLaser.Visibility = Visibility.Visible;
            ptOjoIzqGarras.Visibility = Visibility.Visible;
            ptOjoDerGarras.Visibility = Visibility.Visible;

            dtRelojGarras = new DispatcherTimer();
            dtRelojGarras.Interval = TimeSpan.FromSeconds(4);
            dtRelojGarras.Tick += pararAtaqueGarras;
            dtRelojGarras.Start();

            if (pbEscudo.Value <= 0.0)
            {
                dtReloj2 = new DispatcherTimer();
                dtReloj2.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj2.Tick += incrementarBarraEscudo;
                dtReloj2.Start();
            }
        }

        public event EventHandler StatusUpdated;
        private void ataqueGarras(object sender, RoutedEventArgs e)
        {
            garras();
            turnoIA = true;

            if (this.StatusUpdated != null)
                this.StatusUpdated(this, new EventArgs());
        }

        private void pararAtaqueGarras(object sender, object e)
        {
            imgGarras.Visibility = Visibility.Collapsed;
            vbBocaAtaqueGarras.Visibility = Visibility.Collapsed;
            vbBoca.Visibility = Visibility.Visible;
            vbOjoIzq.Visibility = Visibility.Visible;
            vbOjoDer.Visibility = Visibility.Visible;
            ptOjoIzq.Visibility = Visibility.Visible;
            ptOjoDer.Visibility = Visibility.Visible;
            ptOjoIzqB.Visibility = Visibility.Visible;
            ptOjoDerB.Visibility = Visibility.Visible;
            ptOjoIzqG.Visibility = Visibility.Visible;
            ptOjoDerG.Visibility = Visibility.Visible;
            ptOjoIzqLaser.Visibility = Visibility.Collapsed;
            ptOjoDerLaser.Visibility = Visibility.Collapsed;
            ptOjoIzqGarras.Visibility = Visibility.Collapsed;
            ptOjoDerGarras.Visibility = Visibility.Collapsed;
            imgAtacar.Visibility = Visibility.Collapsed;

            dtRelojGarras.Stop();
            ataqueTerminado = true;
        }

        private void movimientoAtaqueGarras()
        {

            var transform = this.pokemon.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.pokemon.RenderTransform = transform;
            }
            this.pokemon.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbMvAtaqueGarras = new DoubleAnimation
            {
                To = -200,
                From = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            Storyboard.SetTarget(dbMvAtaqueGarras, this.pokemon);
            var axis = "X";
            Storyboard.SetTargetProperty(dbMvAtaqueGarras, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbMvAtaqueGarras = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbMvAtaqueGarras.Children.Add(dbMvAtaqueGarras);
            sbMvAtaqueGarras.Begin();

        }

        private void aumentarGarras()
        {
            DoubleAnimation aumentarGarra1PieDer = new DoubleAnimation();
            DoubleAnimation aumentarGarra2PieDer = new DoubleAnimation();
            DoubleAnimation aumentarGarra1PieIzq = new DoubleAnimation();
            DoubleAnimation aumentarGarra2PieIzq = new DoubleAnimation();
            aumentarGarra1PieDer.From = 17.023;
            aumentarGarra2PieDer.From = 17.023;
            aumentarGarra1PieIzq.From = 17.023;
            aumentarGarra2PieIzq.From = 17.023;
            aumentarGarra1PieDer.To = 25.0;
            aumentarGarra2PieDer.To = 25.0;
            aumentarGarra1PieIzq.To = 25.0;
            aumentarGarra2PieIzq.To = 25.0;
            aumentarGarra1PieDer.AutoReverse = true;
            aumentarGarra2PieDer.AutoReverse = true;
            aumentarGarra1PieIzq.AutoReverse = true;
            aumentarGarra2PieIzq.AutoReverse = true;
            aumentarGarra1PieDer.Duration = new Duration(TimeSpan.FromSeconds(1));
            aumentarGarra2PieDer.Duration = new Duration(TimeSpan.FromSeconds(1));
            aumentarGarra1PieIzq.Duration = new Duration(TimeSpan.FromSeconds(1));
            aumentarGarra2PieIzq.Duration = new Duration(TimeSpan.FromSeconds(1));
            aumentarGarra1PieDer.RepeatBehavior = new RepeatBehavior(1);
            aumentarGarra2PieDer.RepeatBehavior = new RepeatBehavior(1);
            aumentarGarra1PieIzq.RepeatBehavior = new RepeatBehavior(1);
            aumentarGarra2PieIzq.RepeatBehavior = new RepeatBehavior(1);
            Storyboard sbAumentarGarra1PieDer = new Storyboard();
            Storyboard.SetTargetProperty(aumentarGarra1PieDer,
            "Height");
            Storyboard.SetTarget(aumentarGarra1PieDer, this.ptGarra1PieDer);
            sbAumentarGarra1PieDer.Begin();

            Storyboard sbAumentarGarra2PieDer = new Storyboard();
            Storyboard.SetTargetProperty(aumentarGarra2PieDer,
            "Height");
            Storyboard.SetTarget(aumentarGarra2PieDer, this.ptGarra2PieDer);
            sbAumentarGarra2PieDer.Begin();

            Storyboard sbAumentarGarra1PieIzq = new Storyboard();
            Storyboard.SetTargetProperty(aumentarGarra1PieIzq,
            "Height");
            Storyboard.SetTarget(aumentarGarra1PieIzq, this.ptGarra1PieIzq);
            sbAumentarGarra1PieIzq.Begin();

            Storyboard sbAumentarGarra2PieIzq = new Storyboard();
            Storyboard.SetTargetProperty(aumentarGarra2PieIzq,
            "Height");
            Storyboard.SetTarget(aumentarGarra2PieIzq, this.ptGarra2PieIzq);
            sbAumentarGarra2PieIzq.Begin();
        }

        public void ocultarElementos()
        {
            pbVida.Visibility = Visibility.Collapsed;
            pbEscudo.Visibility = Visibility.Collapsed;
            imgCorazon.Visibility = Visibility.Collapsed;
            imgEscudo.Visibility = Visibility.Collapsed;
            imgPocima.Visibility = Visibility.Collapsed;
            btnAtaqueGarras.Visibility = Visibility.Collapsed;
            btnAtaqueLuna.Visibility = Visibility.Collapsed;
            btnAtaqueNaranja.Visibility = Visibility.Collapsed;
            btnAtaqueOjos.Visibility = Visibility.Collapsed;
            btnAtaqueOjosLaser.Visibility = Visibility.Collapsed;
            btnEscudo.Visibility = Visibility.Collapsed;
        }

        public void ocultarBotones()
        {
            imgPocima.Visibility = Visibility.Collapsed;
            btnAtaqueGarras.Visibility = Visibility.Collapsed;
            btnAtaqueLuna.Visibility = Visibility.Collapsed;
            btnAtaqueNaranja.Visibility = Visibility.Collapsed;
            btnAtaqueOjos.Visibility = Visibility.Collapsed;
            btnAtaqueOjosLaser.Visibility = Visibility.Collapsed;
            btnEscudo.Visibility = Visibility.Collapsed;
        }

        private async void pinOso(object sender, PointerRoutedEventArgs e)
        {
            SecondaryTile myTile = new SecondaryTile("Favorito", "Dos", "Tres",
            new Uri("ms-appx:///imagenesOso/osoNoF.png"),
            Windows.UI.StartScreen.TileSize.Square150x150);
            myTile.DisplayName = "Tediursa";
            myTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await myTile.RequestCreateAsync();
        }

        private void NotificacionSubida(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
                .AddArgument("action", "Favoritos")
                .AddArgument("conversationId", 9813)
                .AddText("Tediursa ha evolucionado")
                .AddText("Puedes ver más información en IPOkemon")
                .AddInlineImage(new Uri("ms-appx:///imagenesOso/osoEvolucionNoF.png"))
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
            imgChinchetaOso.Visibility = Visibility.Collapsed;
            imgPiedraOso.Visibility = Visibility.Collapsed;
        }
    }
}
