using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISDesign_ZY
{
    enum SymbolType
    {
        SimpleMarkerSymbol, SimpleLineSymbol,
        SimpleFillSymbol, HatchFillSymbol
    }

    enum MarkerStyleConstant
    {
        MCircle, MSolidCircle, MRectengle,
        MSolidRectengle, MTriangle, MSolidTriangle,
        MDotCircle, MDoubleCircle
    }

    enum LineStyleConstant
    {
        LSolid, LDash, LDot, LDashDot, LDashDotDash
    }

    enum FillStyleConstant
    {
        FColor, FTransparent
    }

    enum HatchStyleConstant
    {
        HLine, HDot, HCrossLine
    }

    enum RendererType
    {
        SimpleRenderer, UniqueValueRenderer,
        ClassBreaksRenderer
    }

    enum FeatureTypeConstant
    {
        Point, Polyline, Polygon
    }
}
