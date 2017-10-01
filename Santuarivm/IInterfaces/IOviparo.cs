using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Santuarivm
{
    interface IOviparo
    {
        void BotarOvo(Animacoes movimentos);
        void ChocarOvo(Image ovo, Image filhote);
    }
}
