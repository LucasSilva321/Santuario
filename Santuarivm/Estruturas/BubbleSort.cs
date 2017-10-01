using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lista;
using System.Collections;

namespace Santuarivm
{

    static class BubbleSort
    {

        public static Lista Ordenar(this Lista lista,
            IComparer comparador)
        {
            object aux;
            bool houvetroca;

            do
            {
                houvetroca = false;
                Nodo no = lista.RetornaPrimeiro();
                while (no.Proximo != null)
                {
                    if (comparador.Compare(no.Dado, no.Proximo.Dado) > 0)
                    {
                        aux = no.Dado;
                        no.Dado = no.Proximo.Dado;
                        no.Proximo.Dado = aux;
                        houvetroca = true;
                    }
                    no = no.Proximo;
                }
            }
            while (houvetroca == true);
            return lista;
        }
    }
}