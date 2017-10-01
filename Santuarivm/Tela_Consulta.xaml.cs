using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Media;
using WMPLib;




namespace Santuarivm
{

    /// <summary>
    /// Interaction logic for Tela_Consulta.xaml
    /// </summary>
    public partial class Tela_Consulta : Window
    {
        Animacoes movimentos;
        internal ArvoreBin arvore;
        Animal animal;
        WindowsMediaPlayer somAnimal = new WindowsMediaPlayer();
        
        
        SoundPlayer musicaFundo = new SoundPlayer();
        
        ImageSource somon = new BitmapImage(new Uri("Imagens/somon.png", UriKind.Relative));
        ImageSource somoff = new BitmapImage(new Uri("Imagens/somoff.png", UriKind.Relative));
        bool audioMusica, audioAnimal;

        public Tela_Consulta()
        {
            InitializeComponent();
            movimentos = new Animacoes()
            {
                AquecerAoSol = FindResource("AquecerAoSol") as Storyboard,
                Bicar = FindResource("Bicar") as Storyboard,
                BotarOvo = FindResource("BotarOvo") as Storyboard,
                Comer = FindResource("Comer") as Storyboard,
                CorrerDireita = FindResource("CorrerDireita") as Storyboard,
                CorrerEsquerda = FindResource("CorrerEsquerda") as Storyboard,
                Direita = FindResource("Direita") as Storyboard,
                Esquerda = FindResource("Esquerda") as Storyboard,
                IrParaAgua = FindResource("IrParaAgua") as Storyboard,
                IrParaSuperficie = FindResource("IrParaSuperficie") as Storyboard,
                Mergulhar = FindResource("Mergulhar") as Storyboard,
                RastejarDireita = FindResource("RastejarDireita") as Storyboard,
                RastejarEsquerda = FindResource("RastejarEsquerda") as Storyboard,
                VoarBaixo = FindResource("VoarBaixo") as Storyboard,
                VoarCima = FindResource("VoarCima") as Storyboard,
                Amamentar = FindResource("Amamentar") as Storyboard
            };


            image3.Visibility = Visibility.Hidden;
            groupBox.Visibility = Visibility.Hidden;
            audioAnimal = audioMusica = true;
            
            
        }

        void Pesquisar()
        {
            try
            {
                Tela_Pesquisa p = new Tela_Pesquisa();
                p.arvore = arvore;
                p.animal = animal;
                
                p.ShowDialog();
                
                
                animal = p.animal;
                if (animal != null)
                {
                    image1.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Hidden;
                    image.Source = animal.Imagem;
                    lblInfo.Content = animal.ToString() + "\n\n";
                    if (animal is ITerrestre)
                        lblInfo.Content += $"Qtde. Patas: {(animal as ITerrestre).QtdePatas}";
                    if (animal is IVoador)
                    {
                        lblInfo.Content += $"Veloc. Voo: {(animal as IVoador).Velocidade_De_Voo} Km/h" +
                            $"\nAltitude Max: {(animal as IVoador).Altitude} m";
                    }

                }

            }
            catch
            {

            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Key tecla = e.Key;
            if (animal != null && groupBox.Visibility == Visibility.Hidden)
            {
                if (tecla == Key.Left || tecla == Key.Right || tecla == Key.Up || tecla == Key.Down)
                    animal.Movimentar(tecla, movimentos);
                if ((tecla == Key.Q || tecla == Key.W) && animal is ITerrestre)
                    (animal as ITerrestre).Correr(tecla, movimentos);
                if ((tecla == Key.E || tecla == Key.R) && animal is ITerrestre)
                    (animal as ITerrestre).Rastejar(tecla, movimentos);

            }

        }

        private void label_MouseEnter(object sender, MouseEventArgs e)
        {
            label.FontSize = 26;
        }

        private void label_MouseLeave(object sender, MouseEventArgs e)
        {
            label.FontSize = 22;
        }

        private void label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Pesquisar();
        }

        private void label_Copy_MouseEnter(object sender, MouseEventArgs e)
        {
            label_Copy.FontSize = 26;
        }

        private void label_Copy_MouseLeave(object sender, MouseEventArgs e)
        {
            label_Copy.FontSize = 22;
        }

        private void label_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void lblAudios_MouseEnter(object sender, MouseEventArgs e)
        {
            lblAudios.FontSize = 26;
        }

        private void lblAudios_MouseLeave(object sender, MouseEventArgs e)
        {
            lblAudios.FontSize = 22;
        }

        private void imgSomDeFundo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (audioMusica)
            {
                musicaFundo.Stop();
                audioMusica = false;
                imgSomDeFundo.Source = somoff;
            }
            else
            {
                musicaFundo.PlayLooping();
                audioMusica = true;
                imgSomDeFundo.Source = somon;
            }
        }

        private void imgSomAnimais_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (audioAnimal)
            {
                audioAnimal = false;
                imgSomAnimais.Source = somoff;
            }
            else
            {
                audioAnimal = true;
                imgSomAnimais.Source = somon;
            }
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            musicaFundo.Stop();
            somAnimal.close();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            somAnimal.settings.volume = 100;
            musicaFundo.SoundLocation = "Audios/TRILHA GLOBO RURAL.wav";
            musicaFundo.PlayLooping();
            Pesquisar();
        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            Key tecla = e.Key;
            if (animal != null && groupBox.Visibility == Visibility.Hidden)
            {  
                if (tecla == Key.D1 && animal is IAquatico)
                    (animal as IAquatico).RespirarForaDagua(movimentos);
                if (tecla == Key.D2 && animal is IAquatico)
                    (animal as IAquatico).Mergulhar(movimentos);
                if (tecla == Key.D3 && animal is IOviparo)
                {
                    image2.Visibility = Visibility.Visible;
                    image2.Source = new BitmapImage(new Uri("Imagens/ovo.png", UriKind.Relative));
                    (animal as IOviparo).BotarOvo(movimentos);
                }
                if (tecla == Key.D4 && animal is IOviparo && image2.Visibility == Visibility.Visible)
                    (animal as IOviparo).ChocarOvo(image2, image);
                if (tecla == Key.D5 && animal is Ave)
                    (animal as Ave).Bicar(movimentos);
                if (tecla == Key.D6 && animal is Reptil)
                {
                    image1.Visibility = Visibility.Visible;
                    (animal as Reptil).Aquecer_Ao_Sol(movimentos);
                }

                if (tecla == Key.D7 && animal is Mamifero)
                {
                    image3.Visibility = Visibility.Visible;
                    (animal as Mamifero).Amamentar(movimentos);
                }

                if (tecla == Key.Back)
                    animal.Comer(movimentos);

                if (tecla == Key.Space && audioAnimal)
                {
                    somAnimal.URL = animal.Comunicar();
                    somAnimal.controls.play();

                }

            }
        }

        private void lblAudios_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (groupBox.Visibility == Visibility.Hidden) groupBox.Visibility = Visibility.Visible;
            else groupBox.Visibility = Visibility.Hidden;
        }
    }
}
