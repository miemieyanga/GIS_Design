using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISDesign_ZY
{
    static class SymbolFactory
    {
        static public Symbol CreateSymbol(SymbolType mSymbolType)
        {
            Symbol cSymbol = new SimpleMarkerSymbol();
            switch (mSymbolType)
            {
                case SymbolType.SimpleMarkerSymbol:
                    cSymbol = new SimpleMarkerSymbol();
                    break;
                case SymbolType.SimpleLineSymbol:
                    cSymbol = new SimpleLineSymbol();
                    break;
                case SymbolType.SimpleFillSymbol:
                    cSymbol = new SimpleFillSymbol();
                    break;
                case SymbolType.HatchFillSymbol:
                    cSymbol = new HatchFillSymbol();
                    break;
                default:
                    throw new Exception("未实现的类型");
            }
            return cSymbol;
        }
    }
}
