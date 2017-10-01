using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Santuarivm
{
  
    interface IAquatico
    {
        void RespirarForaDagua(Animacoes movimentos);
        void Nadar(Key tecla, Animacoes movimentos);
        void Mergulhar(Animacoes movimentos);
    }
}
