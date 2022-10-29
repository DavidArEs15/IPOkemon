using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab5
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CombatePokemon : Page
    {
        string idioma = "Español";
        int contador = 0;
        DispatcherTimer ganarReloj;
        Boolean sableyeSelect = false;
        Boolean castformSelect = false;
        Boolean pipluplSelect = false;
        Boolean teddiursaSelect = false;
        static double vidaSableye = 100.0;
        static double vidaCastform = 100.0;
        static double vidaPiplup = 100.0;
        static double vidaTeddiursa = 100.0;

        public Boolean selectSabeye
        {
            get { return this.sableyeSelect; }
            set { this.sableyeSelect = value; }
        }

        public Boolean selectCastform
        {
            get { return this.castformSelect; }
            set { this.castformSelect = value; }
        }

        public Boolean selectPiplup
        {
            get { return this.pipluplSelect; }
            set { this.pipluplSelect = value; }
        }

        public Boolean selectTeddiursa
        {
            get { return this.teddiursaSelect; }
            set { this.teddiursaSelect = value; }
        }

        public CombatePokemon()
        {
            this.InitializeComponent();
            mucCastform.ocultarImgAbajo();
            mucSableye.ocultarImgAbajo();
            mucTeddiursa.ocultarImgAbajo();
            mucPiplup.ocultarImgAbajo();
            vidaSableye = 100.0;
            vidaCastform = 100.0;
            vidaPiplup = 100.0;
            vidaTeddiursa = 100.0;
            this.mucSableye.StatusUpdated += new EventHandler(StatusUpdatedSableye1);
            this.mucSableye.StatusUpdated2 += new EventHandler(StatusUpdatedSableye2);
            this.mucSableye.StatusUpdated3 += new EventHandler(StatusUpdatedSableye3);
            this.mucSableye.StatusUpdated4 += new EventHandler(StatusUpdatedSableye4);

            this.mucPiplup.StatusUpdated += new EventHandler(StatusUpdatedPiplup1);
            this.mucPiplup.StatusUpdated2 += new EventHandler(StatusUpdatedPiplup2);
            this.mucPiplup.StatusUpdated3 += new EventHandler(StatusUpdatedPiplup3);
            this.mucPiplup.StatusUpdated4 += new EventHandler(StatusUpdatedPiplup4);

            this.mucTeddiursa.StatusUpdated += new EventHandler(StatusUpdatedOso1);
            this.mucTeddiursa.StatusUpdated2 += new EventHandler(StatusUpdatedOso2);
            this.mucTeddiursa.StatusUpdated3 += new EventHandler(StatusUpdatedOso3);
            this.mucTeddiursa.StatusUpdated4 += new EventHandler(StatusUpdatedOso4);
            this.mucTeddiursa.StatusUpdated5 += new EventHandler(StatusUpdatedOso5);
            this.mucTeddiursa.StatusUpdated6 += new EventHandler(StatusUpdatedOso6);

            this.mucCastform.StatusUpdated += new EventHandler(StatusUpdatedCastform1);
            this.mucCastform.StatusUpdated2 += new EventHandler(StatusUpdatedCastform2);
            this.mucCastform.StatusUpdated3 += new EventHandler(StatusUpdatedCastform3);
            this.mucCastform.StatusUpdated4 += new EventHandler(StatusUpdatedCastform4);
            this.mucCastform.StatusUpdated5 += new EventHandler(StatusUpdatedCastform5);
        }

        private async Task winSableyeAsync(object sender, object e)
        {
            

            if (vidaCastform <= 0.0)
            {
                mucCastform.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaSableye.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaPiplup <= 0.0)
            {
                mucPiplup.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaSableye.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaTeddiursa <= 0.0)
            {
                mucTeddiursa.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaSableye.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
        }

        private async Task winPiplupAsync(object sender, object e)
        {
            

            if (vidaCastform <= 0.0)
            {
                mucCastform.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaPiplup.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaSableye <= 0.0)
            {
                mucSableye.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaPiplup.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaTeddiursa <= 0.0)
            {
                mucTeddiursa.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaPiplup.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
        }

        private async Task winTeddiursaAsync(object sender, object e)
        {
            

            if (vidaCastform <= 0.0)
            {
                mucCastform.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaOso.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaSableye <= 0.0)
            {
                mucSableye.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaOso.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaPiplup <= 0.0)
            {
                mucPiplup.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaOso.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
        }

        private async Task winCastformAsync(object sender, object e)
        {
            

            if (vidaPiplup <= 0.0)
            {
                mucPiplup.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaCastform.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaSableye <= 0.0)
            {
                mucSableye.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaCastform.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
            else if (vidaTeddiursa <= 0.0)
            {
                mucTeddiursa.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(10));
                ganaCastform.Visibility = Visibility.Visible;
                btnRepetir.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgJugador2.Visibility = Visibility.Collapsed;
            }
        }

        public void StatusUpdatedSableye1(object sender, EventArgs e)
        {
            mucPiplup.Herido(20.0);
            mucCastform.Herido(20.0);
            mucTeddiursa.Herido(20.0);

            if (pipluplSelect == true)
            {
                vidaPiplup -= 20.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 20.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 20.0;
            }

            mucSableye.desactivarBotones();
            mucCastform.activarBotones();
            mucPiplup.activarBotones();
            mucTeddiursa.activarBotones();

            winSableyeAsync(sender, e);
        }

        public void StatusUpdatedSableye2(object sender, EventArgs e)
        {
            mucPiplup.Herido(35.0);
            mucCastform.Herido(35.0);
            mucTeddiursa.Herido(35.0);

            if (pipluplSelect == true)
            {
                vidaPiplup -= 35.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 35.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 35.0;
            }

            mucSableye.desactivarBotones();
            mucCastform.activarBotones();
            mucPiplup.activarBotones();
            mucTeddiursa.activarBotones();

            winSableyeAsync(sender, e);
        }

        public void StatusUpdatedSableye3(object sender, EventArgs e)
        {
            mucPiplup.Herido(10.0);
            mucCastform.Herido(10.0);
            mucTeddiursa.Herido(10.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 10.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 10.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 10.0;
            }

            mucSableye.desactivarBotones();
            mucCastform.activarBotones();
            mucPiplup.activarBotones();
            mucTeddiursa.activarBotones();

            winSableyeAsync(sender, e);
        }

        public void StatusUpdatedSableye4(object sender, EventArgs e)
        {
            if (vidaSableye + 40 <= 100.0)
            {
                vidaSableye += 40.0;
            }
            else
            {
                vidaSableye = 100.0;
            }

            mucSableye.desactivarBotones();
            mucCastform.activarBotones();
            mucPiplup.activarBotones();
            mucTeddiursa.activarBotones();
        }

            public void StatusUpdatedPiplup1(object sender, EventArgs e)
        {
            mucSableye.Herido(35.0);
            mucCastform.Herido(35.0);
            mucTeddiursa.Herido(35.0);
            if (sableyeSelect == true)
            {
                vidaSableye -= 35.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 35.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 35.0;
            }

            mucPiplup.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucTeddiursa.activarBotones();

            winPiplupAsync(sender, e);
        }

        public void StatusUpdatedPiplup2(object sender, EventArgs e)
        {
            mucSableye.Herido(5.0);
            mucCastform.Herido(5.0);
            mucTeddiursa.Herido(5.0);
            if (sableyeSelect == true)
            {
                vidaSableye -= 5.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 5.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 5.0;
            }
           
            mucPiplup.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucTeddiursa.activarBotones();

            winPiplupAsync(sender, e);
        }

        public void StatusUpdatedPiplup3(object sender, EventArgs e)
        {
            mucSableye.Herido(20.0);
            mucCastform.Herido(20.0);
            mucTeddiursa.Herido(20.0);
            if (sableyeSelect == true)
            {
                vidaSableye -= 20.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 20.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 20.0;
            }

            mucPiplup.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucTeddiursa.activarBotones();

            winPiplupAsync(sender, e);
        }

        public void StatusUpdatedPiplup4(object sender, EventArgs e)
        {
            if (vidaPiplup + 40 <= 100.0)
            {
                vidaPiplup += 40.0;
            }
            else
            {
                vidaPiplup = 100.0;
            }

            mucPiplup.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucTeddiursa.activarBotones();
        }

            public void StatusUpdatedOso1(object sender, EventArgs e)
        {
            mucPiplup.Herido(35.0);
            mucSableye.Herido(35.0);
            mucCastform.Herido(35.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 35.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 35.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 35.0;
            }

            mucTeddiursa.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winTeddiursaAsync(sender, e);
        }

        public void StatusUpdatedOso2(object sender, EventArgs e)
        {
            mucPiplup.Herido(15.0);
            mucSableye.Herido(15.0);
            mucCastform.Herido(15.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 15.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 15.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 15.0;
            }

            mucTeddiursa.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winTeddiursaAsync(sender, e);
        }

        public void StatusUpdatedOso3(object sender, EventArgs e)
        {
            mucPiplup.Herido(25.0);
            mucSableye.Herido(25.0);
            mucCastform.Herido(25.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 25.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 25.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 25.0;
            }

            mucTeddiursa.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winTeddiursaAsync(sender, e);
        }

        public void StatusUpdatedOso4(object sender, EventArgs e)
        {
            mucPiplup.Herido(5.0);
            mucSableye.Herido(5.0);
            mucCastform.Herido(5.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 5.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 5.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 5.0;
            }

            mucTeddiursa.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winTeddiursaAsync(sender, e);
        }

        public void StatusUpdatedOso5(object sender, EventArgs e)
        {
            mucPiplup.Herido(10.0);
            mucSableye.Herido(10.0);
            mucCastform.Herido(10.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 10.0;
            }
            else if (castformSelect == true)
            {
                vidaCastform -= 10.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 10.0;
            }

            mucTeddiursa.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winTeddiursaAsync(sender, e);
        }

        public void StatusUpdatedOso6(object sender, EventArgs e)
        {
            if (vidaTeddiursa + 40 <= 100.0)
            {
                vidaTeddiursa += 40.0;
            }
            else
            {
                vidaTeddiursa = 100.0;
            }


            mucTeddiursa.desactivarBotones();
            mucCastform.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();
        }

            public void StatusUpdatedCastform1(object sender, EventArgs e)
        {
            mucPiplup.Herido(35.0);
            mucSableye.Herido(35.0);
            mucTeddiursa.Herido(35.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 35.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 35.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 35.0;
            }

            mucCastform.desactivarBotones();
            mucTeddiursa.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winCastformAsync(sender, e);
        }

        public void StatusUpdatedCastform2(object sender, EventArgs e)
        {
            mucPiplup.Herido(15.0);
            mucSableye.Herido(15.0);
            mucTeddiursa.Herido(15.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 15.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 15.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 15.0;
            }

            mucCastform.desactivarBotones();
            mucTeddiursa.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winCastformAsync(sender, e);
        }

        public void StatusUpdatedCastform3(object sender, EventArgs e)
        {
            mucPiplup.Herido(10.0);
            mucSableye.Herido(10.0);
            mucTeddiursa.Herido(10.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 10.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 10.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 10.0;
            }

            mucCastform.desactivarBotones();
            mucTeddiursa.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winCastformAsync(sender, e);
        }

        public void StatusUpdatedCastform4(object sender, EventArgs e)
        {
            mucPiplup.Herido(25.0);
            mucSableye.Herido(25.0);
            mucTeddiursa.Herido(25.0);
            if (pipluplSelect == true)
            {
                vidaPiplup -= 25.0;
            }
            else if (teddiursaSelect == true)
            {
                vidaTeddiursa -= 25.0;
            }
            else if (sableyeSelect == true)
            {
                vidaSableye -= 25.0;
            }

            mucCastform.desactivarBotones();
            mucTeddiursa.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();

            winCastformAsync(sender, e);
        }

        public void StatusUpdatedCastform5(object sender, EventArgs e)
        {
            if (vidaCastform + 40 <= 100.0)
            {
                vidaCastform += 40.0;
            }
            else
            {
                vidaCastform = 100.0;
            }

            mucCastform.desactivarBotones();
            mucTeddiursa.activarBotones();
            mucSableye.activarBotones();
            mucPiplup.activarBotones();
        }

            public void sableyeSeleccionado(object sender, PointerRoutedEventArgs e)
        {
            imgSableye.Visibility = Visibility.Collapsed;
            tbSableye.Visibility = Visibility.Collapsed;
            sableyeSelect = true;
            contador += 1;
            comprobarContador();
        }

        public void teddiursaSeleccionado(object sender, PointerRoutedEventArgs e)
        {
            imgOso.Visibility = Visibility.Collapsed;
            tbTeddiursa.Visibility = Visibility.Collapsed;
            teddiursaSelect = true;
            contador += 1;
            comprobarContador();
        }

        public void castformSeleccionado(object sender, PointerRoutedEventArgs e)
        {
            imgCastform.Visibility = Visibility.Collapsed;
            tbCastform.Visibility = Visibility.Collapsed;
            castformSelect = true;
            contador += 1;
            comprobarContador();
        }

        public void piplupSeleccionado(object sender, PointerRoutedEventArgs e)
        {
            imgPiplup.Visibility = Visibility.Collapsed;
            tbPiplup.Visibility = Visibility.Collapsed;
            pipluplSelect = true;
            contador += 1;
            comprobarContador();
        }

        private void comprobarContador()
        {
            if (contador >= 2)
            {
                imgCastform.Visibility = Visibility.Collapsed;
                imgOso.Visibility = Visibility.Collapsed;
                imgPiplup.Visibility = Visibility.Collapsed;
                imgSableye.Visibility = Visibility.Collapsed;
                tbCastform.Visibility = Visibility.Collapsed;
                tbPiplup.Visibility = Visibility.Collapsed;
                tbSableye.Visibility = Visibility.Collapsed;
                tbTeddiursa.Visibility = Visibility.Collapsed;
                tbSleccionarMultijugador2.Visibility = Visibility.Collapsed;
                tbSleccionarMultijugadorIngles2.Visibility = Visibility.Collapsed;

                if (idioma.Equals("Español"))
                {
                    tbEleccionMultijugador.Visibility = Visibility.Visible;
                    btnJugarMultijugador.Visibility = Visibility.Visible;
                    btnSelecPokMultijugador.Visibility = Visibility.Visible;

                    tbEleccionMultijugadorIngles.Visibility = Visibility.Collapsed;
                    btnJugarMultijugadorIngles.Visibility = Visibility.Collapsed;
                    btnSelecPokMultijugadorIngles.Visibility = Visibility.Collapsed;
                }
                else if (idioma.Equals("English"))
                {
                    tbEleccionMultijugador.Visibility = Visibility.Collapsed;
                    btnJugarMultijugador.Visibility = Visibility.Collapsed;
                    btnSelecPokMultijugador.Visibility = Visibility.Collapsed;

                    tbEleccionMultijugadorIngles.Visibility = Visibility.Visible;
                    btnJugarMultijugadorIngles.Visibility = Visibility.Visible;
                    btnSelecPokMultijugadorIngles.Visibility = Visibility.Visible;
                }
            }
            else if (contador == 1)
            {

                if (idioma.Equals("Español"))
                {
                    tbSleccionarMultijugador1.Visibility = Visibility.Collapsed;
                    tbSleccionarMultijugador2.Visibility = Visibility.Visible;

                    tbSleccionarMultijugadorIngles1.Visibility = Visibility.Collapsed;
                    tbSleccionarMultijugadorIngles2.Visibility = Visibility.Collapsed;
                }
                else if (idioma.Equals("English"))
                {
                    tbSleccionarMultijugadorIngles1.Visibility = Visibility.Collapsed;
                    tbSleccionarMultijugadorIngles2.Visibility = Visibility.Visible;

                    tbSleccionarMultijugador1.Visibility = Visibility.Collapsed;
                    tbSleccionarMultijugador2.Visibility = Visibility.Collapsed;
                }

                if (sableyeSelect == true)
                {
                    desplazarMUCsableye(1120);
                    mucSableye.activarBotones();
                    desplazarMUCteddiursa(550);
                    mucTeddiursa.desactivarBotones();
                    desplazarMUCcastform(580);
                    mucCastform.desactivarBotones();
                    desplazarMUCpiplup(550);
                    mucPiplup.desactivarBotones();
                }
                else if (pipluplSelect == true)
                {
                    desplazarMUCsableye(580);
                    mucSableye.desactivarBotones();
                    desplazarMUCteddiursa(550);
                    mucTeddiursa.desactivarBotones();
                    desplazarMUCcastform(580);
                    mucCastform.desactivarBotones();
                    desplazarMUCpiplup(1120);
                    mucPiplup.activarBotones();
                }
                else if (castformSelect == true)
                {
                    desplazarMUCcastform(1120);
                    mucCastform.activarBotones();
                    desplazarMUCpiplup(550);
                    mucPiplup.desactivarBotones();
                    desplazarMUCsableye(580);
                    mucSableye.desactivarBotones();
                    desplazarMUCteddiursa(550);
                    mucTeddiursa.desactivarBotones();
                }
                else if (teddiursaSelect == true)
                {
                    desplazarMUCteddiursa(1120);
                    mucTeddiursa.activarBotones();
                    desplazarMUCcastform(580);
                    mucCastform.desactivarBotones();
                    desplazarMUCpiplup(550);
                    mucPiplup.desactivarBotones();
                    desplazarMUCsableye(580);
                    mucSableye.desactivarBotones();
                }
            }
        }

        private void desplazarMUCsableye(int valor)
        {
            var transform = this.mucSableye.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.mucSableye.RenderTransform = transform;
            }
            this.mucSableye.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbLateral = new DoubleAnimation
            {
                To = valor,
                From = 100,
                Duration = TimeSpan.FromMilliseconds(0),
            };
            Storyboard.SetTarget(dbLateral, this.mucSableye);
            var axis = "X";
            Storyboard.SetTargetProperty(dbLateral, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbLateral = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbLateral.Children.Add(dbLateral);
            sbLateral.Begin();
        }

        private void desplazarMUCteddiursa(int valor)
        {
            var transform = this.mucTeddiursa.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.mucTeddiursa.RenderTransform = transform;
            }
            this.mucTeddiursa.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbLateral = new DoubleAnimation
            {
                To = valor,
                From = 100,
                Duration = TimeSpan.FromMilliseconds(0),
            };
            Storyboard.SetTarget(dbLateral, this.mucTeddiursa);
            var axis = "X";
            Storyboard.SetTargetProperty(dbLateral, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbLateral = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbLateral.Children.Add(dbLateral);
            sbLateral.Begin();
        }

        private void desplazarMUCcastform(int valor)
        {
            var transform = this.mucCastform.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.mucCastform.RenderTransform = transform;
            }
            this.mucCastform.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbLateral = new DoubleAnimation
            {
                To = valor,
                From = 100,
                Duration = TimeSpan.FromMilliseconds(0),
            };
            Storyboard.SetTarget(dbLateral, this.mucCastform);
            var axis = "X";
            Storyboard.SetTargetProperty(dbLateral, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbLateral = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbLateral.Children.Add(dbLateral);
            sbLateral.Begin();
        }

        private void desplazarMUCpiplup(int valor)
        {
            var transform = this.mucPiplup.RenderTransform as CompositeTransform;

            if (transform == null)
            {
                transform = new CompositeTransform();
                this.mucPiplup.RenderTransform = transform;
            }
            this.mucPiplup.RenderTransformOrigin = new Point(0.5, 0.5);

            var dbLateral = new DoubleAnimation
            {
                To = valor,
                From = 100,
                Duration = TimeSpan.FromMilliseconds(0),
            };
            Storyboard.SetTarget(dbLateral, this.mucPiplup);
            var axis = "X";
            Storyboard.SetTargetProperty(dbLateral, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");

            var sbLateral = new Storyboard
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };

            sbLateral.Children.Add(dbLateral);
            sbLateral.Begin();
        }

        private void tbTeddiursa_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void tbPiplup_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void tbCastform_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void tbSleccionar_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btnRepetir_Click(object sender, RoutedEventArgs e)
        {
            ganaSableye.Visibility = Visibility.Collapsed;
            ganaPiplup.Visibility = Visibility.Collapsed;
            ganaOso.Visibility = Visibility.Collapsed;
            ganaCastform.Visibility = Visibility.Collapsed;
            btnRepetir.Visibility = Visibility.Collapsed;
            vidaCastform = 100.0;
            vidaPiplup = 100.0;
            vidaSableye = 100.0;
            vidaTeddiursa = 100.0;
            Frame.Navigate(typeof(CombatePokemon), idioma);

        }

        private void empezarJuego(object sender, RoutedEventArgs e)
        {
            tbEleccionMultijugador.Visibility = Visibility.Collapsed;
            btnJugarMultijugador.Visibility = Visibility.Collapsed;
            btnSelecPokMultijugador.Visibility = Visibility.Collapsed;

            tbEleccionMultijugadorIngles.Visibility = Visibility.Collapsed;
            btnJugarMultijugadorIngles.Visibility = Visibility.Collapsed;
            btnSelecPokMultijugadorIngles.Visibility = Visibility.Collapsed;

            imgJugador1.Visibility = Visibility.Visible;
            imgJugador2.Visibility = Visibility.Visible;
            if (sableyeSelect == true)
            {
                mucSableye.Visibility = Visibility.Visible;
            }
            if (pipluplSelect == true)
            {
                mucPiplup.Visibility = Visibility.Visible;
            }
            if (teddiursaSelect == true)
            {
                mucTeddiursa.Visibility = Visibility.Visible;
            }
            if (castformSelect == true)
            {
                mucCastform.Visibility = Visibility.Visible;
            }
        }

        private void volverSeleccionar(object sender, RoutedEventArgs e)
        {
            ganaSableye.Visibility = Visibility.Collapsed;
            ganaPiplup.Visibility = Visibility.Collapsed;
            ganaOso.Visibility = Visibility.Collapsed;
            ganaCastform.Visibility = Visibility.Collapsed;
            btnRepetir.Visibility = Visibility.Collapsed;
            vidaCastform = 100.0;
            vidaPiplup = 100.0;
            vidaSableye = 100.0;
            vidaTeddiursa = 100.0;
            Frame.Navigate(typeof(CombatePokemon), idioma);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (idioma.Equals("Español"))
            {
                tbTítuloMultijugador.Visibility = Visibility.Visible;
                tbSleccionarMultijugador1.Visibility = Visibility.Visible;
                tbSleccionarMultijugador2.Visibility = Visibility.Collapsed;
                btnRepetir.Content = "Combatir de nuevo";

                tbTítuloMultijugadorIngles.Visibility = Visibility.Collapsed;
                tbSleccionarMultijugadorIngles1.Visibility = Visibility.Collapsed;
                tbSleccionarMultijugadorIngles2.Visibility = Visibility.Collapsed;
            }
            else if (idioma.Equals("English"))
            {
                tbTítuloMultijugadorIngles.Visibility = Visibility.Visible;
                tbSleccionarMultijugadorIngles1.Visibility = Visibility.Visible;
                tbSleccionarMultijugadorIngles2.Visibility = Visibility.Collapsed;
                btnRepetir.Content = "Combat Again";

                tbTítuloMultijugador.Visibility = Visibility.Collapsed;
                tbSleccionarMultijugador1.Visibility = Visibility.Collapsed;
                tbSleccionarMultijugador2.Visibility = Visibility.Collapsed;
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbEleccionMultijugador.FontSize = 35;
            tbEleccionMultijugadorIngles.FontSize = 35;
            tbSleccionarMultijugador1.FontSize = 35;
            tbSleccionarMultijugador2.FontSize = 35;
            tbPiplup.FontSize = 35;
            tbSableye.FontSize = 35;
            tbSleccionarMultijugadorIngles1.FontSize = 35;
            tbSleccionarMultijugadorIngles2.FontSize = 35;
            tbTeddiursa.FontSize = 35;
            tbCastform.FontSize = 35;
            btnJugarMultijugador.FontSize = 30;
            btnJugarMultijugadorIngles.FontSize = 30;
            btnRepetir.FontSize = 30;
            btnSelecPokMultijugador.FontSize = 30;
            btnSelecPokMultijugadorIngles.FontSize = 30;

        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbEleccionMultijugador.FontSize = 30;
            tbEleccionMultijugadorIngles.FontSize = 30;
            tbSleccionarMultijugador1.FontSize = 30;
            tbSleccionarMultijugador2.FontSize = 30;
            tbPiplup.FontSize = 30;
            tbSableye.FontSize = 30;
            tbSleccionarMultijugadorIngles1.FontSize = 30;
            tbSleccionarMultijugadorIngles2.FontSize = 30;
            tbTeddiursa.FontSize = 30;
            tbCastform.FontSize = 30;
            btnJugarMultijugador.FontSize = 25;
            btnJugarMultijugadorIngles.FontSize = 25;
            btnRepetir.FontSize = 25;
            btnSelecPokMultijugador.FontSize = 25;
            btnSelecPokMultijugadorIngles.FontSize = 25;
        }
    }
}
