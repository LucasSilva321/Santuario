using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santuarivm
{

    class ComparadorDeData : IComparer
    {
        public int Compare(object x, object y)
        {
            return DateTime.Compare((x as Animal).Nascimento, (y as Animal).Nascimento) * -1;
        }
    }
}
