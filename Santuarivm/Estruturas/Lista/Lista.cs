using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lista;
using System.Collections;

namespace Santuarivm
{

    class Lista : IEnumerable, IEnumerator
    {
        Nodo noEach = null;
        Nodo primeiro = null;
        int qtde = 0;

        public int Quantidade { get { return qtde; } }

        private void InsereNaPosicao(Nodo anterior, object valor)
        {
            Nodo novo = new Nodo();
            novo.Dado = valor;

            if (anterior == null)
            {
                if (primeiro == null)
                    primeiro = novo;
                else
                {
                    novo.Proximo = primeiro;
                    primeiro = novo;
                }
            }
            else
            {
                novo.Proximo = anterior.Proximo;
                anterior.Proximo = novo;
            }
            qtde++;
        }

        public void InserirNoInicio(object valor)
        {
            InsereNaPosicao(null, valor);
        }



        public void InserirNoFim(Object valor)
        {
            if (qtde == 0)
                InserirNoInicio(valor);
            else
            {
                Nodo aux = primeiro;
                while (aux.Proximo != null)
                {
                    aux = aux.Proximo;
                }
                InsereNaPosicao(aux, valor);
            }
        }

        public void InserirNaPosicao(object valor, int posicao)
        {
            if (posicao >= qtde || posicao < 0)
                throw new Exception("Posição se encontra fora dos limites da lista");
            if (posicao == 0)
                InserirNoInicio(valor);
            else
            {
                Nodo aux = primeiro;
                for (int i = 0; i < posicao; i++)
                {
                    aux = aux.Proximo;
                }

                InsereNaPosicao(aux, valor);
            }
        }

        public object RemoverDaPosicao(int posicao)
        {
            if (posicao >= qtde || posicao < 0)
                throw new Exception("Posição se encontra fora dos limites da lista");

            object valor = null;
            if (posicao == 0)
            {
                valor = primeiro.Dado;
                primeiro = primeiro.Proximo;
            }
            else
            {
                Nodo aux = primeiro;
                for (int i = 0; i < posicao - 1; i++)
                {
                    aux = aux.Proximo;
                }

                valor = aux.Proximo.Dado;
                aux.Proximo = aux.Proximo.Proximo;
            }

            qtde--;
            return valor;
        }

        public bool Pesquisa(object dado, IComparer comparador)
        {
            Nodo aux = primeiro;
            while (aux != null)
            {
                if (comparador.Compare(aux.Dado, dado) == 0)
                    return true;
                aux = aux.Proximo;
            }
            return false;
        }

        public Nodo RetornaPrimeiro()
        {
            return primeiro;
        }

        public void OrdenarPorNome()
        {
            if (Quantidade == 0) return;
            ComparadorDeNome compara = new ComparadorDeNome();
            this.Ordenar(compara);
        }

        public void OrdenarPorIdade()
        {
            if (Quantidade == 0) return;
            ComparadorDeData compara = new ComparadorDeData();
            this.Ordenar(compara);
        }

        #region Metodos para Foreach
        public object Current
        {
            get
            {
                if (noEach == null)
                    return null;
                else
                    return noEach.Dado;
            }
        }

        public bool MoveNext()
        {
            if (noEach == null)
                noEach = primeiro;
            else
                noEach = noEach.Proximo;

            return noEach != null;
        }

        public void Reset()
        {
            noEach = null;
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        #endregion




    }
}
