using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Santuarivm
{
    class MorcegoGigante : Mamifero,IVoador
    {
        public MorcegoGigante()
        {

        }

        public MorcegoGigante(string nome, DateTime nascimento, string sexo,string cor) 
            :base(nome, nascimento,sexo,cor)
        {
            
        }


        public override bool Venenoso { get { return false; } }
        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Herbívoro; } }
        public override bool Marsupial { get { return false; } }
        public override bool Pelo { get { return false; } }
        public override int qtdeMamas { get { return 2; } }

        double IVoador.Velocidade_De_Voo
        {
            get
            {
                return 50;
            }
        }

        double IVoador.Altitude
        {
            get
            {
                return 1300;
            }
        }

        void IVoador.Voar(Key tecla, Animacoes movimentos)
        {
            if (tecla == Key.Up)
                movimentos.VoarCima.Begin();
            if (tecla == Key.Down)
                movimentos.VoarBaixo.Begin();
            if (tecla == Key.Left)
                movimentos.Esquerda.Begin();
            if (tecla == Key.Right)
                movimentos.Direita.Begin();
        }



        public override void Movimentar(Key tecla, Animacoes movimentos)
        {
            (this as IVoador).Voar(tecla, movimentos);
        }

        public override string Especie { get { return "Morcego Gigante"; } }

        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/morcego.png", UriKind.Relative)); } }

        public override string Comunicar() { return "Audios/morcego.wav"; }
    }
}
