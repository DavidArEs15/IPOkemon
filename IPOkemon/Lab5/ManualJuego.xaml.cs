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
    public sealed partial class ManualJuego : Page
    {
        string idioma = "Español";
        public ManualJuego()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            idioma = (string)e.Parameter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (idioma.Equals("Español"))
            {
                imgFuncionamiento.Visibility = Visibility.Visible;
                imgFuncionamientoIngles.Visibility = Visibility.Collapsed;
                imgTextoManual.Visibility = Visibility.Visible;
                imgTextoManualIngles.Visibility = Visibility.Collapsed;
                imgBotones.Visibility = Visibility.Visible;
                imgBotonesIngles.Visibility = Visibility.Collapsed;
                tbBotones.Text = "Ten cuidado con la barra de energía a la hora de seleccionar el ataque que tu Pokemon va a realizar en ese turno. Deberás saber que existen tres tipos de ataques, los cuales se identifican por el color del marco de su botón de activación: el rojo, que es el ataque más poderoso, pero el que más energía consume, el amarillo, que también es poderoso pero no tanto como el rojo, consumiendo por tanto una cantidad menor de energía, y por último los verdes, que son los ataques normales, que no hacen mucho daño y por tanto no gastan energía. Hay que tener en cuenta que si la energía de la barra se gasta, no podrás elegir los ataques poderosos hasta que se recargue de nuevo. Cuidado también con los ataques rojos, ya que para algunos de ellos necesitas que tu energía supere un determinado límite para que se puedan emplear, así que úsalos sabiamente.";
                tbFuncionamiento.Text = "Para comenzar, deberá elegir una de las dos modalidades de juego. Por un lado, podrás combatir con amigos en el modo multijugador, donde cada uno manejará un Pokemon, y por otro, el modo individual, donde podrás pelear contra nuestra IA. Después de seleccionar los Pokemon que participarán en el combate y de pulsar Jugar, comenzará el juego. Los combates van por turnos, de modo que no podrás realizar ninguna acción hasta que el contrincante termine su turno, de forma que hasta que el contrincante no haya acabado su ataque, no podrás actuar. Una vez sea tu turno, deberás decidir si realizar un ataque, teniendo en cuenta la barra de energía a la hora de seleccionar el movimiento en cuestión, o, en cambio, curar al Pokemon, pulsando en el ítem de la poción, ¡Pero cuidado, úsala sabiamente, ya que solo se podrá emplear una vez y gastará el turno! El combate finalizará cuando la vida de uno de los dos Pokemon llegue a cero, momento en el cual se mostrará una pantalla donde se presume al Pokemon ganador, además de dar la opción de combatir de nuevo, pulsando el botón correspondiente.";
            }
            else if (idioma.Equals("English"))
            {
                imgFuncionamiento.Visibility = Visibility.Collapsed;
                imgFuncionamientoIngles.Visibility = Visibility.Visible;
                imgTextoManual.Visibility = Visibility.Collapsed;
                imgTextoManualIngles.Visibility = Visibility.Visible;
                imgBotones.Visibility = Visibility.Collapsed;
                imgBotonesIngles.Visibility = Visibility.Visible;
                tbBotones.Text = "Be careful with the energy bar when selecting the attack that your Pokemon is going to perform on that turn. You should know that there are three types of attacks, which are identified by the color of the frame of their activation button: red, which is the most powerful attack, but the one that consumes the most energy, yellow, which is also powerful but does not as much as the red one, therefore consuming a smaller amount of energy, and finally the green ones, which are normal attacks, which do not do much damage and therefore do not spend energy. Note that if the energy bar runs out, you won't be able to choose powerful attacks until it recharges again. Also watch out for red attacks, as some of them require your energy to exceed a certain limit before they can be used, so use them wisely.";
                tbFuncionamiento.Text = "To start, you will have to choose one of the two game modes. On the one hand, you will be able to battle with friends in the multiplayer mode, where each one will manage a Pokemon, and on the other hand, the individual mode, where you will be able to fight against our AI. After selecting the Pokemon that will participate in the battle and pressing Play, the game will start. The battles are turn-based, so you will not be able to perform any action until the opponent finishes his turn, so until the opponent has finished his attack, you will not be able to act. Once it is your turn, you must decide whether to perform an attack, taking into account the energy bar when selecting the move in question, or, instead, heal the Pokemon, by clicking on the potion item, but be careful, use it wisely, as it can only be used once and you will spend your turn! The battle will end when the life of one of the two battling Pokemon reaches zero, at which point a screen will be displayed where the winning Pokemon is presumed, as well as giving the option to battle again, by pressing the corresponding button.";
            }
        }

        private void imgAumentar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Collapsed;
            imgDisminuir.Visibility = Visibility.Visible;

            tbFuncionamiento.FontSize = 18;
            tbBotones.FontSize = 18;
        }

        private void imgDisminuir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            imgAumentar.Visibility = Visibility.Visible;
            imgDisminuir.Visibility = Visibility.Collapsed;

            tbFuncionamiento.FontSize = 15;
            tbBotones.FontSize = 15;
        }
    }
}
