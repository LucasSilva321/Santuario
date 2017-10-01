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
    class CisneNegro : Ave,IAquatico
    {
        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/cisne.png", UriKind.Relative)); } }

        public CisneNegro()
        {

        }

        public CisneNegro(string nome, DateTime nascimento, string sexo,CoresAve cor) 
            :base(nome, nascimento,sexo,cor)
        {
            
        }

        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Onívoro; } }
        public override bool Venenoso { get { return false; } }
        public override bool Rapina { get { return false; } }

        void IAquatico.RespirarForaDagua( Animacoes movimentos)
        {
            movimentos.IrParaSuperficie.Begin();
        }

        void IAquatico.Nadar(Key tecla, Animacoes movimentos)
        {
            if (tecla == Key.Left) movimentos.Esquerda.Begin();
            if (tecla == Key.Right) movimentos.Direita.Begin();
        }

        void IAquatico.Mergulhar( Animacoes movimentos)
        {
            movimentos.Mergulhar.Begin();
        }

        public override void Movimentar(Key tecla, Animacoes movimentos)
        {
            movimentos.IrParaAgua.Begin();
            (this as IAquatico).Nadar(tecla,movimentos);
        }

        public override string Especie { get { return "Cisne Negro"; } }

        public override string Comunicar() { return "Audios/cisne.wav"; }
    }
}
