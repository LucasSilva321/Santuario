using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Santuarivm
{
    interface ITerrestre
    {
        int QtdePatas { get; }
        void Andar(Key tecla, Animacoes movimentos);
        void Correr(Key tecla, Animacoes movimentos);
        void Rastejar(Key tecla, Animacoes movimentos);
    }
}
