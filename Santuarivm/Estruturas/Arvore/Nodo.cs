using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Santuarivm;

namespace Arvore
{

    class Nodo
    {
        public bool Visitado = false;
        public Nodo Pai { get; set; }
        public Nodo Direita { get; set; }
        public Nodo Esquerda { get; set; }
        public Animal Dado { get; set; }

        public bool EhRaiz()
        {
            return Pai == null;
        }

        public bool EhExterno()
        {
            return Direita == null && Esquerda == null;
        }

        public bool EhInterno()
        {
            return !EhExterno();
        }

        public void CriarExternos()
        {
            Esquerda = new Nodo();
            Esquerda.Pai = this;
            Direita = new Nodo();
            Direita.Pai = this;
        }
    }
}
