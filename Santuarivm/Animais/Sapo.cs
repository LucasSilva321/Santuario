using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Santuarivm
{
    class Sapo:Reptil,IVoador
    {
        public Sapo()
        {

        }

        public Sapo(string nome, DateTime nascimento, string sexo, TipoDePele pele) 
            :base(nome, nascimento,sexo,pele)
        {

        }

        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Herbívoro; } }
        public override bool Venenoso { get { return true; } }


        double IVoador.Velocidade_De_Voo
        {
            get
            {
                return 999;
            }
        }

        double IVoador.Altitude
        {
            get
            {
                return 9999;
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





        public override string Especie { get { return "Sapo"; } }
        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/sapo.png", UriKind.Relative)); } }

        public override string Comunicar() { return "Audios/sapo.wav"; }
    }
}

