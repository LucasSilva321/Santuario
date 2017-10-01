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

    class AquilaAudax : Ave, IVoador
    {
        public AquilaAudax()
        {

        }

        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/aquila.png", UriKind.Relative)); } }


        public AquilaAudax(string nome, DateTime nascimento, string sexo, CoresAve cor)
            : base(nome, nascimento, sexo, cor)
        {

        }

        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Carnívoro; } }
        public override bool Venenoso { get { return false; } }
        public override bool Rapina { get { return true; } }

        double IVoador.Velocidade_De_Voo
        {
            get
            {
                return 70;
            }
        }

        double IVoador.Altitude
        {
            get
            {
                return 2000;
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

        public override string Especie { get { return "Aquila Audax"; } }

        public override string Comunicar() { return "Audios/aquila.wav"; }
        

    }
}
