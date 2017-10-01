using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Santuarivm;

namespace Lista
{

    class Nodo
    {
        public object Dado { get; set; }
        public Nodo Proximo { get; set; }

        public Nodo(object dado, Nodo proximo)
        {
            Dado = dado;
            Proximo = proximo;
        }

        public Nodo()
        {

        }
    }
}
