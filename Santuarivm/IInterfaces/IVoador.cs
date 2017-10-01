using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Santuarivm
{
    interface IVoador
    {
        Double Velocidade_De_Voo { get; }
        double Altitude { get; }
        void Voar(Key tecla, Animacoes movimentos);

    }
}
