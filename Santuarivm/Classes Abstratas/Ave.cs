using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Santuarivm
{

    abstract class Ave : Animal, IOviparo
    {
        public abstract bool Rapina { get; }
        public CoresAve Coloracao { get; private set; }

        public Ave()
        {

        }

        public Ave(string nome, DateTime nascimento, string sexo, CoresAve cor)
            : base(nome, nascimento, sexo)
        {
            Coloracao = cor;
        }

        public override int CalcularIdade()
        {
            return (int)DateTime.Now.Subtract(Nascimento).TotalDays;
        }

        public override string ToString()
        {
            string rapina = Rapina ? "Possui" : "Não Possui";
            string coloracao = (Coloracao.ToString().IndexOf('_') == -1) ? Coloracao.ToString() : Coloracao.ToString().Replace("_", " ");
            string retorno= base.ToString() + $"Rapina: {rapina} \nColoração:\n{coloracao}";
            return retorno.Replace("meses", "dias");
        }

        void IOviparo.BotarOvo( Animacoes movimentos)
        {
            movimentos.BotarOvo.Begin();
        }

        void IOviparo.ChocarOvo(Image ovo, Image filhote)
        {
            ovo.Source = filhote.Source;
        }

        public void Bicar(Animacoes movimentos)
        {
            movimentos.Bicar.Begin();
        }
    }
}
