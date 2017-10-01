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

    class Coala : Mamifero,ITerrestre
    {
        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/coala.png", UriKind.Relative)); } }

        public Coala()
        {

        }

        public Coala(string nome, DateTime nascimento, string sexo,string cor) 
            :base(nome, nascimento,sexo,cor)
        {
          
        }

        public override bool Venenoso { get { return false; } }
        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Herbívoro; } }
        public override bool Marsupial { get { return true; } }
        public override bool Pelo { get { return true; } }
        public override int qtdeMamas { get { return 2; } }

        int ITerrestre.QtdePatas
        {
            get
            {
                return 2;
            }
        }

        void ITerrestre.Andar(Key tecla, Animacoes movimentos)
        {
            if (tecla == Key.Left) movimentos.Esquerda.Begin();
            if (tecla == Key.Right) movimentos.Direita.Begin();
        }

        void ITerrestre.Correr(Key tecla, Animacoes movimentos)
        {
            if (tecla == Key.Q) movimentos.CorrerEsquerda.Begin();
            if (tecla == Key.W) movimentos.CorrerDireita.Begin();
        }

        void ITerrestre.Rastejar(Key tecla, Animacoes movimentos)
        {
            if (tecla == Key.E) movimentos.RastejarEsquerda.Begin();
            if (tecla == Key.R) movimentos.RastejarDireita.Begin();
        }

        public override void Movimentar(Key tecla, Animacoes movimentos)
        {
            movimentos.IrParaSuperficie.Begin();
            (this as ITerrestre).Andar(tecla, movimentos);
        }


        public override string Especie { get { return "Coala"; } }

        public override string Comunicar() { return "Audios/coala.wav"; }
    }
}
