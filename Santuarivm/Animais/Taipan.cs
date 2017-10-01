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
    class Taipan : Reptil,ITerrestre
    {
        public Taipan()
        {

        }

        public Taipan(string nome, DateTime nascimento, string sexo,TipoDePele pele) 
            :base(nome, nascimento,sexo,pele)
        {

        }

        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Carnívoro; } }
        public override bool Venenoso { get { return true; } }

        int ITerrestre.QtdePatas
        {
            get
            {
                return 0;
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
        public override string Especie { get { return "Taipan"; } }
        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/taipan.png", UriKind.Relative)); } }

        public override string Comunicar() { return "Audios/taipan.wav"; }
    }
}
