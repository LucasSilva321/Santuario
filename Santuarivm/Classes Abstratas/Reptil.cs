using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Santuarivm
{
    abstract class Reptil : Animal,IOviparo
    {
        public  TipoDePele Pele { get; private set; }

        public Reptil()
        {

        }

        public Reptil(string nome, DateTime nascimento, string sexo,TipoDePele pele)
            : base(nome, nascimento, sexo)
        {
            Pele = pele;
        }

        public override string ToString()
        {
            string pele = (Pele.ToString().IndexOf("_") == -1) ? Pele.ToString() : Pele.ToString().Replace("_", " ");
            return base.ToString()+ $"Pele: {pele}";
        }

        public void Aquecer_Ao_Sol(Animacoes movimentos)
        {
            movimentos.AquecerAoSol.Begin();
        }

        void IOviparo.BotarOvo(Animacoes movimentos)
        {
            movimentos.BotarOvo.Begin();
        }

        void IOviparo.ChocarOvo(Image ovo, Image filhote)
        {
            ovo.Source = filhote.Source;
        }
    }
}
