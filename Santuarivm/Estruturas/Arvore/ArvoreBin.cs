using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arvore;
using System.Collections;

namespace Santuarivm
{

    class ArvoreBin : IEnumerable, IEnumerator
    {
        private Nodo raiz = null;
        private int qtdeInternos = 0;
        ComparadorDeNome comparador = new ComparadorDeNome();
        Lista lista;


        public int Quantidade
        {
            get { return qtdeInternos; }
        }

        public void Insere(Animal dado)
        {
            Nodo aux;

            if (Quantidade == 0)
            {
                aux = new Nodo();
                raiz = aux;
            }
            else
            {
                aux = PesquisaValor(dado, raiz);
                if (aux.EhInterno())
                    throw new Exception("Este nome já está cadastrado");
            }
            aux.Dado = dado;
            aux.CriarExternos();
            qtdeInternos++;
        }

        private void PercursoInterfixado(Nodo no)
        {
            if (no.EhExterno()) return;
            PercursoInterfixado(no.Esquerda);
            lista.InserirNoFim(no.Dado);
            PercursoInterfixado(no.Direita);
        }

        public Animal RetornaValor(string nome)
        {
            Nodo retorno = RetornaValor(nome, raiz);
            if (retorno == null)
                throw new Exception("O animal pesquisado não existe");
            return retorno.Dado;
        }


        private Nodo RetornaValor(string nome,Nodo no)
        {
            if (no.Dado == null) return null;
            if (nome == no.Dado.Nome)
                return no;
            else if (String.Compare(nome,no.Dado.Nome) >0)
                return RetornaValor(nome, no.Direita);
            else
                return RetornaValor(nome, no.Esquerda);
        }


        private Nodo PesquisaValor(Animal dado, Nodo no)
        {
            if (no.EhExterno() || comparador.Compare(dado, no.Dado) == 0)
                return no;
            else if (comparador.Compare(dado, no.Dado) > 0)
                return PesquisaValor(dado, no.Direita);
            else
                return PesquisaValor(dado, no.Esquerda);
        }

        public void Remove(Animal dado)
        {
            Nodo noApagado = PesquisaValor(dado, raiz);

            if (noApagado == null || noApagado.EhExterno())
                throw new Exception("O nome procurado não existe");
            else
            {
                if (noApagado.Esquerda.EhExterno() || noApagado.Direita.EhExterno())
                    ExcluiComNodoExterno(noApagado);
                else
                    ExcluiSemNodoExterno(noApagado);
            }
        }

        private void ExcluiComNodoExterno(Nodo no)
        {
            qtdeInternos--;

            Nodo substituto;

            if (no.Esquerda.EhInterno())
                substituto = no.Esquerda;
            else
                substituto = no.Direita;

            Nodo paiApagado = no.Pai;
            if (paiApagado != null)
            {
                if (paiApagado.Direita == no)
                    paiApagado.Direita = substituto;
                else
                    paiApagado.Esquerda = substituto;
            }
            else
                raiz = substituto;
        }

        private Nodo PesquisaNodoInternoInterfixado(Nodo no)
        {
            if (no.EhExterno()) return null;
            Nodo retorno = PesquisaNodoInternoInterfixado(no.Esquerda);
            if (retorno == null) return no;
            return retorno;

        }

        private void ExcluiSemNodoExterno(Nodo no)
        {
            Nodo substituto = PesquisaNodoInternoInterfixado(no.Direita);
            no.Dado = substituto.Dado;
            ExcluiComNodoExterno(substituto);
        }


        public Lista ParaLista()
        {
            if (Quantidade > 0)
            {
                lista = new Lista();
                PercursoInterfixado(raiz);
                return lista;
            }
            return new Lista();

        }

        #region Gambiarra Para Foreach

        Nodo nodoParaEach;
        int devolvidos = 0;

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        public void Reset()
        {
            nodoParaEach = null;
            Desvisitar(raiz);
            devolvidos = 0;
        }

        private void Desvisitar(Nodo no)
        {
            if (raiz != null)
            {
                if (no.EhExterno())
                    return;
                Desvisitar(no.Esquerda);
                no.Visitado = false;
                Desvisitar(no.Direita);
            }

        }

        public void Percurso(Nodo no)
        {
            if (no.Esquerda.EhExterno() == false && !no.Esquerda.Visitado)
                nodoParaEach = no.Esquerda;
            else if (no.Direita.EhExterno() == false && !no.Direita.Visitado)
                nodoParaEach = no.Direita;
            else
                Percurso(no.Pai);
        }


        public bool MoveNext()
        {
            if (devolvidos == Quantidade)
                return false;
            if (nodoParaEach == null && devolvidos == 0)
                nodoParaEach = raiz;
            else
            {
                Percurso(nodoParaEach);
            }

            return nodoParaEach != null;
        }

        public Object Current
        {
            get
            {
                if (nodoParaEach == null)
                    return null;
                else
                {
                    nodoParaEach.Visitado = true;
                    devolvidos++;
                    return nodoParaEach.Dado;

                }
            }
        }

        #endregion






    }
}
