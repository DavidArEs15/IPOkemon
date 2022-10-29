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
    public sealed partial class MUCCastform : UserControl
    {
        static double vida_actual = 100.0;
        DispatcherTimer dtReloj;
        public Boolean turnoIA = false;
        public Boolean pocionUtilizada = false;
        static double valor = 0.0;
        public double escudo_actual = 100.0;
        DispatcherTimer dtReloj2;
        public double vidaCastform
        {
            get { return this.pbVida1.Value; }
            set { this.pbVida1.Value = value; }
        }

        public ProgressBar barraVidaCastform
        {
            get { return pbVida1; }
            set { pbVida1 = value; }
        }

        public MUCCastform()
        {
            this.InitializeComponent();
        }

        public void hipnosis()
        {
            Storyboard sb = (Storyboard)this.pupila_der.Resources["pupilaRojaDKey"];
            sb.Begin();
            Storyboard sb1 = (Storyboard)this.pupila_izq.Resources["pupilaRojaIKey"];
            sb1.Begin();
        }

        public event EventHandler StatusUpdated2;
        private void btnOjos_Click(object sender, RoutedEventArgs e)
        {
            hipnosis();
            turnoIA = true;

            if (this.StatusUpdated2 != null)
                this.StatusUpdated2(this, new EventArgs());
        }

        private void btnpbVida1_Click(object sender, RoutedEventArgs e)
        {
            pbVida1.Value -= 30;
            double vida = this.pbVida1.Value;


            if (vida <= 20 && vida > 0)
            {
                cvnTirita.Visibility = Visibility.Visible;
                tirita1.Visibility = Visibility.Visible;

            }
            if (vida <= 0)
            {
                cnvCruces.Visibility = Visibility.Visible;
                ojo_izq.Visibility = Visibility.Collapsed;
                Ojo_der.Visibility = Visibility.Collapsed;
                muerte();
            }

        }

        private void incrementarBarraEscudo(object sender, object e)
        {
            this.pbEscudo1.Value += 0.4;
            if (pbEscudo1.Value >= 100.0)
            {
                escudo_actual = 100.0;
                dtReloj2.Stop();
            }
        }

        public void cuerno()
        {
            Storyboard sCuernoRojo = (Storyboard)this.Cuerno.Resources["cuernoRojoKey"];

            sCuernoRojo.Begin();

            pbEscudo1.Value = escudo_actual - 35;
            escudo_actual -= 35;

            if (pbEscudo1.Value <= 0.0)
            {
                dtReloj2 = new DispatcherTimer();
                dtReloj2.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj2.Tick += incrementarBarraEscudo;
                dtReloj2.Start();
            }
        }

        public event EventHandler StatusUpdated;
        private void btnGiroCuerno_Click(object sender, RoutedEventArgs e)
        {
            cuerno();
            turnoIA = true;
            
            if (this.StatusUpdated != null)
                this.StatusUpdated(this, new EventArgs());

        }




        private void ActivaCruces()
        {
            if (pbVida1.Value < 1)
            {
                ojo_izq.Visibility = Visibility.Collapsed;
                Ojo_der.Visibility = Visibility.Collapsed;
                cnvCruces.Visibility = Visibility.Visible;
            }
        }

        public event EventHandler StatusUpdated5;
        private void btnPocima_Click(object sender, RoutedEventArgs e)
        {
            curar();
            if (this.StatusUpdated5 != null)
                this.StatusUpdated5(this, new EventArgs());
            turnoIA = true;
        }

        public void tormenta()
        {
            enfado();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(7000);
            dtReloj.Tick += desenfado;
            dtReloj.Start();
            Storyboard sb = (Storyboard)this.Resources["ataqueNubes"];
            sb.Begin();
            pbEscudo1.Value = escudo_actual - 15;
            escudo_actual -= 15;
            if (pbEscudo1.Value <= 0.0)
            {
                dtReloj2 = new DispatcherTimer();
                dtReloj2.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj2.Tick += incrementarBarraEscudo;
                dtReloj2.Start();
            }
        }

        public event EventHandler StatusUpdated4;
        private void btnAtaque2_Click(object sender, RoutedEventArgs e)
        {
            tormenta();
            turnoIA = true;

            if (this.StatusUpdated4 != null)
                this.StatusUpdated4(this, new EventArgs());
        }
        private void enfado()
        {
            gbNubes.Visibility = Visibility.Visible;
            gbRayos.Visibility = Visibility.Visible;
            cejas.Visibility = Visibility.Visible;
            bocaSad.Visibility = Visibility.Visible;
            boca.Visibility = Visibility.Collapsed;
        }

        private void desenfado(object sender, object e)
        {
            gbNubes.Visibility = Visibility.Collapsed;
            gbRayos.Visibility = Visibility.Collapsed;
            cejas.Visibility = Visibility.Collapsed;
            bocaSad.Visibility = Visibility.Collapsed;
            boca.Visibility = Visibility.Visible;
        }

        public void story()
        {
            Storyboard sb = (Storyboard)this.Resources["vuelo"];
            sb.Begin();
        }

        public event EventHandler StatusUpdated3;
        private void btnStory_Click(object sender, RoutedEventArgs e)
        {
            story();
            turnoIA = true;
            
            if (this.StatusUpdated3 != null)
                this.StatusUpdated3(this, new EventArgs());
        }



        private void muerte()
        {
            RotateTransform rotateTransform2 = new RotateTransform();
            rotateTransform2.Angle = 90;
            rotateTransform2.CenterX = 25;
            rotateTransform2.CenterY = 50;
            cnvPokemon.RenderTransform = rotateTransform2;
            desactivarBotones();
            ActivaCruces();
        }

        public void curar()
        {
            if (pbVida1.Value > 0.0)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += incrementarBarra;
                dtReloj.Start();
                btnPocima.Visibility = Visibility.Collapsed;
                pocionUtilizada = true;
                vida_actual = pbVida1.Value;
            }
            
        }

        private void incrementarBarra(object sender, object e)
        {
            if (vida_actual + 40.0 >= 100)
            {
                this.pbVida1.Value = 100.0;
            }
            else
            {
                this.pbVida1.Value = vida_actual + 40.0;
            }
            dtReloj.Stop();
        }

        public void activarBotones()
        {
            if (escudo_actual > 50.0 && escudo_actual <= 100.0)
            {
                btnGiroCuerno.IsEnabled = true;
            }
            if (escudo_actual > 0.0 && escudo_actual <= 100.0)
            {
                btnAtaque2.IsEnabled = true;
            }
            btnOjos.IsEnabled = true;
            if (pocionUtilizada == false)
            {
                btnPocima.IsEnabled = true;
            }
            btnStory.IsEnabled = true;
            tbTurno.Visibility = Visibility.Visible;
        }

        public void desactivarBotones()
        {
            btnGiroCuerno.IsEnabled = false;
            btnAtaque2.IsEnabled = false;
            btnOjos.IsEnabled = false;
            btnPocima.IsEnabled = false;
            btnStory.IsEnabled = false;
            tbTurno.Visibility = Visibility.Collapsed;
        }

        private void decrementarBarraVida(object sender, object e)
        {
            this.pbVida1.Value -= 1.0;
            if (pbVida1.Value == vida_actual - valor)
            {
                dtReloj.Stop();
            }
        }

        public void Herido(double valorpasado)
        {
            valor = valorpasado;
            vida_actual = this.pbVida1.Value;
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(80);
            dtReloj.Tick += decrementarBarraVida;
            dtReloj.Start();


            if (vida_actual - valor <= 25 && vida_actual - valor > 0)
            {
                cvnTirita.Visibility = Visibility.Visible;
                tirita1.Visibility = Visibility.Visible;

            }
            else if (vida_actual - valor <= 0.0)
            {
                cnvCruces.Visibility = Visibility.Visible;
                ojo_izq.Visibility = Visibility.Collapsed;
                Ojo_der.Visibility = Visibility.Collapsed;
                muerte();
                desactivarBotones();
            }
        }

        public void ocultarElementos()
        {
            pbVida1.Visibility = Visibility.Collapsed;
            pbEscudo1.Visibility = Visibility.Collapsed;
            imagen_cor.Visibility = Visibility.Collapsed;
            imag_escudo.Visibility = Visibility.Collapsed;
            btnPocima.Visibility = Visibility.Collapsed;
            btnAtaque2.Visibility = Visibility.Collapsed;
            btnGiroCuerno.Visibility = Visibility.Collapsed;
            btnOjos.Visibility = Visibility.Collapsed;
            btnStory.Visibility = Visibility.Collapsed;
        }

        public void ocultarBotones()
        {
            btnPocima.Visibility = Visibility.Collapsed;
            btnAtaque2.Visibility = Visibility.Collapsed;
            btnGiroCuerno.Visibility = Visibility.Collapsed;
            btnOjos.Visibility = Visibility.Collapsed;
            btnStory.Visibility = Visibility.Collapsed;
        }

        private async void pinCastform(object sender, PointerRoutedEventArgs e)
        {
            SecondaryTile myTile = new SecondaryTile("Favorito", "Dos", "Tres",
            new Uri("ms-appx:///imagenesCastform/castformNoF.png"),
            Windows.UI.StartScreen.TileSize.Square150x150);
            myTile.DisplayName = "Castform";
            myTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await myTile.RequestCreateAsync();
        }

        private void NotificacionSubida(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
                .AddArgument("action", "Favoritos")
                .AddArgument("conversationId", 9813)
                .AddText("Castform ha evolucionado")
                .AddText("Puedes ver más información en IPOkemon")
                .AddInlineImage(new Uri("ms-appx:///imagenesCastform/castformEvolucionNoF.png"))
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
            imgChinchetaCastform.Visibility = Visibility.Collapsed;
            imgPiedraCastform.Visibility = Visibility.Collapsed;
        }
    }
}
