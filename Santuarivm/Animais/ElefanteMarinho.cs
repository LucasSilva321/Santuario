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
    class ElefanteMarinho : Mamifero,IAquatico
    {
        public ElefanteMarinho()
        {

        }

        public ElefanteMarinho(string nome, DateTime nascimento, string sexo,string cor) 
            :base(nome, nascimento,sexo,cor)
        {

        }

        public override bool Venenoso { get { return false; } }
        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Carnívoro; } }
        public override bool Marsupial { get { return false; } }
        public override bool Pelo { get { return true; } }
        public override int qtdeMamas { get { return 2; } }

        void IAquatico.RespirarForaDagua(Animacoes movimentos)
        {
            movimentos.IrParaSuperficie.Begin();
        }

        void IAquatico.Nadar(Key tecla, Animacoes movimentos)
        {
            if (tecla == Key.Left) movimentos.Esquerda.Begin();
            if (tecla == Key.Right) movimentos.Direita.Begin();
        }

        void IAquatico.Mergulhar(Animacoes movimentos)
        {
            movimentos.Mergulhar.Begin();
        }

        public override void Movimentar(Key tecla, Animacoes movimentos)
        {
            movimentos.IrParaAgua.Begin();
            (this as IAquatico).Nadar(tecla, movimentos);
        }

        public override string Especie { get { return "Elefante Marinho"; } }

        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/elefante.png", UriKind.Relative)); } }

        public override string Comunicar() { return "Audios/elefante.wav"; }
    }
}
