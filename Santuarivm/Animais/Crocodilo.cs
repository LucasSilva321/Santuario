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
    class Crocodilo : Reptil,IAquatico
    {
        public Crocodilo()
        {

        }

        public Crocodilo(string nome, DateTime nascimento, string sexo,TipoDePele pele ) 
            :base(nome, nascimento,sexo,pele)
        {

        }

        public override TipoDeAlimentacao Alimentacao { get { return TipoDeAlimentacao.Carnívoro; } }
        public override bool Venenoso { get { return false; } }

       

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

        public override string Especie { get { return "Crocodilo"; } }

        public override ImageSource Imagem { get { return new BitmapImage(new Uri("Imagens/crocodilo.png", UriKind.Relative)); } }

        public override string Comunicar() { return "Audios/crocodilo.wav"; }
    }
}
