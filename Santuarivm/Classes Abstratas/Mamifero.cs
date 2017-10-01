using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santuarivm
{
    abstract class Mamifero : Animal
    {
        public abstract bool  Marsupial { get; }
        public abstract int qtdeMamas { get; }
        public abstract bool Pelo { get;}
        public string CorPeleo { get; set; }

        public Mamifero()
        {

        }

        public Mamifero(string nome, DateTime nascimento, string sexo,string cor) 
            :base(nome, nascimento,sexo)
        {
            CorPeleo = cor;
        }

        public void Amamentar(Animacoes movimentos)
        {
            movimentos.Amamentar.Begin();
        }

        public override string ToString()
        {
            string marsupial = Marsupial ? "Sim" : "Não";
            string pelo = Pelo ? "Sim" : "Não";
            return base.ToString() +
                $"Marsupial: {marsupial} \nNº Mamas: {qtdeMamas} \nPelo: {pelo} \nCor Pele: {CorPeleo}";
        }


    }
}
