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
    class Ornintorrinco : Mamifero,IOviparo,IAquatico,ITerrestre
    {
        public Ornintorrinco()
        {

        }

        public Ornintorrinco(string nome, DateTime nascimento, string sexo,string cor) 
            :base(nome, nascimento,sexo,cor)
        {

        }

        public override bool Venenoso { get { return false; } }
        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Carnívoro; } }
        public override bool Marsupial { get { return true; } }
        public override bool Pelo { get { return true; } }
        public override int qtdeMamas { get { return 0; } }

        int ITerrestre.QtdePatas
        {
            get
            {
                return 4;
            }
        }

        void IOviparo.BotarOvo( Animacoes movimentos)
        {
            movimentos.BotarOvo.Begin();
        }

        void IOviparo.ChocarOvo(Image ovo, Image filhote)
        {
            ovo.Source = filhote.Source;
        }

        void IAquatico.RespirarForaDagua( Animacoes movimentos)
        {
            movimentos.IrParaSuperficie.Begin();
        }

        void IAquatico.Nadar(Key tecla, Animacoes movimentos)
        {
            movimentos.IrParaAgua.Begin();
        }

        void IAquatico.Mergulhar( Animacoes movimentos)
        {
            movimentos.Mergulhar.Begin();
        }

        void ITerrestre.Andar(Key tecla, Animacoes movimentos)
        {
            movimentos.IrParaSuperficie.Begin();
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
            if (tecla == Key.Up) (this as ITerrestre).Andar(tecla, movimentos);
            if (tecla == Key.Down) (this as IAquatico).Nadar(tecla, movimentos);
            if (tecla == Key.Left) movimentos.Esquerda.Begin();
            if (tecla == Key.Right) movimentos.Direita.Begin();
        }

        public override string Especie { get { return "Ornitorrinco"; } }

        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/ornintorrinco.png", UriKind.Relative)); } }

        public override string Comunicar() { return "Audios/ornitorrinco.wav"; }
    }
}
