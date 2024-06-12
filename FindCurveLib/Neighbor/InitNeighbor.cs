using FindCurveLib.Neighbor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCurveLib.Neighbor
{
    class InitNeighbor
    {
        public static INeighbor Init(TypeNeighbor type)
        {
            switch(type)
            {
                case TypeNeighbor.Eight:
                    return new _8Neighbor();
                case TypeNeighbor.Four:
                    return new _4Neighbor();
                default:
                    return Init(TypeNeighbor.Eight);
            }
        }
    }
}
