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
    public sealed partial class PokemonCombateIndividual : Page
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
        static UserControl jugador;
        static UserControl bot;

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

        public PokemonCombateIndividual()
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
            this.mucSableye.StatusUpdated += new EventHandler(StatusUpdatedSableye1Async);
            this.mucSableye.StatusUpdated2 += new EventHandler(StatusUpdatedSableye2Async);
            this.mucSableye.StatusUpdated3 += new EventHandler(StatusUpdatedSableye3Async);
            this.mucSableye.StatusUpdated4 += new EventHandler(StatusUpdatedSableye4Async);

            this.mucPiplup.StatusUpdated += new EventHandler(StatusUpdatedPiplup1Async);
            this.mucPiplup.StatusUpdated2 += new EventHandler(StatusUpdatedPiplup2Async);
            this.mucPiplup.StatusUpdated3 += new EventHandler(StatusUpdatedPiplup3Async);
            this.mucPiplup.StatusUpdated4 += new EventHandler(StatusUpdatedPiplup4Async);

            this.mucTeddiursa.StatusUpdated += new EventHandler(StatusUpdatedOso1Async);
            this.mucTeddiursa.StatusUpdated2 += new EventHandler(StatusUpdatedOso2Async);
            this.mucTeddiursa.StatusUpdated3 += new EventHandler(StatusUpdatedOso3Async);
            this.mucTeddiursa.StatusUpdated4 += new EventHandler(StatusUpdatedOso4Async);
            this.mucTeddiursa.StatusUpdated5 += new EventHandler(StatusUpdatedOso5Async);
            this.mucTeddiursa.StatusUpdated6 += new EventHandler(StatusUpdatedOso6Async);

            this.mucCastform.StatusUpdated += new EventHandler(StatusUpdatedCastform1Async);
            this.mucCastform.StatusUpdated2 += new EventHandler(StatusUpdatedCastform2Async);
            this.mucCastform.StatusUpdated3 += new EventHandler(StatusUpdatedCastform3Async);
            this.mucCastform.StatusUpdated4 += new EventHandler(StatusUpdatedCastform4Async);
            this.mucCastform.StatusUpdated5 += new EventHandler(StatusUpdatedCastform5Async);
        }

        private async Task winSableyeAsync(object sender, object e)
        {


            if (vidaCastform <= 0.0)
            {
                mucCastform.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaSableye.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaPiplup <= 0.0)
            {
                mucPiplup.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaSableye.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaTeddiursa <= 0.0)
            {
                mucTeddiursa.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaSableye.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
        }

        private async Task winPiplupAsync(object sender, object e)
        {


            if (vidaCastform <= 0.0)
            {
                mucCastform.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaPiplup.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaSableye <= 0.0)
            {
                mucSableye.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaPiplup.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaTeddiursa <= 0.0)
            {
                mucTeddiursa.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaPiplup.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
        }

        private async Task winTeddiursaAsync(object sender, object e)
        {


            if (vidaCastform <= 0.0)
            {
                mucCastform.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaOso.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaSableye <= 0.0)
            {
                mucSableye.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaOso.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaPiplup <= 0.0)
            {
                mucPiplup.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaOso.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
        }

        private async Task winCastformAsync(object sender, object e)
        {


            if (vidaPiplup <= 0.0)
            {
                mucPiplup.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaCastform.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaSableye <= 0.0)
            {
                mucSableye.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaCastform.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
            else if (vidaTeddiursa <= 0.0)
            {
                mucTeddiursa.desactivarBotones();
                await Task.Delay(TimeSpan.FromSeconds(5));
                ganaCastform.Visibility = Visibility.Visible;
                btnRepetirIndividual.Visibility = Visibility.Visible;
                imgJugador1.Visibility = Visibility.Collapsed;
                imgMaquina.Visibility = Visibility.Collapsed;
            }
        }

        public async void StatusUpdatedSableye1Async(object sender, EventArgs e)
        {
            a1Sableye(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaPiplup > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a1Sableye(object sender, EventArgs e)
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
            
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winSableyeAsync(sender, e);
        }

        public async void StatusUpdatedSableye2Async(object sender, EventArgs e)
        {
            a2Sableye(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaPiplup > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a2Sableye(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winSableyeAsync(sender, e);
        }

        public async void StatusUpdatedSableye3Async(object sender, EventArgs e)
        {
            a3Sableye(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaPiplup > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a3Sableye(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winSableyeAsync(sender, e);
        }

        public async void StatusUpdatedSableye4Async(object sender, EventArgs e)
        {
            a4Sableye(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaPiplup > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a4Sableye(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }
        }

        public async void StatusUpdatedPiplup1Async(object sender, EventArgs e)
        {
            a1Piplup(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a1Piplup(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            

            winPiplupAsync(sender, e);
        }

        public async void StatusUpdatedPiplup2Async(object sender, EventArgs e)
        {
            a2Piplup(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a2Piplup(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }

            winPiplupAsync(sender, e);
        }

        public async void StatusUpdatedPiplup3Async(object sender, EventArgs e)
        {
            a3Piplup(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a3Piplup(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }

            winPiplupAsync(sender, e);
        }

        public async void StatusUpdatedPiplup4Async(object sender, EventArgs e)
        {
            a4Piplup(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaTeddiursa > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a4Piplup(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
        }

        public async void StatusUpdatedOso1Async(object sender, EventArgs e)
        {
            a1Oso(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a1Oso(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winTeddiursaAsync(sender, e);
        }

        public async void StatusUpdatedOso2Async(object sender, EventArgs e)
        {
            a2Oso(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a2Oso(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winTeddiursaAsync(sender, e);
        }

        public async void StatusUpdatedOso3Async(object sender, EventArgs e)
        {
            a3Oso(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a3Oso(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winTeddiursaAsync(sender, e);
        }

        public async void StatusUpdatedOso4Async(object sender, EventArgs e)
        {
            a4Oso(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }

        }

        public void a4Oso(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winTeddiursaAsync(sender, e);
        }

        public async void StatusUpdatedOso5Async(object sender, EventArgs e)
        {
            a5Oso(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a5Oso(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winTeddiursaAsync(sender, e);
        }

        public async void StatusUpdatedOso6Async(object sender, EventArgs e)
        {
            a6Oso(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaCastform > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a6Oso(object sender, EventArgs e)
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
            if (!bot.Equals(mucCastform))
            {
                mucCastform.activarBotones();
            }
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }
        }

        public async void StatusUpdatedCastform1Async(object sender, EventArgs e)
        {
            a1Castform(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaTeddiursa > 0.0) 
            { 
                algoritmoCombate(sender, e); 
            }
        }

        public void a1Castform(object sender, EventArgs e)
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
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winCastformAsync(sender, e);
        }

        public async void StatusUpdatedCastform2Async(object sender, EventArgs e)
        {
            a2Castform(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaTeddiursa > 0.0)
            {
                algoritmoCombate(sender, e);
            }

        }

        public void a2Castform(object sender, EventArgs e)
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
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winCastformAsync(sender, e);
        }

        public async void StatusUpdatedCastform3Async(object sender, EventArgs e)
        {
            a3Castform(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaTeddiursa > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a3Castform(object sender, EventArgs e)
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
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winCastformAsync(sender, e);
        }

        public async void StatusUpdatedCastform4Async(object sender, EventArgs e)
        {
            a4Castform(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaTeddiursa > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a4Castform(object sender, EventArgs e)
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
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }

            winCastformAsync(sender, e);
        }

        public async void StatusUpdatedCastform5Async(object sender, EventArgs e)
        {
            a5Castform(sender, e);
            await Task.Delay(TimeSpan.FromSeconds(10));
            if (vidaSableye > 0.0 && vidaPiplup > 0.0 && vidaTeddiursa > 0.0)
            {
                algoritmoCombate(sender, e);
            }
        }

        public void a5Castform(object sender, EventArgs e)
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
            if (!bot.Equals(mucSableye))
            {
                mucSableye.activarBotones();
            }
            if (!bot.Equals(mucTeddiursa))
            {
                mucTeddiursa.activarBotones();
            }
            if (!bot.Equals(mucPiplup))
            {
                mucPiplup.activarBotones();
            }
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
                tbSleccionarIndividual2.Visibility = Visibility.Collapsed;
                tbSleccionarIndividualIngles2.Visibility = Visibility.Collapsed;

                if (idioma.Equals("Español"))
                {
                    tbEleccionIndividual.Visibility = Visibility.Visible;
                    btnJugarIndividual.Visibility = Visibility.Visible;
                    btnSelecPokIndividual.Visibility = Visibility.Visible;

                    tbEleccionIndividualIngles.Visibility = Visibility.Collapsed;
                    btnJugarIndividualIngles.Visibility = Visibility.Collapsed;
                    btnSelecPokIndividualIngles.Visibility = Visibility.Collapsed;
                }
                else if (idioma.Equals("English"))
                {
                    tbEleccionIndividualIngles.Visibility = Visibility.Visible;
                    btnJugarIndividualIngles.Visibility = Visibility.Visible;
                    btnSelecPokIndividualIngles.Visibility = Visibility.Visible;

                    tbEleccionIndividual.Visibility = Visibility.Collapsed;
                    btnJugarIndividual.Visibility = Visibility.Collapsed;
                    btnSelecPokIndividual.Visibility = Visibility.Collapsed;
                }
            }
            else if (contador == 1)
            {
                tbSleccionarIndividual1.Visibility = Visibility.Collapsed;
                tbSleccionarIndividual2.Visibility = Visibility.Visible;

                if (idioma.Equals("Español"))
                {
                    tbSleccionarIndividual1.Visibility = Visibility.Collapsed;
                    tbSleccionarIndividual2.Visibility = Visibility.Visible;

                    tbSleccionarIndividualIngles1.Visibility = Visibility.Collapsed;
                    tbSleccionarIndividualIngles2.Visibility = Visibility.Collapsed;
                }
                else if (idioma.Equals("English"))
                {
                    tbSleccionarIndividualIngles1.Visibility = Visibility.Collapsed;
                    tbSleccionarIndividualIngles2.Visibility = Visibility.Visible;

                    tbSleccionarIndividual1.Visibility = Visibility.Collapsed;
                    tbSleccionarIndividual2.Visibility = Visibility.Collapsed;
                }

                if (sableyeSelect == true)
                {
                    jugador = mucSableye;
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
                    jugador = mucPiplup;
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
                    jugador = mucCastform;
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
                    jugador = mucTeddiursa;
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
            btnRepetirIndividual.Visibility = Visibility.Collapsed;
            vidaCastform = 100.0;
            vidaPiplup = 100.0;
            vidaSableye = 100.0;
            vidaTeddiursa = 100.0;
            Frame.Navigate(typeof(PokemonCombateIndividual), idioma);

        }

        private void empezarJuego(object sender, RoutedEventArgs e)
        {
            tbSleccionarIndividualIngles2.Visibility = Visibility.Collapsed;
            tbSleccionarIndividual2.Visibility = Visibility.Collapsed;
            tbEleccionIndividual.Visibility = Visibility.Collapsed;
            btnJugarIndividual.Visibility = Visibility.Collapsed;
            btnSelecPokIndividual.Visibility = Visibility.Collapsed;

            tbEleccionIndividualIngles.Visibility = Visibility.Collapsed;
            btnJugarIndividualIngles.Visibility = Visibility.Collapsed;
            btnSelecPokIndividualIngles.Visibility = Visibility.Collapsed;

            imgJugador1.Visibility = Visibility.Visible;
            imgMaquina.Visibility = Visibility.Visible;
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
            if (sableyeSelect == true && !jugador.Equals(mucSableye))
            {
                bot = mucSableye;
                mucSableye.ocultarBotones();
            }
            else if (pipluplSelect == true && !jugador.Equals(mucPiplup))
            {
                bot = mucPiplup;
                mucPiplup.ocultarBotones();
            }
            else if (teddiursaSelect == true && !jugador.Equals(mucTeddiursa))
            {
                bot = mucTeddiursa;
                mucTeddiursa.ocultarBotones();
            }
            else if (castformSelect == true && !jugador.Equals(mucCastform))
            {
                bot = mucCastform;
                mucCastform.ocultarBotones();
            }
        }

        private void volverSeleccionar(object sender, RoutedEventArgs e)
        {
            ganaSableye.Visibility = Visibility.Collapsed;
            ganaPiplup.Visibility = Visibility.Collapsed;
            ganaOso.Visibility = Visibility.Collapsed;
            ganaCastform.Visibility = Visibility.Collapsed;
            btnRepetirIndividual.Visibility = Visibility.Collapsed;
            vidaCastform = 100.0;
            vidaPiplup = 100.0;
            vidaSableye = 100.0;
            vidaTeddiursa = 100.0;
            Frame.Navigate(typeof(PokemonCombateIndividual), idioma);
        }

        public void algoritmoCombate(object sender, EventArgs e)
        {
            
            Random random = new Random();
            int num = 1;
            //(mucTeddiursa.ataqueTerminado == true)
            if (sableyeSelect == true && mucSableye.barraVidaSableye.Value == vidaSableye && vidaSableye > 0.0 && vidaCastform > 0.0 && vidaPiplup > 0.0 && vidaTeddiursa > 0.0 && !jugador.Equals(mucSableye) && (mucPiplup.turnoIA == true || mucTeddiursa.turnoIA == true || mucCastform.turnoIA == true))
            {
                num = random.Next(1, 3);
                bot = mucSableye;
                if (num == 1 && vidaSableye <= 50.0 && mucSableye.pocionUtilizada == false)
                {
                    StatusUpdatedSableye4Async(sender, e);
                    mucSableye.curar();
                    mucSableye.pocionUtilizada = true;
                    mucPiplup.turnoIA = false;
                    mucTeddiursa.turnoIA = false;
                    mucCastform.turnoIA = false;
                    mucTeddiursa.ataqueTerminado = false;
                }
                else if (num == 2 || vidaSableye > 50.0 || mucSableye.pocionUtilizada == true)
                {
                    num = random.Next(1, 4);
                    if (num == 1)
                    {
                        if (mucSableye.escudo_actual <= 100.0 && mucSableye.escudo_actual > 0.0)
                        {
                            StatusUpdatedSableye2Async(sender, e);
                            mucSableye.aranazo_maligno();
                            mucPiplup.turnoIA = false;
                            mucTeddiursa.turnoIA = false;
                            mucCastform.turnoIA = false;
                            mucTeddiursa.ataqueTerminado = false;
                        }
                        else if (mucSableye.escudo_actual <= 0.0)
                        {
                            num = random.Next(1, 3);
                            if (num == 1)
                            {
                                StatusUpdatedSableye1Async(sender, e);
                                mucSableye.ataqueBolaSombra();
                                mucPiplup.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedSableye3Async(sender, e);
                                mucSableye.destello_espejismo();
                                mucPiplup.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                        }
                    }
                    else if (num == 2)
                    {
                        StatusUpdatedSableye1Async(sender, e);
                        mucSableye.ataqueBolaSombra();
                        mucPiplup.turnoIA = false;
                        mucTeddiursa.turnoIA = false;
                        mucCastform.turnoIA = false;
                        mucTeddiursa.ataqueTerminado = false;
                    }
                    else if (num == 3)
                    {
                        StatusUpdatedSableye3Async(sender, e);
                        mucSableye.destello_espejismo();
                        mucPiplup.turnoIA = false;
                        mucTeddiursa.turnoIA = false;
                        mucCastform.turnoIA = false;
                        mucTeddiursa.ataqueTerminado = false;
                    }
                
                }

            }
            else if (pipluplSelect == true && mucPiplup.barraVidaPiplup.Value == vidaPiplup && (mucTeddiursa.ataqueTerminado == true || mucSableye.ataqueTerminado == true) && vidaPiplup > 0.0 && vidaCastform > 0.0 && vidaSableye > 0.0 && vidaTeddiursa > 0.0 && !jugador.Equals(mucPiplup) && (mucSableye.turnoIA == true || mucTeddiursa.turnoIA == true || mucCastform.turnoIA == true))
            {
                num = random.Next(1, 3);
                bot = mucPiplup;
                if (num == 1 && vidaPiplup <= 50.0 && mucPiplup.pocionUtilizada == false)
                {
                    StatusUpdatedPiplup4Async(sender, e);
                    mucPiplup.curar();
                    mucPiplup.pocionUtilizada = true;
                    mucSableye.turnoIA = false;
                    mucCastform.turnoIA = false;
                    mucTeddiursa.turnoIA = false;
                    mucTeddiursa.ataqueTerminado = false;
                    mucSableye.ataqueTerminado = false;
                }
                else if (num == 2 || vidaPiplup > 50.0 || mucPiplup.pocionUtilizada == true)
                {
                    num = random.Next(1, 4);
                    if (num == 1)
                    {
                        if (mucPiplup.escudo_actual <= 100.0 && mucPiplup.escudo_actual > 0.0)
                        {
                            StatusUpdatedPiplup1Async(sender, e);
                            mucPiplup.miradaPetrificadora();
                            mucSableye.turnoIA = false;
                            mucCastform.turnoIA = false;
                            mucTeddiursa.turnoIA = false;
                            mucTeddiursa.ataqueTerminado = false;
                            mucSableye.ataqueTerminado = false;
                        }
                        else if (mucPiplup.escudo_actual <= 0.0)
                        {
                            num = random.Next(1, 3);
                            if (num == 1)
                            {
                                StatusUpdatedPiplup3Async(sender, e);
                                mucPiplup.ataqueBomba();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucTeddiursa.ataqueTerminado = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedPiplup2Async(sender, e);
                                mucPiplup.piesRapidos();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucTeddiursa.ataqueTerminado = false;
                                mucSableye.ataqueTerminado = false;
                            }
                        }
                    }
                    else if (num == 2)
                    {
                        StatusUpdatedPiplup2Async(sender, e);
                        mucPiplup.piesRapidos();
                        mucSableye.turnoIA = false;
                        mucCastform.turnoIA = false;
                        mucTeddiursa.turnoIA = false;
                        mucTeddiursa.ataqueTerminado = false;
                        mucSableye.ataqueTerminado = false;
                    }
                    else if (num == 3)
                    {
                        StatusUpdatedPiplup3Async(sender, e);
                        mucPiplup.ataqueBomba();
                        mucSableye.turnoIA = false;
                        mucCastform.turnoIA = false;
                        mucTeddiursa.turnoIA = false;
                        mucTeddiursa.ataqueTerminado = false;
                        mucSableye.ataqueTerminado = false;
                    }
                }

            }
            else if (teddiursaSelect == true && mucTeddiursa.barraVidaTeddiursa.Value == vidaTeddiursa && vidaTeddiursa > 0.0 && vidaCastform > 0.0 && vidaSableye > 0.0 && vidaPiplup > 0.0 && !jugador.Equals(mucTeddiursa) && (mucPiplup.turnoIA == true || mucSableye.turnoIA == true || mucCastform.turnoIA == true))
            {
                num = random.Next(1, 3);
                bot = mucTeddiursa;
                if (num == 1 && vidaTeddiursa <= 50.0 && mucTeddiursa.pocionUtilizada == false)
                {
                    StatusUpdatedOso6Async(sender, e);
                    mucTeddiursa.curar();
                    mucTeddiursa.pocionUtilizada = true;
                    mucSableye.turnoIA = false;
                    mucCastform.turnoIA = false;
                    mucPiplup.turnoIA = false;
                    mucSableye.ataqueTerminado = false;
                }
                else if (num == 2 || vidaTeddiursa > 50.0 || mucTeddiursa.pocionUtilizada == true)
                {

                    num = random.Next(1, 6);
                    if (num == 1)
                    {
                        if (mucTeddiursa.escudo_actual <= 100.0 && mucTeddiursa.escudo_actual > 50.0)
                        {
                            StatusUpdatedOso1Async(sender, e);
                            mucTeddiursa.garras();
                            mucSableye.turnoIA = false;
                            mucCastform.turnoIA = false;
                            mucPiplup.turnoIA = false;
                            mucSableye.ataqueTerminado = false;
                        }
                        else if (mucTeddiursa.escudo_actual <= 50.0 && mucTeddiursa.escudo_actual > 0.0)
                        {
                            num = random.Next(1, 5);
                            if (num == 1)
                            {
                                StatusUpdatedOso5Async(sender, e);
                                mucTeddiursa.ojos();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedOso2Async(sender, e);
                                mucTeddiursa.laser();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 3)
                            {
                                StatusUpdatedOso3Async(sender, e);
                                mucTeddiursa.fuego();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 4)
                            {
                                StatusUpdatedOso4Async(sender, e);
                                mucTeddiursa.luna();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                        }
                        else if (mucTeddiursa.escudo_actual <= 0.0)
                        {
                            num = random.Next(1, 4);
                            if (num == 1)
                            {
                                StatusUpdatedOso5Async(sender, e);
                                mucTeddiursa.ojos();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedOso2Async(sender, e);
                                mucTeddiursa.laser();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 3)
                            {
                                StatusUpdatedOso4Async(sender, e);
                                mucTeddiursa.luna();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                        }
                    }
                    else if (num == 2)
                    {
                        StatusUpdatedOso2Async(sender, e);
                        mucTeddiursa.laser();
                        mucSableye.turnoIA = false;
                        mucCastform.turnoIA = false;
                        mucPiplup.turnoIA = false;
                        mucSableye.ataqueTerminado = false;
                    }
                    else if (num == 3)
                    {
                        if (mucTeddiursa.escudo_actual <= 100.0 && mucTeddiursa.escudo_actual > 0.0)
                        {
                            StatusUpdatedOso3Async(sender, e);
                            mucTeddiursa.fuego();
                            mucSableye.turnoIA = false;
                            mucCastform.turnoIA = false;
                            mucPiplup.turnoIA = false;
                            mucSableye.ataqueTerminado = false;
                        }
                        else if (mucTeddiursa.escudo_actual <= 0.0)
                        {
                            num = random.Next(1, 4);
                            if (num == 1)
                            {
                                StatusUpdatedOso5Async(sender, e);
                                mucTeddiursa.ojos();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedOso2Async(sender, e);
                                mucTeddiursa.laser();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                            else if (num == 3)
                            {
                                StatusUpdatedOso4Async(sender, e);
                                mucTeddiursa.luna();
                                mucSableye.turnoIA = false;
                                mucCastform.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                            }
                        }
                    }
                    else if (num == 4)
                    {
                        StatusUpdatedOso4Async(sender, e);
                        mucTeddiursa.luna();
                        mucSableye.turnoIA = false;
                        mucCastform.turnoIA = false;
                        mucPiplup.turnoIA = false;
                        mucSableye.ataqueTerminado = false;
                    }
                    else if (num == 5)
                    {
                        StatusUpdatedOso5Async(sender, e);
                        mucTeddiursa.ojos();
                        mucSableye.turnoIA = false;
                        mucCastform.turnoIA = false;
                        mucPiplup.turnoIA = false;
                        mucSableye.ataqueTerminado = false;
                    }
                }
            }

            else if (castformSelect == true && mucCastform.barraVidaCastform.Value == vidaCastform && (mucTeddiursa.ataqueTerminado == true || mucSableye.ataqueTerminado == true) && vidaCastform > 0.0 && vidaPiplup > 0.0 && vidaSableye > 0.0 && vidaTeddiursa > 0.0 && !jugador.Equals(mucCastform) && (mucPiplup.turnoIA == true || mucTeddiursa.turnoIA == true || mucSableye.turnoIA == true))
            {
                num = random.Next(1, 3);
                bot = mucCastform;
                if (num == 1 && vidaCastform <= 50.0 && mucCastform.pocionUtilizada == false)
                {
                    StatusUpdatedCastform5Async(sender, e);
                    mucCastform.curar();
                    mucCastform.pocionUtilizada = true;
                    mucSableye.turnoIA = false;
                    mucTeddiursa.turnoIA = false;
                    mucPiplup.turnoIA = false;
                    mucSableye.ataqueTerminado = false;
                    mucTeddiursa.ataqueTerminado = false;
                }
                else if (num == 2 || vidaCastform > 50.0 || mucCastform.pocionUtilizada == true)
                {

                    num = random.Next(1, 5);
                    if (num == 1)
                    {
                        if (mucCastform.escudo_actual <= 100.0 && mucCastform.escudo_actual > 50.0)
                        {
                            StatusUpdatedCastform1Async(sender, e);
                            mucCastform.cuerno();
                            mucSableye.turnoIA = false;
                            mucTeddiursa.turnoIA = false;
                            mucPiplup.turnoIA = false;
                            mucSableye.ataqueTerminado = false;
                            mucTeddiursa.ataqueTerminado = false;
                        }
                        else if (mucCastform.escudo_actual > 0.0 && mucCastform.escudo_actual <= 50.0)
                        {
                            num = random.Next(1, 4);
                            if (num == 1)
                            {
                                StatusUpdatedCastform4Async(sender, e);
                                mucCastform.tormenta();
                                mucSableye.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedCastform2Async(sender, e);
                                mucCastform.hipnosis();
                                mucSableye.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                            else if (num == 3)
                            {
                                StatusUpdatedCastform3Async(sender, e);
                                mucCastform.story();
                                mucSableye.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                        }
                        else if (mucCastform.escudo_actual <= 0.0)
                        {
                            num = random.Next(1, 3);
                            if (num == 1)
                            {
                                StatusUpdatedCastform3Async(sender, e);
                                mucCastform.story();
                                mucSableye.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedCastform2Async(sender, e);
                                mucCastform.hipnosis();
                                mucSableye.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                        }
                    }
                    else if (num == 2)
                    {
                        StatusUpdatedCastform2Async(sender, e);
                        mucCastform.hipnosis();
                        mucSableye.turnoIA = false;
                        mucTeddiursa.turnoIA = false;
                        mucPiplup.turnoIA = false;
                        mucSableye.ataqueTerminado = false;
                        mucTeddiursa.ataqueTerminado = false;
                    }
                    else if (num == 3)
                    {
                        StatusUpdatedCastform3Async(sender, e);
                        mucCastform.story();
                        mucSableye.turnoIA = false;
                        mucTeddiursa.turnoIA = false;
                        mucPiplup.turnoIA = false;
                        mucSableye.ataqueTerminado = false;
                        mucTeddiursa.ataqueTerminado = false;
                    }
                    else if (num == 4)
                    {
                        if (mucCastform.escudo_actual <= 100.0 && mucCastform.escudo_actual > 0.0)
                        {
                            StatusUpdatedCastform4Async(sender, e);
                            mucCastform.tormenta();
                            mucSableye.turnoIA = false;
                            mucTeddiursa.turnoIA = false;
                            mucPiplup.turnoIA = false;
                            mucSableye.ataqueTerminado = false;
                            mucTeddiursa.ataqueTerminado = false;
                        }
                        else if (mucCastform.escudo_actual <= 0.0)
                        {
                            num = random.Next(1, 3);
                            if (num == 1)
                            {
                                StatusUpdatedCastform3Async(sender, e);
                                mucCastform.story();
                                mucSableye.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                            else if (num == 2)
                            {
                                StatusUpdatedCastform2Async(sender, e);
                                mucCastform.hipnosis();
                                mucSableye.turnoIA = false;
                                mucTeddiursa.turnoIA = false;
                                mucPiplup.turnoIA = false;
                                mucSableye.ataqueTerminado = false;
                                mucTeddiursa.ataqueTerminado = false;
                            }
                        }
                    }
                }
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (idioma.Equals("Español"))
            {
                tituloIndividual.Visibility = Visibility.Visible;
                tbSleccionarIndividual1.Visibility = Visibility.Visible;
                tbSleccionarIndividual2.Visibility = Visibility.Collapsed;
                btnRepetirIndividual.Content = "Combatir de nuevo";

                tituloIndividualIngles.Visibility = Visibility.Collapsed;
                tbSleccionarIndividualIngles1.Visibility = Visibility.Collapsed;
                tbSleccionarIndividualIngles2.Visibility = Visibility.Collapsed;
            }
            else if (idioma.Equals("English"))
            {
                tbSleccionarIndividual1.Visibility = Visibility.Collapsed;
                tbSleccionarIndividual2.Visibility = Visibility.Collapsed;
                tituloIndividual.Visibility = Visibility.Collapsed;
                btnRepetirIndividual.Content = "Combat Again";

                tbSleccionarIndividualIngles1.Visibility = Visibility.Visible;
                tbSleccionarIndividualIngles2.Visibility = Visibility.Collapsed;
                tituloIndividualIngles.Visibility = Visibility.Visible;
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbEleccionIndividual.FontSize = 35;
            tbEleccionIndividualIngles.FontSize = 35;
            tbSleccionarIndividual1.FontSize = 35;
            tbSleccionarIndividual2.FontSize = 35;
            tbPiplup.FontSize = 35;
            tbSableye.FontSize = 35;
            tbSleccionarIndividualIngles1.FontSize = 35;
            tbSleccionarIndividualIngles2.FontSize = 35;
            tbTeddiursa.FontSize = 35;
            tbCastform.FontSize = 35;
            btnJugarIndividual.FontSize = 30;
            btnJugarIndividualIngles.FontSize = 30;
            btnRepetirIndividual.FontSize = 30;
            btnSelecPokIndividual.FontSize = 30;
            btnSelecPokIndividualIngles.FontSize = 30;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbEleccionIndividual.FontSize = 30;
            tbEleccionIndividualIngles.FontSize = 30;
            tbSleccionarIndividual1.FontSize = 30;
            tbSleccionarIndividual2.FontSize = 30;
            tbPiplup.FontSize = 30;
            tbSableye.FontSize = 30;
            tbSleccionarIndividualIngles1.FontSize = 30;
            tbSleccionarIndividualIngles2.FontSize = 30;
            tbTeddiursa.FontSize = 30;
            tbCastform.FontSize = 30;
            btnJugarIndividual.FontSize = 25;
            btnJugarIndividualIngles.FontSize = 25;
            btnRepetirIndividual.FontSize = 25;
            btnSelecPokIndividual.FontSize = 25;
            btnSelecPokIndividualIngles.FontSize = 25;
        }
    }
}
