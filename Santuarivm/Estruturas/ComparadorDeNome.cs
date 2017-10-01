using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santuarivm
{

    class ComparadorDeNome : IComparer
    {
        public int Compare(Object x, Object y)
        {
            return String.Compare((x as Animal).Nome.ToUpper(), (y as Animal).Nome.ToUpper());
        }
    }
}
